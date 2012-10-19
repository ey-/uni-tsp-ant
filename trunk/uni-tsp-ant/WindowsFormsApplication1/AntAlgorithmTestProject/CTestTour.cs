using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    [TestClass]
    public class CTestTour
    {
        protected CTSPPoint TEST_POINT_1 = new CTSPPoint(0, 0, "Point1");
        protected CTSPPoint TEST_POINT_2 = new CTSPPoint(10, 0, "Point2");
        protected CTSPPoint TEST_POINT_3 = new CTSPPoint(10, 15.5f, "Point3");

        protected const float DISTANCE_1_TO_2 = 10f;
        protected const float DISTANCE_2_TO_3 = 15.5f;
        protected const float DISTANCE_TOTAL = DISTANCE_1_TO_2 + DISTANCE_2_TO_3;

        [TestInitialize]
        public void testInitialize()
        {
            CTSPPointList.getInstance().removeAll();
            CConnectionList.getInstance().removeAll();

            CTSPPointList.getInstance().addPoint(TEST_POINT_1);
            CTSPPointList.getInstance().addPoint(TEST_POINT_2);
            CTSPPointList.getInstance().addPoint(TEST_POINT_3);

            CConnectionList.getInstance().generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);
        }

        [TestMethod]
        public void testAdding()
        {
            CTour tour = new CTour();

            tour.addPoint(TEST_POINT_1);
            Assert.IsTrue(tour.getListLength() == 1);
            Assert.IsTrue(tour.getTourLength() == 0);

            tour.addPoint(TEST_POINT_2);
            Assert.IsTrue(tour.getListLength() == 2);
            Assert.IsTrue(tour.getTourLength() == DISTANCE_1_TO_2);

            tour.addPoint(TEST_POINT_3);
            Assert.IsTrue(tour.getListLength() == 3);
            Assert.IsTrue(tour.getTourLength() == DISTANCE_TOTAL);
        }

        [TestMethod]
        public void testGetPoints()
        {
            CTour tour = new CTour();

            tour.addPoint(TEST_POINT_1);
            tour.addPoint(TEST_POINT_2);
            tour.addPoint(TEST_POINT_3);

            CTSPPoint point1 = tour.getPoint(0);
            Assert.AreSame(point1, TEST_POINT_1);

            CTSPPoint point2 = tour.getPoint(1);
            Assert.AreSame(point2, TEST_POINT_2);

            CTSPPoint point3 = tour.getPoint(2);
            Assert.AreSame(point3, TEST_POINT_3);
        }
    }
}
