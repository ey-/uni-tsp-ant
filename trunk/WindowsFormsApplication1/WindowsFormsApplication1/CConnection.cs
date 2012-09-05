using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CConnection
    {
        protected int mCityIndex1;
        protected int mCityIndex2;
        protected double mPheromone;
        protected double mDistance;


        public CConnection(int cityIndex1, int cityIndex2, double initialPheromone = 0)
        { 
            mCityIndex1 = cityIndex1;
            mCityIndex2 = cityIndex2;
            mPheromone = initialPheromone;

            CTSPPoint city1 = CTSPPointList.getInstance().getPoint(cityIndex1);
            CTSPPoint city2 = CTSPPointList.getInstance().getPoint(cityIndex2);

            double deltaX = (city1.x - city2.x);
            double deltaY = (city1.y - city2.y);
            mDistance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public bool hasCity(int cityIndex)
        {
            if (cityIndex == mCityIndex1) return true;
            if (cityIndex == mCityIndex2) return true;

            return false;
        }

        public double getDistance()
        {
            return mDistance;
        }

        public double getPheromone()
        {
            return mPheromone;
        }

        public void addPheromone(double additionalPheromone)
        {
            mPheromone += additionalPheromone;
        }
    }
}
