using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake
    {

        public List<SnakeBodyPart> bodyParts = new();

        public Snake() { }

        public void addBodyPart(int x = 0, int y = 0)
        {
            this.bodyParts.Add(new(x, y));
        }

        public (int x, int y) getPosition()
        {
            return (bodyParts[0].x, bodyParts[0].y);
        }

        public void addLast()
        {
            //set new body part position to the value of the last part's position on the list
            this.bodyParts.Add(new(this.bodyParts[this.bodyParts.Count - 1].x, this.bodyParts[this.bodyParts.Count - 1].y));
        }

        public bool isCollidingWithSelf()
        {
            for(int i = 1; i < this.bodyParts.Count; i++)
            {
                if (this.bodyParts[i].x == this.bodyParts[0].x && this.bodyParts[i].y == this.bodyParts[0].y)
                {
                    return true;
                }
            }
            return false;
        }

        public void clear()
        {
            bodyParts.Clear();
        }

        public void updateBodyPartsPosition(int stepx, int stepy)
        {
            int posx = this.bodyParts[0].x + stepx;
            int posy = this.bodyParts[0].y + stepy;
            foreach (SnakeBodyPart bodyPart in this.bodyParts){
                int bodyPartPosX = bodyPart.x;
                int bodyPartPosY = bodyPart.y;
                bodyPart.x = posx; bodyPart.y = posy;
                posx = bodyPartPosX; posy = bodyPartPosY;
            }
        }

    }
}
