using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFN2.Business
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
    }
}
