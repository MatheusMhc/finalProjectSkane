using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameSpace.Business
{
    internal class TurnPoint
    {
        public Point turnPoint {  get; set; }
        public Directions headDirection { get; set; }

        public Directions tailDirection { get; set; }

        public TurnPoint() { 
        }

        public TurnPoint(Point point, Directions headDirec, Directions tailDirec)
        {
            this.tailDirection = tailDirec;
            this.turnPoint = point;
            this.headDirection = headDirec;
        }

        public bool equals(TurnPoint other)
        {
            return this.turnPoint.X == other.turnPoint.X && this.turnPoint.Y == other.turnPoint.Y;
        }

        public int contains(List<TurnPoint> turnPoints)
        {
            foreach (TurnPoint tp in turnPoints)
            {
                if (tp.equals(this)) return turnPoints.IndexOf(tp);
            }
            return -1;
        }
    }
}
