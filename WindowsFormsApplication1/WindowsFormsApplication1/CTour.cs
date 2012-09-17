using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CTour
    {

        private CTSPPointList _points;
        private double _tourLength;


        public void Add(CTSPPoint point)
        {
            if (_points.length() == 0)
                _tourLength = 0;
            else
                _tourLength = _tourLength + CConnectionList.getInstance().getConnection(_points.getPoint(_points.length()-1),point).getDistance();
            _points.addPoint(point);
        }

        public CTSPPoint GetPoint(int index)
        {
            return _points.getPoint(index);
        }

        public double Length
        {
            get
            {
                return _tourLength;
            }
        }



    }
}
