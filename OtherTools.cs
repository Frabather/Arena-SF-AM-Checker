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
    public partial class OtherTools : Form
    {
        public OtherTools()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var undergroundform = new Underground_Upgrade_List
            {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(this.Location.X + 50, this.Location.Y + 50)
            };
            undergroundform.Show();
            this.Close();
        }
    }
}
