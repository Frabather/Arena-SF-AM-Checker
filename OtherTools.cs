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
            var undergroundform = new Underground_Upgrade_List();
            undergroundform.Show();
            this.Close();
        }
    }
}
