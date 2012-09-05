using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CTSPPointList
    {
        static CTSPPointList mInstance = new CTSPPointList();

        protected List<CTSPPoint> mPointList;

        public CTSPPointList()
        { }

        public CTSPPointList copy()
        {
            throw new NotImplementedException();
        }

        public static CTSPPointList getInstance()
        { 
            return mInstance;
        }

        public CTSPPoint getPoint(int index)
        {
            if ((index >= 0) && (index < mPointList.Count))
                return null;

            return mPointList[index];
        }

        public void delete(int index)
        {
            throw new NotImplementedException();
        }

        public void delete(CTSPPoint point)
        {
            throw new NotImplementedException();
        }

        public void deleteAll()
        {
            throw new NotImplementedException();
        }
    }
}
