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
        int speed;
        int amplitude;
        int center;
        Point position;
        bool wings;
        bool eaten;
        int points;
        

        public Fly(int speed, int amplitude, int center, Point position, bool wings)
        {
            this.speed = speed;
            this.amplitude = amplitude;
            this.center = center;
            this.position = position;
            this.wings = wings;
            this.eaten = false;
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
