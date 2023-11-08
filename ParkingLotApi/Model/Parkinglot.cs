using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ParkingLotApi.Model
{
    public class Parkinglot
    {
        internal static readonly string CollectionName = "Parkinglot";

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
    }
}
