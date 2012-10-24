using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class CIterationList : IEnumerable
    {
        protected static Form1 mform1 = null;
        protected static CIterationList mInstance = new CIterationList();

        private List<CIteration> mIterationList =  new List<CIteration>();
        private CTour bestTour = new CTour();

        public static CIterationList getInstance()
        {
            return mInstance;
        }

        public static void setForm(Form1 form1)
        {
            mform1 = form1;            
        }

        public void refreshStatisticNumbers()
        {
            mform1.Invoke(mform1.refreshDelegateStatistic);
        }

        public int Add(CIteration iteration)
        {
            mIterationList.Add(iteration);
            return mIterationList.Count();
        }

        public void Clear()
        {
            mIterationList.Clear();
        }

        public CIteration Last()
        {
            if (mIterationList.Count > 0)
            {
                return mIterationList.Last();
            }
            return null;
        }

        public double GlobalAverageTourLength()
        {
            var avg = 0.0;
            for (var i = 0; i < mIterationList.Count; i++)
                avg += (mIterationList[i].AverageTourLength / mIterationList.Count);
            return avg;
        }

        public CTour getBestGlobalTour()
        {
            if (mIterationList.Count > 0)
            {
                bestTour = mIterationList[0].ShortestTour;
                for (var i = 1; i < mIterationList.Count; i++)
                {
                    var currentTour = mIterationList[i].ShortestTour;
                    if (currentTour.getTourLength() < bestTour.getTourLength())
                        bestTour = currentTour;
                }
                return bestTour;
            }
            return null;
        }

        public CTour getBestLastIterationTour()
        {
            if (mIterationList.Count > 0)
            {
                return mIterationList.Last().ShortestTour;
            }
            return null;
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
