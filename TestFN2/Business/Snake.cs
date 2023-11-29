using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameSpace.Business
{
    internal class Snake
    {
        public Point head { get; set; }

        public Point tail { get; set; }

        public List<BendPoint> turnPoints { get; set; } 

        public Directions headDirection { get; set; }

        public Directions tailDirection { get; set; }

        Stack<Point> stackSnake;

        public Snake() { 
            
            head = new Point(2 , 0);
            tail = new Point(0, 0);
            headDirection = Directions.DOWN;
            tailDirection = Directions.DOWN;
            turnPoints = new List<BendPoint>();
        }

        public void addTurnPointIfNotExist(BendPoint turnPoint)
        {
            int a = turnPoint.contains(turnPoints);
            if (a < 0) {
                this.turnPoints.Add(turnPoint);
                return;
            }

            turnPoints.Insert(a, turnPoint);
        }

        public void increaseMySize()
        {
            if (this.tailDirection == Directions.RIGHT)
            {
                Point point = new Point(this.tail.X, this.tail.Y - 1);
                this.tailDirection = Directions.RIGHT;
                this.tail = point;
            }

            if (this.tailDirection == Directions.DOWN)
            {
                Point point = new Point(this.tail.X - 1, this.tail.Y);
                this.tailDirection = Directions.DOWN;
                this.tail = point;
            }
            if (this.tailDirection == Directions.LEFT)
            {
                Point point = new Point(this.tail.X, this.tail.Y + 1);
                this.tailDirection = Directions.LEFT;
                this.tail = point;
            }
            if (this.tailDirection == Directions.UP)
            {
                Point point = new Point(this.tail.X + 1, this.tail.Y);
                this.tailDirection = Directions.UP;
                this.tail = point;
            }

            returnSnakePoints();
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
            stackSnake = new Stack<Point>();

            if(turnPoints.Count == 0)
            {
                if(head.X == tail.X && head.Y > tail.Y)
                {
                    for(int y =  tail.Y; y <= head.Y; y++)
                    {
                        stackSnake.Push(new Point(head.X, y));
                    }
                }

                if (head.X == tail.X && head.Y < tail.Y)
                {
                    for (int y = tail.Y; y >= head.Y ; y--)
                    {
                        stackSnake.Push(new Point(head.X, y));
                    }
                }

                if (head.Y == tail.Y && head.X > tail.X)
                {
                    for (int x = tail.X; x <= head.X; x++)
                    {
                        stackSnake.Push(new Point(x, tail.Y));
                    }
                }

                if (head.Y == tail.Y && head.X < tail.X)
                {
                    for (int x = tail.X; x >= head.X; x--)
                    {
                        stackSnake.Push(new Point(x, tail.Y));
                    }
                }

            }
            else
            {
                Point temp = tail;
                BendPoint first = turnPoints.First();
                if(tail.X == first.turnPoint.X && tail.Y == first.turnPoint.Y)
                {
                    turnPoints.Remove(first);
                    tailDirection = first.headDirection;
                    stackSnake.Push(tail);
                }

                foreach (BendPoint p in turnPoints)
                {
                    if (temp.X == p.turnPoint.X && temp.Y > p.turnPoint.Y)
                    {
                        for (int y = p.turnPoint.Y; y <= temp.Y; y++)
                        {
                            stackSnake.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.X == p.turnPoint.X && temp.Y < p.turnPoint.Y)
                    {
                        for (int y = p.turnPoint.Y; y >= temp.Y; y--)
                        {
                            stackSnake.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.Y == p.turnPoint.Y && temp.X > p.turnPoint.X)
                    {
                        for (int x = p.turnPoint.X; x <= temp.X; x++)
                        {
                            stackSnake.Push(new Point(x, temp.Y));
                        }
                    }

                    if (temp.Y == p.turnPoint.Y && temp.X < p.turnPoint.X)
                    {
                        for (int x = p.turnPoint.X; x >= temp.X; x--)
                        {
                            stackSnake.Push(new Point(x, temp.Y));
                        }
                    }

                    temp = p.turnPoint;
                }

                if (temp.X == head.X && temp.Y < head.Y)
                {
                    for (int y = head.Y; y > temp.Y; y--)
                    {
                        stackSnake.Push(new Point(temp.X, y));
                    }
                }

                if (temp.X == head.X && temp.Y > head.Y)
                {
                    for (int y = head.Y; y < temp.Y; y++)
                    {
                        stackSnake.Push(new Point(temp.X, y));
                    }
                }

                if (temp.Y == head.Y && temp.X < head.X)
                {
                    for (int x = head.X; x > temp.X; x--)
                    {
                        stackSnake.Push(new Point(x, temp.Y));
                    }
                }

                if (temp.Y == head.Y && temp.X > head.X)
                {
                    for (int x = head.X; x < temp.X; x++)
                    {
                        stackSnake.Push(new Point(x, temp.Y));
                    }
                }

            }

            
            return stackSnake;
        }

        public bool wasIBitten()
        {
            int check = 0;
            foreach (var item in stackSnake)
            {
                if (item.X == head.X && item.Y == head.Y) check++; continue;
            }
            return check>1;
        }

        public bool didIHitTheWall(int rowNum, int colNum)
        {
            return head.X == rowNum || head.X < 0 || head.Y == colNum || head.Y < 0;
        }
    }
}
