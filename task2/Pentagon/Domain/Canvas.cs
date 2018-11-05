using System.Collections.Generic;

namespace Task2.Domain
{
    /// <summary>
    /// Class to represent a Canvas with pentagons
    /// </summary>
    public class Canvas
    {
        /// <summary>
        /// List of the <see cref="Task2.Pentagon"/>
        /// </summary>
        public List<Pentagon> Pentagons { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/>
        /// </summary>
        public Canvas()
        {
            Pentagons = new List<Pentagon>();
        }

        /// <summary>
        /// Adds a <see cref="Pentagon"/> to current canvas
        /// </summary>
        public void AddPentagon(Pentagon pentagon)
        {
            Pentagons.Add(pentagon);
        }
    }
}
