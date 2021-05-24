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
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Retriever.Common;
using Retriever.Common.Checker;
using Retriever.Common.Checker.Events;

namespace Retriever.Forms
{
    public partial class MainForm : Form
    {
        private readonly CheckerService _cs;
        private readonly Regex _usernamePattern;

        public MainForm()
        {
            _cs = new();
            _cs.OnStarted += Checker_OnStarted;
            _cs.OnCompleted += Checker_OnCompleted;

            InitializeComponent();

            _HeadingText.Parent = _HeadingImage;

            _UsernameInput.TextChanged += UsernameInput_OnTextChanged;
            _UsernameInput.KeyDown += UsernameInput_OnKeyDown;
            _CheckButton.Click += CheckButton_OnClick;
        }

        #region Control Event Handlers
        private void UsernameInput_OnTextChanged(object sender, EventArgs e)
        {
            string text = _UsernameInput.Text.Trim();

            /// See <see cref="Utils.ValidUsername(string)"/>
            _CheckButton.Enabled = Utils.ValidUsername(text);
        }

        private void UsernameInput_OnKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            if (key == Keys.Enter)
            {
                _CheckButton.PerformClick();

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async void CheckButton_OnClick(object sender, EventArgs e)
        {
            string username = _UsernameInput.Text.Trim();

            await _cs.CheckAvailabilityAsync(username);
        }
        #endregion

        #region Checker Event Handlers
        private void Checker_OnStarted(object sender, StartedArgs e)
        {
            _UsernameInput.Enabled = false;
            _CheckButton.Enabled = false;
            _CheckButton.Text = "Checking";
        }

        private void Checker_OnCompleted(object sender, CompletedArgs e)
        {
            var results = e.Results;

            _UsernameInput.Enabled = true;
            _UsernameInput.Text = string.Empty;
            _CheckButton.Text = "Check";

            var resultsForm = new ResultsForm(results);
                resultsForm.ShowDialog(this);
        }
        #endregion
    }
}
