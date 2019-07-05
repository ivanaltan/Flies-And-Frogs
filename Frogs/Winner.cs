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
    public partial class Winner : Form
    {
        int id;
        Image img;

        public Winner(int id, Image img)
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;

            pictureBox1.Image = img;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            if (id != 0)
                lbl.Text = "Player " + id + " Wins!";
            else
                lbl.Text = "      Draw!     ";
        }
    }
}
