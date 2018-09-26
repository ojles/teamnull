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
            const string trianglesFileName = "triangles.txt";
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
            
            CollectionAssert.AreEquivalent(triangles, Tasks.ReadTrianglesToSortedList(trianglesFileName).Keys.ToList());
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
                ColoredTriangle.Parse("Red-1:Blue-2:Red-3"),
                ColoredTriangle.Parse("Black-4:Green-5:Purple-13"),
                ColoredTriangle.Parse("Yellow-4:Yellow-6:Red-3"),
                ColoredTriangle.Parse("Green-3:Green-1:Green-15"),
                ColoredTriangle.Parse("Orange-6:Yellow-9:Green-3"),
                ColoredTriangle.Parse("Orange-1:Orange-2:Orange-20"),
                ColoredTriangle.Parse("Red-5:Green-8:Blue-2"),
                ColoredTriangle.Parse("Green-14:Green-20:Green-3")
            };
        }
    }
}