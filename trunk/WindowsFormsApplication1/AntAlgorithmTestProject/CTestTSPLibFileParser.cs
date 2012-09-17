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
            string fileAdress = "../../ALL_tsp/berlin52.tsp/berlin52.tsp";
            testTSPFileParser(fileAdress, 0, 565,575);
        }

        protected void testTSPFileParser(string fileAdress,int pointToCheck,int expectedX,int expectedY)
        {
            Stream file =new FileStream(fileAdress, FileMode.Open);
            CTSPLibFileParser fileParser = new CTSPLibFileParser(file);
            fileParser.fillTSPPointList();
            file.Close();
            CTSPPoint readPoint=CTSPPointList.getInstance().getPoint(pointToCheck);

            Assert.IsTrue(expectedX == readPoint.x, "X-Wert wurde falsch eingelesen");
            Assert.IsTrue(expectedY == readPoint.y, "Y-Wert wurde falsch eingelesen");
                
        }
    }
}
