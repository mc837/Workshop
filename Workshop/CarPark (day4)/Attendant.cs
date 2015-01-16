namespace Workshop
{
    public class Attendant
    {
        private readonly CarPark _carpark;

        public Attendant(CarPark carpark)
        {
            _carpark = carpark;
        }

        public CarPark.Ticket ParkCar(Car car)
        {
            var spaces = _carpark.SpacesLeft();
            if (spaces == "Not Full")
            {
                return _carpark.AddCarToSpace(car);
            }
            _carpark.SpacesLeft();
            return null;
        }

        public Car RetrieveCar(CarPark.Ticket ticket)
        {
            var car =_carpark.RetrieveFromSpace(ticket.SpaceId);
            return car;
        }

       
    }
}