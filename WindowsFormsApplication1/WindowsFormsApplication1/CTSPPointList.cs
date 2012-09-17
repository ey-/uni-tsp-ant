using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    class CTSPPointList :  IEnumerable
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

            return newList;
        }

        /// <summary>
        /// fügt einen Punkt in die Liste ein
        /// </summary>
        /// <param name="point">Punkt der eingefügt werden soll</param>
        public void addPoint(CTSPPoint point)
        {
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
        public void delete(int index)
        {
            // out of Bounds?
            if ((index >= 0) && (index >= mPointList.Count))
            {
                mPointList.Remove(mPointList[index]);
            }
        }

        /// <summary>
        /// Löscht einen bestimmten Punkt aus der Liste
        /// </summary>
        /// <param name="point"></param>
        public void delete(CTSPPoint point)
        {
            mPointList.Remove(point);
        }

        /// <summary>
        /// Löscht alle Punkte aus der Liste
        /// </summary>
        public void deleteAll()
        {
            mPointList.RemoveRange(0, mPointList.Count());
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
    }
}
