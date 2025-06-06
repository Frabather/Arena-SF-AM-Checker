using System;
using System.Linq;
using System.Windows.Forms;

namespace Arena_SF_AM_Checker
{
    public partial class Form1 : Form
    {
        private DatabaseHelper _db;

        public Form1()
        {
            InitializeComponent();
            _db = new DatabaseHelper();

            // Konfiguracja DataGridView
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += DataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            LoadData();
            AdjustFormWidthToDataGrid();
        }

        private void LoadData()
        {
            var data = _db.GetAll().ToList();
            dataGridView1.DataSource = data;

            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private void AdjustFormWidthToDataGrid()
        {
            int totalWidth = dataGridView1.RowHeadersWidth;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
                if (col.Visible)
                    totalWidth += col.Width;
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
                            _db.UpdateChecked((int)row.Cells["Id"].Value, true);
                        }
                    }
                }

                _db.UpdateChecked((int)changedRow.Cells["Id"].Value, isNowChecked);
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int id = (int)row.Cells["Id"].Value;

                _db.UpdateChecked(id, false);

                LoadData();
            }
        }
    }
}
