using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentagon.Domain
{
    /// <summary>
    /// Class to represent a Canvas with pentagons
    /// </summary>
    public class Canvas
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/>
        /// </summary>
        public Canvas() { pentagonList = new List<task2.Pentagon>(); }

        /// <summary>
        /// List of the <see cref="task2.Pentagon"/>
        /// </summary>
        public List<task2.Pentagon> pentagonList { get; set; }
    }
}
