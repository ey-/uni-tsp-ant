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
        protected CTSPLibFileParser.E_EdgeWeightType mDistanceCalculation;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="tspPoint1">Punkt 1 der Verbindung</param>
        /// <param name="tspPoint2">Punkt 2 der Verbindung</param>
        /// <param name="distanceCalculation">Gibt an auf welche Art die Entfernung zwischen den Punkten berechnet werden soll</param>
        /// <param name="initialPheromone">Pheromon das die Verbindung von Beginn an haben soll</param>
        public CConnection(CTSPPoint tspPoint1, CTSPPoint tspPoint2, CTSPLibFileParser.E_EdgeWeightType distanceCalculation, double initialPheromone = 0)
        {
            mTSPPoint1 = tspPoint1;
            mTSPPoint2 = tspPoint2;
            mDistanceCalculation = distanceCalculation;

            if (initialPheromone < 0)
                mPheromone = 0;
            else
                mPheromone = initialPheromone;

            calculateDistance();
        }

        public CConnection(CTSPPoint tspPoint1, CTSPPoint tspPoint2, double distance, double initialPheromone = 0)
        {
            mDistanceCalculation = CTSPLibFileParser.E_EdgeWeightType.E_EXPLICIT;

            mTSPPoint1 = tspPoint1;
            mTSPPoint2 = tspPoint2;

            mDistance = distance;

            if (initialPheromone < 0)
                mPheromone = 0;
            else
                mPheromone = initialPheromone;
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
        protected void calculateDistance()
        {
            switch (mDistanceCalculation)
            {
                case CTSPLibFileParser.E_EdgeWeightType.E_EUC_2D:
                    {
                        double deltaX = (mTSPPoint1.x - mTSPPoint2.x);
                        double deltaY = (mTSPPoint1.y - mTSPPoint2.y);
                        mDistance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                        break;
                    }
                case CTSPLibFileParser.E_EdgeWeightType.E_CEIL_2D:
                    {
                        double deltaX = (mTSPPoint1.x - mTSPPoint2.x);
                        double deltaY = (mTSPPoint1.y - mTSPPoint2.y);
                        mDistance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                        mDistance = Math.Round(mDistance, MidpointRounding.AwayFromZero);
                        break;
                    }
                case CTSPLibFileParser.E_EdgeWeightType.E_GEO:
                    {
                        double latititudePoint1 = calcualteDegree(mTSPPoint1.x);
                        double longititudePoint1 = calcualteDegree(mTSPPoint1.y);
                        double latititudePoint2 = calcualteDegree(mTSPPoint2.x);
                        double longititudePoint2 = calcualteDegree(mTSPPoint2.y);

                        double q1 = Math.Cos(longititudePoint1 - longititudePoint2);
                        double q2 = Math.Cos(latititudePoint1 - latititudePoint2);
                        double q3 = Math.Cos(latititudePoint1 + latititudePoint2);
                        mDistance = (int)(6378.388 * Math.Acos(0.5 * ((1.0 + q1) * q2 - (1.0 - q1) * q3)) + 1.0);
                        break;
                    }
                case CTSPLibFileParser.E_EdgeWeightType.E_ATT:
                    {
                        double deltaX = (mTSPPoint1.x - mTSPPoint2.x);
                        double deltaY = (mTSPPoint1.y - mTSPPoint2.y);

                        double rij = Math.Sqrt((deltaX * deltaX + deltaY * deltaY) / 10.0);
                        double tij = Math.Abs(rij);

                        mDistance = tij;
                        if (tij < rij)
                            mDistance = tij + 1.0;
                        break;
                    }
                default:
                    // wir machen nichts .. sollten wir vielleich eine Fehlermeldung ausgeben?
                    break;
            }
        }

        /// <summary>
        /// Längen-/Breitengrad berechnen lassen
        /// </summary>
        /// <param name="coordinate">Koordiante im Format 45.3 = 45°3'</param>
        /// <returns>Entsprechender Grad der Koorinate</returns>
        protected double calcualteDegree(double coordinate)
        {
            double deg = Math.Abs(coordinate);
            double min = coordinate - deg;

            return Math.PI * (deg + 5.0 * min / 3.0) / 180.0;
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
