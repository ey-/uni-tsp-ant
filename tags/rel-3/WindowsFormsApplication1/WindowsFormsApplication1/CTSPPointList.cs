using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class CTSPPointList :  IEnumerable
    {
        // Instanz des Singleton
        static CTSPPointList mInstance = new CTSPPointList();

        // Liste der Punkte
        protected List<CTSPPoint> mPointList = new List<CTSPPoint>();

        /// <summary>
        /// Konstruktor
        /// </summary>
        public CTSPPointList()
        { 
            
        }

        /// <summary>
        /// gibt die Instanz der Singleton-Klasse zurück
        /// </summary>
        /// <returns>Singleton-Instanz</returns>
        public static CTSPPointList getInstance()
        {
            return mInstance;
        }

        /// <summary>
        /// Methode zum Optimieren der Liste.
        /// Da die Kapazität des List<T> Objektes stehts höher ist als die eigentliche Anzahl an Elementen
        /// kann man hier Speicher sparen
        /// </summary>
        public void optimizeList()
        {
            mPointList.TrimExcess();
        }

        /// <summary>
        /// Kopiert diese Liste und gibt ein neues Objekt zurück
        /// </summary>
        /// <returns>neue Instanz dieser Liste</returns>
        public CTSPPointList copy()
        {
            // neues Objekt erstellen
            CTSPPointList newList = new CTSPPointList();

            // Objekt füllen
            for (int pointIndex = 0; pointIndex < length(); pointIndex++)
            {
                newList.addPoint(getPoint(pointIndex));
            }

            newList.optimizeList();

            return newList;
        }

        /// <summary>
        /// fügt einen Punkt in die Liste ein
        /// </summary>
        /// <param name="point">Punkt der eingefügt werden soll</param>
        public void addPoint(CTSPPoint point)
        {
            // normal wird die Kapazität immer verdoppelt wenn ein Element
            // zusätzlich eingefügt wird. Das kann aber einen enormen Overhead
            // zur folge haben. Darum erhöhen wir Manuell um kleine Schritte
            if (mPointList.Count + 1 >= mPointList.Capacity)
            {
                if (mPointList.Capacity > 128)
                {
                    mPointList.Capacity += 128;
                }
            }

            mPointList.Add(point);
        }

        /// <summary>
        /// holt einen Punkt anhand des Index in der Liste
        /// </summary>
        /// <param name="index">Index des zu holenden Punktes</param>
        /// <returns></returns>
        public CTSPPoint getPoint(int index)
        {
            // innerhalb der grenzen?
            if ((index >= 0) && (index < mPointList.Count))
                return mPointList[index];

            // sonst null
            return null;
        }

        /// <summary>
        /// holt einen Punkt anhand des Labels aus der Liste
        /// </summary>
        /// <param name="label">Label des zu holenden Punktes</param>
        /// <returns>TSPPoint-Objekt mit den gesuchten Label</returns>
        public CTSPPoint getPoint(string label)
        {
            foreach (CTSPPoint point in mPointList)
            {
                if (point.getLabel() == label)
                {
                    return point;
                }
            }
            return null;
        }



        public override string ToString()
        {
            String output = "";
            for (int i = 0; i < length(); i++)
            {
                output += getPoint(i).ToString();
                output += "\n";
            }
            return output;
        }

        /// <summary>
        /// Löscht einen Punkt anhand des Index in der Liste
        /// </summary>
        /// <param name="index"></param>
        public void remove(int index)
        {
            // out of Bounds?
            if ((index >= 0) && (index < mPointList.Count))
            {
                mPointList.Remove(mPointList[index]);
            }
        }

        /// <summary>
        /// Löscht einen bestimmten Punkt aus der Liste
        /// </summary>
        /// <param name="point"></param>
        public bool remove(CTSPPoint point)
        {
            return mPointList.Remove(point);
        }

        /// <summary>
        /// Löscht alle Punkte aus der Liste
        /// </summary>
        public void removeAll()
        {
            mPointList.RemoveRange(0, mPointList.Count());

            GC.Collect();
        }

        /// <summary>
        /// gibt die Länge der Liste zurück
        /// </summary>
        /// <returns>Länge der Liste</returns>
        public int length()
        {
            return mPointList.Count();
        }

        /// <summary>
        /// Methode zum iterieren mit foreach
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int index = 0; index < length(); index++)
            {
                yield return mPointList[index];
            }
        }
        /// <summary>
        /// gibt aus, ob ein Punkt existiert
        /// </summary>
        /// <param name="x"> X-Wert als float</param>
        /// <param name="y"> Y-Wert als float</param>
        /// <param name="precision">Wert zur Präzision des Treffers</param>
        /// <returns>null wenn der Punkt nicht existiert, Point als Objekt wenn es existiert</returns>

        internal CTSPPoint getPointsbyCoordinates(float x, float y, float precision)
        {
            foreach (CTSPPoint point in mPointList)
            {
               
                double abstand=Math.Sqrt(((point.x-x)*(point.x-x))+((point.y-y)*(point.y-y)));

                if (precision>=abstand)
                {

                    return point;
                }
            }
            return null;            
        }
    }
}
