using System;
using System.Runtime.Serialization;

namespace Ttu.Domain
{
    [Serializable]
    public class PersistenceException : Exception
    {

        #region Constructors

        public PersistenceException()
        {
        }

        public PersistenceException(string message)
            : base(message)
        {
        }

        public PersistenceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // necessary for serialization
        protected PersistenceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

    }
}
