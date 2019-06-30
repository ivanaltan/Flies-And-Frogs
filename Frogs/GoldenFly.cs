﻿using System;
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
            points = Fly.GoldenFlyPoints;
            radius = Fly.GoldenFlyRadius;
        }

    }
}
