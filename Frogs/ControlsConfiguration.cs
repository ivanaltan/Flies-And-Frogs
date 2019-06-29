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
    public partial class ControlsConfiguration : Form
    {
        public Controls c;
        public ControlsConfiguration(Controls c)
        {
            InitializeComponent();
            this.c = c;
            TextBoxes();

        }

        private void TextBoxes() {
            tbNew.Text = c.newgame.ToString();
            tbPause.Text = c.pause.ToString();
            tbP1Left.Text = c.P1left.ToString();
            tbP1Right.Text = c.P1right.ToString();
            tbP1Jump.Text = c.P1jump.ToString();
            tbP1Tongue.Text = c.P1tongue.ToString();
            tbP2Left.Text = c.P2left.ToString();
            tbP2Right.Text = c.P2right.ToString();
            tbP2Jump.Text = c.P2jump.ToString();
            tbP2Tongue.Text = c.P2tongue.ToString();
            tbP3Left.Text = c.P3left.ToString();
            tbP3Right.Text = c.P3right.ToString();
            tbP3Jump.Text = c.P3jump.ToString();
            tbP3Tongue.Text = c.P3tongue.ToString();
        }



        private void tb_Leave(object sender, EventArgs e)
        {
            TextBoxes();
        }

        private void tbPause_KeyDown(object sender, KeyEventArgs e)
        {
            c.pause = e.KeyCode;
        }

        private void tbPause_Enter(object sender, EventArgs e)
        {
            tbPause.Text = "";
        }

        private void tbNew_KeyDown(object sender, KeyEventArgs e)
        {
            c.newgame = e.KeyCode;
        }

        private void tbNew_Enter(object sender, EventArgs e)
        {
            tbNew.Text = "";
        }

        private void tbP1Left_KeyDown(object sender, KeyEventArgs e)
        {
            c.P1left = e.KeyCode;
        }

        private void tbP1Left_Enter(object sender, EventArgs e)
        {
            tbP1Left.Text = "";
        }

        private void tbP1Right_KeyDown(object sender, KeyEventArgs e)
        {
            c.P1right = e.KeyCode;
        }

        private void tbP1Right_Enter(object sender, EventArgs e)
        {
            tbP1Right.Text = "";
        }

        private void tbP1Jump_KeyDown(object sender, KeyEventArgs e)
        {
            c.P1jump = e.KeyCode;
        }

        private void tbP1Jump_Enter(object sender, EventArgs e)
        {
            tbP1Jump.Text = "";
        }

        private void tbP1Tongue_Enter(object sender, EventArgs e)
        {
            tbP1Tongue.Text = "";
        }

        private void tbP1Tongue_KeyDown(object sender, KeyEventArgs e)
        {
            c.P1tongue = e.KeyCode;
        }

        private void tbP2Left_KeyDown(object sender, KeyEventArgs e)
        {
            c.P2left = e.KeyCode;
            
        }

        private void tbP2Left_Enter(object sender, EventArgs e)
        {
            tbP2Left.Text = "";
        }

        private void tbP2Right_KeyDown(object sender, KeyEventArgs e)
        {
            c.P2right = e.KeyCode;
        }

        private void tbP2Right_Enter(object sender, EventArgs e)
        {
            tbP2Right.Text = "";
        }

        private void tbP2Jump_KeyDown(object sender, KeyEventArgs e)
        {
            c.P2jump = e.KeyCode;
        }

        private void tbP2Jump_Enter(object sender, EventArgs e)
        {
            tbP2Jump.Text = "";
        }

        private void tbP2Tongue_Enter(object sender, EventArgs e)
        {
            tbP2Tongue.Text = "";
        }

        private void tbP2Tongue_KeyDown(object sender, KeyEventArgs e)
        {
            c.P2tongue = e.KeyCode;
        }

        private void tbP3Left_KeyDown(object sender, KeyEventArgs e)
        {
            c.P3left = e.KeyCode;

        }

        private void tbP3Left_Enter(object sender, EventArgs e)
        {
            tbP3Left.Text = "";
        }

        private void tbP3Right_KeyDown(object sender, KeyEventArgs e)
        {
            c.P3right = e.KeyCode;
        }

        private void tbP3Right_Enter(object sender, EventArgs e)
        {
            tbP3Right.Text = "";
        }

        private void tbP3Jump_KeyDown(object sender, KeyEventArgs e)
        {
            c.P3jump = e.KeyCode;
        }

        private void tbP3Jump_Enter(object sender, EventArgs e)
        {
            tbP3Jump.Text = "";
        }

        private void tbP3Tongue_Enter(object sender, EventArgs e)
        {
            tbP3Tongue.Text = "";
        }

        private void tbP3Tongue_KeyDown(object sender, KeyEventArgs e)
        {
            c.P3tongue = e.KeyCode;
        }
    }
}
