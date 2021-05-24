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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using Retriever.Common;
using Retriever.Common.Checker;
using Retriever.Common.Checker.Models;
using Retriever.Common.Checker.Events;

namespace Retriever.CLI
{
    class Bootstrapper
    {
        private static async Task Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.ForegroundColor = ConsoleColor.Black;
            foreach (string line in new string[]
            {
                @"    ____         __         _                        ",
                @"   / __ \ ___   / /_ _____ (_)___  _   __ ___   _____",
                @"  / /_/ // _ \ / __// ___// // _ \| | / // _ \ / ___/",
                @" / _, _//  __// /_ / /   / //  __/| |/ //  __// /    ",
                @"/_/ |_| \___/ \__//_/   /_/ \___/ |___/ \___//_/     ",
                @"                                                     ",
            }) Console.WriteLine(line);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.OutputEncoding = Encoding.UTF8;

            if (args.Length > 0)
            {
                string username = args[0].Trim();

                if (Utils.ValidUsername(username))
                {
                    Console.CursorVisible = false;

                    var checker = new CheckerService();
                        checker.OnStarted += Checker_OnStarted;
                        checker.OnCompleted += Checker_OnCompleted;

                    await checker.CheckAvailabilityAsync(username);
                }
                else
                {
                    Console.WriteLine("The supplied username contains characters that are very unlikely to be allowed on a majority of websites.");
                }
            }
            else
            {
                Console.WriteLine("No username supplied");
            }

            Console.CursorVisible = true;
            Console.ResetColor();
        }

        
        private static void Checker_OnStarted(object sender, StartedArgs e) => Console.WriteLine("\nChecking sites for username {0}...\n", e.Username);

        private static void Checker_OnCompleted(object sender, CompletedArgs e)
        {
            var unreliables = new List<Result>();
            var results = e.Results.OrderByDescending(r => r.Status);
            foreach (var result in results)
            {
                if (result.Status != Status.Unreliable)
                {
                    LogSiteResult(result);
                }
                else
                {
                    unreliables.Add(result);
                }
            }

            if (unreliables.Count() > 0)
            {
                string pluralized = unreliables.Count() == 1 ? "site is" : "sites are"; 
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nThe following {0} disabled due to the inability to reliably check username availability:", pluralized);
                foreach (var unreliable in unreliables)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0}{1} ", new string(' ', 4), unreliable.Service);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(unreliable.Url);
                }
            }
        }

        private static void LogSiteResult(Result result)
        {
            var iconColor = GetResultColor(result.Status);
            string icon = GetResultIcon(result.Status);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = iconColor;
            Console.Write(icon);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0} ", result.Service);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("{0} ", result.Url);
            Console.ForegroundColor = iconColor;
            Console.WriteLine(result.Status);

            if (result.Note != null)
            {
                // 5 to take into account the status "icon" plus spaces after it as well as the service name
                int spaceLength = 5 + result.Service.Length;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("{0}{1}", new string(' ', spaceLength), result.Note);
            }
        }

        private static ConsoleColor GetResultColor(Status status) => status switch
        {
            Status.Unavailable => ConsoleColor.Red,
            Status.Unreliable => ConsoleColor.DarkMagenta,
            Status.Available => ConsoleColor.Green,
            Status.Invalid => ConsoleColor.Yellow,
            Status.Error => ConsoleColor.DarkRed,
            _ => throw new ArgumentOutOfRangeException("status")
        };

        private static string GetResultIcon(Status status) => status switch
        {
            Status.Unavailable => "✗",
            Status.Unreliable => "!",
            Status.Available => "✓",
            Status.Invalid => "⨻",
            Status.Error => "E",
            _ => throw new ArgumentOutOfRangeException("status")
        };
    }
}
