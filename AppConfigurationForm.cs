using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arena_SF_AM_Checker
{
    public partial class AppConfigurationForm : Form
    {
        private DatabaseHelper _db;
        public AppConfigurationForm()
        {
            InitializeComponent();
            _db = new DatabaseHelper();

            BtnToBeLine.Enabled = false;
            BtnToBeLine2.Enabled = false;

            twichDropNotificationToggle.Appearance = Appearance.Button;
            twichDropNotificationToggle.AutoSize = false;
            twichDropNotificationToggle.Size = new Size(75, 45);

            var isTwitchEnabled = _db.IsTwitchNotificationEnabled();

            twichDropNotificationToggle.Checked = isTwitchEnabled;
            twichDropNotificationToggle.Text = isTwitchEnabled ? "ON" : "OFF";

            VerifySwitchColor();

            twichDropNotificationToggle.CheckedChanged += (s, e) =>
            {
                var status = twichDropNotificationToggle.Checked;
                twichDropNotificationToggle.Text = status ? "ON" : "OFF";
                _db.UpdateTwitchNotification(1, status ? 1 : 0);
                VerifySwitchColor();
            };
        }

        private void VerifySwitchColor()
        {
            if (twichDropNotificationToggle.Checked)
            {
                twichDropNotificationToggle.BackColor = Color.Green;
            }
            else
            {
                twichDropNotificationToggle.BackColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point location = this.Location;
            location.Offset(50, 50);

            var confirmResult = ConfirmDialog.ShowDialogAt(
                "Are you sure you want to reset drop checkboxes?",
                location
            );

            if (confirmResult == DialogResult.Yes)
            {
                _db.ResetCurrentWeekDrops();
            }
        }

        private void undergroundResetBtn_Click(object sender, EventArgs e)
        {
            Point location = this.Location;
            location.Offset(50, 50);

            var confirmResult = ConfirmDialog.ShowDialogAt(
                "Are you sure you want to reset underground items?",
                location
            );

            if (confirmResult == DialogResult.Yes)
            {
                _db.ResetAllUndergroundItems();
            }
        }
    }
}
