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
        public static int WaspPoints = -150;
        public static int GoldenFlyPoints = 300;
        public static int DragonFlyPoints = 150;

        public static int NormalFlyRadius = 5;
        public static int WaspRadius = 7;
        public static int GoldenFlyRadius = 8;
        public static int DragonFlyRadius = 7;

        public int speed;
        public int amplitude;
        public int frequency;
        public bool direction;
        public Point position;
        public Point center;
        public int radius;
        public bool img;
        public bool[] eaten;
        public int points;
        public int frames;

        public Image img1;
        public Image img2;
        public Image img1F;
        public Image img2F;

        public Fly(Point position, int speed, int amplitude, int frequency, bool direction)
        {
            this.frames = 0;
            this.speed = speed;
            this.amplitude = amplitude;
            this.img = false;
            this.eaten = new bool[3] { false, false, false };
            this.direction = direction;
        }

        public void Move()
        {
            CheckPosition();

            if (direction)
                position.X += (int)(position.X * 0.0166 * speed);

            else
                position.X -= (int)(position.X * 0.0166 * speed);

            position.Y = (int)(position.Y * Math.Sin(frames * 0.0166 * frequency) * amplitude);

            frames++;
        }

        public void CheckPosition()
        {
            if (position.X < -50)
            {
                position.X *= -1;
                direction = true;
            }
            if (position.X > 652)
            {
                position.X *= -1;
                direction = false;
            }

        }

        public void Draw(Graphics g)
        {
            if (direction)
            {
                if (img)
                {
                    g.DrawImageUnscaled(img1, position);
                    img = false;
                }
                else
                {
                    g.DrawImageUnscaled(img2, position);
                    img = true;
                }
            }

            else
            {
                if (img)
                {
                    g.DrawImageUnscaled(img1F, position);
                    img = false;
                }
                else
                {
                    g.DrawImageUnscaled(img2F, position);
                    img = true;
                }
            }
        }

















    }
}
