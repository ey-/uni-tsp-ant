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
            testTSPFileParser(fileAdress, 11, 1.00840e+03, 1.35200e+03);
            
        }

        protected void testTSPFileParser(string fileAdress,int pointToCheck,double expectedX,double expectedY)
        {
            Stream file = new FileStream(fileAdress, FileMode.Open);
            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.fillTSPPointList();
            file.Close();
            CTSPPoint readPoint = CTSPPointList.getInstance().getPoint(pointToCheck);

            Assert.IsTrue(expectedX == readPoint.x, "X-Wert wurde falsch eingelesen");
            Assert.IsTrue(expectedY == readPoint.y, "Y-Wert wurde falsch eingelesen");
                
        }
    }
}
