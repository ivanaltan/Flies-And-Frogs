using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogs
{
    class Player1 : Frog
    {

        public Player1(ref FliesCollection flies) : base(ref flies)
        {
            p = new Point(150, ground);
            id = 0;
            direction = true;
            img1 = Properties.Resources.frog1_1;
            img2 = Properties.Resources.frog1_2;
            imgjump = Properties.Resources.frog1_jump;
            img1F = Properties.Resources.frog1_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.frog1_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            imgjumpF = Properties.Resources.frog1_jump;
            imgjumpF.RotateFlip(RotateFlipType.RotateNoneFlipX);

        }      


    }
}
