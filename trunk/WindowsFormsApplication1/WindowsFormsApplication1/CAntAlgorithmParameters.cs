using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CAntAlgorithmParameters
    {
        public const float START_INITIAL_PHEROMONE = 10f;
        public const float START_PHEROMONE_UPDATE = 10f;
        public const float START_PHEROMONE_PARAMETER = 1f;
        public const float START_LOCAL_INFORMATION_PARAMETER = 1f;
        public const float START_EVAPORATION = 0.999f;

        public float initialPheromone = START_INITIAL_PHEROMONE;
        public float pheromoneUpdate = START_PHEROMONE_UPDATE;
        public float evaporationFactor = START_EVAPORATION;
        public float pheromoneParameter = START_PHEROMONE_PARAMETER;
        public float localInformation = START_LOCAL_INFORMATION_PARAMETER;
        public int numberAnts = 100;
        public int numberMaxIterations = 100;
        public CTour optTour = null;

        protected static CAntAlgorithmParameters mInstance = new CAntAlgorithmParameters();

        protected CAntAlgorithmParameters()
        {}

        public static CAntAlgorithmParameters getInstance()
        {
            return mInstance;
        }
    }
}
