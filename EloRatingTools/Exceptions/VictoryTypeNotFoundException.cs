using System;
using System.Runtime.Serialization;

namespace EloRatingTools.Exceptions
{
    public class VictoryTypeNotFoundException : Exception
    {
        public VictoryTypeNotFoundException()
            : base()
        {

        }
        public VictoryTypeNotFoundException(string message)
            : base(message)
        {

        }
        public VictoryTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {

        }

        // This constructor is needed for serialization.
        protected VictoryTypeNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
