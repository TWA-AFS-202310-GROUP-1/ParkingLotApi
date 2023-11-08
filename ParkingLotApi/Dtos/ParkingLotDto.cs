using ParkingLotApi.Models;

namespace ParkingLotApi.Dtos

{
    public class ParkingLotDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }

        internal ParkingLot ToEntity()
        {
            return new ParkingLot {  Name = Name, Location = Location, Capacity = Capacity };
        }
    }
}