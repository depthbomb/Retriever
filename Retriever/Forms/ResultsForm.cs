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
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Retriever.Common.Checker.Models;

namespace Retriever.Forms
{
    public partial class ResultsForm : Form
    {
        private readonly List<Result> _results;

        public ResultsForm(List<Result> results)
        {
            _results = results.OrderByDescending(u => u.Status).ToList();

            InitializeComponent();

            this.MinimumSize = new Size(475, 350);
            this.Resize += ResultsForm_OnResize;
            this.FormClosing += ResultsForm_OnFormClosing;

            _ResultsList.Columns.Add("Service", -2);
            _ResultsList.Columns.Add("Status", -2);
            _ResultsList.Columns.Add("URL", -2);
            _ResultsList.Columns.Add("Note", -2);

            foreach (var result in _results)
            {
                var status = result.Status;
                var item = new ListViewItem(result.Service);
                    item.SubItems.Add(status.ToString());
                    item.SubItems.Add(result.Url);
                    if (result.Note != null) item.SubItems.Add(result.Note);
                    item.SubItems[1].ForeColor = Color.White;
                    item.SubItems[1].BackColor = GetStatusColor(status);
                    item.UseItemStyleForSubItems = false;

                _ResultsList.Items.Add(item);
            }
        }

        private void ResultsForm_OnResize(object sender, EventArgs e) => _ResultsList.Columns[3].Width = -2;

        private void ResultsForm_OnFormClosing(object sender, FormClosingEventArgs e) => this.Dispose();

        private Color GetStatusColor(Status status) => status switch
        {
            Status.Unreliable => Color.Crimson,
            Status.Available => Color.Green,
            Status.Unavailable => Color.Red,
            Status.Invalid => Color.Orange,
            Status.Error => Color.DarkRed,
            _ => throw new ArgumentOutOfRangeException(nameof(status))
        };
    }
}
