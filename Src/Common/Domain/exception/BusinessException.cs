using System;
using System.Runtime.Serialization;

namespace Ttu.Domain
{
    [Serializable]
    public class BusinessException : Exception
    {

        # region Constructors

        public BusinessException()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // necessary for serialization
        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        # endregion

    }
}
