using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arena_SF_AM_Checker
{
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog(string message)
        {
            InitializeComponent();

            lblMessage.MaximumSize = new Size(350, 0);
            lblMessage.AutoSize = true;
            lblMessage.Text = message;

            
            int padding = 30;
            int width = Math.Max(lblMessage.Width + 20, 200);
            int height = lblMessage.Height + buttonYes.Height + padding;

            this.ClientSize = new Size(width, height);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            buttonYes.Location = new Point(width / 2 - buttonYes.Width - 10, height - buttonYes.Height - 10);
            buttonNo.Location = new Point(width / 2 + 10, height - buttonNo.Height - 10);

            lblMessage.Location = new Point((width - lblMessage.Width) / 2, 15);
        }

        public static DialogResult ShowDialogAt(string message, Point location)
        {
            using (var dlg = new ConfirmDialog(message))
            {
                dlg.StartPosition = FormStartPosition.Manual;
                dlg.Location = location;
                return dlg.ShowDialog();
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
