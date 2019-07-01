using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    class Wasp : Fly
    {

        public Wasp(Point position, int speed, int amplitude, int frequency, bool direction) : base(position, speed, amplitude, frequency, direction)
        {
            points = Fly.WaspPoints;
            radius = Fly.WaspRadius;

            img1 = Properties.Resources.wasp_1;
            img2 = Properties.Resources.wasp_2;
            img1F = Properties.Resources.wasp_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.wasp_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

    }
}
