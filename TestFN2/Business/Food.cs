using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameSpace.Business
{
    internal class Food
    {
        public Point point { get; set; }
        private bool _created;
        public bool created
        {
            get { return _created;  }
            set { _created = value; }
        }

        public Food()
        {
            this._created = false;
        }

        public void createRandomFood(int maximumX, int maximumY, Stack<Point> snake)
        {
            if(!created)
            {
                Random rn = new Random();
                int a = rn.Next(0, maximumX);
                int b = rn.Next(0, maximumY);
                this.point = new Point(a, b);

                if(snake.Contains(this.point))
                {
                    return;
                }
                this.created = true;
            }
        }


        public bool wasEaten(Stack<Point> snake)
        {
            bool check = false;
            foreach (var item in snake)
            {
                if (item.X == point.X && item.Y == point.Y) check = true; continue;
                
            }
            return check;
        }
    }

    
}
