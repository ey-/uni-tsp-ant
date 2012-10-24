using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class CAntAlgorithm
    {

        private CAnt[] arrayOfAnts = new CAnt[CAntAlgorithmParameters.getInstance().numberAnts];
        private RenderWindow mRenderWindow;

        private CConnectionList mConnectionList = CConnectionList.getInstance();
        private CAntAlgorithmParameters mAlgorithmParam = CAntAlgorithmParameters.getInstance();

        private int mMaxIterations = 0;
        private float mPheromoneParam = 0f;
        private float mPhermomoneUpdate = 0f;
        private float mInitialPheromone = 0f;
        private float mEvaporationFactor = 0f;
        private CTour mOptTour = null;
        
        public CAntAlgorithm(RenderWindow renderWindow)
        {
            mRenderWindow = renderWindow;

            mMaxIterations = mAlgorithmParam.numberMaxIterations;
            mPheromoneParam = mAlgorithmParam.pheromoneParameter;
            mPhermomoneUpdate = mAlgorithmParam.pheromoneUpdate;
            mInitialPheromone = mAlgorithmParam.initialPheromone;
            mEvaporationFactor = mAlgorithmParam.evaporationFactor;
            mOptTour = mAlgorithmParam.optTour;
        }

        public void startAlgorithm()
        {
            CProgressManager.setStepsIteration(mMaxIterations);

            mConnectionList.SetInitialPheromone(mInitialPheromone);
            
            for (var iteration = 0; iteration < mMaxIterations; iteration++)
            {
                NewIteration();

                // haben wir eine bessere Lösung als die Optimale Lösung gefunden?
                // dann können wir abbrechen
                /*if (optTour != null) 
                {
                    CTour bestGlobalTour = CIterationList.getInstance().getBestGlobalTour();
                    if (bestGlobalTour != null)
                    {
                        if ((optTour.getTourLength() <= bestGlobalTour.getTourLength()))
                        {
                            break;
                        }
                    }
                }*/

                // Pheromon-Update
                //--------------------------------
                // Dazu durch alle Touren von allen Ameisen nachgehen und für jede Verbindung die 
                // Pheromonwerte neu berechnen
                // Formel: delta(t ij) = Q / (distance ij)
                foreach (CAnt ant in arrayOfAnts)
                {
                    CTour antTour = ant.GetTour();

                    // wir fangen mit Index 1 an! Damit die Punkte der Verbindungen mit den Indizies 
                    // index -1 und index geholt werden können
                    for (int pointIndex = 1; pointIndex < antTour.getListLength(); pointIndex++)
                    {
                        CTSPPoint fromPoint = antTour.getPoint(pointIndex - 1);
                        CTSPPoint toPoint = antTour.getPoint(pointIndex);

                        CConnection tourConnection = mConnectionList.getConnection(fromPoint, toPoint);
                        tourConnection.addPheromone(mPhermomoneUpdate);
                    }
                }

                mRenderWindow.debugTour = arrayOfAnts[0].GetTour();

                // Evaporation (verdunstung)
                //--------------------------------
                // Dazu iterieren wir durch alle Verbindungen und lassen das Pheromon verdunsten
                foreach (CConnection connection in mConnectionList)
                {
                    connection.evaporate(mEvaporationFactor);
                }


                CIterationList.getInstance().refreshStatisticNumbers();
                mRenderWindow.Invoke(mRenderWindow.refreshDelegate);
                CProgressManager.stepDone();

                Debug.WriteLine("Iteration done: " + (iteration + 1));
                Debug.WriteLine(mConnectionList.ToString());
            }
        }

        public CTSPPoint decisionNextPoint(CTSPPoint currentPoint, CTSPPointList listOfPointsToTravel)
        {
            // Formel:
            //          (t ij) ^ alpha * (n ij) ^ beta
            // p ij = ----------------------------------
            //        Sum l( (t il) ^ alpha * (n il) ^ beta )
            //
            // i = Startpunkt
            // j = Zielpunkt
            // l = ein Punkt von den noch zu Besuchenden Punkten

            // zuerst berechnen wir mal den Divisor der Formel, da dieser einmal pro Bewegung berechnet werden muss
            double sumFactorOfPossibleConnections = calculateSumFactorOfPossibleConnections(currentPoint, listOfPointsToTravel);
            
            // jetzt berechnen wir die probability p von allen Verbindungen und bestimmen die beste
            double bestProbability = 0;
            CTSPPoint bestTarget = null;

            foreach (CTSPPoint possibleTarget in listOfPointsToTravel)
            {
                CConnection connection = mConnectionList.getConnection(currentPoint, possibleTarget);

                // von diesem Punkt erstmal die Werte für (t ij) ^ alpha und (n ij) ^ beta berechnen.
                // Damit haben wir dann die Werte für den Dividenten
                double t_ij = calculatePheromoneTrail(connection);
                double n_ij = calculateLocalInformation(connection);

                // die probability berechnen
                double probability = (t_ij * n_ij) / sumFactorOfPossibleConnections;

                // die der probability-Wert höher besser?
                if (probability > bestProbability)
                {
                    // dann merken wir uns diesen Punkt
                    bestProbability = probability;
                    bestTarget = possibleTarget;
                }
            }

            return bestTarget;
        }

        // Entspricht in der Formel:
        // Sum l( (t il) ^ alpha * (n il) ^ beta )
        private double calculateSumFactorOfPossibleConnections(CTSPPoint currentPoint, CTSPPointList listOfPointsToTravel)
        {
            double sumFactorOfPossibleConnections = 0;
            foreach (CTSPPoint possiblePoint in listOfPointsToTravel)
            {
                CConnection connection = mConnectionList.getConnection(currentPoint, possiblePoint);

                double n_il = calculateLocalInformation(connection);
                double t_il = calculatePheromoneTrail(connection);

                sumFactorOfPossibleConnections += n_il * t_il;
            }
            return sumFactorOfPossibleConnections;
        }

        // entspricht in der Formel
        // (n ij) ^ beta
        public double calculateLocalInformation(CConnection connection)
        {
            float connectionDistance = connection.getDistance();
            return Math.Pow((1 / connectionDistance), mAlgorithmParam.localInformation);
        }

        // entspricht in der Formel
        // (t ij) ^ alpha
        public double calculatePheromoneTrail(CConnection connection)
        {
            float connectionPheromone = connection.getPheromone();
            return Math.Pow(connectionPheromone, mAlgorithmParam.pheromoneParameter);
        }

        public void CreateNewAnts()
        {
            Random random = new Random();
            int numPoints = CTSPPointList.getInstance().length();

            for (int i = 0; i < arrayOfAnts.Length; i++)
            {
                int randomPointIndex = random.Next(numPoints);
                CTSPPoint randomPoint = CTSPPointList.getInstance().getPoint(randomPointIndex);
                arrayOfAnts[i] = new CAnt(randomPoint);
            }
        }

        public void NewIteration()
        {
            CreateNewAnts();

            // Ameisen laufen lassen
            for (var i = 0; i < CTSPPointList.getInstance().length(); i++)
            {
                foreach (CAnt ant in arrayOfAnts)
                {
                    CTSPPoint nextPoint = decisionNextPoint(ant.CurrentPoint, ant.PointsToVisit);

                    if (nextPoint == null)
                        nextPoint = ant.GetTour().getPoint(0);

                    ant.CurrentPoint = nextPoint;
                }
            }

            // kürzeste Tour ermitteln und die durchschnittliche Länge 
            CTour shortestTour = new CTour();
            double averageTourLength = 0;
            foreach (CAnt ant in arrayOfAnts)
            {
                averageTourLength += ant.GetTour().getTourLength() / arrayOfAnts.Length;  
                if ((ant.GetTour().getTourLength() < shortestTour.getTourLength()) || (shortestTour.getTourLength() == 0))
                    shortestTour = ant.GetTour();

            }
            
            Debug.WriteLine(shortestTour.getTourLength());

            // Iteration in die Liste zurückspeichern
            CIterationList.getInstance().Add(new CIteration(shortestTour, averageTourLength));
        }
    }
}
