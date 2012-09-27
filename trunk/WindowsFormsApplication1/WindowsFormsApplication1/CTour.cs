using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTour
    {

        private CTSPPointList mPoints = new CTSPPointList();
        private double mTourLength = 0;

     
        public void Add(CTSPPoint point)
        {
            if (mPoints.length() == 0)
            {
                mTourLength = 0;
            }
            else
            {
                CTSPPoint lastPointInList = mPoints.getPoint(mPoints.length() - 1);
                CConnection additinalConnection = CConnectionList.getInstance().getConnection(lastPointInList, point);
                mTourLength += additinalConnection.getDistance();
            }

            mPoints.addPoint(point);
        }

        public CTSPPoint GetPoint(int index)
        {
            return mPoints.getPoint(index);
        }

        public double Length
        {
            get
            {
                return mTourLength;
            }
        }



    }
}
