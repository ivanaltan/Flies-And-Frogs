using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public class Frog
    {
        public int tongue;
        public Point p;
        public bool direction;

        public static int jumpheight = 180;
        public static int ground = 430;

        public bool moving;
        public bool jumping;
        public bool img;
        public bool top;
        public bool powerup;

        public int points;

        public Image img1;
        public Image img2;
        public Image imgjump;
        public Image img1F;
        public Image img2F;
        public Image imgjumpF;

        public Frog()
        {
            points = 0;
            powerup = false;
            moving = false;
            jumping = false;
        }

        public void Draw(Graphics g)
        {
            if (direction)
            {
                if (moving)
                    g.DrawImageUnscaled(img2, p);
                else if (jumping)
                    g.DrawImageUnscaled(imgjump, p);
                else
                    g.DrawImageUnscaled(img1, p);
            }

            else
            {
                if (moving)
                    g.DrawImageUnscaled(img2F, p);
                else if (jumping)
                    g.DrawImageUnscaled(imgjumpF, p);
                else
                    g.DrawImageUnscaled(img1F, p);
            }

            moving = false;


        }

        public void Jump()
        {
            if (jumping && !powerup) return;
            if (p.X <= 38 && !direction) return;
            if (p.X >= 967 && direction) return;

            jumping = true;
            top = false;
        }

        public void Tongue()
        {




        }

        public void Move(bool d)
        {

            if (jumping) return;

            if (direction != d)
                direction = d;

            else
            {
                if (p.X <= 35 && !direction) return;
                if (p.X >= 970 && direction) return;

                if (direction) p.X += 5;
                else p.X -= 5;

                moving = true;
            }

        }

        public void CheckJump()
        {
            if (jumping)
            {

                if(p.X<=35 || p.X>=970)
                {
                    if (direction) direction = false;
                    else direction = true;
                }

                if (!top && p.Y <= jumpheight)
                    top = true;

                if (top && p.Y >= ground)
                {
                    jumping = false;
                    p.Y = ground;
                    return;
                }

                else if (!top && direction)
                {
                    p.X += 3;
                    p.Y -= 5;
                }

                else if (!top && !direction)
                {
                    p.X -= 3;
                    p.Y -= 5;
                }

                else if (top && direction)
                {
                    p.X += 3;
                    p.Y += 5;
                }

                else if (top && !direction)
                {
                    p.X -= 3;
                    p.Y += 5;
                }
            }
        }

    }
}
