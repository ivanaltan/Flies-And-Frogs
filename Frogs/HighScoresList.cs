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
    public partial class HighScoresList : Form
    {
        public HighScoresList(HighScores hs)
        {
            InitializeComponent();
            lbl1.Text = "1.     " + hs.scores[0].GetName() + "           " + hs.scores[0].GetPoints();
            lbl2.Text = "2.     " + hs.scores[1].GetName() + "           " + hs.scores[1].GetPoints();
            lbl3.Text = "3.     " + hs.scores[2].GetName() + "           " + hs.scores[2].GetPoints();
            lbl4.Text = "4.     " + hs.scores[3].GetName() + "           " + hs.scores[3].GetPoints();
            lbl5.Text = "5.     " + hs.scores[4].GetName() + "           " + hs.scores[4].GetPoints();
            lbl6.Text = "6.     " + hs.scores[5].GetName() + "           " + hs.scores[5].GetPoints();
            lbl7.Text = "7.     " + hs.scores[6].GetName() + "           " + hs.scores[6].GetPoints();
            lbl8.Text = "8.     " + hs.scores[7].GetName() + "           " + hs.scores[7].GetPoints();
            lbl9.Text = "9.     " + hs.scores[8].GetName() + "           " + hs.scores[8].GetPoints();
            lbl10.Text = "10.    " + hs.scores[9].GetName() + "           " + hs.scores[9].GetPoints();
        }
    }
}
