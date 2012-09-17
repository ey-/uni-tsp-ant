using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    [TestClass]
    public class CTestTSPPoint
    {
        [TestMethod]
        public void constructorTest()
        {
            CTSPPoint testPoint = new CTSPPoint("");

            testAPoint(testPoint, 0, 0, "");
        }

        protected void testAPoint(CTSPPoint point, int expectedX, int expectedY, string expectedLabel)
        {
            Assert.IsTrue(point.x == expectedX, "X-Koordinate von CTSPPoint falsch");
            Assert.IsTrue(point.y == expectedY, "Y-Koordinate von CTSPPoint falsch");
            Assert.IsTrue(point.getLabel() == expectedLabel, "Label von CTSPPoint falsch");
        }
    }
}
