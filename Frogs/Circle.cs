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

        public Circle(Point center)
        {
            this.center = center;
        }

        public void Move(int x, int y)
        {
            x += center.X;
            y += center.Y;
            center = new Point(x, y);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, center.X - Adjustments.circleradius, center.Y - Adjustments.circleradius, 2 * Adjustments.circleradius, 2 * Adjustments.circleradius);
            brush.Dispose();
        }
    }
}
