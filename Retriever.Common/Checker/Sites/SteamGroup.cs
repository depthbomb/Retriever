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

namespace Retriever.Common.Checker.Sites
{
    public sealed class SteamGroup : BaseSite
    {
        public SteamGroup()
        {
            Service = "Steam Group";
            CheckType = CheckType.HtmlContent;
            ErrorContent = "No group could be retrieved for the given URL.";
            Url = "https://steamcommunity.com/groups/{0}";
        }
    }
}
