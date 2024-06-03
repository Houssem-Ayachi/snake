using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class SnakeBodyPart
    {

        public int x, y;
        public int width = 30, height = 30;

        public SnakeBodyPart(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void changePos(short newX, short newY)
        {
            x = newX;
            y = newY;
        }

    }
}
