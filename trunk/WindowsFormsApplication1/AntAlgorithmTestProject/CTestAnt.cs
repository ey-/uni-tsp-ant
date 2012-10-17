using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    [TestClass]
    public class CTestAnt
    {
        const float POINT1_X = 5.5f;
        const float POINT1_Y = 5f;

        const float POINT2_X = 5.5f;
        const float POINT2_Y = 10.5f;

        const float POINT3_X = 5.5f;
        const float POINT3_Y = 10.5f;

        CTSPPoint TEST_POINT_1 = new CTSPPoint(POINT1_X, POINT1_Y, "POINT 1");
        CTSPPoint TEST_POINT_2 = new CTSPPoint(POINT2_X, POINT2_Y, "POINT 2");
        CTSPPoint TEST_POINT_3 = new CTSPPoint(POINT3_X, POINT3_Y, "POINT 3");

        [TestInitialize]
        public void TestMethod1()
        {
            CTSPPointList.getInstance().removeAll();

            CTSPPointList.getInstance().addPoint(TEST_POINT_1);
            CTSPPointList.getInstance().addPoint(TEST_POINT_2);
            CTSPPointList.getInstance().addPoint(TEST_POINT_3);
        }

        public void TourTest()
        {
             CTSPPointList Testlist =  CTSPPointList.getInstance().copy();
             CAnt Tourtestant = new CAnt(Testlist, TEST_POINT_1);
             Assert.AreSame(TEST_POINT_1 , Tourtestant.GetTour().GetPoint(0));
             Tourtestant.CurrentPoint = TEST_POINT_2;
             Assert.AreSame(TEST_POINT_2, Tourtestant.GetTour().GetPoint(1));
             Tourtestant.CurrentPoint = TEST_POINT_3;
             Assert.AreSame(TEST_POINT_3, Tourtestant.GetTour().GetPoint(2));
        }

        [TestMethod]
        public void construtorTest()
        {
            CAnt testAnt = new CAnt(CTSPPointList.getInstance().copy(), TEST_POINT_1);

            Assert.AreSame(testAnt.CurrentPoint, TEST_POINT_1);

            foreach (CTSPPoint point in testAnt.PointsToVisit)
            {
                Assert.AreSame(CTSPPointList.getInstance().getPoint(point.getLabel()), point);
            }
        }
    }
}
