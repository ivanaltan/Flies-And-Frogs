using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public class Fly
    {
        public static int NormalFlyPoints = 100;
        public static int SpanishFlyPoints = -150;
        public static int GoldenFlyPoints = 300;
        public static int DragonFlyPoints = 150;

        public static int NormalFlyRadius = 5;
        public static int SpanishFlyRadius = 7;
        public static int GoldenFlyRadius = 8;
        public static int DragonFlyRadius = 7;

        public int speed;
        public int amplitude;
        public int frequency;
        public bool direction;
        public Point center;
        public int radius;
        public Point position;
        public bool wings;
        public bool[] eaten;
        public int points;

        public Image img1;
        public Image img2;
        public Image img1F;
        public Image img2F;

        public Fly(int speed, int amplitude, Point center, bool wings, bool direction)
        {
            this.speed = speed;
            this.amplitude = amplitude;
            this.center = center;
            this.wings = wings;
            this.eaten = new bool[3] { false, false, false };
            this.direction = direction;
        }

        void Move()
        {

        }

        public void Draw(Graphics g)
        {
            
        }

















    }
}
