using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ParkingLotApi.Models
{
    public class ParkingLot
    {
        [BsonId]
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
    }
}
