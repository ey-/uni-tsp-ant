using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CAnt
    {
        private CTSPPointList _pointsVisited;
        private CTSPPointList _pointsToVisit;
        private double _pheromon;

        private CTSPPoint _currentPoint
        {
            get
            {
                return _pointsVisited.getPoint(_pointsVisited.length() - 1);
            }
            set
            {
                _pointsVisited.addPoint(value);
                _pointsToVisit.delete(value);
            }
        }

        public CAnt(ref CTSPPointList points, double pheromon)
        {
            var random = new Random();
            _pointsToVisit = points.copy();
            _currentPoint = points.getPoint(random.Next((int) points.length()));
        }
        
        public CTSPPointList VisitedPoints
        {
            get
            {
                return _pointsVisited;
            }
        }

        public void GoToNextPoint()
        {
            double dChanceValue;
            double dPheromone = 1;
            double dSumChanceValue = 0;
            double dBetha = 10;
            double dAlpha = 0;
            double currentBestDistance = 0;

            foreach (var p in _pointsToVisit)
            {
                var distance = CConnectionList.getInstance().getConnection(_currentPoint,p).getDistance();
                dSumChanceValue = Math.Pow((1 / distance), dAlpha);
  
                dChanceValue = ((Math.Pow(dPheromone, dAlpha)) * (Math.Pow((1 / distance), dBetha)));
                if (((dChanceValue / dSumChanceValue) > currentBestDistance))
                {
                    currentBestDistance = distance;
                    _currentPoint = p;
                }

            }


        }
    }
}
