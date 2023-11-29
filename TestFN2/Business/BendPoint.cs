using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameSpace.Business
{ /*
   * This is the class to control the points where the snake bends
   */
    internal class BendPoint
    {
        public Point turnPoint {  get; set; }

        public Directions headDirection { get; set; }

        public Directions tailDirection { get; set; }

        public BendPoint() { 
        }

        public BendPoint(Point point, Directions headDirec, Directions tailDirec)
        {
            this.tailDirection = tailDirec;
            this.turnPoint = point;
            this.headDirection = headDirec;
        }

        public bool equals(BendPoint other)
        {
            return this.turnPoint.X == other.turnPoint.X && this.turnPoint.Y == other.turnPoint.Y;
        }

        public int contains(List<BendPoint> turnPoints)
        {
            foreach (BendPoint tp in turnPoints)
            {
                if (tp.equals(this)) return turnPoints.IndexOf(tp);
            }
            return -1;
        }
    }
}
