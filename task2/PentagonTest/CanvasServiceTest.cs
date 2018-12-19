using Task2.Service;
using Task2.Domain;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PentagonTest
{
    [TestClass]
    public class CanvasServiceTest
    {
        public CanvasService canvasService = new CanvasService();

        [TestMethod]
        public void TestSaveCanvas()
        {
            Pentagon pentagon = new Pentagon();
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));

            Canvas canvas = new Canvas();
            canvas.AddPentagon(pentagon);

            canvasService.Save(canvas, "test1");

            Assert.IsTrue(File.Exists("test1"));
        }

        [TestMethod]
        public void TestGetCanvas()
        {
            Pentagon pentagon = new Pentagon();
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));
            pentagon.AddPoint(new Point(3, 2));

            Canvas canvas = new Canvas();
            canvas.AddPentagon(pentagon);

            canvasService.Save(canvas, "test2");

            Canvas retrievedCanvas = canvasService.Get("test2");

            Assert.AreEqual(retrievedCanvas.Pentagons.Count, canvas.Pentagons.Count);
        }
    }
}
