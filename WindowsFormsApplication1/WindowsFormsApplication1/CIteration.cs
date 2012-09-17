using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CIteration
    {
        private double _averageTourLength;
        private CTour _shortestTour;
        public CIteration(CTour shortestTour, double averageTourLength)
        {
            _averageTourLength = averageTourLength;
            _shortestTour = shortestTour;
        }

        public double AverageTourLength {
            get
            {
                return _averageTourLength;
            }
        }

        public CTour ShortestTour
        {
            get
            {
                return _shortestTour;
            }
        }
    }
}
