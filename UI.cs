using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class UI
    {
        private Label scoreLabel;
        public UI(Label scoreLabel) 
        {
            this.scoreLabel = scoreLabel;
        }

        public void DisplayScore(short score)
        {
            scoreLabel.Text = score.ToString();
        }
    }
}
