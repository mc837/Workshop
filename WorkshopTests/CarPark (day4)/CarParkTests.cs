using NUnit.Framework;
using Workshop;

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
            const int expectedTicket = 0;
            
            var result = customer.AskToPark();
            
            Assert.That(result.SpaceId, Is.EqualTo(expectedTicket));
        }

        [Test]
        public void Should_ReturnTicketWithId1_When_CarIsParked()
        {
            var carpark = new CarPark(2);

            var car1 = new Car { Reg = "AF53 NEU" };
            var car2 = new Car { Reg = "AF53 NEU" };
            var customer1 = new Customer(carpark, car1);
            var customer2 = new Customer(carpark, car2);
            const int expectedTicket = 1;

            customer1.AskToPark();
            var result = customer2.AskToPark();

            Assert.That(result.SpaceId, Is.EqualTo(expectedTicket));
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
            var ticket =attendant.ParkCar(car2);
            attendant.ParkCar(car3);

            //Retrieve car
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
            var ticket = attendant.ParkCar(car2);
            attendant.ParkCar(car3);

            //Retrieve car
            var retrievedCar = attendant.RetrieveCar(ticket);

            Assert.True(retrievedCar.Equals(car2));

            //Park next car
            var car4 = new Car { Reg = "AF54 NEU" };
            attendant.ParkCar(car4);

            Assert.True(carpark.CarSpaces[1].Equals(car4));
        }

        [Test]
        public void Customer_Should_RecieveCorrectCar_When_ReturningTicketToAttendant()
        {
            var carpark = new CarPark(2);

            var car1 = new Car { Reg = "AF53 NEU" };
            var car2 = new Car { Reg = "AF54 NEU" };
            var customer1 = new Customer(carpark, car1);
            var customer2 = new Customer(carpark, car2);
            var ticket = customer1.AskToPark();
            customer2.AskToPark();

            var returnedCar = customer1.AskForCar(ticket);

            Assert.True(returnedCar.Equals(car1));
        }

    }
}
