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
    public partial class NewHighScore : Form
    {
        public string name;
        public NewHighScore(int points, int position)
        {
            InitializeComponent();
            lblPoints.Text = "Points:     " + points;
            lblPosition.Text = "Position:     " + position;
            name = "Unnamed";
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            name = tbName.Text;
        }
    }
}
