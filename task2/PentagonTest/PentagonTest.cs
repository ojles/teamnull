using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2.Domain;

namespace PentagonTest
{
    [TestClass]
    public class PentagonTest
    {
        [TestMethod]
        public void TestPentagonIsCompleted()
        {
            Pentagon pentagon = new Pentagon();
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            Assert.IsFalse(pentagon.IsCompleted());
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            Assert.IsTrue(pentagon.IsCompleted());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestPentagonPointOverflow()
        {
            Pentagon pentagon = new Pentagon();
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
            pentagon.AddPoint(new Point(1, 2));
        }
    }
}
