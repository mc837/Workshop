using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WorkshopTests
{
    class CarParkTests
    {
        [Test]
        public void Should_ReturnNull_When_ACustomerWantsToParkInAFullCarpark()
        {
            var carpark = new CarPark(0);
            var car = new Car { Reg = "AF53 NEU" };
            var customer = new Customer(carpark, car);
            
            var answer =customer.AskToPark();

            Assert.That(answer, Is.EqualTo(null));
        }

        [Test]
        public void Should_ReturnTicketWithId_When_CarparkHasSpacesLeft()
        {
            var carpark = new CarPark(1);

            var car = new Car { Reg = "AF53 NEU" };
            var customer = new Customer(carpark, car);
            var expectedTicket = new Ticket(0);
            
            var result = customer.AskToPark();
            
            Assert.That(result, Is.EqualTo(expectedTicket));
        }

        [Test]
        public void Should_ReturnTicketWithId1_When_CarparkHasSpacesLeft()
        {
            var carpark = new CarPark(2);

            var car1 = new Car { Reg = "AF53 NEU" };
            var car2 = new Car { Reg = "AF53 NEU" };
            var customer1 = new Customer(carpark, car1);
            var customer2 = new Customer(carpark, car2);
            var expectedTicket = new Ticket(1);

            customer1.AskToPark();
            var result = customer2.AskToPark();

            Assert.That(result, Is.EqualTo(expectedTicket));
        }


        [Test]
        public void Attendant_Should_ParkCarInSpace1_When_ACarCanBeParked()
        {
            var carpark = new CarPark(1);
            var attendant = new Attendant(carpark);
            var car = new Car { Reg = "AF53 NEU" };
            attendant.ParkCar(car);
            var result = carpark.CarSpaces[0];

            Assert.That(result.Equals(car));
        }

        [Test]
        public void Attendant_Should_RetreiveCorrectCar_When_GivenATicket()
        {
            //Park car
            var carpark = new CarPark(3);
            var attendant = new Attendant(carpark);
            var car1 = new Car { Reg = "AF52 NEU" };
            var car2 = new Car { Reg = "AF53 NEU" };
            var car3 = new Car { Reg = "AF54 NEU" };
            attendant.ParkCar(car1);
            attendant.ParkCar(car2);
            attendant.ParkCar(car3);

            //Retrieve car
            var ticket = new Ticket(1);
            var retrievedCar = attendant.RetrieveCar(ticket);

            Assert.True(retrievedCar.Equals(car2));
        }

        [Test]
        public void Attendant_Can_ParkACar_When_ASpaceHasBeenVacated()
        {
            //Park car
            var carpark = new CarPark(3);
            var attendant = new Attendant(carpark);
            var car1 = new Car { Reg = "AF51 NEU" };
            var car2 = new Car { Reg = "AF52 NEU" };
            var car3 = new Car { Reg = "AF53 NEU" };
            attendant.ParkCar(car1);
            attendant.ParkCar(car2);
            attendant.ParkCar(car3);

            //Retrieve car
            var ticket = new Ticket(1);
            var retrievedCar = attendant.RetrieveCar(ticket);

            Assert.True(retrievedCar.Equals(car2));

            //Park next car
            var car4 = new Car { Reg = "AF54 NEU" };
            attendant.ParkCar(car4);

            Assert.True(carpark.CarSpaces[1].Equals(car4));

        }
    }

    internal class Customer
    {
        private readonly CarPark _carpark;
        private readonly Car _car;

        public Customer(CarPark carpark, Car car)
        {
            _carpark = carpark;
            _car = car;
        }

        public Ticket AskToPark()
        {
            return new Attendant(_carpark).ParkCar(_car);
        }
    }

    internal class Car
    {
        public string Reg { private get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Car)) return false;
            var car = obj as Car;
            return Reg.Equals(car.Reg);
        }
    }

    internal class Attendant
    {
        private readonly CarPark _carpark;

        public Attendant(CarPark carpark)
        {
            _carpark = carpark;
        }

        public Ticket ParkCar(Car car)
        {
            var spaces = _carpark.SpacesLeft();
            if (spaces == "Not Full")
            {
                var ticketId = _carpark.AddCarToSpace(car);
                return new Ticket(ticketId);
            }
            _carpark.SpacesLeft();
            return null;
        }

        public Car RetrieveCar(Ticket ticket)
        {
            var car =_carpark.RetrieveFromSpace(ticket.SpaceId);
            return car;
        }
    }

    internal class Ticket
    {
        public readonly int SpaceId;

        public Ticket(int spaceId)
        {
            SpaceId = spaceId;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Ticket)) return false;
            var ticket = obj as Ticket;
            return SpaceId.Equals(ticket.SpaceId);
        }
    }


    internal class CarPark
    {
        private int _spaces;
        public readonly Dictionary<int, Car> CarSpaces = new Dictionary<int, Car>();
        private int _nextAvailableSpaceId;

        public CarPark(int spaces)
        {
            _spaces = spaces;
            
            for (var i = 0; i < _spaces; i++)
            {
                CarSpaces.Add(i, null);
            }
        }

        public string SpacesLeft()
        {
            return _spaces <= 0 ? "Full" : "Not Full";
        }

        public int AddCarToSpace(Car car)
        {
            CarSpaces[_nextAvailableSpaceId] = car;
            _spaces -= 1;
            var ticketNo = _nextAvailableSpaceId;
            FindNextAvailableSpace();
            return ticketNo;
        }

        private void FindNextAvailableSpace()
        {
            if (_spaces != 0)
            {
                _nextAvailableSpaceId = CarSpaces.First(s => s.Value == null).Key;
            }
        }

        public Car RetrieveFromSpace(int carSpaceId)
        {
            Car car = CarSpaces[carSpaceId];
            CarSpaces[carSpaceId] = null;
            _spaces = + 1;
            FindNextAvailableSpace();
            
            return car;
        }
    }
}
