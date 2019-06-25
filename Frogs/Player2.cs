using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogs
{
    class Player2 : Frog
    {
        int tongue;
        Point p;
        bool direction;

        bool moving;
        bool jumping;
        bool top;

        Image img1;
        Image img2;
        Image imgjump;
        Image img1F;
        Image img2F;
        Image imgjumpF;

        public Player2()
        {
            p = new Point(750, 400);

            direction = false;
            img1 = Properties.Resources.frog2_1;
            img2 = Properties.Resources.frog2_2;
            imgjump = Properties.Resources.frog2_jump;
            img1F = Properties.Resources.frog2_1;
            img1F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            img2F = Properties.Resources.frog2_2;
            img2F.RotateFlip(RotateFlipType.RotateNoneFlipX);
            imgjumpF = Properties.Resources.frog2_jump;
            imgjumpF.RotateFlip(RotateFlipType.RotateNoneFlipX);

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
            jumping = true;
            top = false;
        }

        public void Tongue()
        {




        }

        public void Move(bool d)
        {

            if (jumping) return;

                direction = d;

                if (direction) p.X += 5;
                else p.X -= 5;

                moving = true;


            
        }

        public void CheckJump()
        {
            if (jumping)
            {
                if (!top && p.Y <= 150)
                    top = true;

                if (top && p.Y >= 400)
                {
                    jumping = false;
                    p.Y = 400;
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
