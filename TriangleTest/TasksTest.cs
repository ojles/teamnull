using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Triangle;
using Triangle.Domain;

namespace TriangleTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestReadTrianglesToSortedList()
        {
            var triangles = ProvideTriangles();
            const string trianglesFileName = "Triangles.txt";
            using (var fileStream = new FileStream(trianglesFileName, FileMode.Create, FileAccess.ReadWrite))
            {
                using (var streamWriter = new StreamWriter(fileStream))
                {
                    foreach (var triangle in triangles)
                    {
                        streamWriter.WriteLine(triangle);
                    }
                }
            }
            
            CollectionAssert.AreEquivalent(triangles, Tasks.ReadTrianglesToSortedList(trianglesFileName).Values.ToList());
        }
        
        [Test]
        public void TestTask3()
        {
            var triangles = ProvideTriangles();
            var triangleMap = Tasks.Task3(triangles);

            var orangeTrianglesExpectedList = new List<ColoredTriangle>
            {
                triangles[5]
            };

            var greenTrianglesExpectedList = new List<ColoredTriangle>
            {
                triangles[3],
                triangles[7]
            };

            Assert.AreEqual(triangleMap.Count, 2);
            CollectionAssert.AreEquivalent(triangleMap[Color.Orange], orangeTrianglesExpectedList);
            CollectionAssert.AreEquivalent(triangleMap[Color.Green], greenTrianglesExpectedList);
        }

        private static List<ColoredTriangle> ProvideTriangles()
        {
            return new List<ColoredTriangle>
            {
                ColoredTriangle.Parse("Red-2:Blue-2:Red-3"),
                ColoredTriangle.Parse("Black-8:Green-6:Purple-13"),
                ColoredTriangle.Parse("Yellow-4:Yellow-6:Red-3"),
                ColoredTriangle.Parse("Green-6:Green-10:Green-15"),
                ColoredTriangle.Parse("Orange-6:Yellow-9:Green-4"),
                ColoredTriangle.Parse("Orange-10:Orange-25:Orange-20"),
                ColoredTriangle.Parse("Red-6:Green-8:Blue-3"),
                ColoredTriangle.Parse("Green-14:Green-20:Green-7")
            };
        }
    }
}
