using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameSpace.Business
{
    internal class Snake
    {
        public Point head { get; set; }

        public Point tail { get; set; }

        public List<BendPoint> bendPoints { get; set; } 

        public Directions headDirection { get; set; }

        public Directions tailDirection { get; set; }

        /*FIFO the head is always on the top*/
        Stack<Point> stackSnake;

        public Snake() { 
            
            head = new Point(2 , 0);
            tail = new Point(0, 0);
            headDirection = Directions.DOWN;
            tailDirection = Directions.DOWN;
            bendPoints = new List<BendPoint>();
        }

        public void addBendPointIfNotExist(BendPoint bendPoint)
        {
            int bendPointFind = bendPoint.contains(bendPoints);
            if (bendPointFind < 0) {
                this.bendPoints.Add(bendPoint);
                return;
            }

            /* I am adding again because the direction can be different, and I wnat always the newest one 
               So, if for any reason the same point was send =, for example, left and right was pressed very fast in the same point,
               the last one will be the correct moviment*/
            bendPoints.Insert(bendPointFind, bendPoint);
        }

        public void increaseMySize()
        {
            /* add a point to the end */
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

            if(bendPoints.Count == 0)
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
                BendPoint first = bendPoints.First();
                if(tail.X == first.turnPoint.X && tail.Y == first.turnPoint.Y)
                {
                    /* When the tail passes the last bendPoint, remove it*/
                    bendPoints.Remove(first);
                    tailDirection = first.headDirection;
                    stackSnake.Push(tail);
                }
                 /*
                  *  X ------------------------------------------>
                  * Y
                  * |
                  * |     
                  * |      
                  * |
                  * |
                  * |
                  * |
                    V
                  */
                foreach (BendPoint p in bendPoints)
                {
                    if (temp.X == p.turnPoint.X && temp.Y > p.turnPoint.Y)
                    {
                        /*
                         *  X ------------------------------------------>
                         * Y
                         * |
                         * |     *          &
                         * |      
                         * |
                         * |
                         * |
                         * |
                           V
                         */
                        for (int y = p.turnPoint.Y; y <= temp.Y; y++)
                        {
                            stackSnake.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.X == p.turnPoint.X && temp.Y < p.turnPoint.Y)
                    {
                        /*
                         *  X ------------------------------------------>
                         * Y
                         * |
                         * |     &          *
                         * |      
                         * |
                         * |
                         * |
                         * |
                           V
                         */
                        for (int y = p.turnPoint.Y; y >= temp.Y; y--)
                        {
                            stackSnake.Push(new Point(temp.X, y));
                        }
                    }

                    if (temp.Y == p.turnPoint.Y && temp.X > p.turnPoint.X)
                    {
                        /*
                         *  X ------------------------------------------>
                         * Y
                         * |
                         * |     *          
                         * |      
                         * |      
                         * |       
                         * |     &
                         * |
                           V
                         */
                        for (int x = p.turnPoint.X; x <= temp.X; x++)
                        {
                            stackSnake.Push(new Point(x, temp.Y));
                        }
                    }

                    if (temp.Y == p.turnPoint.Y && temp.X < p.turnPoint.X)
                    {
                        /*
                         *  X ------------------------------------------>
                         * Y
                         * |
                         * |     &          
                         * |      
                         * |     
                         * |    
                         * |     *
                         * |
                           V
                         */
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
