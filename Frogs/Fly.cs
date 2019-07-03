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
            this.position = position;
            this.speed = speed;
            this.amplitude = amplitude;
            this.frequency = frequency;
            this.direction = direction;

            this.center.X = position.X + radius;
            this.center.Y = position.Y + radius;

            frames = 0;
            img = false;
            eaten = new bool[3] { false, false, false };                   
        }


        public virtual void Move()
        {
            CheckPosition();

            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);

            position.Y = (int)(Math.Sin(frames * 0.0166 * frequency) * amplitude)-position.Y;

            frames++;

            this.center.X = position.X + radius;
            this.center.Y = position.Y + radius;
        }

        public void MoveStraight()
        {
            CheckPosition();

            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);

            this.center.X = position.X + radius;
            this.center.Y = position.Y + radius;
        }


        public void CheckPosition()
        {
            if (position.X <= Adjustments.minposXl && direction==false)
            {
                direction = true;
            }
            if (position.X >= Adjustments.maxposXr && direction == true)
            {
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
