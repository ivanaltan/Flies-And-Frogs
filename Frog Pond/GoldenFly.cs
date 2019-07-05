using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    class GoldenFly : Fly
    {

        public GoldenFly(Point position, int speed, int amplitude, int frequency, bool direction) : base(position, speed, amplitude, frequency, direction)
        {
            points = Adjustments.GoldenFlyPoints;
            radius = Adjustments.GoldenFlyRadius;

            img1 = Properties.Resources.goldenfly_1;
            img2 = Properties.Resources.goldenfly_2;
            img3 = Properties.Resources.goldenfly_3;
            imgdead = Properties.Resources.goldenfly_dead;
            img1F = Properties.Resources.goldenfly_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.goldenfly_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img3F = Properties.Resources.goldenfly_3;
            img3F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            imgdeadF = Properties.Resources.goldenfly_dead;
            imgdeadF.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

    }
}
