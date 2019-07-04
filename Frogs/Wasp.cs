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
            points = Adjustments.WaspPoints;
            radius = Adjustments.WaspRadius;

            img1 = Properties.Resources.wasp_1;
            img2 = Properties.Resources.wasp_2;
            img3 = Properties.Resources.wasp_3;
            img4 = Properties.Resources.wasp_4;
            img1F = Properties.Resources.wasp_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.wasp_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img3F = Properties.Resources.wasp_3;
            img3F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img4F = Properties.Resources.wasp_4;
            img4F.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }

    }
}
