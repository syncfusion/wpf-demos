using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CustomMetroStyle
{
    /// <summary>
    /// Class contains Metro Style Names and Corrsponding Brushes
    /// </summary>
    public class MetroStyleColor
    {
        public Brush Brush { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroStyleColor"/> class.
        /// </summary>
        public MetroStyleColor()
        {
        }
    }
}
