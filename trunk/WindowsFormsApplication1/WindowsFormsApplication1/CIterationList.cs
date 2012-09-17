using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CIterationList
    {
        private List<CIteration> _iterationList =  new List<CIteration>();

        public int Add(CIteration iteration)
        {
            _iterationList.Add(iteration);
            return _iterationList.Count();
        }

        public void Clear()
        {
            _iterationList.Clear();
        }

        public List<CIteration> Instance()
        {
            return _iterationList;
        }

        public CIteration Last()
        {
            return _iterationList.Last();
        }

        public double GlobalAverageTourLength()
        {
            var avg = 0.0;
            for (var i = 0; i < _iterationList.Count; i++)
                avg += (_iterationList[i].AverageTourLength / _iterationList.Count);
            return avg;
        }

        public CTour GlobalBestTour()
        {
            CTour bestTour = _iterationList[0].ShortestTour;
            for (var i = 1; i < _iterationList.Count; i++)
            {
                var currentTour = _iterationList[i].ShortestTour;
                if (currentTour.Length < bestTour.Length)
                    bestTour = currentTour;
            }
            return bestTour;
        }
    }
}
