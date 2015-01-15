using System;
using System.Collections.Generic;
using NUnit.Framework;
using WorkshopTests.Annotations;

namespace WorkshopTests
{
    class CarParkTests
    {
        [Test]
        public void Should_ReturnFull_When_ACustomerWantsToParkInAFullCar()
        {
            var carpark = new CarPark(0);
            var attendant = new Attendant(carpark);

            var car = new Car { Reg = "AF53 NEU" };
            attendant.ParkCar(car);

            var result = carpark.SpacesLeft();
            Assert.That(result, Is.EqualTo("Full"));
        }

        [Test]
        public void Should_ReturnNotFull_When_CarparkHasSpacesLeft()
        {
            var carpark = new CarPark(2);

            var attendant = new Attendant(carpark);
            var car = new Car { Reg = "AF53 NEU" };
            attendant.ParkCar(car);

            var result = carpark.SpacesLeft();
            Assert.That(result, Is.EqualTo("Not Full"));
        }

        [Test]
        public void Should_ReturnATicketWithSpaceIdOF1_When_ACarCanBeParked()
        {
            var carpark = new CarPark(2);
            var attendant = new Attendant(carpark);
            var car = new Car { Reg = "AF53 NEU" };
            attendant.ParkCar(car);
            var expectedResult = new Ticket(1);

            var result = attendant.ParkCar(car);

            Assert.True(result.Equals(expectedResult));
        }

        [Test]
        public void Should_NotReturnATicket_When_ACarCanNotBeParked()
        {
            var carpark = new CarPark(0);
            var attendant = new Attendant(carpark);
            var car = new Car { Reg = "AF53 NEU" };
            var result = attendant.ParkCar(car);

            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void Should_ParkCarInSpace1_When_ACarCanBeParked()
        {
            var carpark = new CarPark(2);
            var parkingSpace = new Space { Id = 0 };
            var attendant = new Attendant(carpark);
            var car = new Car { Reg = "AF53 NEU" };
            attendant.ParkCar(car);
            var result = carpark.SpacesList[0];

            Assert.True(result.Equals(parkingSpace));
        }


    }

    internal class Car
    {
        public string Reg { get; set; }
        public string Owner { get; set; }
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
                _carpark.AddCarToSpace(car);
                return new Ticket(1);
            }
            _carpark.SpacesLeft();
            return null;
        }
    }

    internal class Ticket
    {
        private readonly int _spaceId;

        public Ticket(int spaceId)
        {
            _spaceId = spaceId;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Ticket)) return false;
            var ticket = obj as Ticket;
            return _spaceId.Equals(ticket._spaceId);
        }
    }


    internal class CarPark
    {
        private int _spaces;
        private int _index;
        public List<Space> SpacesList { get; set; }

        public CarPark(int spaces)
        {
            _spaces = spaces;
            SpacesList = new List<Space>();
        }

        public string SpacesLeft()
        {
            return _spaces <= 0 ? "Full" : "Not Full";
        }

        public void AddCarToSpace(Car car)
        {
            SpacesList.Add(new Space{Id = _index, CarReg = car.Reg});
            _spaces -= 1;
            _index ++;
        }
    }

    internal class Space
    {
        public int Id { get; set; }
        public string CarReg  { get; set; }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Space)) return false;
            var space = obj as Space;
            return Id.Equals(space.Id);
        }
    }
}
