using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CAnt
    {
        private CTSPPointList  pointsToVisit;
        private CTour tour;
        private CTSPPoint currentPoint;

        public CAnt(CTSPPointList _pointsToVisit, CTSPPoint startPoint)
        {
            tour = new CTour();
            PointsToVisit = _pointsToVisit;
            CurrentPoint = startPoint;
        }

        public CTSPPointList PointsToVisit
        {
            get { return pointsToVisit; }
            private set { pointsToVisit = value;}
        }
        public CTour GetTour()
        {
            return tour;
        }

        public CTSPPoint CurrentPoint
        {
            get { return currentPoint; }
            set
            {
                tour.Add(value);
                pointsToVisit.remove(value);
                currentPoint = value;
            }
        }
    }
}
