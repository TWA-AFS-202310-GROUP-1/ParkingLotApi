namespace ParkingLotApi.Exceptions
{
    public class NameConflitedException : Exception
    {
        public NameConflitedException(string? message) : base(message)
        {
        }
    }
}
