using Workshop;
using NUnit.Framework;

namespace WorkshopTests
{
    class SquareTests
    {
        [Test]
        public void Should_ReturnPerimeter_For_Square()
        {
            const decimal expectedResult = 8;
            const int side = 2;
            var square = new Square(side);

            var result = square.Perimeter;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(5, 25)]
        [TestCase(2, 4)]
        [TestCase(8, 64)]
        public void Should_ReturnArea_For_Square(decimal side, decimal expectedResult)
        {
            var square = new Square(side);
      
            var result = square.Area;
    
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
