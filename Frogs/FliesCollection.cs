using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public class FliesCollection
    {
        public static int maxamplitude=100;
        public static int minamplitude=1;
        public static int maxspeed=100;
        public static int minspeed=1;
        public static int maxfrequency=3;
        public static int minfrequency=1;
        public static int maxposXl=-50;
        public static int minposXl =-150;
        public static int maxposXr = 1225;
        public static int minposXr = 1125;
        public static int maxposY=380;
        public static int minposY=50;
        public List<Fly> flies;
        private static Random random = new Random();

        public FliesCollection()
        {
            flies = new List<Fly>();
        }

        public void RemoveEaten()
        {
            for (int i = flies.Count - 1; i >= 0; --i)
            {
                if (flies[i].eaten[0] || flies[i].eaten[1] || flies[i].eaten[2])
                {
                    flies.RemoveAt(i);
                }
            }        
        }

        public void Move()
        {
            foreach (Fly f in flies)
            {
                f.Move();
            }
        }

        public void AddFly() {

            Fly f;

            int speed = random.Next(minspeed,maxspeed);
            int frequency = random.Next(minfrequency, maxfrequency);

            bool direction;
            int c = random.Next(0, 2);
            if (c == 0) direction = false;
            else direction = true;

            int posX;
            int posY = random.Next(minposY, maxposY);

            if (random.Next(0, 2)==0)
                posX = random.Next(minposXl, maxposXl);
            else 
                posX = random.Next(minposXr, maxposXr);

            Point p = new Point(posX, posY);

            int amplitude = random.Next(minamplitude, maxamplitude);
            while (amplitude + posY < 0 || amplitude + posY > Frog.ground)
                amplitude = random.Next(minamplitude, maxamplitude);

            int type = random.Next(1, 12);
            if (type <= 6)
                f = new NormalFly(p, speed, amplitude, frequency, direction);
            else if (type<=8)
                f = new DragonFly(p, speed, amplitude, frequency, direction);
            else if (type<=10)
                f = new Wasp(p, speed, amplitude, frequency, direction);
            else
                f = new GoldenFly(p, speed, amplitude, frequency, direction);

            flies.Add(f);

        }

        public void Draw(Graphics g)
        {
            foreach (Fly f in flies)
                f.Draw(g);
        }

    }
}
