using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public class Circle
    {

        public Point center;
        public static int radius=3;

        public Circle(Point center)
        {
            this.center = center;
        }

        public int CheckCollisions(List<Fly> flies, int i)
        {
            int points = 0;

            foreach (Fly f in flies)
            {
                if ((center.X - f.center.X) * (center.X - f.center.X) + (center.Y - f.center.Y) * (center.Y - f.center.Y) <= ((radius + f.radius) * (radius + f.radius)))
                {
                    if (f.eaten[i] == false)
                    {
                        f.eaten[i] = true;
                        points += f.points;
                    }
                }
            }

            return points;
            
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius);
            brush.Dispose();
        }
    }
}
