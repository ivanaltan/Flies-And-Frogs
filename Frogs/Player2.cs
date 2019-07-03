using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogs
{
    class Player2 : Frog
    {

        public Player2 (FliesCollection flies) : base(flies)
        {
            position = new Point(875, Adjustments.Ground);
            id = 2;
            direction = false;
            img1 = Properties.Resources.frog2_1;
            img2 = Properties.Resources.frog2_2;
            imgjump = Properties.Resources.frog2_jump;
            img1F = Properties.Resources.frog2_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.frog2_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            imgjumpF = Properties.Resources.frog2_jump;
            imgjumpF.RotateFlip(RotateFlipType.RotateNoneFlipX);

            tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX, position.Y + Adjustments.TongueOffsetY)));

        }


    }
}
