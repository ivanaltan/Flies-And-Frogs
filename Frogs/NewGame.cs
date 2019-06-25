using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogs
{
    public partial class NewGame : Form
    {
        public bool players;
        public int time;
        private String memtime;
        public NewGame()
        {
            InitializeComponent();
            players = false;
            time = 90;
            memtime = "90";
            tbTime.Text = "90";
            tbTime.Enabled = false;
        }

        private void radio1P_CheckedChanged(object sender, EventArgs e)
        {
            if(radio1P.Checked==true)
            {
                players = false;
                memtime = tbTime.Text;
                tbTime.Text = "90";
                tbTime.Enabled = false;
            }

            else
            {
                players = true;
                tbTime.Text = memtime;
                tbTime.Enabled = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            time = int.Parse(tbTime.Text);
            if (time < 10) time = 90;
        }

        private void tbTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
