﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogs
{
    [Serializable]
    public class HighScores
    {
        Score[] scores;

        public HighScores() {
            Score[] scores = new Score[10];
        }


        Score GetScore(int index)
        {
            return scores[index];
        }

        void Add(int score, string name, int position)
        {
            position--;
            Score newscore = new Score(score,name);
            Score[] helper = new Score[9-position];

            int k = 0;
            for (int i = position; i < 9; i++)
            {
                helper[k]=scores[i];
                k++;
            }

            scores[position] = newscore;

            k = 0;

            for (int i = position+1; i < 10; i++)
            {
                scores[i]=helper[k];
                k++;
            }



        }

        int Check(int points)
        {
            int i = 0;

            foreach (Score s in scores)
            {
                if (s.GetPoints() > points) i++;

                else if (s.GetPoints() == points)
                {
                    i++;
                    break;
                }

                else break;

            }

            return i+1;
        }
    }
}
