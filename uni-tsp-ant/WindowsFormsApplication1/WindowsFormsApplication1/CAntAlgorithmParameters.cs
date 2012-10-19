using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class CAntAlgorithmParameters
    {
        public float initialPheromone;
        public float pheromoneUpdate;
        public float evaporationFactor;
        public float pheromoneParameter;
        public float localInformation;
        public int numberAnts;
        public int numberMaxIterations;
        public CTour optTour;

        protected static CAntAlgorithmParameters mInstance = new CAntAlgorithmParameters();

        protected CAntAlgorithmParameters()
        {}

        public static CAntAlgorithmParameters getInstance()
        {
            return mInstance;
        }
    }
}
