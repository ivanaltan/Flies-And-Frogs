using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    abstract class Fly
    {
        public static int NormalFlyPoints = 100;
        public static int SpanishFlyPoints = -150;
        public static int GoldenFlyPoints = 300;
        public static int DragonFlyPoints = 150;

        public int speed;
        public int amplitude;
        public int center;
        public Point position;
        public bool wings;
        public bool eaten;
        public int points;
        public bool direction;
        

        public Fly(int speed, int amplitude, int center, bool wings, bool direction)
        {
            this.speed = speed;
            this.amplitude = amplitude;
            this.center = center;
            this.wings = wings;
            this.eaten = false;
            this.direction = direction;
        }

        void MoveLeft()
        {

        }

        void MoveRight()
        {

        }

        public void Draw(Graphics g)
        {
            
        }

















    }
}
