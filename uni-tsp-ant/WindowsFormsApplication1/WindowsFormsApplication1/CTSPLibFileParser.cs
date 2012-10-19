using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class CTSPLibFileParser
    {
        protected Stream mFile = null;
        protected T_TSP_FILE_HEADER mFileHeader;

        protected static char[] COORD_SPLIT_CHARACTERS = {' ', '\t' };

        public enum E_TSP_TYPE
        {
            E_TSP,
            E_ATSP,
            E_SOP,
            E_HCP,
            E_CVRP,
            E_TOUR
        }

        public enum E_EDGE_WEIGHT_TYPE
        {
            E_EXPLICIT,
            E_EUC_2D,
            E_EUC_3D,
            E_MAX_2D,
            E_MAX_3D,
            E_MAN_2D,
            E_MAN_3D,
            E_CEIL_2D,
            E_GEO,
            E_ATT,
            E_XRAY1,
            E_XRAY2,
            E_SPECIAL
        }

        public enum E_EDGE_WEIGHT_FORMAT
        {
            E_FUNCTION,
            E_FULL_MATRIX,
            E_UPPER_ROW,
            E_LOWER_ROW,
            E_UPPER_DIAG_ROW,
            E_LOWER_DIAG_ROW,
            E_UPPER_COL,
            E_LOWER_COL,
            E_UPPER_DIAG_COL,
            E_LOWER_DIAG_COL
        }

        public enum E_EDGE_DATA_FORMAT
        {
            E_EDGE_LIST,
            E_ADJ_LIST
        }

        public enum E_NODE_COORD_TYPE
        {
            E_2DCOORDS,
            E_3DCOORDS,
            E_NO_COORDS
        }

        public enum E_DISPLAY_DATA_TYPE
        {
            E_COORD_DISPLAY,
            E_TWOD_DISPLAY,
            E_NO_DISPLAY
        }

        public struct T_TSP_FILE_HEADER
        {
            public string name;
            public E_TSP_TYPE type;
            public string comment;
            public int dimension;
            public E_EDGE_WEIGHT_TYPE edgeWeightType;
            public E_EDGE_WEIGHT_FORMAT edgeWeightFormat;
            public E_EDGE_DATA_FORMAT edgeDataFormat;
            public E_NODE_COORD_TYPE nodeCoordType;
            public E_DISPLAY_DATA_TYPE displayDataType;
        }



        public CTSPLibFileParser(Stream inputFile)
        {   
            mFile = inputFile;

            // Defaultdaten für den Dateiheader setzen
            mFileHeader = new T_TSP_FILE_HEADER();
            mFileHeader.dimension = 0; //default Dimension
            mFileHeader.nodeCoordType = E_NODE_COORD_TYPE.E_NO_COORDS; //default nodeCoordType
            mFileHeader.displayDataType = E_DISPLAY_DATA_TYPE.E_NO_DISPLAY; //default displaydatatype
        }

        /// <summary>
        /// füllt die Liste der Punkte mit dem Datensatz aus der "*.tsp"-Datei
        /// </summary>
        public void fillTSPPointList()
        {
            // erstmal den aktuellen Stand an Punkten löschen
            CTSPPointList.getInstance().removeAll();
            CConnectionList.getInstance().removeAll();

            Debug.WriteLine("Startspeicher: " + GC.GetTotalMemory(true));

            readFile();
        }

        public void getOptTour()
        {
            readFile();
        }

        private void readFile()
        {
             StreamReader reader = new StreamReader(mFile);

             string actualLine = "";
             bool bLineAlreadyRead = false;
             while (!(actualLine == "EOF"))
             {
                 string readLine = actualLine;
                 if (bLineAlreadyRead == false)
                 {
                     readLine = reader.ReadLine();
                 }

                 // wenn wir das Ende der Datei erreicht habe 
                 if (readLine == null)
                 {
                     // brechen wir ab
                     break;
                 }

                 bLineAlreadyRead = false;

                 actualLine = readLine.Trim().Replace(" ","");                 
                 string[] actualLineSplit = actualLine.Split(new Char[] { ':' });

                 switch (actualLineSplit[0])
                 {
                     // Fileheader Einträge
                     case "NAME":
                         mFileHeader.name = actualLineSplit[1];   
                         break;
                     case "TYPE":
                         HandleTspType(actualLineSplit[1]);
                         break;
                     case "COMMENT": 
                         mFileHeader.comment = actualLineSplit[1];
                         break;
                     case "DIMENSION": 
                         mFileHeader.dimension = Int32.Parse(actualLineSplit[1]);
                         CProgressManager.setStepsPointsAndConnections(mFileHeader.dimension);
                         CMemoryTester.fitMemory(mFileHeader.dimension);
                         break;
                     case "EDGE_WEIGHT_TYPE": 
                         handleEdgeWeightType(actualLineSplit[1]);
                         break;
                     case "EDGE_WEIGHT_FORMAT":
                         handleEdgeWeightFormat(actualLineSplit[1]);
                         break;
                     case "EDGE_DATA_FORMAT":
                         handleEdgeDataFormat(actualLineSplit[1]);
                         break;
                     case "NODE_COORD_TYPE":
                         handleNoordCoordType(actualLineSplit[1]);
                         break;
                     case "DISPLAY_DATA_TYPE":
                         handleDisplayDataType(actualLineSplit[1]);
                         break;
                    
                     // Dateneinträge
                     case "NODE_COORD_SECTION":
                         actualLine = handleNodeCoordSection(reader);
                         bLineAlreadyRead = true;
                         break;
                     case "EDGE_WEIGHT_SECTION":
                         actualLine = handleEdgeWeightSection(reader);
                         bLineAlreadyRead = true;
                         break;
                     case "DISPLAY_DATA_SECTION":
                         actualLine = handleDisplayDataSection(reader);
                         bLineAlreadyRead = true;
                         break;
                     case "TOUR_SECTION":
                         actualLine = handleTourSection(reader);
                         bLineAlreadyRead = true;
                         break;
                 } // switch
             }  // while
                
        }

        private string handleDisplayDataSection(StreamReader reader)
        {
            if (mFileHeader.displayDataType != E_DISPLAY_DATA_TYPE.E_TWOD_DISPLAY)
            {
                throw new Exception("Fehler beim lesen der Anzeigedaten!");
            }

            // da es sein kann das die DisplayDataSection nach der EdgeWeightSection kommt und 
            // die Punkte damit schon angelegt sind müssen zuerst ermittelt werden, ob neue Punkte
            // angelegt werden müssen oder die bestehenden verwendet werden können
            bool bCreateNewPoints = CTSPPointList.getInstance().length() == 0;

            int nodeIndex = 0;
            string actualLine = reader.ReadLine();
            while ((actualLine != null) && (actualLine != "EOF") && (nodeIndex <= mFileHeader.dimension))
            {
                CTSPPoint point = parseLineToPoint(actualLine);

                if (bCreateNewPoints == true)
                {
                    CTSPPointList.getInstance().addPoint(point);
                }
                else
                {
                    CTSPPoint storedPoint = CTSPPointList.getInstance().getPoint(nodeIndex);
                    storedPoint.setLabel(point.getLabel());
                    storedPoint.x = point.x;
                    storedPoint.y = point.y;
                }

                nodeIndex++;
                actualLine = reader.ReadLine();
            }

            // Nachdem alle Punkte eingefügt wurden noch die Liste optimieren, 
            // da sich hier eigentlich nichts mehr ändern sollte
            CTSPPointList.getInstance().optimizeList();

            return actualLine;
        }

        private string handleEdgeWeightSection(StreamReader reader)
        {
            // bevor wir mit dem Parsen anfangen, prüfen wir erstmal ein paar sachen

            // Der Typ muss korrekt sein
            if (mFileHeader.edgeWeightType != E_EDGE_WEIGHT_TYPE.E_EXPLICIT)
            {
                throw new Exception("Fileformat Fehler! Datei kann nicht gelesen werden.");
            }

            // Damit wir die Verbindungen erzeugen können müssen Punkte vorhanden sein.
            // Das machen wir aber nur wenn nicht schon Punkte vorhanden sind 
            // (z.B. durch eine DISPLAY_DATA_SECTION)
            if (CTSPPointList.getInstance().length() == 0)
            {
                for (int point = 1; point <= mFileHeader.dimension; point++)
                { 
                    CTSPPointList.getInstance().addPoint(new CTSPPoint(point.ToString()));
                }

                // Nachdem alle Punkte eingefügt wurden noch die Liste optimieren, 
                // da sich hier eigentlich nichts mehr ändern sollte
                CTSPPointList.getInstance().optimizeList();
            }

            // Damit wir später die Verbindungen einfügen können, muss die Liste der Verbindungen 
            // erstmal, für die Anzahl initialisert werden
            CConnectionList.getInstance().initList(mFileHeader.dimension);

            int expectedWeightElements = getNumberElementsToRead();
            int weightElementsRead = 0;
            
            // Es gibt kein wirkliches Stoppkriterum.. es muss mitgezählt werden wieviele Element bereites ausgelesen wurden
            String actualLine = reader.ReadLine();
            while ((actualLine != null) && (weightElementsRead < expectedWeightElements))
            {
                actualLine = actualLine.Trim();
                string[] elements = actualLine.Split(COORD_SPLIT_CHARACTERS);
                elements = removeSpacesInString(elements);

                foreach (string element in elements)
                {
                    handleEdgeWeightElement(element, weightElementsRead);

                    // ein Element wurde gelesen
                    weightElementsRead++;
                }

                // nächste Zeile lesen
                actualLine = reader.ReadLine();
            }

            return actualLine;
        }

        private void handleEdgeWeightElement(string element, int elementIndex)
        {
            CTSPPointList pointList = CTSPPointList.getInstance();
            CConnectionList connList = CConnectionList.getInstance();

            float distance = float.Parse(element);

            switch (mFileHeader.edgeWeightFormat)
            {
                case E_EDGE_WEIGHT_FORMAT.E_FULL_MATRIX:
                {
                    int row = elementIndex / mFileHeader.dimension;
                    int pointIndex = elementIndex % mFileHeader.dimension;

                    // Es werden nur die Punkte unter der Diagonalen betrachtet.
                    // damit werden keine Verbindungen Doppelt eingefügt und Verbindungen 
                    // auf den gleichen Punkt, also Distanz = 0, vermieden
                    if (pointIndex < row)
                    {
                        CTSPPoint point1 = pointList.getPoint(row);
                        CTSPPoint point2 = pointList.getPoint(pointIndex);
                        connList.addConnection(new CConnection(point1, point2, distance, CAntAlgorithmParameters.getInstance().initialPheromone));
                    }
                    break;
                }
                case E_EDGE_WEIGHT_FORMAT.E_UPPER_ROW:
                {
                    int row = 0;
                    while ((elementIndex / (mFileHeader.dimension - 1 - row)) > 0)
                    {
                        elementIndex -= (mFileHeader.dimension - 1 - row);
                        row++;
                    }
                    // Index des Punktes ist der Offset bis zur Diagonalen + den Index des Elementes
                    int pointIndex = row + 1 + elementIndex;

                    CTSPPoint point1 = pointList.getPoint(row);
                    CTSPPoint point2 = pointList.getPoint(pointIndex);
                    connList.addConnection(new CConnection(point1, point2, distance, CAntAlgorithmParameters.getInstance().initialPheromone));
                    break;
                }
                case E_EDGE_WEIGHT_FORMAT.E_UPPER_DIAG_ROW:
                {
                    int row = 0;
                    while ((elementIndex / (mFileHeader.dimension - row)) > 0)
                    {
                        elementIndex -= (mFileHeader.dimension - row);
                        row++;
                    }
                    // Index des Punktes ist der Offset bis zur Diagonalen + den Index des Elementes
                    int pointIndex = row  + elementIndex;

                    if (pointIndex != row)
                    {
                        CTSPPoint point1 = pointList.getPoint(row);
                        CTSPPoint point2 = pointList.getPoint(pointIndex);
                        connList.addConnection(new CConnection(point1, point2, distance, CAntAlgorithmParameters.getInstance().initialPheromone));
                    }
                    break;
                }
                case E_EDGE_WEIGHT_FORMAT.E_LOWER_DIAG_ROW:
                {
                    int row = 0;
                    int pointIndex = elementIndex;
                    while ((pointIndex / (row + 1)) > 0)
                    {
                        pointIndex -= row + 1;
                        row++;
                    }

                    if (pointIndex != row)
                    {
                        CTSPPoint point1 = pointList.getPoint(pointIndex);
                        CTSPPoint point2 = pointList.getPoint(row);
                        connList.addConnection(new CConnection(point1, point2, distance, CAntAlgorithmParameters.getInstance().initialPheromone));
                    }

                    break;
                }
                
            }
        }

        private int getNumberElementsToRead()
        {
            switch (mFileHeader.edgeWeightFormat)
            {
                case E_EDGE_WEIGHT_FORMAT.E_FULL_MATRIX:
                    // 0 1 2    Dimension: 3
                    // 1 0 3    3x3 Matrix => 9 Einträge
                    // 2 3 0
                    return mFileHeader.dimension * mFileHeader.dimension;
                case E_EDGE_WEIGHT_FORMAT.E_UPPER_ROW:
                {
                    //   1 2    Dimension: 3
                    //     3    3x3 Matrix => 3 Einträge
                    //      
                    int numElements = 0;
                    for (int row = 0; row < mFileHeader.dimension; row++)
                    {
                        // Elemente: Dimension - Anzahl der Elemente hinter der Diagonalen - Diagonale 
                        numElements += mFileHeader.dimension - row - 1;
                    }
                    return numElements;
                }
                case E_EDGE_WEIGHT_FORMAT.E_UPPER_DIAG_ROW:
                case E_EDGE_WEIGHT_FORMAT.E_LOWER_DIAG_ROW:
                {
                    // 0 1 2    Dimension: 3
                    //   0 3    3x3 Matrix => 6 Einträge
                    //     0
                    // LowerDiagRow wird genauso berechnet
                    int numElements = 0;
                    for (int row = 0; row < mFileHeader.dimension; row++)
                    {
                        // Elemente: Dimension - Anzahl der Elemente hinter der Diagonalen
                        numElements += mFileHeader.dimension - row;
                    }
                    return numElements;
                }
                default:
                    throw new Exception("Fileformat Fehler! Datei kann nicht gelesen werden.");
            }
        }

        private string handleTourSection(StreamReader reader)
        {
            String actualLine = reader.ReadLine();
            
            if (mFileHeader.dimension == 0)
            {
                mFileHeader.dimension = Int32.MaxValue;
            }

            // Die Anzahl der Knoten in der Datei muss mit der Anzahl der Einträge in der Punktliste übereinstimmen.
            // Sonst greifen wir eventuell noch auf Punkte zu die es nicht gibt.
            if (mFileHeader.dimension != CTSPPointList.getInstance().length())
            {
                throw new Exception("Tour-Datei ist nicht kompatibel mit der geladenen TSP-Datei!");
            }

            CTour optTour = new CTour();

            int i = 1;
            while ((!(actualLine == "-1")) && (i <= mFileHeader.dimension))
            {
                actualLine = actualLine.Trim();
                
                // Punkt suchen
                CTSPPoint point = CTSPPointList.getInstance().getPoint(actualLine);

                if (point != null)
                {
                    // Punkt in Tour einfügen
                    optTour.addPoint(point);
                }
                else 
                {
                    throw new Exception("Fehler beim auslesen der Optimalen Tour!");
                }

                actualLine = reader.ReadLine();
                i++;
            }

            // Tour abspeichern
            CAntAlgorithmParameters.getInstance().optTour = optTour;

            return actualLine;
        }

        private string handleNodeCoordSection(StreamReader reader)
        {
            String actualLine=reader.ReadLine();
            int i = 1;
            if (mFileHeader.dimension == 0)
            {
                mFileHeader.dimension = Int32.MaxValue;
            }
            while ((!(actualLine == "EOF")) && (i <= mFileHeader.dimension))
            {
                CTSPPoint point = parseLineToPoint(actualLine);
                CTSPPointList.getInstance().addPoint(point);

                actualLine = reader.ReadLine();
                i++;
            }

            // Nachdem alle Punkte eingefügt wurden noch die Liste optimieren, 
            // da sich hier eigentlich nichts mehr ändern sollte
            CTSPPointList.getInstance().optimizeList();

            // Nachdem wir alle Punkte ausgelesen haben, können wir nun die Verbindungen nach 
            // im FileHeader angegebenen Algorithmus berechnen
            CConnectionList.getInstance().generateFromPointList(mFileHeader.edgeWeightType);

            PerformanceCounter freeMemory = new PerformanceCounter("Memory", "Available Bytes");
            Debug.WriteLine("Am Ende RAM frei: " + freeMemory.RawValue);
            Debug.WriteLine("Endspeicher: " + GC.GetTotalMemory(true));

            return actualLine;
        }

        /// <summary>
        /// ließt einen Punkt aus einer Zeile aus
        /// Die Daten des Punktes müssen im Format "Label X Y" sein
        /// </summary>
        /// <param name="actualLine">Zeile mit den Daten des Punktes</param>
        /// <returns>ausgelesener Punkt</returns>
        private CTSPPoint parseLineToPoint(string actualLine)
        {
            actualLine = actualLine.Trim();
            string[] actualLineSplit = actualLine.Split(COORD_SPLIT_CHARACTERS);
            actualLineSplit = removeSpacesInString(actualLineSplit);

            float pointX = float.Parse(actualLineSplit[1], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            float pointY = float.Parse(actualLineSplit[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            string index = actualLineSplit[0];

            return new CTSPPoint(pointX, pointY, index); ;
        }


        private string[] removeSpacesInString(string[] actualLineSplit)
        {
            List<string> clearedSplitList = new List<string>();
            foreach (string split in actualLineSplit)
            {
                if (split != "")
                { 
                    clearedSplitList.Add(split);
                }
            }

            string[] output = new string[clearedSplitList.Count];

            clearedSplitList.CopyTo(output);
            return output;
            /*
            int j = 0;
            while (j < 3)       //wir brauchen nur 3 Werte, Rest wird ignoriert
            {
                if (actualLineSplit[j] == "")
                {
                    moveStringArray(actualLineSplit, j); // verschiebe das Array um 1 nach Links wenn ein Leerzeichen enthalten ist.
                }
                j++;
            }*/
        }

        private void moveStringArray(string[] actualLineSplit, int j)
        {
            for (int i = j; i < actualLineSplit.Length-1; i++)
            {
                actualLineSplit[i] = actualLineSplit[i + 1];
            }
        }



        private void handleDisplayDataType(string displayDataType)
        {
            switch (displayDataType)
            {
                case "COORD_DISPLAY":
                    mFileHeader.displayDataType = E_DISPLAY_DATA_TYPE.E_COORD_DISPLAY;
                    break;
                case "TWOD_DISPLAY":
                    mFileHeader.displayDataType = E_DISPLAY_DATA_TYPE.E_TWOD_DISPLAY;
                    break;
                case "NO_DISPLAY":
                    mFileHeader.displayDataType = E_DISPLAY_DATA_TYPE.E_NO_DISPLAY;
                    break;
            }

        }

        private void handleNoordCoordType(string noordCoordType)
        {
            switch (noordCoordType)
            {
                case "TWOD_COORDS":
                    mFileHeader.nodeCoordType = E_NODE_COORD_TYPE.E_2DCOORDS;
                    mFileHeader.displayDataType = E_DISPLAY_DATA_TYPE.E_COORD_DISPLAY; //default displayDataType if noordCoords are specified, here it is
                    break;
                case "THREED_COORDS":
                    mFileHeader.nodeCoordType = E_NODE_COORD_TYPE.E_3DCOORDS;
                    mFileHeader.displayDataType = E_DISPLAY_DATA_TYPE.E_COORD_DISPLAY; //default displayDataType if noordCoords are specified, here it is
                    break;
                default:
                    mFileHeader.nodeCoordType = E_NODE_COORD_TYPE.E_NO_COORDS;
                    break;
            }
        }

        private void handleEdgeDataFormat(string edgeDataFormat)
        {
            switch (edgeDataFormat)
            {
                case "EDGE_LIST":
                    mFileHeader.edgeDataFormat = E_EDGE_DATA_FORMAT.E_EDGE_LIST;
                    break;
                case "ADJ_LIST":
                    mFileHeader.edgeDataFormat = E_EDGE_DATA_FORMAT.E_ADJ_LIST;
                    break;
            }
        }

        private void handleEdgeWeightFormat(string edgeWeightFormat)
        {
            switch (edgeWeightFormat)
            { 
                case "FUNCTION":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_FUNCTION;
                    break;
                case "FULL_MATRIX":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_FULL_MATRIX;
                    break;
                case "UPPER_ROW":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_UPPER_ROW;
                    break;
                case "LOWER_ROW":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_LOWER_ROW;
                    break;
                case "UPPER_DIAG_ROW":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_UPPER_DIAG_ROW;
                    break;
                case "LOWER_DIAG_ROW":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_LOWER_DIAG_ROW;
                    break;
                case "UPPER_COL":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_UPPER_COL;
                    break;
                case "LOWER_COL":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_UPPER_COL;
                    break;
                case "UPPER_DIAG_COL":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_UPPER_DIAG_COL;
                    break;
                case "LOWER_DIAG_COL":
                    mFileHeader.edgeWeightFormat = E_EDGE_WEIGHT_FORMAT.E_LOWER_DIAG_COL;
                    break;
            }
        }

        private void handleEdgeWeightType(string edgeWeightType)
        {
            switch (edgeWeightType)
            { 
                case "EXPLICIT":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_EXPLICIT;
                    break;
                case "EUC_2D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_EUC_2D;
                    break;
                case "EUC_3D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_EUC_3D;
                    break;
                case "MAX_2D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_MAX_2D;
                    break;
                case "MAX_3D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_MAX_3D;
                    break;
                case "MAN_2D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_MAN_2D;
                    break;
                case "MAN_3D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_MAN_3D;
                    break;
                case "CEIL_2D":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_CEIL_2D;
                    break;
                case "GEO":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_GEO;
                    break;
                case "ATT":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_ATT;
                    break;
                case "XRAY1":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_XRAY1;
                    break;
                case "XRAY2":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_XRAY2;
                    break;
                case "SPECIAL":
                    mFileHeader.edgeWeightType = E_EDGE_WEIGHT_TYPE.E_SPECIAL;
                    break;  
            }
        }

        private void HandleTspType(string actualLine)
        {
            switch (actualLine)
            {
                case "TSP": 
                    mFileHeader.type = E_TSP_TYPE.E_TSP;
                    break;
                case "TOUR":
                    mFileHeader.type = E_TSP_TYPE.E_TOUR;
                    break;
                case "ATSP": 
                    mFileHeader.type = E_TSP_TYPE.E_ATSP;
                    throw new Exception("Es können keine ATSP-Dateien (asymmetric traveling salesman problem) gelesen werden.");
                case "SOP": 
                    mFileHeader.type = E_TSP_TYPE.E_SOP;
                    throw new Exception("Es können keine SOP-Dateien (sequential ordering problem) gelesen werden.");
                case "HCP": 
                    mFileHeader.type = E_TSP_TYPE.E_HCP;
                    throw new Exception("Es können keine HCP-Dateien (hamiltonian cycle problem) gelesen werden.");
                case "CVRP": 
                    mFileHeader.type = E_TSP_TYPE.E_CVRP;
                    throw new Exception("Es können keine CVRP-Dateien (capacitated vehicle routing problem) gelesen werden.");
                default:
                    throw new Exception("Datei mit unbekannten Typ kann nicht gelesen werden.");
            }
        }

   } 
}
