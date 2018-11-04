using System;

namespace Pentagon
{
    /// <summary>
    /// Class to represent a pentagon in two-dimensional space
    /// </summary>
    [Serializable]
    public class Pentagon
    {
        public Color Color { get; set; }

        /// <summary>
        /// Points of pentagon vertices
        /// </summary>
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public Point D { get; set; }
        public Point E { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pentagon"/>
        /// </summary>
        public Pentagon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pentagon"/>
        /// </summary>
        /// <param name="color">Color of pentagon</param>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <param name="c">Point C</param>
        /// <param name="d">Point D</param>
        /// <param name="e">Point E</param>
        public Pentagon(Point a, Point b, Point c, Point d, Point e, Color color)
        {
            Color = color;
            A = a;
            B = b;
            C = c;
            D = d;
            E = e;
        }
    }
}