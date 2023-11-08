using ParkingLotApi.Models;
using System.Xml.Linq;

namespace ParkingLotApi.Dtos
{
    public class ParkingLotCapacityDto
    {
        public int Capacity { get; set; }

        internal ParkingLot ToEntity()
        {
            return new ParkingLot()
            {
                Capacity = Capacity
            };

            throw new NotImplementedException();
        }
    }
}
