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
            
            head = new Point(0, 3);
            tail = new Point(0, 0);
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
                Point temp = tail;
                Point first = turnPoint.First();
                if(tail.X == first.X && tail.Y == first.Y)
                {
                    turnPoint.Remove(first);
                    myStack.Push(new Point(tail.X, tail.Y));
                }

                foreach (Point p in turnPoint)
                {
                    if (temp.X == p.X && temp.Y > p.Y)
                    {
                        for (int y = p.Y; y < temp.Y; y++)
                        {
                            myStack.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.X == p.X && temp.Y < p.Y)
                    {
                        for (int y = p.Y; y >= temp.Y; y--)
                        {
                            myStack.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.Y == p.Y && temp.X > p.X)
                    {
                        for (int x = p.X; x < temp.X; x++)
                        {
                            myStack.Push(new Point(x, temp.Y));
                        }
                    }

                    if (temp.Y == p.Y && temp.X < p.X)
                    {
                        for (int y = p.Y; y < temp.Y; y--)
                        {
                            myStack.Push(new Point(temp.X, y));
                        }
                    }

                    temp = p;
                }

                if (temp.X == head.X && temp.Y < head.Y)
                {
                    for (int y = head.Y; y > temp.Y; y--)
                    {
                        myStack.Push(new Point(temp.X, y));
                    }
                }

                if (temp.Y == head.Y && temp.X < head.X)
                {
                    for (int x = head.X; x > temp.X; x--)
                    {
                        myStack.Push(new Point(x, temp.Y));
                    }
                }

            }

            return myStack;
        }



    }
}
