using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Settings
    {

        public enum Directions
        {
            up, down, left, right
        }
        public Directions currentDirection = Directions.right;

        public int step = 30;
        
        //check if newDirection isn't the opposite of currentDirection and updates the latter
        public void UpdateDirection(Directions newDirection)
        {
            if(newDirection == Directions.up && this.currentDirection != Directions.down) {
                this.currentDirection = newDirection;
            }
            else if(newDirection == Directions.down && this.currentDirection != Directions.up) {
                this.currentDirection = newDirection;
            }
            else if (newDirection == Directions.left && this.currentDirection != Directions.right)
            {
                this.currentDirection = newDirection;
            }
            else if (newDirection == Directions.right && this.currentDirection != Directions.left)
            {
                this.currentDirection = newDirection;
            }
        }
    }
}
