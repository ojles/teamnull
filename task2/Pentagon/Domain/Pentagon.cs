using System;
using System.Collections.Generic;

namespace Task2.Domain
{
    /// <summary>
    /// Class to represent a pentagon in two-dimensional space
    /// </summary>
    [Serializable]
    public class Pentagon
    {
        private const int PointAmount = 5;
        public Color Color { get; set; }

        /// <summary>
        /// Points of pentagon vertices
        /// </summary>
        public List<Point> Points = new List<Point>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Pentagon"/>
        /// </summary>
        public Pentagon()
        {
        }

        public void AddPoint(Point point)
        {
            if (IsCompleted())
            {
                throw new IndexOutOfRangeException("The pentagon has already all points set");
            }
            Points.Add(point);
        }

        public bool IsCompleted()
        {
            return Points.Count == PointAmount;
        }
    }
}
