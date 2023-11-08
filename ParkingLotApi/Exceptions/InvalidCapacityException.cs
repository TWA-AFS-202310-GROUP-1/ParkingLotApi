namespace ParkingLotApi.Exceptions
{
    public class InvalidCapacityException : Exception
    {
        public InvalidCapacityException(string? message) : base(message)
        {
        }
    }
}
