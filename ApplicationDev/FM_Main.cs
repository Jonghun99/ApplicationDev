using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationDev
{
    public partial class FM_Main : Form
    {
        public FM_Main()
        {
            InitializeComponent();
            FM_Login2 login = new FM_Login2();
            login.ShowDialog();
            tssUserName.Text = login.Tag.ToString();

            this.stbExit.Click += new System.EventHandler(this.stbExit_Click);
        }
        private void stbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssNowDate.Text = DateTime.Now.ToString();
        }
    }
}
