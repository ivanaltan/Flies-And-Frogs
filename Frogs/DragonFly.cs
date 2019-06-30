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
            points = Fly.DragonFlyPoints;
            radius = Fly.DragonFlyRadius;

            img1 = Properties.Resources.dragonfly_1;
            img2 = Properties.Resources.dragonfly_2;
            img1F = Properties.Resources.dragonfly_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.dragonfly_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

        new public void Move()
        {
            
        }

    }
}
