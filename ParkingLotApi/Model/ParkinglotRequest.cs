namespace ParkingLotApi.Model
{
    public class ParkinglotRequest
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public Parkinglot ToEntity() { return new Parkinglot {  Name = Name, Location = Location, Capacity = Capacity }; }
    }
}
