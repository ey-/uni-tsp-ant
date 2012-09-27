using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication1;

namespace AntAlgorithmTestProject
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für CTestConnectionList
    /// </summary>
    [TestClass]
    public class CTestConnectionList
    {
        /**********************************************************************
         * In diesem Test wird ein minimales System getestet.
         * Es gibt 3 Punkte und somit auch 3 Verbindungen.
         * Den Punkten werden Koordinaten zugewiesen damit getestet werden, ob 
         * dass ermittlen der Verbindungen anhand der Punkte korrekt funktioniert.
        **********************************************************************/
        const double POINTA_X = 0;
        const double POINTA_Y = 0;

        const double POINTB_X = 5.5;
        const double POINTB_Y = 5;

        const double POINTC_X = 5.5;
        const double POINTC_Y = 10.5;
        
        protected static CTSPPoint TEST_POINT_A = new CTSPPoint(POINTA_X, POINTA_Y, "POINT A");
        protected static CTSPPoint TEST_POINT_B = new CTSPPoint(POINTB_X, POINTB_Y, "POINT B");
        protected static CTSPPoint TEST_POINT_C = new CTSPPoint(POINTC_X, POINTC_Y, "POINT C");
        
        // Testdaten mit Expliziten Verbindungen
        const double TEST_DISTANCE_AB = 10;
        const double TEST_DISTANCE_BC = 15;
        const double TEST_DISTANCE_AC = 7;
        protected static CConnection TEST_CONNECTION_AB_EXPLICIT = new CConnection(TEST_POINT_A, TEST_POINT_B, TEST_DISTANCE_AB);
        protected static CConnection TEST_CONNECTION_BC_EXPLICIT = new CConnection(TEST_POINT_B, TEST_POINT_C, TEST_DISTANCE_BC);
        protected static CConnection TEST_CONNECTION_AC_EXPLICIT = new CConnection(TEST_POINT_A, TEST_POINT_C, TEST_DISTANCE_AC);

        protected static CConnection TEST_CONNECTION_NOT_IN_LIST = new CConnection(TEST_POINT_A, TEST_POINT_B, 0.0);

        [TestInitialize]
        public void testInitialize()
        {
            // Für jeden Test soll die Liste initial leer sein
            CConnectionList.getInstance().removeAll();
            CTSPPointList.getInstance().removeAll();
        }

        [TestMethod]
        public void testSingleton()
        {
            CConnectionList list = CConnectionList.getInstance();
        }

        [TestMethod]
        public void testAddRemoveConnections()
        {
            CConnectionList list = CConnectionList.getInstance();

            list.addConnection(TEST_CONNECTION_AB_EXPLICIT);
            list.addConnection(TEST_CONNECTION_BC_EXPLICIT);
            list.addConnection(TEST_CONNECTION_AC_EXPLICIT);
            Assert.IsTrue(list.length() == 3);
            Assert.AreSame(list.getConnection(0), TEST_CONNECTION_AB_EXPLICIT);
            Assert.AreSame(list.getConnection(1), TEST_CONNECTION_BC_EXPLICIT);
            Assert.AreSame(list.getConnection(2), TEST_CONNECTION_AC_EXPLICIT);

            list.removeConnection(TEST_CONNECTION_BC_EXPLICIT);
            Assert.IsTrue(list.length() == 2);
            Assert.AreSame(list.getConnection(0), TEST_CONNECTION_AB_EXPLICIT);
            Assert.AreSame(list.getConnection(1), TEST_CONNECTION_AC_EXPLICIT);

            // Löschen einer Verbindung die nicht verhanden ist
            list.removeConnection(TEST_CONNECTION_NOT_IN_LIST);
            Assert.IsTrue(list.length() == 2);

            list.removeAll();
            Assert.IsTrue(list.length() == 0);
        }

        [TestMethod]
        public void testGetConnection()
        {
            CConnectionList list = CConnectionList.getInstance();

            list.addConnection(TEST_CONNECTION_AB_EXPLICIT);
            list.addConnection(TEST_CONNECTION_BC_EXPLICIT);
            list.addConnection(TEST_CONNECTION_AC_EXPLICIT);

            Assert.AreSame(list.getConnection(0), TEST_CONNECTION_AB_EXPLICIT);
            Assert.AreSame(list.getConnection(1), TEST_CONNECTION_BC_EXPLICIT);
            Assert.AreSame(list.getConnection(2), TEST_CONNECTION_AC_EXPLICIT);

            List<CConnection> connectionsOfPoint = list.getConnectionOfPoint(TEST_POINT_A);
            Assert.IsTrue(connectionsOfPoint.Contains(TEST_CONNECTION_AB_EXPLICIT));
            Assert.IsTrue(connectionsOfPoint.Contains(TEST_CONNECTION_AC_EXPLICIT));
            Assert.IsFalse(connectionsOfPoint.Contains(TEST_CONNECTION_BC_EXPLICIT));
        }

        [TestMethod]
        public void testGenerateConnections()
        {
            CTSPPointList pointList = CTSPPointList.getInstance();
            CConnectionList connList = CConnectionList.getInstance();

            // Testpunkte einfügen
            pointList.addPoint(TEST_POINT_A);
            pointList.addPoint(TEST_POINT_B);
            pointList.addPoint(TEST_POINT_C);

            // Wir verwenden hier der Einfachheit halber den Euklidischen 2D Algorithmus.
            // Die Berechnung selbst ist hier auch nicht relevant und wird in der CTestConnection
            // getestet. Hier wird nur überprüft ob überhaupt Verbindungen erzeugt und Werte ermittelt werden
            connList.generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);

            Assert.IsTrue(connList.length() == 3);
            foreach (CConnection connection in connList)
            {
                // es muss eine Distanz größer als 0 herauskommen
                // Wie groß die ist, ist in diesem Test nicht relevant
                Assert.IsTrue(connection.getDistance() > 0);
            }
        }
    }
}
