namespace Workshop
{
    public class Customer
    {
        private readonly CarPark _carpark;
        private readonly Car _car;

        public Customer(CarPark carpark, Car car)
        {
            _carpark = carpark;
            _car = car;
        }

        public CarPark.Ticket AskToPark()
        {
            return new Attendant(_carpark).ParkCar(_car);
        }

        public Car AskForCar(CarPark.Ticket ticket)
        {
            return new Attendant(_carpark).RetrieveCar(ticket);
        }
    }
}