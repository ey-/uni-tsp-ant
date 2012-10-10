using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class CRandomPointGenerator
    {
        public const int DEFAULT_NUM_POINTS = 10;
        public const int DEFAULT_SIZE_X = 100;
        public const int DEFAULT_SIZE_Y = 100;

        public static int mNumPoints = DEFAULT_NUM_POINTS;
        public static int mSizeX = DEFAULT_SIZE_X;
        public static int mSizeY = DEFAULT_SIZE_Y;

        public static void generateTSP()
        {
            try
            {
                // erstmal alles altes löschen
                CTSPPointList.getInstance().removeAll();
                CConnectionList.getInstance().removeAll();

                GC.Collect();
                
                CMemoryTester.fitMemory(mNumPoints);

                generatePoints();
                CConnectionList.getInstance().generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE.E_EUC_2D);
            }
            catch (CInsufficientMemoryException memoryException)
            {
                if (memoryException.getType() == CInsufficientMemoryException.E_EXCEPTION_TYPE.E_32_BIT_ERROR)
                {
                    MessageBox.Show("Um ein Projekt mit der angegeben größe erzeugen zu können, benötigen Sie ca. " + memoryException.getMemoryNeeded()
                        + " MByte. 32-Bit-Anwendungen können aber maximal " + memoryException.getMemoryAvailable() + " MByte verwalten. "
                        + "Bitte verwenden sie die 64-Bit Version oder wählen Sie ein geringe Anzahl an Punkten.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Auf ihrem System stehen noch " + memoryException.getMemoryAvailable() + " MByte zur Verfügung. Es werden aber ca. "
                        + memoryException.getMemoryNeeded() + " MByte benötigt. "
                        + "Wenn Sie dieses Projekt mit dieser Anzahl von Punkten erstellen möchten stellen Sie Bitte mehr RAM zur Verfügung.", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void generatePoints()
        {
            Random rand = new Random();
            for (int cityIndex = 0; cityIndex < mNumPoints; cityIndex++)
            {
                CTSPPoint createdPoint = new CTSPPoint(rand.Next(1000), rand.Next(1000), "");
                CTSPPointList.getInstance().addPoint(createdPoint);
            }
        }
    }
}
