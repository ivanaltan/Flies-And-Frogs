using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public class FrogText
    {
        public int points;

        public bool active;
        public int duration;

        Font font;
        SolidBrush brush;
        StringFormat format;

        public FrogText()
        {
            active = false;

            font = new Font("Arial", 12, FontStyle.Italic | FontStyle.Bold);
            brush = new SolidBrush(Color.Red);
            format = new StringFormat();
        }

        public void AddPoints(int newpoints)
        {
            if (active)
                points += newpoints;

            else
            {
                points = newpoints;
                active = true;
            }

            duration = 0;
        }

        public void Draw(Graphics g, Point p)
        {
            duration++;
            string text;

            if (duration > Adjustments.FrogTextDuration)
                active = false;

            else
            {
                if (points > 0)
                    text = "+" + points.ToString();
                else
                    text = points.ToString();

                g.DrawString(text,font,brush,new Point(p.X+Adjustments.FrogTextOffsetX,p.Y+Adjustments.FrogTextOffsetY),format);
            }
        }
    }
}
