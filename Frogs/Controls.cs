using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogs
{
    [Serializable]
    class Controls
    {
        public Keys pause;
        public Keys newgame;

        public Keys P1left;
        public Keys P1right;
        public Keys P1jump;
        public Keys P1tongue;

        public Keys P2left;
        public Keys P2right;
        public Keys P2jump;
        public Keys P2tongue;

        public Keys P3left;
        public Keys P3right;
        public Keys P3jump;
        public Keys P3tongue;

        public Controls()
        {
            pause = Keys.P;
            newgame = Keys.N;

            P1left = Keys.Left;
            P1right = Keys.Right;
            P1jump = Keys.RControlKey;
            P1tongue = Keys.RShiftKey;

            P2left = Keys.D;
            P2right = Keys.G;
            P2jump = Keys.Q;
            P2tongue = Keys.W;

            P3left = Keys.NumPad4;
            P3right = Keys.NumPad6;
            P3jump = Keys.NumPad8;
            P3tongue = Keys.NumPad9;
        }




    }
}
