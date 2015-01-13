using NUnit.Framework;
using Workshop;

namespace WorkshopTests
{
    class CircleTests
    {
        [TestCase(10, 62.83)]
        [TestCase(12, 75.4)]
        public void Should_ReturnPerimeter_For_Circle(double radius, double expectedResult)
        {
            var circle = new Circle(radius);
            var result = circle.Perimeter;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 314.16)]
        [TestCase(7, 153.94)]
        public void Should_ReturnAre_For_Circle(double radius, decimal expectedResult)
        {
            var circle = new Circle(radius);
            var result = circle.Area;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
