using NUnit.Framework;
using Triangle.Domain;

namespace TriangleTest.Domain
{
    [TestFixture]
    internal class ColoredTriangleTest
    {
        [Test]
        public void TestParseValidTriangle()
        {
            var coloredTriangle = ColoredTriangle.Parse("Red-7:Blue-8:Orange-4");
            var expectedTriangle = new ColoredTriangle
            {
                FirstSide = new ColoredSide(Color.Red, 7),
                SecondSide = new ColoredSide(Color.Blue, 8),
                ThirdSide = new ColoredSide(Color.Orange, 4)
            };
            Assert.AreEqual(coloredTriangle, expectedTriangle);
        }

        [Test]
        public void TestParseInvalidTriangleFormat()
        {
            Assert.Throws<DomainException>(() => ColoredTriangle.Parse("Rdd-43:Blue-23"));
        }

        [Test]
        public void TestParseInvalidTriangleSidesLength()
        {
            Assert.Throws<DomainException>(() => ColoredTriangle.Parse("Red-1:Blue-2:Orange-3"));
        }

        [Test]
        public void TestEqualsAndHashCode()
        {
            var side1 = new ColoredSide(Color.Red, 7);
            var side2 = new ColoredSide(Color.Blue, 6);
            var side3 = new ColoredSide(Color.Yellow, 5);
            var triangle = new ColoredTriangle
            {
                FirstSide = side1,
                SecondSide = side2,
                ThirdSide = side3
            };

            var triangle2 = new ColoredTriangle
            {
                FirstSide = side1,
                SecondSide = side2,
                ThirdSide = side3
            };


            Assert.IsTrue(triangle.Equals(triangle2));
            Assert.AreEqual(triangle.GetHashCode(), triangle2.GetHashCode());
        }
    }
}
