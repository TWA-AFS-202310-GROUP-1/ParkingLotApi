namespace ParkingLotApi.Models
{
    public class ParkingLotDatabaseSettings
    {
        public string ConnectionString { get; set; } = null;
        public string DatabaseName { get; set; } = null;
        public string CollectionName { get; set; } = null;
    }
}
