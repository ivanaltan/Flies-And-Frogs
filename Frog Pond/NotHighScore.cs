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
    public partial class NotHighScore : Form
    {
        public NotHighScore(int points)
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;

            lblPoints.Text = "Points:   "+points.ToString();
        }
    }
}
