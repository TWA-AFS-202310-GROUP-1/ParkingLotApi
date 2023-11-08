using Microsoft.AspNetCore.Mvc;

namespace ParkingLotApi.Controllers
{
    public class ParkringlotService
    {
        private readonly int _capacity = 10;
        private readonly IParkinglotRepository _parkinglotRepository;
        public ParkringlotService(IParkinglotRepository parkinglotRepository) 
        {
            _parkinglotRepository = parkinglotRepository;
        }

        public Parkinglot CreateParkinglot(ParkinglotRequest parkinglotRequest)
        {
            if(parkinglotRequest == null || parkinglotRequest.Capacity < _capacity ) 
            {
                throw new ArgumentException("Capacity is lest than " + _capacity);
                
            }
            return null;
            //return _parkinglotRepository.create();
        }
    }
}