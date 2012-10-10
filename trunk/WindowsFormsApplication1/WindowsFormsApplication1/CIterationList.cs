using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class CIterationList : IEnumerable
    {
        private static List<CIteration> mIterationList =  new List<CIteration>();
        private static CTour bestTour = new CTour();
        public static int Add(CIteration iteration)
        {
            mIterationList.Add(iteration);
            return mIterationList.Count();
        }

        public static void Clear()
        {
            mIterationList.Clear();
        }

        public static CIteration Last()
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

        public static CTour GlobalBestTour
        {
            get
            {
                bestTour = mIterationList[0].ShortestTour;
                for (var i = 1; i < mIterationList.Count; i++)
                {
                    var currentTour = mIterationList[i].ShortestTour;
                    if (currentTour.Length < bestTour.Length)
                        bestTour = currentTour;
                }
                return bestTour;
            }
        }

        /// <summary>
        /// Methode zum iterieren mit foreach
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (var i = 0; i < mIterationList.Count ; i++)
            {
                yield return mIterationList[i];
            }
        }
    }
}
