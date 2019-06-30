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
        //implement
        public static int maxamplitude;
        public static int minamplitude;
        public static int maxspeed;
        public static int minspeed;
        public static int maxfrequency;
        public static int minfrequency;
        public static int maxpositionX;
        public static int maxpositionY;
        public static int minpositionX;
        public static int minpositionY;
        public List<Fly> flies;
        private Random random;

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

            //int speed = random.Next(1,?);
            //int amplitude = random.Next(1,?);
            //int center = random.Next(?,?);
           //c = random.Next(0, 1);
            //bool direction;
           //if (c == 0) direction = false;
           //else direction = true;

           //int type = random.Next(1, 11);

            //Fly f;

            //if (type <= 6)
            //    f = new NormalFly(speed, amplitude, center, wings, direction);
            //else if (type<=8)
            //    f = new DragonFly(speed, amplitude, center, wings, direction);
            //else if (type<=10)
            //    f = new Wasp(speed, amplitude, center, wings, direction);
            //else
            //    f = new GoldenFly(speed, amplitude, center, wings, direction);

            //flies.Add(f);

        }

        public void Draw(Graphics g)
        {
            foreach (Fly f in flies)
                f.Draw(g);
        }

    }
}
