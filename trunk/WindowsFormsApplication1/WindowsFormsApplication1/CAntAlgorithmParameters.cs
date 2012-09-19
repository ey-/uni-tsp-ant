﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CAntAlgorithmParameters
    {
        public double initialPheromone;
        public double pheromoneUpdate;
        public double evaporationFactor;
        public double pheromoneParameter;
        public double localInformation;
        public int numberAnts;
        public int numberMaxIterations;

        protected static CAntAlgorithmParameters mInstance = new CAntAlgorithmParameters();

        protected CAntAlgorithmParameters()
        {}

        public static CAntAlgorithmParameters getInstance()
        {
            return mInstance;
        }
    }
}
