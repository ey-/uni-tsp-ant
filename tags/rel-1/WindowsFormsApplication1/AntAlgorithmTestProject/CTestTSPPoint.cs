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
        const float X_TEST_VALUE_1 = 25.03f;
        const float X_TEST_VALUE_2 = float.MaxValue;

        const float Y_TEST_VALUE_1 = -400.903f;
        const float Y_TEST_VALUE_2 = float.MinValue;

        const string TEST_LABEL = "LabelSet";

        [TestMethod]
        public void constructorTest()
        {
            CTSPPoint defaultConstrutor = new CTSPPoint();
            testAPoint(defaultConstrutor, 0, 0, "");

            CTSPPoint defaultConstructorLabeled = new CTSPPoint(TEST_LABEL);
            testAPoint(defaultConstructorLabeled, 0, 0, TEST_LABEL);

            CTSPPoint specificConstrutorCoordOnly = new CTSPPoint(X_TEST_VALUE_1, Y_TEST_VALUE_1);
            testAPoint(specificConstrutorCoordOnly, X_TEST_VALUE_1, Y_TEST_VALUE_1, "");

            CTSPPoint specificConstrutor = new CTSPPoint(X_TEST_VALUE_2, Y_TEST_VALUE_2, TEST_LABEL);
            testAPoint(specificConstrutor, X_TEST_VALUE_2, Y_TEST_VALUE_2, TEST_LABEL);
        }

        protected void testAPoint(CTSPPoint point, float expectedX, float expectedY, string expectedLabel)
        {
            Assert.IsTrue(point.x == expectedX, "X-Koordinate von CTSPPoint falsch");
            Assert.IsTrue(point.y == expectedY, "Y-Koordinate von CTSPPoint falsch");
            Assert.IsTrue(point.getLabel() == expectedLabel, "Label von CTSPPoint falsch");
        }
    }
}
