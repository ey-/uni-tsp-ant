using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CConnection
    {
        protected CTSPPoint mTSPPoint1;
        protected CTSPPoint mTSPPoint2;
        protected double mPheromone;
        protected double mDistance;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="tspPoint1">Punkt 1 der Verbindung</param>
        /// <param name="tspPoint2">Punkt 2 der Verbindung</param>
        /// <param name="initialPheromone">Pheromon das die Verbindung von Beginn an haben soll</param>
        public CConnection(CTSPPoint tspPoint1, CTSPPoint tspPoint2, double initialPheromone = 0)
        {
            mTSPPoint1 = tspPoint1;
            mTSPPoint2 = tspPoint2;
            mPheromone = initialPheromone;

            calculateDistance();
        }

        /// <summary>
        /// Prüft ob ein Punkt in der Verbindung enthalten ist
        /// </summary>
        /// <param name="tspPoint">Punkt der in der Verbindung enthalten sein soll</param>
        /// <returns>true - Punkt ist in der Verbindung enthalten; false - Punkt ist NICHT teil der Verbindung</returns>
        public bool containsPoint(CTSPPoint tspPoint)
        {
            if (mTSPPoint1 == tspPoint) return true;
            if (mTSPPoint2 == tspPoint) return true;

            return false;
        }

        /// <summary>
        /// gibt die Entfernung der Punkte zurück
        /// </summary>
        /// <returns></returns>
        public double getDistance()
        {
            return mDistance;
        }

        /// <summary>
        /// berechnet die Entfernung der Punkte und speichert diese
        /// </summary>
        public void calculateDistance()
        {
            double deltaX = (mTSPPoint1.x - mTSPPoint2.x);
            double deltaY = (mTSPPoint1.y - mTSPPoint2.y);
            mDistance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        /// <summary>
        /// holt den aktuellen Pheromon-Wert der Verbindung
        /// </summary>
        /// <returns>Pheromonwert</returns>
        public double getPheromone()
        {
            return mPheromone;
        }

        /// <summary>
        /// addiert den angegeben Wert auf den aktuellen Pheromonwert rauf
        /// </summary>
        /// <param name="additionalPheromone">Wert der aufaddiert werden soll</param>
        public void addPheromone(double additionalPheromone)
        {
            mPheromone += additionalPheromone;

            // keine negativen Pheromonwerte zulassen
            if (mPheromone < 0)
            {
                mPheromone = 0;
            }
        }

        public void getPoints(out CTSPPoint tspPoint1, out CTSPPoint tspPoint2)
        {
            tspPoint1 = mTSPPoint1;
            tspPoint2 = mTSPPoint2;
        }
    }
}
