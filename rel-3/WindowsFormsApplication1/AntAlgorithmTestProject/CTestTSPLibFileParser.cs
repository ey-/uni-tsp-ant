using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    [TestClass]
    public class CTestTSPLibFileParser
    {
        [TestMethod]
        public void constructorFileParserTest()
        {
            string fileAdress = "../../../../ALL_tsp/berlin52.tsp/berlin52.tsp";
            testTSPFileParser(fileAdress, 0, 565,575);
            testTSPFileParser(fileAdress, 19, 560, 365);
            testTSPFileParser(fileAdress, 36, 770, 610);
            testTSPFileParser(fileAdress, 51, 1740, 245);

            fileAdress = "../../../../ALL_tsp/ALL_tsp_rest/d198.tsp";
            testTSPFileParser(fileAdress, 0, 0, 0);
            testTSPFileParser(fileAdress, 11, 1008.4f, 1352f);
        }

        [TestMethod]
        public void testTSPExplicitLowerDiagRowFormat()
        {
            string fileAdress = "../../../../ALL_tsp/LowerDiagRowTest.tsp";
            Stream file = new FileStream(fileAdress, FileMode.Open);

            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.fillTSPPointList();

            CConnectionList connList = CConnectionList.getInstance();
            CTSPPoint point1, point2;

            CConnection connection12 = connList.getConnection(0);
            Assert.IsTrue(connection12.getDistance() == 1.0);
            connection12.getPoints(out point1, out point2);

        }

        [TestMethod]
        public void testTSPExplicitUpperRowFormat()
        {
            string fileAdress = "../../../../ALL_tsp/UpperRowTest.tsp";
            Stream file = new FileStream(fileAdress, FileMode.Open);

            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.fillTSPPointList();
        }

        [TestMethod]
        public void testTSPExplicitUpperDiagRowFormat()
        {
            string fileAdress = "../../../../ALL_tsp/UpperDiagRowTest.tsp";
            Stream file = new FileStream(fileAdress, FileMode.Open);

            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.fillTSPPointList();
        }

       

        [TestMethod]
        public void testTourParsing()
        {
            // Damit der Test durchlaufen kann muss zunächst die berlin52.tsp geparst werden damit die Listen korrekt gefüllt sind
            string tspFilePath = "../../../../ALL_tsp/berlin52.tsp/berlin52.tsp";
            Stream tspFile = new FileStream(tspFilePath, FileMode.Open);
            CTSPLibFileParser tspFileParser= new CTSPLibFileParser(tspFile);
            tspFileParser.fillTSPPointList();

            // Jetzt kann die Tour erfolgreich ausgelesen werden
            string fileAdress = "../../../../ALL_tsp/berlin52.tsp/berlin52.opt.tour";
            Stream file = new FileStream(fileAdress, FileMode.Open);

            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.getOptTour();

            
            Assert.IsTrue(CAntAlgorithmParameters.getInstance().optTour.getPoint(0).getLabel() == "1");
            Assert.IsTrue(CAntAlgorithmParameters.getInstance().optTour.getPoint(0).getLabel() == "1");
        }

        protected void testTSPFileParser(string fileAdress, int pointToCheck, float expectedX, float expectedY)
        {
            Stream file = new FileStream(fileAdress, FileMode.Open);
            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.fillTSPPointList();
            file.Close();
            CTSPPoint readPoint = CTSPPointList.getInstance().getPoint(pointToCheck);

            if (readPoint == null)
            {
                Assert.Fail("Zu prüfender Punkt konnte nicht geholt werden.");
            }

            Assert.IsTrue(expectedX == readPoint.x, "X-Wert wurde falsch eingelesen");
            Assert.IsTrue(expectedY == readPoint.y, "Y-Wert wurde falsch eingelesen");
                
        }


    }
}
