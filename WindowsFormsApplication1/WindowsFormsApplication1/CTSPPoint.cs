using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTSPPoint
    {
        public double x = 0;
        public double y = 0;
        protected string mLabel;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="label">Label des Punktes</param>
        public CTSPPoint(string label = "")
        {
            mLabel = label;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="inX">X-Koordinate des Punktes</param>
        /// <param name="inY">Y-Koordinate des Punktes</param>
        /// <param name="label">Labes des Punktes</param>
        public CTSPPoint(double inX, double inY, string label = ""  )
        {
            x = inX;
            y = inY;
            mLabel = label;
        }

        /// <summary>
        /// gibt das Label des Punktes zurück
        /// </summary>
        /// <returns>Label des Punktes</returns>
        public string getLabel()
        {
            return mLabel;
        }

        public void setLabel(string label)
        {
            mLabel = label;
        }

        public override string ToString()
        {
            return mLabel + " X=" + x + " Y=" + y;
        }
    }
}
