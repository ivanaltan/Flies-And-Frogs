using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    public class FliesCollection
    {
        public List<Fly> flies;
        private Random random;

        public FliesCollection()
        {
            flies = new List<Fly>();
        }

        void AddFly() {

            //int speed = random.Next(1,?);
            //int amplitude = random.Next(1,?);
            //int center = random.Next(?,?);
            int c = random.Next(0, 1);
            bool wings;
            if (c == 0) wings = false;
            else wings = true;
            c = random.Next(0, 1);
            bool direction;
            if (c == 0) direction = false;
            else direction = true;

            int type = random.Next(1, 11);

            //Fly f;

            //if (type <= 6)
            //    f = new NormalFly(speed, amplitude, center, wings, direction);
            //else if (type<=8)
            //    f = new DragonFly(speed, amplitude, center, wings, direction);
            //else if (type<=10)
            //    f = new SpanishFly(speed, amplitude, center, wings, direction);
            //else
            //    f = new GoldenFly(speed, amplitude, center, wings, direction);

            //flies.Add(f);

        }


    }
}
