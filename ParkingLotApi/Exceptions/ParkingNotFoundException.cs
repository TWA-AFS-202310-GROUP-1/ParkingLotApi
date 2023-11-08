using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class ParkingNotFoundException : Exception
    {
        public ParkingNotFoundException()
        {
        }

        public ParkingNotFoundException(string? message) : base(message)
        {
        }

        public ParkingNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ParkingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}