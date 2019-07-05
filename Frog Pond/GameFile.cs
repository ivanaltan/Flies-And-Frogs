using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    [Serializable]
    public class GameFile
    {
        public HighScores highscores;
        public Controls controls;

        public GameFile() {
            highscores = new HighScores();
            controls = new Controls();
        }

    }
}
