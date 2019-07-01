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
        //adjust these
        public static int flyspawnintervalsingle = 2500;
        public static int flyspawnintervalmulti = 2000;
        public static double flyspawnintervaldecrease = 0.0001;
        public static int maxamplitude = 500;
        public static int minamplitude = 10;
        public static int maxspeed = 280;
        public static int minspeed = 150;
        public static int maxfrequency = 7;
        public static int minfrequency = 1;
        public static int maxposXl = -50;
        public static int minposXl = -150;
        public static int maxposXr = 1225;
        public static int minposXr = 1125;
        public static int maxposY = 380;
        public static int minposY = 80;

        public List<Fly> flies;

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
                f.Move();
        }

        public void AddFly() {

            Fly f;

            int speed = CustomRandom.GetNumber(minspeed,maxspeed);
            int frequency = CustomRandom.GetNumber(minfrequency, maxfrequency);

            bool direction;
            int c = CustomRandom.GetNumber(0, 2);
            if (c == 0) direction = false;
            else direction = true;

            int posX;
            int posY = CustomRandom.GetNumber(minposY, maxposY);

            if (CustomRandom.GetNumber(0, 2)==0)
                posX = CustomRandom.GetNumber(minposXl, maxposXl);
            else 
                posX = CustomRandom.GetNumber(minposXr, maxposXr);

            Point p = new Point(posX, posY);

            int amplitude = CustomRandom.GetNumber(minamplitude, maxamplitude);
            while (posY - amplitude < 0 || amplitude + posY > Frog.ground)
                amplitude = CustomRandom.GetNumber(minamplitude, maxamplitude);

            int type = CustomRandom.GetNumber(1, 12);
            if (type <= 6)
                f = new NormalFly(p, speed, amplitude, frequency, direction);
            else if (type<=8)
                f = new DragonFly(p, speed, amplitude, frequency, direction);
            else if (type<=10)
                f = new Wasp(p, speed, amplitude, frequency, direction);
            else
                f = new GoldenFly(p, speed+200, amplitude, frequency, direction);
            flies.Add(f);

        }

        public void Draw(Graphics g)
        {
            foreach (Fly f in flies)
                f.Draw(g);
        }

    }
}
