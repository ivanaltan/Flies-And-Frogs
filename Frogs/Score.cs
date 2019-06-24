using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    class Score
    {
        string name;
        int points;

        public Score(int points, string name)
        {
            this.points = points;
            this.name = name;
        }

        public int GetPoints() {
            return points;
        }



    }
}
