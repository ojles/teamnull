using NUnit.Framework;
using Triangle.Domain;

namespace TriangleTest.Domain
{
    [TestFixture]
    class ColoredSideTest
    {
        [Test]
        public void TestParseValidSide()
        {
            var coloredSide = ColoredSide.Parse("Red-7");
            var expectedSide = new ColoredSide(Color.Red, 7);
            Assert.AreEqual(coloredSide, expectedSide);
        }

        [Test]
        public void TestParseInvalidSide()
        {
            Assert.Throws<DomainException>(() => ColoredSide.Parse("Rdd-43"));
        }

        [Test]
        public void TestEqualsAndHashCode()
        {
            var side1 = new ColoredSide(Color.Red, 7);
            var side2 = new ColoredSide(Color.Red, 7);

            Assert.IsTrue(side1.Equals(side2));
            Assert.AreEqual(side1.GetHashCode(), side2.GetHashCode());
            side2 = new ColoredSide(Color.Black, 7);
            Assert.IsFalse(side1.Equals(side2));
        }
    }
}
