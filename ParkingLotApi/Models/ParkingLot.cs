using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ParkingLotApi.Models
{
    public class ParkingLot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }

    }
}
