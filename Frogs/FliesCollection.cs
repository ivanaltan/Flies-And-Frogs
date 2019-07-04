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
        public List<Fly> flies;

        public FliesCollection()
        {
            flies = new List<Fly>();
        }

        public void RemoveEaten()
        {
            for (int i = flies.Count - 1; i >= 0; --i)
            {
                if (flies[i].eaten[0] || flies[i].eaten[1] || flies[i].eaten[2] || flies[i].eaten[3])
                {
                    if(flies[i].deadstate>Adjustments.DeadStateDuration)
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

            int speed = CustomRandom.GetNumber(Adjustments.MinSpeed, Adjustments.MaxSpeed);
            int frequency = CustomRandom.GetNumber(Adjustments.MinFrequency, Adjustments.MaxFrequency);

            bool direction;
            int c = CustomRandom.GetNumber(0, 2);
            if (c == 0) direction = false;
            else direction = true;

            int posX;
            int posY = CustomRandom.GetNumber(Adjustments.MinPosY, Adjustments.MaxPosY);

            if (CustomRandom.GetNumber(0, 2)==0)
                posX = CustomRandom.GetNumber(Adjustments.MinPosXL, Adjustments.MaxPosXL);
            else 
                posX = CustomRandom.GetNumber(Adjustments.MinposXR, Adjustments.MaxPosXR);

            Point p = new Point(posX, posY);

            int amplitude = CustomRandom.GetNumber(Adjustments.MinAmplitude, Adjustments.MaxAmplitude);
            while (posY - amplitude < 0 || amplitude + posY > Adjustments.Ground)
                amplitude = CustomRandom.GetNumber(Adjustments.MinAmplitude, Adjustments.MaxAmplitude);

            int type = CustomRandom.GetNumber(1, 12);
            if (type <= 6)
                f = new NormalFly(p, speed, amplitude, frequency, direction);
            else if (type<=8)
                f = new DragonFly(p, speed+ Adjustments.DragonFlySpeedUp, amplitude, frequency, direction);
            else if (type<=10)
                f = new Wasp(p, speed, amplitude, frequency, direction);
            else
                f = new GoldenFly(p, speed+Adjustments.GoldenFlySpeedUp, amplitude, frequency, direction);
            flies.Add(f);

        }

        public void Draw(Graphics g)
        {
            foreach (Fly f in flies)
                f.Draw(g);
        }

    }
}
