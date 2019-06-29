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

        public GoldenFly(int speed, int amplitude, Point center, bool wings, bool direction) : base(speed, amplitude, center, wings, direction)
        {
            points = Fly.GoldenFlyPoints;
            radius = Fly.GoldenFlyRadius;
        }

    }
}
