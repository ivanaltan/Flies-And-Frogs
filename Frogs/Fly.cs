﻿using System;
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
        public int deadstate;
        public int firsty;

        public Image img1;
        public Image img2;
        public Image img1F;
        public Image img2F;
        public Image img3;
        public Image img3F;

        public Fly(Point position, int speed, int amplitude, int frequency, bool direction)
        {
            this.position = position;
            this.speed = speed;
            this.amplitude = amplitude;
            this.frequency = frequency;
            this.direction = direction;

            this.center.X = position.X + radius;
            this.center.Y = position.Y + radius;

            firsty = position.Y;

            deadstate = 0;
            frames = 0;
            img = false;
            eaten = new bool[4] { false, false, false, false };                   
        }


        public virtual void Move()
        {
            if (deadstate != 0)
                return;

            CheckPosition();

            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);

            position.Y = (int)(Math.Sin(frames * 0.0166 * frequency) * amplitude)+firsty;


            frames++;

            center.X = position.X + radius;
            center.Y = position.Y + radius;

            Dissapear();
        }

        public void MoveStraight()
        {
            if (deadstate != 0)
                return;

            CheckPosition();

            if (direction)
                position.X += (int)(0.0166 * speed);

            else
                position.X -= (int)(0.0166 * speed);

            center.X = position.X + radius;
            center.Y = position.Y + radius;

            frames++;

            Dissapear();
        }


        public void CheckPosition()
        {
            if (position.X <= Adjustments.MinPosXL && direction==false)
            {
                direction = true;
            }
            if (position.X >= Adjustments.MaxPosXR && direction == true)
            {
                direction = false;
            }

        }

        public void Draw(Graphics g)
        {
            if (deadstate > 0)
            {
                if (direction)
                {
                        g.DrawImageUnscaled(img3, position);
                        img = false;
                }

                else
                {     
                        g.DrawImageUnscaled(img3F, position);
                        img = false;
                }

                deadstate++;
                return;
            }


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

        private void Dissapear()
        {
            if (frames/60 <= Adjustments.FlyLifetime)
                return;

            if ((position.X <= Adjustments.MinPosXL && direction == false) || (position.X >= Adjustments.MaxPosXR && direction == true))
            {
                eaten[0] = true;
            }

        }

















    }
}
