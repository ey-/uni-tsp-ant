using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class CIterationList : IEnumerable
    {
        private List<CIteration> mIterationList =  new List<CIteration>();

        public int Add(CIteration iteration)
        {
            mIterationList.Add(iteration);
            return mIterationList.Count();
        }

        public void Clear()
        {
            mIterationList.Clear();
        }

        public List<CIteration> Instance()
        {
            return mIterationList;
        }

        public CIteration Last()
        {
            return mIterationList.Last();
        }

        public double GlobalAverageTourLength()
        {
            var avg = 0.0;
            for (var i = 0; i < mIterationList.Count; i++)
                avg += (mIterationList[i].AverageTourLength / mIterationList.Count);
            return avg;
        }

        public CTour GlobalBestTour()
        {
            CTour bestTour = mIterationList[0].ShortestTour;
            for (var i = 1; i < mIterationList.Count; i++)
            {
                var currentTour = mIterationList[i].ShortestTour;
                if (currentTour.Length < bestTour.Length)
                    bestTour = currentTour;
            }
            return bestTour;
        }

        /// <summary>
        /// Methode zum iterieren mit foreach
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < mIterationList.Count; index++)
            {
                yield return mIterationList[index];
            }
        }
    }
}
