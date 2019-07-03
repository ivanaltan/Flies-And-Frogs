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
        public int tonguestate;
        public Point p;
        public bool direction;

        public bool jumping;

        public bool moving;
        public bool img;
        public bool top;
        public bool powerup;

        public int points;
        public int id;

        public Image img1;
        public Image img2;
        public Image imgjump;
        public Image img1F;
        public Image img2F;
        public Image imgjumpF;

        public List<Circle> tongue;

        public FliesCollection flies;

        public Frog(FliesCollection flies)
        {
            this.flies = flies;
            points = 0;
            tonguestate = 0;
            powerup = false;
            moving = false;
            jumping = false;

            tongue = new List<Circle>();
        }

        public void Draw(Graphics g)
        {
            foreach (Circle c in tongue)
                c.Draw(g);

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

        public void Move(bool d)
        {

            if (jumping) return;

            if (direction != d)
                direction = d;

            else
            {
                if (p.X <= 35 && !direction) return;
                if (p.X >= 970 && direction) return;

                if (direction)
                {
                    UpdatePosition(5, 0);
                }
                else
                {
                    UpdatePosition(-5, 0);
                }

                moving = true;
            }


        }


        public void UpdateJump()
        {
            if (jumping)
            {

                if(p.X<=35 || p.X>=970)
                {
                    if (direction) direction = false;
                    else direction = true;
                }

                if (!top && p.Y <= Adjustments.jumpheight)
                    top = true;

                if (top && p.Y >= Adjustments.ground)
                {
                    jumping = false;
                    p.Y = Adjustments.ground;
                    return;
                }

                else if (!top && direction)
                    UpdatePosition(2,-5);

                else if (!top && !direction)
                    UpdatePosition(-2, -5);

                else if (top && direction)
                    UpdatePosition(2, 5);

                else if (top && !direction)
                    UpdatePosition(-2, 5);
            }
        }

        public void UpdatePosition(int x, int y)
        {
            p.X += x;
            p.Y += y;

            foreach (Circle c in tongue)
                c.Move(x,y);
        }

        public void Tongue()
        {
            if (tonguestate == 0)
                tonguestate = 1;   
        }

        public void UpdateTongue()
        {

            switch (tonguestate)
            {
                case 0:
                    return;
                case 1:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 2, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 2:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 4, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 3:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 6, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 4:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 8, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 5:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 10, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 6:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 12, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 7:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 14, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 8:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 16, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 9:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 18, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 10:
                    tongue.Add(new Circle(new Point(p.X + Adjustments.tongueoffsetx + 20, p.Y + Adjustments.tongueoffsety)));
                    tonguestate++;
                    return;
                case 11:
                    tonguestate++;
                    return;
                case 12:
                    tongue.RemoveAt(10);
                    tonguestate++;
                    return;
                case 13:
                    tongue.RemoveAt(9);
                    tonguestate++;
                    return;
                case 14:
                    tongue.RemoveAt(8);
                    tonguestate++;
                    return;
                case 15:
                    tongue.RemoveAt(7);
                    tonguestate++;
                    return;
                case 16:
                    tongue.RemoveAt(6);
                    tonguestate++;
                    return;
                case 17:
                    tongue.RemoveAt(5);
                    tonguestate++;
                    return;
                case 18:
                    tongue.RemoveAt(4);
                    tonguestate++;
                    return;
                case 19:
                    tongue.RemoveAt(3);
                    tonguestate++;
                    return;
                case 20:
                    tongue.RemoveAt(2);
                    tonguestate++;
                    return;
                case 21:
                    tongue.RemoveAt(1);
                    tonguestate=0;
                    return;
            }

        }

        public void CheckCollisions()
        {
            foreach (Circle c in tongue)
            {
                foreach (Fly f in flies.flies)
                {
                    if ((c.center.X - f.center.X) * (c.center.X - f.center.X) + (c.center.Y - f.center.Y) * (c.center.Y - f.center.Y) <= ((Adjustments.circleradius + f.radius) * (Adjustments.circleradius + f.radius)))
                    {
                        if (!f.eaten[id])
                        {
                            f.eaten[id] = true;
                            points += f.points;
                        }
                    }
                }
            }

        }

    }
}
