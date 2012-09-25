using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CAntAlgorithem
    {

        public static CTSPPoint decisionNextPoint( CTSPPoint currentPoint, CTSPPointList listOfPointsToTravel)
        {
            CTSPPoint nextPointToTravel = null;
            double dSumChanceValue = 0;
            double dChanceValue = 0;
            double actuelbest = 0;
            CAntAlgorithmParameters parameters = CAntAlgorithmParameters.getInstance();
            
            foreach (CTSPPoint i in listOfPointsToTravel)
            {


                dSumChanceValue = Math.Pow((1 / CConnectionList.getInstance().getConnection(currentPoint, i).getDistance()), parameters.pheromoneParameter);

            }


            foreach (CTSPPoint i in listOfPointsToTravel)
            {

                dChanceValue = ((Math.Pow(CConnectionList.getInstance().getConnection(currentPoint, i).getPheromone(), parameters.pheromoneParameter)) * (Math.Pow((1 / CConnectionList.getInstance().getConnection(currentPoint, i).getDistance()), parameters.localInformation)));
                if (  ((dChanceValue / dSumChanceValue)  > actuelbest)  )
                {


                    actuelbest = CConnectionList.getInstance().getConnection(currentPoint, i).getDistance();
                    nextPointToTravel = i;
                    
                }

            }

            return nextPointToTravel;
        }
    }
}
