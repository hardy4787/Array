using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class ArrayRangeException : Exception
    {
        public ArrayRangeException()
        {
        }

        public ArrayRangeException(string message) : base(message)
        {
        }

        public ArrayRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ArrayRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
