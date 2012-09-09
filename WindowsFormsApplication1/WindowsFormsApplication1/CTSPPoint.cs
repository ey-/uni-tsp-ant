using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CTSPPoint
    {
        public int x = 0;
        public int y = 0;
        protected string mLabel;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="label">Label des Punktes</param>
        public CTSPPoint(string label)
        {
            mLabel = label;
        }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="inX">X-Koordinate des Punktes</param>
        /// <param name="inY">Y-Koordinate des Punktes</param>
        /// <param name="label">Labes des Punktes</param>
        public CTSPPoint(int inX, int inY, string label)
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

    }
}
