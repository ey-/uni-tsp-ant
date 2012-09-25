using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WindowsFormsApplication1
{
    public class CConnectionList : IEnumerable
    {
        // Instanz dieses Singleton
        protected static CConnectionList mInstance = new CConnectionList();

        // Liste der Verbindungen
        protected List<CConnection> mConnectionList = new List<CConnection>();

        /// <summary>
        /// Konstruktor
        /// </summary>
        protected CConnectionList()
        { }

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
        public void generateFromPointList(CTSPLibFileParser.E_EdgeWeightType edgeWeightType)
        {
            // zuerst altes Zeug aus der Liste raus
            removeAll();

            // jetzt kann die Liste neu gefüllt werden
            CTSPPointList pointList = CTSPPointList.getInstance();

            for (int originCityIndex = 0; originCityIndex < pointList.length(); originCityIndex++)
            { 
                for (int destinationCityIndex = originCityIndex +1; destinationCityIndex < pointList.length(); destinationCityIndex++)
                {
                    addConnection(new CConnection(pointList.getPoint(originCityIndex), pointList.getPoint(destinationCityIndex), edgeWeightType));
                }
            }
        }

        /// <summary>
        /// fügt eine Verbindung in die Liste ein
        /// </summary>
        /// <param name="newConnection"></param>
        public void addConnection(CConnection newConnection)
        {
            mConnectionList.Add(newConnection);
        }

        /// <summary>
        /// löscht eine bestimmt Verbindung
        /// </summary>
        /// <param name="connection">Verbindung die gelöscht werden soll</param>
        public void removeConnection(CConnection connection)
        {
            mConnectionList.Remove(connection);
        }

        /// <summary>
        /// löscht alle Verbindungen aus der Liste
        /// </summary>
        public void removeAll()
        {
            mConnectionList.RemoveRange(0, mConnectionList.Count());
        }

        /// <summary>
        /// gibt die Anzahl der Verbindungen in der Liste zurück
        /// </summary>
        /// <returns>Anzahl der Verbindungen</returns>
        public int length()
        {
            return mConnectionList.Count();
        }

        /// <summary>
        /// gibt eine Verbindung aus der Liste anhand des Indexes zurück
        /// </summary>
        /// <param name="index">Index der Verbindung die geholt werden soll</param>
        /// <returns>geholte Verbindung</returns>
        public CConnection getConnection(int index)
        {
            if ((index >= 0) && (index < mConnectionList.Count))
            {
                return mConnectionList[index];
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

            // alle Verbindungen durchgehen
            foreach (CConnection connection in mConnectionList)
            {
                // wenn die Verbindung den gesuchten Punkt enthält, diesen in die Liste aufnehmen
                if (connection.containsPoint(tspPoint) == true)
                {
                    ret.Add(connection);
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
            for (int index = 0; index < length(); index++)
            {
                yield return mConnectionList[index];
            }
        }

    }
}
