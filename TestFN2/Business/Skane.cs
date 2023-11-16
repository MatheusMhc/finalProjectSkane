using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFN2.Business
{
    internal class Skane
    {
        public Point head { get; set; }
        public Point tail { get; set; }

        public List<Point> turnPoint { get; set; } 

        public Directions headDirection { get; set; }

        Stack<Point> myStack;

        public Skane() { 
            
            head = new Point(0, 0);
            tail = new Point(0, 3);
            headDirection = Directions.RIGHT;
            turnPoint = new List<Point>();
        }

        public Stack<Point> returnSnakePoints()
        {
            //myStack.Push(tail);
            myStack = new Stack<Point>();

            if(turnPoint.Count == 0)
            {
                if(head.X == tail.X && head.Y > tail.Y)
                {
                    for(int y =  tail.Y; y < head.Y; y++)
                    {
                        myStack.Push(new Point(head.X, y));
                    }
                }

                if (head.X == tail.X && head.Y < tail.Y)
                {
                    for (int y = tail.Y; y > head.Y ; y--)
                    {
                        myStack.Push(new Point(head.X, y));
                    }
                }

                myStack.Push(head);
            }
            else
            {

            }

            return myStack;
        }



    }
}
