using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTour
    {

        private CTSPPointList mPoints = new CTSPPointList();
        private float mTourLength = 0;

     
        public void addPoint(CTSPPoint point)
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

        public CTSPPoint getPoint(int index)
        {
            return mPoints.getPoint(index);
        }

        public int getListLength()
        {
            return mPoints.length();
        }

        public float getTourLength()
        {
            return mTourLength;
        }



    }
}
