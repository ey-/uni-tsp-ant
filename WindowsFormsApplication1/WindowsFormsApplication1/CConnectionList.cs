using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public class CConnectionList : IEnumerable
    {
        // Instanz dieses Singleton
        protected static CConnectionList mInstance = new CConnectionList();

        // Liste der Verbindungen
        //protected List<CConnection> mConnectionList = new List<CConnection>();
        protected CConnection[] mConnectionList = null;
        long mConnectionsAdded = 0;

        /// <summary>
        /// Konstruktor
        /// </summary>
        protected CConnectionList()
        {
        }

        /// <summary>
        /// gibt die Instanz der Singleton-Klasse zurück
        /// </summary>
        /// <returns>Singleton-Instanz</returns>
        public static CConnectionList getInstance()
        {
            return mInstance;
        }

        /// <summary>
        /// erstellt die Liste aller Verbindungen, anhand aller Einträge 
        /// in der CTSPPointList
        /// </summary>
        public void generateFromPointList(CTSPLibFileParser.E_EDGE_WEIGHT_TYPE edgeWeightType)
        {
            // jetzt kann die Liste neu gefüllt werden
            CTSPPointList pointList = CTSPPointList.getInstance();

            // die Liste neu initialiseren
            initList(pointList.length());

            for (int originCityIndex = 0; originCityIndex < pointList.length(); originCityIndex++)
            { 
                for (int destinationCityIndex = originCityIndex +1; destinationCityIndex < pointList.length(); destinationCityIndex++)
                {
                    addConnection(new CConnection(pointList.getPoint(originCityIndex), pointList.getPoint(destinationCityIndex), edgeWeightType));

                    Debug.WriteLineIf(length() % 100000 == 0, length());
                }
                // Zeit für die GC lassen
                // Sonst gibt es Fehler, weil diese nicht genug Zeit bekommt ihr Ding zu machen
                System.Threading.Thread.Sleep(1);
            }

            Debug.WriteLine("Verbindungen erstellt: " + length());
        }

        /// <summary>
        /// initialisiert die Liste und 
        /// </summary>
        /// <param name="numberPoints"></param>
        public void initList(int numberPoints)
        {
            // Summenfunktion, zum Berechnen der Anzahl der Verbindungen
            long numConnections = (numberPoints -1) * numberPoints /2;
            mConnectionList = null;

            // Der GarbageCollection bescheidgeben das jetzt ein großer Speicherbereich frei wurde
            GC.Collect();

            mConnectionList = new CConnection[numConnections];
            mConnectionsAdded = 0;
        }

        /// <summary>
        /// fügt eine Verbindung in die Liste ein
        /// </summary>
        /// <param name="newConnection"></param>
        public bool addConnection(CConnection newConnection)
        {
            if (mConnectionList != null)
            {
                if (mConnectionsAdded < mConnectionList.LongLength)
                {
                    mConnectionList[mConnectionsAdded] = newConnection;
                    mConnectionsAdded++;

                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// gibt alle in die Liste eingefügten Objekte frei.
        /// Dabei wird die interne Liste erhalten und muss nicht 
        /// neu initialisiert werden
        /// </summary>
        public void removeAll()
        {
            for (long index = 0; index < length(); index++)
            {
                mConnectionList[index] = null;
            }
            mConnectionsAdded = 0;
        }

        /// <summary>
        /// gibt die Anzahl der Verbindungen in der Liste zurück
        /// </summary>
        /// <returns>Anzahl der Verbindungen</returns>
        public long length()
        {
            if (mConnectionList != null)
            {
                return mConnectionsAdded;
            }
            return 0;
        }

        /// <summary>
        /// gibt eine Verbindung aus der Liste anhand des Indexes zurück
        /// </summary>
        /// <param name="index">Index der Verbindung die geholt werden soll</param>
        /// <returns>geholte Verbindung</returns>
        public CConnection getConnection(long index)
        {
            if (mConnectionList != null)
            {
                if ((index >= 0) && (index < length()))
                {
                    return mConnectionList[index];
                }
            }
            return null;
        }

        /// <summary>
        /// holt eine Verbindung aus der Liste und gibt diese zurück
        /// </summary>
        /// <param name="tspPoint1">Punkt 1 der in der Verbindung vorhanden sein muss</param>
        /// <param name="tspPoint2">Punkt 2 der in der Verbindung vorhanden sein muss</param>
        /// <returns>gefundene Verbindung oder null</returns>
        public CConnection getConnection(CTSPPoint tspPoint1, CTSPPoint tspPoint2)
        {
            if (mConnectionList == null)
            {
                return null;
            }

            // alle Verbindungen durchgehen
            foreach (CConnection connection in mConnectionList)
            {
                // wenn die Verbindung beide Punkte enthält ist das die gesuchte Verbindung
                if (connection.containsPoint(tspPoint1) == true)
                {
                    if (connection.containsPoint(tspPoint2) == true)
                    {
                        return connection;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// ermittelt alle Verbindungen in denen ein Punkt enthalten ist 
        /// und gibt die Liste zurück
        /// </summary>
        /// <param name="tspPoint">Punkt dessen Verbindungen gesucht werden sollen</param>
        /// <returns>Liste mit Verbindungen des Punktes</returns>
        public List<CConnection> getConnectionOfPoint(CTSPPoint tspPoint)
        {
            List<CConnection> ret = new List<CConnection>();

            if (mConnectionList != null)
            {
                // alle Verbindungen durchgehen
                foreach (CConnection connection in mConnectionList)
                {
                    // wenn die Verbindung den gesuchten Punkt enthält, diesen in die Liste aufnehmen
                    if (connection.containsPoint(tspPoint) == true)
                    {
                        ret.Add(connection);
                    }
                }
            }

            // die Liste der Verbindungen für den Punkt zurückgeben
            return ret;
        }

        /// <summary>
        /// Methode zum iterieren mit foreach
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (long index = 0; index < length(); index++)
            {
                yield return mConnectionList[index];
            }
        }

        public void SetInitialPheromone(float initialPheromone)
        {
            foreach (CConnection connection in CConnectionList.mInstance)
                connection.SetPheromone(initialPheromone);
        }

    }
}
