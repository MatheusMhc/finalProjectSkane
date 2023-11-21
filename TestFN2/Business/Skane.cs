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

        public List<TurnPoint> turnPoint { get; set; } 

        public Directions headDirection { get; set; }

        public Directions tailDirection { get; set; }

        Stack<Point> myStack;

        public Skane() { 
            
            head = new Point(2 , 0);
            tail = new Point(0, 0);
            headDirection = Directions.DOWN;
            tailDirection = Directions.DOWN;
            turnPoint = new List<TurnPoint>();
        }

        public void moveHeadDirection()
        {
            if (this.headDirection == Directions.RIGHT)
            {
                Point point = new Point(this.head.X, this.head.Y + 1);
                this.headDirection = Directions.RIGHT;
                this.head = point;
            }

            if (this.headDirection == Directions.DOWN)
            {
                Point point = new Point(this.head.X + 1, this.head.Y);
                this.headDirection = Directions.DOWN;
                this.head = point;
            }
            if (this.headDirection == Directions.LEFT)
            {
                Point point = new Point(this.head.X, this.head.Y - 1);
                this.headDirection = Directions.LEFT;
                this.head = point;
            }
            if (this.headDirection == Directions.UP)
            {
                Point point = new Point(this.head.X - 1, this.head.Y);
                this.headDirection = Directions.UP;
                this.head = point;
            }
        }

        public void moveTailDirection()
        {
            if (this.tailDirection == Directions.RIGHT)
            {
                Point point = new Point(this.tail.X, this.tail.Y + 1);
                this.tailDirection = Directions.RIGHT;
                this.tail = point;
            }

            if (this.tailDirection == Directions.DOWN)
            {
                Point point = new Point(this.tail.X + 1, this.tail.Y);
                this.tailDirection = Directions.DOWN;
                this.tail = point;
            }
            if (this.tailDirection == Directions.LEFT)
            {
                Point point = new Point(this.tail.X, this.tail.Y - 1);
                this.tailDirection = Directions.LEFT;
                this.tail = point;
            }
            if (this.tailDirection == Directions.UP)
            {
                Point point = new Point(this.tail.X - 1, this.tail.Y);
                this.tailDirection = Directions.UP;
                this.tail = point;
            }
        }

        public Stack<Point> returnSnakePoints()
        {
            myStack = new Stack<Point>();

            if(turnPoint.Count == 0)
            {
                if(head.X == tail.X && head.Y > tail.Y)
                {
                    for(int y =  tail.Y; y <= head.Y; y++)
                    {
                        myStack.Push(new Point(head.X, y));
                    }
                }

                if (head.X == tail.X && head.Y < tail.Y)
                {
                    for (int y = tail.Y; y >= head.Y ; y--)
                    {
                        myStack.Push(new Point(head.X, y));
                    }
                }

                if (head.Y == tail.Y && head.X > tail.X)
                {
                    for (int x = tail.X; x <= head.X; x++)
                    {
                        myStack.Push(new Point(x, tail.Y));
                    }
                }

                if (head.Y == tail.Y && head.X < tail.X)
                {
                    for (int x = tail.X; x >= head.X; x--)
                    {
                        myStack.Push(new Point(x, tail.Y));
                    }
                }

            }
            else
            {
                Point temp = tail;
                TurnPoint first = turnPoint.First();
                if(tail.X == first.turnPoint.X && tail.Y == first.turnPoint.Y)
                {
                    turnPoint.Remove(first);
                    tailDirection = first.headDirection;
                    myStack.Push(tail);
                }

                foreach (TurnPoint p in turnPoint)
                {
                    if (temp.X == p.turnPoint.X && temp.Y > p.turnPoint.Y)
                    {
                        for (int y = p.turnPoint.Y; y <= temp.Y; y++)
                        {
                            myStack.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.X == p.turnPoint.X && temp.Y < p.turnPoint.Y)
                    {
                        for (int y = p.turnPoint.Y; y >= temp.Y; y--)
                        {
                            myStack.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.Y == p.turnPoint.Y && temp.X > p.turnPoint.X)
                    {
                        for (int x = p.turnPoint.X; x <= temp.X; x++)
                        {
                            myStack.Push(new Point(x, temp.Y));
                        }
                    }

                    if (temp.Y == p.turnPoint.Y && temp.X < p.turnPoint.X)
                    {
                        for (int x = p.turnPoint.X; x >= temp.X; x--)
                        {
                            myStack.Push(new Point(x, temp.Y));
                        }
                    }

                    temp = p.turnPoint;
                }

                if(checkColision())
                {
                    return null;
                }

                if (temp.X == head.X && temp.Y < head.Y)
                {
                    for (int y = head.Y; y > temp.Y; y--)
                    {
                        myStack.Push(new Point(temp.X, y));
                    }
                }

                if (temp.X == head.X && temp.Y > head.Y)
                {
                    for (int y = head.Y; y < temp.Y; y++)
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

                if (temp.Y == head.Y && temp.X > head.X)
                {
                    for (int x = head.X; x < temp.X; x++)
                    {
                        myStack.Push(new Point(x, temp.Y));
                    }
                }

            }

            
            return myStack;
        }

        private bool checkColision()
        {
            bool check = false;
            foreach (var item in myStack)
            {
                if (item.X == head.X && item.Y == head.Y) check = true; continue;
                
            }
            return check;
        }


    }
}
