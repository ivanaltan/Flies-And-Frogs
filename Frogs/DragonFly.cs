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
        public DragonFly(int speed, int amplitude, Point center, bool wings, bool direction) : base(speed, amplitude, center, wings, direction)
        {
            points = Fly.DragonFlyPoints;
            radius = Fly.DragonFlyRadius;
        }



    }
}
