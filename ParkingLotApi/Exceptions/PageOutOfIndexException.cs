using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class PageOutOfIndexException : Exception
    {
        public PageOutOfIndexException()
        {
        }

        public PageOutOfIndexException(string? message) : base(message)
        {
        }

        public PageOutOfIndexException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PageOutOfIndexException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}