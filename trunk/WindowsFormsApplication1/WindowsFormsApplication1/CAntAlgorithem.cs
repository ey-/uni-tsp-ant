using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CAntAlgorithm
    {

        private CAnt[] arrayOfAnts = new CAnt[CAntAlgorithmParameters.getInstance().numberAnts];

        public CAntAlgorithm()
        {
            var maxIteration = CAntAlgorithmParameters.getInstance().numberMaxIterations;

            var pheromoneParam = CAntAlgorithmParameters.getInstance().pheromoneParameter;
            var phermomoneUpdate = CAntAlgorithmParameters.getInstance().pheromoneUpdate;
            var initialPheromone = CAntAlgorithmParameters.getInstance().initialPheromone;
            var evaporationFactor = CAntAlgorithmParameters.getInstance().evaporationFactor;
            var optTour = CAntAlgorithmParameters.getInstance().optTour;

            CConnectionList.getInstance().SetInitialPheromone(initialPheromone);

            for (var i = maxIteration; i >= 0; i--)
            {
                NewIteration();

                
                if (optTour != null && optTour.Length <= CIterationList.GlobalBestTour.Length)
                break;


                //Pheromone Evaporization
                foreach (CConnection conn in CConnectionList.getInstance())
                    conn.SetPheromone(conn.getPheromone() - (conn.getPheromone() * evaporationFactor));
            }
        }

        public static CTSPPoint decisionNextPoint(CTSPPoint currentPoint, CTSPPointList listOfPointsToTravel)
        {
            CTSPPoint nextPointToTravel = currentPoint;
            float dSumChanceValue = 0;
            float dChanceValue = 0;
            float currentBestConnectionRatio = 0;
            CAntAlgorithmParameters parameters = CAntAlgorithmParameters.getInstance();

            foreach (CTSPPoint i in listOfPointsToTravel)
            {
                dSumChanceValue = (float)Math.Pow((1 / CConnectionList.getInstance().getConnection(currentPoint, i).getDistance()), parameters.pheromoneParameter);
            }


            foreach (CTSPPoint point in listOfPointsToTravel)
            {
                dChanceValue = (float)((Math.Pow(CConnectionList.getInstance().getConnection(currentPoint, point).getPheromone(), parameters.pheromoneParameter)) * (Math.Pow((1 / CConnectionList.getInstance().getConnection(currentPoint, point).getDistance()), parameters.localInformation)));
                if (((dChanceValue / dSumChanceValue) > currentBestConnectionRatio))
                {
                    currentBestConnectionRatio = CConnectionList.getInstance().getConnection(currentPoint, point).getDistance();
                    nextPointToTravel = point;
                }
            }

            return nextPointToTravel;
        }

        public void CreateNewAnts()
        {
            for (int i = 0; i < arrayOfAnts.Length; i++)
                arrayOfAnts[i] = new CAnt(CTSPPointList.getInstance(),
                                            CTSPPointList.getInstance().getPoint(
                                                (new Random()).Next(CTSPPointList.getInstance().length())
                                            )
                                          );
        }

        public void NewIteration()
        {
            CreateNewAnts();
            for (var i = 0; i < CTSPPointList.getInstance().length(); i++)
            {
                foreach (CAnt ant in arrayOfAnts)
                {
                    var nextPoint = decisionNextPoint(ant.CurrentPoint, ant.PointsToVisit);
                    if (nextPoint == null)
                        nextPoint = ant.GetTour().GetPoint(0);
                    ant.CurrentPoint = nextPoint;
                }
            }

            CTour shortestTour = new CTour();
            double averageTourLength = 0;
            foreach (CAnt ant in arrayOfAnts)
            {
                averageTourLength += ant.GetTour().Length / arrayOfAnts.Length;  
                if (shortestTour.Length > ant.GetTour().Length || shortestTour.Length == 0)
                    shortestTour = ant.GetTour();

            }
            CIterationList.Add(new CIteration(shortestTour, averageTourLength));
        }
    }
}
