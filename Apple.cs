using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Apple
    {
        public int x, y;
        private Random rnd = new Random();
        private bool AppleCollidingWithBody(List<SnakeBodyPart> snake)
        {
            foreach (SnakeBodyPart part in snake)
            {
                if (part.x == this.x && part.y == this.y)
                {
                    return true;
                }
            }
            return false;
        }


        //generates new apple coords and checks if new coords do not collide with any part of the snake body
        public void GenerateAppleCoords(short numRows, List<SnakeBodyPart> snake)
        {
            //20 is how much cols in each row of the grid (hard coded cus im lazy)            
            do
            {
                x = rnd.Next(0, numRows);
                y = rnd.Next(0, numRows);
            } while (this.AppleCollidingWithBody(snake) || x == 0 || y == 0 || x == 19 || y == 19 );
        }
    }
}
