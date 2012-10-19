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
        protected float mPheromone;
        protected float mDistance;
        static protected CTSPLibFileParser.E_EDGE_WEIGHT_TYPE mDistanceCalculation;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="tspPoint1">Punkt 1 der Verbindung</param>
        /// <param name="tspPoint2">Punkt 2 der Verbindung</param>
        /// <param name="distanceCalculation">Gibt an auf welche Art die Entfernung zwischen den Punkten berechnet werden soll</param>
        /// <param name="initialPheromone">Pheromon das die Verbindung von Beginn an haben soll</param>
        public CConnection(CTSPPoint tspPoint1, CTSPPoint tspPoint2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE distanceCalculation, float initialPheromone = 0)
        {
            mTSPPoint1 = tspPoint1;
            mTSPPoint2 = tspPoint2;
            mDistanceCalculation = distanceCalculation;

            if (initialPheromone < 0)
                mPheromone = 0;
            else
                mPheromone = initialPheromone;

            calculateDistance();

            // es wurde eine Verbindung erzeugt .. also ein Schritt erfolgreich abgearbeteitet
            CProgressManager.stepDone();
        }

        public CConnection(CTSPPoint tspPoint1, CTSPPoint tspPoint2, float distance, float initialPheromone = 0)
        {
            mDistanceCalculation = CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EXPLICIT;

            mTSPPoint1 = tspPoint1;
            mTSPPoint2 = tspPoint2;

            mDistance = distance;

            if (initialPheromone < 0)
                mPheromone = 0;
            else
                mPheromone = initialPheromone;

            // es wurde eine Verbindung erzeugt .. also ein Schritt erfolgreich abgearbeteitet
            CProgressManager.stepDone();
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

        public bool containsPoint(CTSPPoint tspPoint1, CTSPPoint tspPoint2)
        {
            if (mTSPPoint1 == tspPoint1)
            { 
                if (mTSPPoint2 == tspPoint2)
                {
                    return true;
                }
            }
            else if (mTSPPoint1 == tspPoint2)
            {
                if (mTSPPoint2 == tspPoint1)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// gibt die Entfernung der Punkte zurück
        /// </summary>
        /// <returns></returns>
        public float getDistance()
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
                case CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D:
                    {
                        float deltaX = (mTSPPoint1.x - mTSPPoint2.x);
                        float deltaY = (mTSPPoint1.y - mTSPPoint2.y);
                        mDistance = (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                        break;
                    }
                case CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_CEIL_2D:
                    {
                        float deltaX = (mTSPPoint1.x - mTSPPoint2.x);
                        float deltaY = (mTSPPoint1.y - mTSPPoint2.y);
                        mDistance = (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                        mDistance = (float)Math.Round(mDistance, MidpointRounding.AwayFromZero);
                        break;
                    }
                case CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_GEO:
                    {
                        float latititudePoint1 = calcualteDegree(mTSPPoint1.x);
                        float longititudePoint1 = calcualteDegree(mTSPPoint1.y);
                        float latititudePoint2 = calcualteDegree(mTSPPoint2.x);
                        float longititudePoint2 = calcualteDegree(mTSPPoint2.y);

                        float q1 = (float)Math.Cos(longititudePoint1 - longititudePoint2);
                        float q2 = (float)Math.Cos(latititudePoint1 - latititudePoint2);
                        float q3 = (float)Math.Cos(latititudePoint1 + latititudePoint2);
                        mDistance = (int)(6378.388 * Math.Acos(0.5 * ((1.0 + q1) * q2 - (1.0 - q1) * q3)) + 1.0);
                        break;
                    }
                case CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_ATT:
                    {
                        float deltaX = (mTSPPoint1.x - mTSPPoint2.x);
                        float deltaY = (mTSPPoint1.y - mTSPPoint2.y);

                        float rij = (float)Math.Sqrt((deltaX * deltaX + deltaY * deltaY) / 10.0);
                        float tij = (float)Math.Abs(rij);

                        mDistance = tij;
                        if (tij < rij)
                            mDistance = tij + 1.0f;
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
        protected float calcualteDegree(float coordinate)
        {
            float deg = Math.Abs(coordinate);
            float min = coordinate - deg;

            return (float)Math.PI * (deg + 5.0f * min / 3.0f) / 180.0f;
        }

        /// <summary>
        /// holt den aktuellen Pheromon-Wert der Verbindung
        /// </summary>
        /// <returns>Pheromonwert</returns>
        public float getPheromone()
        {
            return mPheromone;
        }
        
        public void addPheromone(float pheromoneUpdateFactor)
        {
            mPheromone += pheromoneUpdateFactor;// / mDistance;
        }

        public void evaporate(float evaporationFactor)
        {
            // Evaporation (verdunstung)
            //--------------------------------
            // Dazu iterieren wir durch alle Verbindungen und berechnen den neuen Pheromonwert.
            // Formel: (t ij)neu = (t ij)alt * p
            // p = Verdunstungsfaktor
            mPheromone *= evaporationFactor;
        }

        public void getPoints(out CTSPPoint tspPoint1, out CTSPPoint tspPoint2)
        {
            tspPoint1 = mTSPPoint1;
            tspPoint2 = mTSPPoint2;
        }

        public void SetPheromone(float pheromone)
        {
            mPheromone = pheromone;
        }
    }
}
