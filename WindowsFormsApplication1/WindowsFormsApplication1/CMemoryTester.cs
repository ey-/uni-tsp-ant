using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class CMemoryTester
    {
#if X64
        // Ein Objekt hat immer 16Byte + die Bytes der Membervariablen
        static int bytePerConnection = 40;
        static int bytePerPoint = 32;
        static int bytePerPointListEntry = 8;
#else
        // Ein Objekt hat immer 8Byte + die Bytes der Membervariablen
        static int bytePerConnection = 24;
        static int bytePerPoint = 20;
        static int bytePerPointListEntry = 4;
#endif

        /// <summary>
        /// Prüft ob genug Speicher vorhanden ist um die Datenhaltung zu garantieren
        /// </summary>
        /// <param name="numPoints">Anzahl der Punkte des Problems</param>
        /// <exception cref="Exception">Fehler wenn nicht genug Speicher zur Verfügung steht</exception>
        public static void fitMemory(int numPoints)
        {
            PerformanceCounter freeMemory = new PerformanceCounter("Memory", "Available Bytes");
            long byteAvailable = freeMemory.RawValue;
            long bytesNeeded = 0;

            bytesNeeded += bytePerPoint * numPoints;
            bytesNeeded += bytePerPointListEntry * numPoints;

            // Summenfunktion, zum Berechnen der Anzahl der Verbindungen
            long numConnections = (long)numPoints * ((long)numPoints - 1) / 2;
            bytesNeeded += numConnections * bytePerConnection;

            // Test haben gezeigt das trotzdem noch irgendwo Overhead entsteht
            // Darum rechnen wir zur Sicherheit nochmal 20% drauf
            bytesNeeded = (long)((double)bytesNeeded * 1.2);
            

#if !X64
            // Auf 32Bit-Maschinen kann man nicht mehr als 1,4 GByte allozieren,
            // darum müssen wir das hier abfangen.
            // Das gibt uns trotzdem keinen 100%igen Schutz, da es immer zu einer
            // Fragmentierung im Speicher kommen kann und so Overhead erzeugt wird.
            if (bytesNeeded > (1.4 *1024 * 1024 *1024))
            {
                long freeMB = byteAvailable /1024 /1024;
                long neededMB = bytesNeeded /1024 /1024;
                throw new CInsufficientMemoryException(CInsufficientMemoryException.E_EXCEPTION_TYPE.E_32_BIT_ERROR, neededMB, (long)(1.4 * 1024));
             /*   throw new Exception("Um dieses Projekt laden zu können werden ca. " + neededMB 
                    + " MByte benötigt. 32-Bit-Anwendungen können aber maximal " + 1.4 * 1024 + " MByte verwalten. "
                    + "Bitte verwenden sie die 64-Bit Version oder öffnen sie ein kleineres Projekt.");*/
            }
#endif
            Debug.WriteLine("zusätzlicher Speicher: " + bytesNeeded);
            if (bytesNeeded > byteAvailable)
            {
                long freeMB = byteAvailable /1024 /1024;
                long neededMB = bytesNeeded /1024 /1024;

                throw new CInsufficientMemoryException(CInsufficientMemoryException.E_EXCEPTION_TYPE.E_RAM_SIZE_ERROR, neededMB, freeMB);
                /*throw new Exception("Auf ihrem System stehen noch " + freeMB + " MByte zur Verfügung. Es werden aber ca. "
                    + neededMB + " MByte benötigt. "
                    + "Wenn Sie dieses Projekt laden möchten stellen Sie bitte mehr RAM zur Verfügung.");*/
            }
        }

    }
}
