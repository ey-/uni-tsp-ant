using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class CAntAlgorithm
    {

        private CAnt[] arrayOfAnts = new CAnt[CAntAlgorithmParameters.getInstance().numberAnts];
        private RenderWindow mRenderWindow;
        private TextBox mItertationsTextbox;

        private CConnectionList mConnectionList = CConnectionList.getInstance();
        private CAntAlgorithmParameters mAlgorithmParam = CAntAlgorithmParameters.getInstance();

        private int mMaxIterations = 0;
        private float mPheromoneParam = 0f;
        private float mPhermomoneUpdate = 0f;
        private float mInitialPheromone = 0f;
        private float mEvaporationFactor = 0f;
        private CTour mOptTour = null;
        
        public CAntAlgorithm(RenderWindow renderWindow, TextBox iterationTextbox)
        {
            mRenderWindow = renderWindow;
            mItertationsTextbox = iterationTextbox;

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

            mItertationsTextbox.Invoke(new Action(delegate()
            {
                mItertationsTextbox.Text = "0/" + mMaxIterations;
            }));

            DateTime startTime = DateTime.Now;

            int iteration = 0;
            bool bStopAlgorithm = false;
            while ((iteration < mMaxIterations) && (bStopAlgorithm == false))
            {
                NewIteration();

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

                mItertationsTextbox.Invoke(new Action(delegate()
                    {
                       mItertationsTextbox.Text = (iteration +1) + "/" + mMaxIterations;
                    }));

                Debug.WriteLine("Iteration done: " + (iteration + 1));


                // Stopkriterien testen
                bStopAlgorithm = checkStopCriteria();

                // Iterationszähler erhöhen
                iteration++;
            }

            Debug.WriteLine("Dauer: " + (DateTime.Now - startTime).TotalSeconds + " sek");
        }

        private bool checkStopCriteria()
        {
            CTour bestGlobalTour = CIterationList.getInstance().getBestGlobalTour();

            // haben wir eine bessere Lösung als die Optimale Lösung gefunden?
            // dann können wir abbrechen
            if (mOptTour != null)
            {
                if (bestGlobalTour != null)
                {
                    if ((bestGlobalTour.getTourLength() <= mOptTour.getTourLength()) && (mAlgorithmParam.bBestTourStop == true))
                    {
                        return true;
                    }
                }
            }

            // Haben wir den Schwellenwert unterschritten?
            if (bestGlobalTour != null)
            {
                if ((bestGlobalTour.getTourLength() <= mAlgorithmParam.iLimitStop) && (mAlgorithmParam.bLimitStop == true))
                {
                    return true;
                }
            }
            return false;
        }

        public CTSPPoint decisionNextPoint(CTSPPoint currentPoint, CTSPPoint startPoint, CTSPPointList listOfPointsToTravel)
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
            double sumFactorOfPossibleConnections = calculateSumFactorOfPossibleConnections(currentPoint, startPoint, listOfPointsToTravel);
            
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
        private double calculateSumFactorOfPossibleConnections(CTSPPoint currentPoint, CTSPPoint startPoint, CTSPPointList listOfPointsToTravel)
        {
            double sumFactorOfPossibleConnections = 0;
            foreach (CTSPPoint possiblePoint in listOfPointsToTravel)
            {
                CConnection connection = mConnectionList.getConnection(currentPoint, possiblePoint);

                double n_il = calculateLocalInformation(connection);
                double t_il = calculatePheromoneTrail(connection);

                sumFactorOfPossibleConnections += n_il * t_il;
            }

            // wir müssen natürlich auch den Weg zurück zum Startpunkt beachten, der darf aber nicht in der 
            // Liste der noch zu besuchenden Punkte stehen.
            // Daher müssen wir diesen nochmal explizit am ende einbeziehen
            CConnection startConnection = mConnectionList.getConnection(startPoint, currentPoint);
            if (startConnection != null)
            {
                double start_n_il = calculateLocalInformation(startConnection);
                double start_t_il = calculatePheromoneTrail(startConnection);

                sumFactorOfPossibleConnections += start_n_il * start_t_il;
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

        public void handleAnt(object antObject)
        {
            CAnt ant = (CAnt)antObject;

            // Ameisen laufen lassen
            for (var i = 0; i < CTSPPointList.getInstance().length(); i++)
            {
                CTSPPoint nextPoint = decisionNextPoint(ant.CurrentPoint, ant.GetTour().getPoint(0), ant.PointsToVisit);

                if (nextPoint == null)
                    nextPoint = ant.GetTour().getPoint(0);

                ant.CurrentPoint = nextPoint;
            }
        }

        public void NewIteration()
        {
            CreateNewAnts();

            List<Thread> antThreadList = new List<Thread>();

            // Ameisen laufen lassen
            foreach (CAnt ant in arrayOfAnts)
            {
                Thread antThread = new Thread(new ParameterizedThreadStart(this.handleAnt));
                antThreadList.Add(antThread);

                antThread.Name = "AntThread" + antThreadList.Count.ToString();
                antThread.Priority = ThreadPriority.Highest;

                antThread.Start(ant);
            }

            // Prüfen ob alle Threads fertig sind
            bool bAllThreadsFinished = false;
            while (bAllThreadsFinished == false)
            {
                Thread.Sleep(1);
                bAllThreadsFinished = true;

                foreach (Thread antThread in antThreadList)
                {
                    if (antThread.ThreadState == System.Threading.ThreadState.Running)
                    {
                        bAllThreadsFinished = false;
                    }
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
