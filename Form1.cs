using Arena_SF_AM_Checker.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Arena_SF_AM_Checker
{
    public partial class Form1 : Form
    {
        private DatabaseHelper _db;
        private System.Windows.Forms.Timer _timer;
        private List<TwitchDropModel> dropSchedule;

        public Form1()
        {
            InitializeComponent();
            _db = new DatabaseHelper();

            var rawImage = Properties.Resources.settingsImage;
            var resizedImage = new Bitmap(rawImage, new Size(75, 75));

            buttonSettings.Image = resizedImage;
            buttonSettings.ImageAlign = ContentAlignment.MiddleCenter;
            buttonSettings.Size = new Size(75, 75);
            buttonSettings.FlatStyle = FlatStyle.Flat;

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
            Timer_Tick(null, EventArgs.Empty);
            _timer.Start();


            LoadData();
            AdjustFormWidthToDataGrid();

            var isLastSacrificeDate = _db.SelectLastSacrificeDate().FirstOrDefault().LastSacrifice.ToString("yyyy-MM-dd HH:mm");
            if (isLastSacrificeDate != "0001-01-01 00:00")
            {
                lastSacrificeDate.Text = isLastSacrificeDate;
            }
            else
            {
                lastSacrificeDate.Text = "Never sacrificed";
            }

        }

        private void LoadData()
        {
            var data = _db.GetAllArena().ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].Visible = false;
            }

            InitializeTwitchDrops();
        }

        private void InitializeTwitchDrops()
        {
            var isTwitchEnabled = _db.IsTwitchNotificationEnabled();
            
            lblTwitchDrops.Visible = isTwitchEnabled;
            dataGridViewTwitchDrops.Visible = isTwitchEnabled;
            buttonTwitchTV.Visible = isTwitchEnabled;


            dropSchedule = GetThisWeeksDropDates();

            DateTime now = DateTime.Now;
            DateTime weekEnd = GetDropsWeekEnd();

            foreach (var drop in dropSchedule)
            {
                _db.EnsureDropExists(drop.DropDate);
                drop.IsDone = _db.IsDropDone(drop.DropDate);
                drop.IsEnabled = now >= drop.DropDate && now <= weekEnd;
            }

            int active = dropSchedule.Count(d => DateTime.Now >= d.DropDate && DateTime.Now <= GetDropsWeekEnd());

            lblTwitchDrops.ForeColor = active > 0 ? Color.Green : Color.Gray;
            lblTwitchDrops.Text = active > 0 ? $"DROPS ACTIVE ({active}/3)" : "NO ACTIVE DROPS";

            var bindingList = new BindingSource { DataSource = dropSchedule };
            dataGridViewTwitchDrops.DataSource = bindingList;

            dataGridViewTwitchDrops.Columns["DropDate"].HeaderText = "Drop";
            dataGridViewTwitchDrops.Columns["DropDate"].DefaultCellStyle.Format = "dddd HH:mm";
            dataGridViewTwitchDrops.Columns["IsDone"].HeaderText = "Done";
            dataGridViewTwitchDrops.Columns["IsEnabled"].Visible = false;

            dataGridViewTwitchDrops.ReadOnly = false;
            dataGridViewTwitchDrops.Columns["IsDone"].ReadOnly = false;
            dataGridViewTwitchDrops.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewTwitchDrops.AllowUserToAddRows = false;

            dataGridViewTwitchDrops.RowPrePaint -= DataGridViewTwitchDrops_RowPrePaint;
            dataGridViewTwitchDrops.RowPrePaint += DataGridViewTwitchDrops_RowPrePaint;

            dataGridViewTwitchDrops.CellValueChanged -= DataGridViewTwitchDrops_CellValueChanged;
            dataGridViewTwitchDrops.CellValueChanged += DataGridViewTwitchDrops_CellValueChanged;

            dataGridViewTwitchDrops.CurrentCellDirtyStateChanged -= DataGridViewTwitchDrops_CurrentCellDirtyStateChanged;
            dataGridViewTwitchDrops.CurrentCellDirtyStateChanged += DataGridViewTwitchDrops_CurrentCellDirtyStateChanged;

            AdjustFormWidthToDataGrid();
        }


        private List<TwitchDropModel> GetThisWeeksDropDates()
        {
            DateTime GetDrop(DayOfWeek dow)
            {
                var baseDate = DateTime.Today;
                int diff = (int)dow - (int)baseDate.DayOfWeek;

                if (diff > 0)
                    return baseDate.AddDays(diff).AddHours(16);
                else
                    return baseDate.AddDays(diff).AddHours(16);
            }

            return new List<TwitchDropModel>
            {
                new TwitchDropModel { DropDate = GetDrop(DayOfWeek.Monday) },
                new TwitchDropModel { DropDate = GetDrop(DayOfWeek.Wednesday) },
                new TwitchDropModel { DropDate = GetDrop(DayOfWeek.Friday) }
            };
        }

        private void DataGridViewTwitchDrops_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewTwitchDrops.IsCurrentCellDirty)
                dataGridViewTwitchDrops.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DataGridViewTwitchDrops_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewTwitchDrops.Columns[e.ColumnIndex].Name == "IsDone")
            {
                var row = dataGridViewTwitchDrops.Rows[e.RowIndex];
                if (row.DataBoundItem is TwitchDropModel model && model.IsDone)
                {
                    _db.MarkDropAsDone(model.DropDate);
                    InitializeTwitchDrops();
                }
            }
        }

        private void DataGridViewTwitchDrops_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridViewTwitchDrops.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            if (row.DataBoundItem is TwitchDropModel model)
            {
                row.DefaultCellStyle.BackColor = model.IsDone
                    ? Color.LightGreen
                    : model.IsEnabled ? Color.White : Color.LightGray;

                row.Cells["IsDone"].ReadOnly = model.IsDone || !model.IsEnabled;
            }
        }


        private DateTime GetDropsWeekEnd()
        {
            var today = DateTime.Today;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            return today.AddDays(daysUntilSunday).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        private void AdjustFormWidthToDataGrid()
        {
            int margin = 80;

            int arenaWidth = dataGridView1.Location.X + dataGridView1.Width;
            int twitchWidth = dataGridViewTwitchDrops.Visible
                ? dataGridViewTwitchDrops.Location.X + dataGridViewTwitchDrops.Width
                : 0;

            int requiredWidth = Math.Max(arenaWidth, twitchWidth) + margin;

            if (this.Width < requiredWidth)
                this.Width = requiredWidth;
        }

        private void DataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "IsChecked")
            {
                var changedRow = dataGridView1.Rows[e.RowIndex];
                bool isNowChecked = (bool)changedRow.Cells["IsChecked"].Value;

                if (isNowChecked)
                {
                    for (int i = 0; i < e.RowIndex; i++)
                    {
                        var row = dataGridView1.Rows[i];
                        if (!(bool)row.Cells["IsChecked"].Value)
                        {
                            row.Cells["IsChecked"].Value = true;
                            _db.UpdateCheckedArena((int)row.Cells["Id"].Value, true);
                        }
                    }
                }

                _db.UpdateCheckedArena((int)changedRow.Cells["Id"].Value, isNowChecked);
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            var isChecked = (bool)row.Cells["IsChecked"].Value;
            row.DefaultCellStyle.BackColor = isChecked ? Color.LightGreen : Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point location = this.Location;
            location.Offset(50, 50);

            var confirmResult = ConfirmDialog.ShowDialogAt(
                "Are you sure you want to reset all Arena upgrades?",
                location
            );

            if (confirmResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    int id = (int)row.Cells["Id"].Value;
                    _db.UpdateCheckedArena(id, false);
                }

                LoadData();
                _db.UpdateLastSacrificeDate();
                lastSacrificeDate.Text = _db.SelectLastSacrificeDate()
                    .FirstOrDefault()
                    .LastSacrifice.ToString("yyyy-MM-dd HH:mm");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var otherForm = new OtherTools
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(this.Location.X + 50, this.Location.Y + 50)
            };
            otherForm.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var sacrifice = _db.SelectLastSacrificeDate().FirstOrDefault();

            if (sacrifice != null && lastSacrificeDate.Text != "Never sacrificed")
            {
                var diff = DateTime.Now - sacrifice.LastSacrifice;

                int hours = (int)diff.TotalHours;
                int minutes = diff.Minutes;
                int seconds = diff.Seconds;

                sinceLastLabel.Text = $"{hours}h {minutes}m {seconds}s";
            }
            else
            {
                sinceLastLabel.Text = "Never sacrificed";
            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            var configForm = new AppConfigurationForm
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(this.Location.X + 50, this.Location.Y + 50)
            };

            configForm.FormClosed += (s, args) => LoadData();
            configForm.Show();
        }

        private async void buttonTwitchTV_Click(object sender, EventArgs e)
        {
            buttonTwitchTV.Enabled = false;

            List<string> twitchUrls = new List<string>
            {
                "https://www.twitch.tv/mozonetv",
                "https://www.twitch.tv/tunyghost",
                "https://www.twitch.tv/n3utr4lsf",
                "https://www.twitch.tv/zsombeyhd",
                "https://www.twitch.tv/domcaofficial",
                "https://www.twitch.tv/sfgameofficial"
            };


            foreach (string url in twitchUrls)
            {
                try
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            await Task.Delay(5000);

            buttonTwitchTV.Enabled = true;
        }
    }
}
