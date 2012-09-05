using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CConnectionList
    {
        protected static CConnectionList mInstance = new CConnectionList();

        protected List<CConnection> mConnectionList;

        protected CConnectionList()
        { }

        public CConnectionList getInstance()
        {
            return mInstance;
        }

        public void addConnection(CConnection newConnection)
        {
            mConnectionList.Add(newConnection);
        }

        public void deleteConnection(CConnection connection)
        {
            throw new NotImplementedException();
        }

        public void deleteAll()
        {
            throw new NotImplementedException();
        }

        public CConnection getConnection(int cityIndex1, int cityIndex2)
        {
            throw new NotImplementedException();
        }


    }
}
