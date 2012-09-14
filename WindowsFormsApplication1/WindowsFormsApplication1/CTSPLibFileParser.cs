using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CTSPLibFileParser
    {
        protected Stream mFile = null;
        protected T_TsPFileHeader mFileHeader;

        public enum E_TspType
        {
            E_TSP,
            E_ATSP,
            E_SOP,
            E_HCP,
            E_CVRP,
            E_TOUR
        }

        public enum E_EdgeWeightType
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

        public enum E_EdgeWeightFormat
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

        public enum E_EdgeDataFormat
        {
            E_EDGE_LIST,
            E_ADJ_LIST
        }

        public enum E_NodeCoordType
        {
            E_2DCOORDS,
            E_3DCOORDS,
            E_NO_COORDS
        }

        public enum E_DisplayDataType
        {
            E_COORD_DISPLAY,
            E_TWOD_DISPLAY,
            E_NO_DISPLAY
        }

        public struct T_TsPFileHeader
        {
            public string name;
            public E_TspType type;
            public string comment;
            public int dimension;
            public E_EdgeWeightType edgeWeightType;
            public E_EdgeWeightFormat edgeWeightFormat;
            public E_EdgeDataFormat edgeDataFormat;
            public E_NodeCoordType nodeCoordType;
            public E_DisplayDataType displayDataType;


        }

        public CTSPLibFileParser(Stream inputFile)
        {
            
            mFile = inputFile;
            mFileHeader = new T_TsPFileHeader();
            mFileHeader.dimension = 0;
            

            /*
            using (StreamReader reader = new System.IO.StreamReader(mFile))
                {
                    String actualLine=reader.ReadLine();
                    CTSPPointList loadedCtsPointList = new CTSPPointList();
                                               
                    
                    while (!(actualLine == "NODE_COORD_SECTION"))
                    {
                        actualLine = reader.ReadLine();

                        if (actualLine.Split(new Char[] { ' ' })[0] == "EDGE_WEIGHT_TYPE")
                        {
                            string[] actualLineSplit = actualLine.Split(new Char[] { ' ' });
                            switch (actualLineSplit[1])
                            {
                                case "":
                            }
                        }


                    }

                    
                    while (!(reader.EndOfStream))
                    {              
                        actualLine = reader.ReadLine();
                            
                        if ((!(actualLine == "EOF")) || (!(actualLine== ""))) 
                        {
                            actualLine=actualLine.Trim();
                            string[] actualLineSplit = actualLine.Split(new Char[] { ' ' });

                          //  for (int i=0; i < actualLineSplit.Length; i++)
                           // {
                            double pointX = (double)double.Parse(actualLineSplit[1],System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                            double pointY = (double)double.Parse(actualLineSplit[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                            string index = actualLineSplit[0];
                            MessageBox.Show("Punkt mit dem I4ndex" + index + "mit den Punkten X=" + pointX + " und Y=" + pointY);                             
                           // loadedCtsPointList.addPoint(new CTSPPoint(pointX,pointY,index);
                          //  }
                        }
                    }

                }
                myResult.Close();
            */
            
        }

        /// <summary>
        /// füllt die Liste der Punkte mit dem Datensatz aus der "*.tsp"-Datei
        /// </summary>
        public void fillTSPPointList()
        {
            // erstmal den aktuellen Stand an Punkten löschen
            CTSPPointList.getInstance().deleteAll();
            readFile();
        }

        private void readFile()
        {
             StreamReader reader = new StreamReader(mFile);
              
             String actualLine=reader.ReadLine();
             while (!(actualLine == "EOF"))
             {
                 actualLine = reader.ReadLine().Trim().Replace(" ","");                 
                 string[] actualLineSplit = actualLine.Split(new Char[] { ':' });

                 switch (actualLineSplit[0])
                 {
                     case "NAME:":
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
                     case "NOORD_COORD_TYPE":
                         handleNoordCoordType(actualLineSplit[1]);
                         break;
                     case "DISPLAY_DATA_TYPE":
                         handleDisplayDataType(actualLineSplit[1]);
                         break;
                     case "NODE_COORD_SECTION":
                         handleNodeCoordSection(reader);
                         break;
                         
                 }


             }
                
        }

        private void handleNodeCoordSection(StreamReader reader)
        {
            String actualLine=reader.ReadLine();
            int i = 1;
            if (mFileHeader.dimension == 0)
            {
                mFileHeader.dimension = Int32.MaxValue;
            }
            while ((!(actualLine == "EOF")) && (i<mFileHeader.dimension))
            {
                actualLine = actualLine.Trim();
                string[] actualLineSplit = actualLine.Split(new Char[] { ' ' });
                int j=0;
                while (j < 3)       //wir brauchen nur 3 Werte, Rest wird ignoriert
                {
                    if (actualLineSplit[j] == "")
                    {
                        moveStringArray(actualLineSplit, j); // verschiebe das Array um 1 nach Links wenn ein Leerzeichen enthalten ist.
                    }
                    j++;
                }

                double pointX = double.Parse(actualLineSplit[1], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                double pointY = double.Parse(actualLineSplit[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                string index = actualLineSplit[0];
                CTSPPoint point = new CTSPPoint(pointX, pointY, index);
                CTSPPointList.getInstance().addPoint(point);
                actualLine = reader.ReadLine();
                i++;
            }
            
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
                    mFileHeader.displayDataType = E_DisplayDataType.E_COORD_DISPLAY;
                    break;
                case "TWOD_DISPLAY":
                    mFileHeader.displayDataType = E_DisplayDataType.E_TWOD_DISPLAY;
                    break;
                case "NO_DISPLAY":
                    mFileHeader.displayDataType = E_DisplayDataType.E_NO_DISPLAY;
                    break;
            }

        }

        private void handleNoordCoordType(string noordCoordType)
        {
            switch (noordCoordType)
            {
                case "TWOD_COORDS":
                    mFileHeader.nodeCoordType = E_NodeCoordType.E_2DCOORDS;
                    break;
                case "THREED_COORDS":
                    mFileHeader.nodeCoordType = E_NodeCoordType.E_3DCOORDS;
                    break;
                default:
                    mFileHeader.nodeCoordType = E_NodeCoordType.E_NO_COORDS;
                    break;
            }
        }

        private void handleEdgeDataFormat(string edgeDataFormat)
        {
            switch (edgeDataFormat)
            {
                case "EDGE_LIST":
                    mFileHeader.edgeDataFormat = E_EdgeDataFormat.E_EDGE_LIST;
                    break;
                case "ADJ_LIST":
                    mFileHeader.edgeDataFormat = E_EdgeDataFormat.E_ADJ_LIST;
                    break;
            }
        }

        private void handleEdgeWeightFormat(string edgeWeightFormat)
        {
            switch (edgeWeightFormat)
            { 
                case "FUNCTION":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_FUNCTION;
                    break;
                case "FULL_MATRIX":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_FULL_MATRIX;
                    break;
                case "UPPER_ROW":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_UPPER_ROW;
                    break;
                case "LOWER_ROW":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_LOWER_ROW;
                    break;
                case "UPPER_DIAG_ROW":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_UPPER_DIAG_ROW;
                    break;
                case "LOWER_DIAG_ROW":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_LOWER_DIAG_ROW;
                    break;
                case "UPPER_COL":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_UPPER_COL;
                    break;
                case "LOWER_COL":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_UPPER_COL;
                    break;
                case "UPPER_DIAG_COL":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_UPPER_DIAG_COL;
                    break;
                case "LOWER_DIAG_COL":
                    mFileHeader.edgeWeightFormat = E_EdgeWeightFormat.E_LOWER_DIAG_COL;
                    break;
            }
        }

        private void handleEdgeWeightType(string edgeWeightType)
        {
            switch (edgeWeightType)
            { 
                case "EXPLICIT":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_EXPLICIT;
                    break;
                case "EUC_2D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_EUC_2D;
                    break;
                case "EUC_3D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_EUC_3D;
                    break;
                case "MAX_2D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_MAX_2D;
                    break;
                case "MAX_3D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_MAX_3D;
                    break;
                case "MAN_2D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_MAN_2D;
                    break;
                case "MAN_3D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_MAN_3D;
                    break;
                case "CEIL_2D":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_CEIL_2D;
                    break;
                case "GEO":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_GEO;
                    break;
                case "ATT":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_ATT;
                    break;
                case "XRAY1":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_XRAY1;
                    break;
                case "XRAY2":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_XRAY2;
                    break;
                case "SPECIAL":
                    mFileHeader.edgeWeightType = E_EdgeWeightType.E_SPECIAL;
                    break;  
            }
        }

        private void HandleTspType(string actualLine)
        {
            switch (actualLine)
            {
                case "TSP": 
                    mFileHeader.type = E_TspType.E_TSP;
                    break;
                case "ATSP": 
                    mFileHeader.type = E_TspType.E_ATSP;
                    break;
                case "SOP": 
                    mFileHeader.type = E_TspType.E_SOP;
                    break;
                case "HCP": 
                    mFileHeader.type = E_TspType.E_HCP;
                    break;
                case "CVRP": 
                    mFileHeader.type = E_TspType.E_CVRP;
                    break;
                case "TOUR": 
                    mFileHeader.type = E_TspType.E_TOUR;
                    break;
            }
        }

   } 
}
