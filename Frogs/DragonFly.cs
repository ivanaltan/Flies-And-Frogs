using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Frogs
{
    class DragonFly : Fly
    {
        public DragonFly(Point position, int speed, int amplitude, int frequency, bool direction) : base(position, speed, amplitude, frequency, direction)
        {
            points = Adjustments.DragonFlyPoints;
            radius = Adjustments.DragonFlyRadius;

            img1 = Properties.Resources.dragonfly_1;
            img2 = Properties.Resources.dragonfly_2;
            img3 = Properties.Resources.dragonfly_3;
            img1F = Properties.Resources.dragonfly_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.dragonfly_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img3F = Properties.Resources.dragonfly_3;
            img3F.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

         public override void Move()
        {
            MoveStraight();
        }

    }
}
