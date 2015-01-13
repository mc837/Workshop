using NUnit.Framework;
using Workshop;


namespace WorkshopTests
{
    class RectangleTests
    {
        [Test]
        public void Should_ReturnAPerimeterOf16_When_ARectangleHasALengthOf6AndWidthOf2()
        {
            var rectangle = new Rectangle(6, 2);
            var result = rectangle.Perimeter;
            Assert.That(result, Is.EqualTo(16));
        }

        [Test]
        public void Should_ReturnPerimeter_For_rectangle()
        {
            const decimal length = 6;
            const decimal width = 2;
            const decimal expectedResult = 16;

            var rectangle = new Rectangle(length, width);
            var result = rectangle.Perimeter;
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(6, 2, 12)]
        [TestCase(8, 5, 40)]
        [TestCase(2, 3, 6)]
        public void Should_ReturnArea_For_Rectangle(decimal length, decimal width, decimal expectedResult)
        {
            var rectangle = new Rectangle(length, width);
            var result = rectangle.Area;

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
