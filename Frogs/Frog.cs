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
        int tonguei;

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
            if (jumping && !powerup)
                return;
            if ((position.X <= 38 && !direction) || (position.X >= 967 && direction))
                return;

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
            {
                direction = d;
                SwitchTongue(); 
            }

            else
            {
                if (position.X <= 35 && !direction) return;
                if (position.X >= 970 && direction) return;

                if (direction)
                {
                    UpdatePosition(7, 0);
                }
                else
                {
                    UpdatePosition(-7, 0);
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
                SwitchTongue();
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

        public void SwitchTongue()
        {
            foreach (Circle c in tongue)
            {
                if (!direction)
                    c.Move(-Adjustments.TongueSwitchOffset, 0);
                else
                    c.Move(Adjustments.TongueSwitchOffset, 0);
            }
        }

        public void Tongue()
        {
            if (tonguestate == 0)
            {
                tonguestate = 1;
                tonguei = 2;
            }
        }

        public void UpdateTongue()
        {
            if (tonguestate == 0)
                return;

            if (tonguestate <= Adjustments.TongueStates / 2)
            {
                if (direction)
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX + tonguestate * Adjustments.TongueStatesPositionOffset, position.Y + Adjustments.TongueOffsetY)));
                else
                    tongue.Add(new Circle(new Point(position.X + Adjustments.TongueOffsetX - Adjustments.TongueSwitchOffset - tonguestate * Adjustments.TongueStatesPositionOffset, position.Y + Adjustments.TongueOffsetY)));

                tonguestate++;
                return;
            }

            if (tonguestate == Adjustments.TongueStates / 2 + 1)
            {
                tonguestate++;
                return;
            }

            if (tonguestate <= Adjustments.TongueStates)
            {
                tongue.RemoveAt(tonguestate-tonguei);
                tonguei +=2;
                tonguestate++;
                return;
            }

                tonguestate = 0;

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
