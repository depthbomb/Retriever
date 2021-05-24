#region License
/// Retriever
/// Copyright(C) 2021  Caprine Logic

/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.

/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
/// GNU General Public License for more details.

/// You should have received a copy of the GNU General Public License
/// along with this program. If not, see <https://www.gnu.org/licenses/>.
#endregion License

using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;

using Retriever.Common.Checker.Sites;
using Retriever.Common.Checker.Events;
using Retriever.Common.Checker.Models;

namespace Retriever.Common.Checker
{
    public class CheckerService
    {
        public List<Result> Results = new();

        public event EventHandler<StartedArgs> OnStarted;
        public event EventHandler<CheckingSiteArgs> OnCheckingSite;
        public event EventHandler<SiteResultsArgs> OnSiteResults;
        public event EventHandler<CompletedArgs> OnCompleted;

        private readonly HashSet<BaseSite> _sites = new();

        private const string MOBILE_UA = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_3_1 like Mac OS X) AppleWebKit/603.1.30 (KHTML, like Gecko) Version/10.0 Mobile/14E304 Safari/602.1";
        private const string DESKTOP_UA = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36";

        public CheckerService()
        {
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetTypeInfo().IsSubclassOf(typeof(BaseSite)));
            foreach (var type in types)
            {
                var instance = (BaseSite)Activator.CreateInstance(type);

                _sites.Add(instance);
            }
        }

        public async Task CheckAvailabilityAsync(string username)
        {
            username = username.ToLower();

            OnStarted?.Invoke(this, new StartedArgs(username));

            Results.Clear();

            List<Task> tasks = new();

            foreach (var site in _sites)
            {
                tasks.Add(TestSite(site, username));
            }

            await Task.WhenAll(tasks);

            OnCompleted?.Invoke(this, new CompletedArgs(Results));
        }

        private async Task TestSite(BaseSite site, string username)
        {
            string url = string.Format(site.Url, username);

            OnCheckingSite?.Invoke(this, new(url));

            var handler = new HttpClientHandler
            {
                UseCookies = true,
                AllowAutoRedirect = site.FollowRedirect,
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                http.Timeout = TimeSpan.FromSeconds(5);
                http.DefaultRequestHeaders.Add("user-agent", site.ViaMobile ? MOBILE_UA : DESKTOP_UA);

                Result result = new();
                int minLength = site.MinimumLength;
                int maxLength = site.MaximumLength;

                if (!site.Enabled)
                {
                    result.Status = Status.Unreliable;
                    result.Note = "This site is disabled due to the inability to reliably check username availability.";
                }
                else if (username.Length < minLength)
                {
                    result.Status = Status.Invalid;
                    result.Note = string.Format("Minimum username length is {0}", minLength);
                }
                else if (username.Length > maxLength)
                {
                    result.Status = Status.Invalid;
                    result.Note = string.Format("Maximum username length is {0}", maxLength);
                }
                else
                {
                    string probeUrl = site.ProbeUrl != null ? string.Format(site.ProbeUrl, username) : url;

                    HttpResponseMessage request;
                    try
                    {
                        request = await http.GetAsync(probeUrl);

                        if (site.CheckType == CheckType.HtmlContent)
                        {
                            string html = await request.Content.ReadAsStringAsync();
                            result.Status = html.Contains(site.ErrorContent) ? Status.Available : Status.Unavailable;
                        }
                        else
                        {
                            result.Status = ((int)request.StatusCode) == site.ErrorCode ? Status.Available : Status.Unavailable;
                        }
                    }
                    catch (WebException ex)
                    {
                        result.Status = Status.Error;

                        switch (ex.Status)
                        {
                            case WebExceptionStatus.NameResolutionFailure:
                                result.Note = "Host name could not be resolved";
                                break;
                            case WebExceptionStatus.ConnectFailure:
                                result.Note = "Failed to connect";
                                break;
                            case WebExceptionStatus.ProtocolError:
                                result.Note = "Server error";
                                break;
                            default:
                            case WebExceptionStatus.UnknownError:
                                result.Note = "Unknown error";
                                break;
                        }

                    }
                    catch (TaskCanceledException)
                    {
                        // Since there really is no way the operation would be cancelled, just assume that it being cancelled is due to a timeout

                        result.Status = Status.Error;
                        result.Note = "Timed out";
                    }
                }

                result.Service = site.Service;
                result.Url = url;

                Results.Add(result);

                OnSiteResults?.Invoke(this, new SiteResultsArgs(result));
            }
        }
    }
}
