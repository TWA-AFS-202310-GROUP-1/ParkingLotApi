using System.Runtime.Serialization;

namespace ParkingLotApi.Exceptions
{
    [Serializable]
    internal class ParkingLotNotFoundException : Exception
    {
        public ParkingLotNotFoundException()
        {
        }

        public ParkingLotNotFoundException(string? message) : base(message)
        {
        }

        public ParkingLotNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ParkingLotNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}