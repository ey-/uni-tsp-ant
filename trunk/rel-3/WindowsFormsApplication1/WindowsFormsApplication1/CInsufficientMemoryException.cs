using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class CInsufficientMemoryException : Exception
    {
        public enum E_EXCEPTION_TYPE
        {
            E_RAM_SIZE_ERROR,
            E_32_BIT_ERROR
        };

        E_EXCEPTION_TYPE mType;
        long mMemoryNeeded;
        long mMemoryAvailable;

        public CInsufficientMemoryException(E_EXCEPTION_TYPE type, long memoryNeeded, long memoryAvailable = 0)
        {
            mType = type;
            mMemoryNeeded = memoryNeeded;
            mMemoryAvailable = memoryAvailable;
        }

        public E_EXCEPTION_TYPE getType()
        {
            return mType;
        }

        public long getMemoryNeeded()
        {
            return mMemoryNeeded;
        }

        public long getMemoryAvailable()
        {
            return mMemoryAvailable;
        }
    }
}
