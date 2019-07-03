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
        public Point position;
        public bool direction;

        public bool jumping;
        public bool top;
        public int jumptime;
        public int jumpvelocityx;
        public int jumpvelocityy;
        public int greatestheight;

        public bool moving;
        public bool img;
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

        public FrogText text;

        public FliesCollection flies;

        public Frog(FliesCollection flies)
        {
            this.flies = flies;
            points = 0;
            tonguestate = 0;
            powerup = false;
            moving = false;
            jumping = false;

            text = new FrogText();
            tongue = new List<Circle>();
        }

        public void Draw(Graphics g)
        {
            foreach (Circle c in tongue)
                c.Draw(g);

            if (text.active)
                text.Draw(g, position);

            if (direction)
            {
                if (moving)
                    g.DrawImageUnscaled(img2, position);
                else if (jumping)
                    g.DrawImageUnscaled(imgjump, position);
                else
                    g.DrawImageUnscaled(img1, position);
            }

            else
            {
                if (moving)
                    g.DrawImageUnscaled(img2F, position);
                else if (jumping)
                    g.DrawImageUnscaled(imgjumpF, position);
                else
                    g.DrawImageUnscaled(img1F, position);
            }

            moving = false;


        }

        public void Jump()
        {
            if (jumping && !powerup) return;
            if (position.X <= 38 && !direction) return;
            if (position.X >= 967 && direction) return;

            jumping = true;
            top = false;
            jumptime = 0;
            jumpvelocityx = (int)(Adjustments.JumpVelocity * Math.Cos(Adjustments.JumpAngle*Math.PI/180));
            jumpvelocityy = (int)(Adjustments.JumpVelocity * Math.Sin(Adjustments.JumpAngle*Math.PI/180));
            greatestheight = Adjustments.Ground+(int)((Adjustments.JumpVelocity * Adjustments.JumpVelocity * Math.Sin(Adjustments.JumpAngle * Math.PI / 180) * Math.Sin(Adjustments.JumpAngle * Math.PI / 180)) / (2 * Adjustments.GravityAcceleration));

        }

        public void Move(bool d)
        {

            if (jumping) return;

            if (direction != d)
                direction = d;

            else
            {
                if (position.X <= 35 && !direction) return;
                if (position.X >= 970 && direction) return;

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
            if (!jumping) return;

            if (position.X <= 35 || position.X >= 970)
            {
                if (direction) direction = false;
                else direction = true;
            }

            if (position.Y >= Adjustments.Ground && top)
            {
                jumping = false;
                position.Y = Adjustments.Ground;
                return;
            }

            int addx, addy;

            if (direction)
                addx = jumpvelocityx;
            
            else
                addx = -jumpvelocityx;

            addy = -(int)(jumpvelocityy - (Adjustments.GravityAcceleration * jumptime * 0.0166));

            if (position.Y + addy >= Adjustments.Ground && top)
            {
                addy = Adjustments.Ground - position.Y;
                jumping = false;
            }

            UpdatePosition(addx, addy);

            jumptime++;
            if (!top && position.Y <= greatestheight) top = true;
        }

        public void UpdatePosition(int x, int y)
        {
            position.X += x;
            position.Y += y;

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
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 2, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 2:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 4, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 3:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 6, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 4:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 8, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 5:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 10, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 6:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 12, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 7:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 14, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 8:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 16, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 9:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 18, position.Y + Adjustments.TongueOffsetY)));
                    tonguestate++;
                    return;
                case 10:
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + 20, position.Y + Adjustments.TongueOffsetY)));
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
                    if ((c.center.X - f.center.X) * (c.center.X - f.center.X) + (c.center.Y - f.center.Y) * (c.center.Y - f.center.Y) <= ((Adjustments.CircleRadius + f.radius) * (Adjustments.CircleRadius + f.radius)))
                    {
                        if (!f.eaten[id])
                        {
                            f.eaten[id] = true;
                            f.deadstate = 1;

                            points += f.points;
                            text.AddPoints(f.points);
                        }
                    }
                }
            }

        }

    }
}
