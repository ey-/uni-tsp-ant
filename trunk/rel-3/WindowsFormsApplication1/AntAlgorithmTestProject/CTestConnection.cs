using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für CTestConnection
    /// </summary>
    [TestClass]
    public class CTestConnection
    {
        const float POINT1_X = 5.5f;
        const float POINT1_Y = 5;

        const float POINT2_X = 5.5f;
        const float POINT2_Y = 10.5f;

        CTSPPoint TEST_POINT_1 = new CTSPPoint(POINT1_X, POINT1_Y, "POINT 1");
        CTSPPoint TEST_POINT_2 = new CTSPPoint(POINT2_X, POINT2_Y, "POINT 2");

        float TEST_CALCULATED_DISTANCE_EUC_2D;
        float TEST_CALCULATED_DISTANCE_CEIL_2D;
        float TEST_CALCULATED_DISTANCE_GEO;
        float TEST_CALCULATED_DISTANCE_ATT;
        const float TEST_EXPLICIT_DISTANCE = 10.5f;
        const float TEST_INITIAL_PHEROMON = 20.5f;
        const float TEST_ADDITIONAL_PHEROMON = 10;
        const float TEST_SUBSTRACT_PHEROMON = -7.5f;

        public CTestConnection()
        { 
            // Distanz berechnen für EUC_2D
            //////////////////////////////////////////////

            float deltaX = (POINT1_X - POINT2_X);
            float deltaY = (POINT1_Y - POINT2_Y);
            TEST_CALCULATED_DISTANCE_EUC_2D = (float)Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            // Distanz berechnen für CEIL_2D
            //////////////////////////////////////////////

            // einfach den Wert von EUC_2d aufrunden
            TEST_CALCULATED_DISTANCE_CEIL_2D = (float)Math.Round(TEST_CALCULATED_DISTANCE_EUC_2D, MidpointRounding.AwayFromZero);

            // Distanz berechen für GEO
            //////////////////////////////////////////////

            // Zuerst Längen und Breitengrad der Punkte bestimmen
            float latititudePoint1 = calcualteDegree(POINT1_X);
            float longititudePoint1 = calcualteDegree(POINT1_Y);
            float latititudePoint2 = calcualteDegree(POINT2_X);
            float longititudePoint2 = calcualteDegree(POINT2_Y);

            float q1 = (float)Math.Cos(longititudePoint1 - longititudePoint2);
            float q2 = (float)Math.Cos(latititudePoint1 - latititudePoint2);
            float q3 = (float)Math.Cos(latititudePoint1 + latititudePoint2);
            TEST_CALCULATED_DISTANCE_GEO = (int)(6378.388 * Math.Acos(0.5 * ((1.0 + q1) * q2 - (1.0 - q1) * q3)) + 1.0);

            // Distanz berechnen für ATT
            //////////////////////////////////////////////

            float rij = (float)Math.Sqrt((deltaX * deltaX + deltaY * deltaY) / 10.0);
            float tij = (float)Math.Abs(rij);

            TEST_CALCULATED_DISTANCE_ATT = tij;
            if (tij < rij)
                TEST_CALCULATED_DISTANCE_ATT = tij + 1.0f;
        }

        protected float calcualteDegree(float coordinate)
        {
            float deg = Math.Abs(coordinate);
            float min = coordinate - deg;

            return (float)Math.PI * (deg + 5.0f * min / 3.0f) / 180.0f;
        }
        
        [TestMethod]
        public void testConstructor()
        {
            CConnection constructor1 = new CConnection(TEST_POINT_1, TEST_POINT_2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);
            testConnectionData(constructor1, TEST_POINT_1, TEST_POINT_2, TEST_CALCULATED_DISTANCE_EUC_2D, 0);

            CConnection constructor2 = new CConnection(TEST_POINT_1, TEST_POINT_2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D, TEST_INITIAL_PHEROMON);
            testConnectionData(constructor2, TEST_POINT_1, TEST_POINT_2, TEST_CALCULATED_DISTANCE_EUC_2D, TEST_INITIAL_PHEROMON);

            CConnection constructor3 = new CConnection(TEST_POINT_1, TEST_POINT_2, TEST_EXPLICIT_DISTANCE);
            testConnectionData(constructor3, TEST_POINT_1, TEST_POINT_2, TEST_EXPLICIT_DISTANCE, 0);

            CConnection constructor4 = new CConnection(TEST_POINT_1, TEST_POINT_2, TEST_EXPLICIT_DISTANCE, TEST_INITIAL_PHEROMON);
            testConnectionData(constructor4, TEST_POINT_1, TEST_POINT_2, TEST_EXPLICIT_DISTANCE, TEST_INITIAL_PHEROMON);
        }

        [TestMethod]
        public void testLengthCalulation()
        {
            CConnection lengthEUC2D = new CConnection(TEST_POINT_1, TEST_POINT_2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);
            Assert.IsTrue(lengthEUC2D.getDistance() == TEST_CALCULATED_DISTANCE_EUC_2D);

            CConnection lengthCEIL2D = new CConnection(TEST_POINT_1, TEST_POINT_2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_CEIL_2D);
            Assert.IsTrue(lengthCEIL2D.getDistance() == TEST_CALCULATED_DISTANCE_CEIL_2D);

            CConnection lengthGEO = new CConnection(TEST_POINT_1, TEST_POINT_2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_GEO);
            Assert.IsTrue(lengthGEO.getDistance() == TEST_CALCULATED_DISTANCE_GEO);

            CConnection lengthATT = new CConnection(TEST_POINT_1, TEST_POINT_2, CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_ATT);
            Assert.IsTrue(lengthATT.getDistance() == TEST_CALCULATED_DISTANCE_ATT);
        }

        [TestMethod]
        public void testPheromonHandling()
        {
            CConnection connection = new CConnection(TEST_POINT_1, TEST_POINT_2, TEST_EXPLICIT_DISTANCE, TEST_INITIAL_PHEROMON);
            Assert.IsTrue(connection.getPheromone() == TEST_INITIAL_PHEROMON);

            connection.addPheromone(TEST_ADDITIONAL_PHEROMON);
            Assert.IsTrue(connection.getPheromone() == (TEST_INITIAL_PHEROMON + TEST_ADDITIONAL_PHEROMON));

            connection.addPheromone(TEST_SUBSTRACT_PHEROMON);
            Assert.IsTrue(connection.getPheromone() == (TEST_INITIAL_PHEROMON + TEST_ADDITIONAL_PHEROMON + TEST_SUBSTRACT_PHEROMON));
        }

        public void testNegativePheromon()
        {
            CConnection connection = new CConnection(TEST_POINT_1, TEST_POINT_2, TEST_EXPLICIT_DISTANCE, TEST_INITIAL_PHEROMON);
            Assert.IsTrue(connection.getPheromone() == TEST_INITIAL_PHEROMON);
        }

        /// <summary>
        /// Tested den Datenbestand einer Verbindung
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="expectedPoint1"></param>
        /// <param name="expectedPoint2"></param>
        /// <param name="expectedDistance"></param>
        /// <param name="expectedPheromon"></param>
        protected void testConnectionData(CConnection connection, CTSPPoint expectedPoint1, CTSPPoint expectedPoint2, float expectedDistance, float expectedPheromon)
        { 
            CTSPPoint testPoint1;
            CTSPPoint testPoint2;
            connection.getPoints(out testPoint1, out testPoint2);

            Assert.AreSame(testPoint1, expectedPoint1);
            Assert.AreSame(testPoint2, expectedPoint2);

            Assert.IsTrue(connection.getDistance() == expectedDistance);
            Assert.IsTrue(connection.getPheromone() == expectedPheromon);
        }
    }
}
