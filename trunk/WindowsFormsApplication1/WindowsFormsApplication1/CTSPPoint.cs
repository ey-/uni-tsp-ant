using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTSPPoint
    {
        public int x;
        public int y;
        protected string mLabel;

        public CTSPPoint(string label)
        {
            mLabel = label;
        }

        public CTSPPoint(int inX, int inY, string label)
        {
            x = inX;
            y = inX;
            mLabel = label;
        }

        public string getLabel()
        {
            return mLabel;
        }

    }
}
