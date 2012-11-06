using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    [TestClass]
    public class CTestIteration
    {
        protected CTSPPoint TEST_POINT_1 = new CTSPPoint("Point1");
        protected CTSPPoint TEST_POINT_2 = new CTSPPoint("Point2");
        protected CTSPPoint TEST_POINT_3 = new CTSPPoint("Point3");

        protected CTour TEST_TOUR = null;
        protected float TEST_AVERAGE_LENGTH = 23.3f;

        public CTestIteration()
        {
            CTSPPointList.getInstance().removeAll();
            CConnectionList.getInstance().removeAll();

            CTSPPointList.getInstance().addPoint(TEST_POINT_1);
            CTSPPointList.getInstance().addPoint(TEST_POINT_2);
            CTSPPointList.getInstance().addPoint(TEST_POINT_3);

            CConnectionList.getInstance().generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);

            TEST_TOUR = new CTour();
            TEST_TOUR.addPoint(TEST_POINT_1);
            TEST_TOUR.addPoint(TEST_POINT_2);
            TEST_TOUR.addPoint(TEST_POINT_3);
        }
        
        [TestMethod]
        public void testConstructor()
        {
            CIteration iteration = new CIteration(TEST_TOUR, TEST_AVERAGE_LENGTH);
            Assert.AreSame(TEST_TOUR, iteration.ShortestTour);
            Assert.IsTrue(iteration.AverageTourLength == TEST_AVERAGE_LENGTH);
        }
    }
}
