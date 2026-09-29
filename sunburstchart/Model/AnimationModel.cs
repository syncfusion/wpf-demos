using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.sunburstchartdemos.wpf
{
    /// <summary>
    /// Represents a model for animation data containing geographic and population information.
    /// </summary>
    public class AnimationModel
    {
        /// <summary>
        /// Gets or sets the continent name.
        /// </summary>
        public string Continent { get; set; }

        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the state name.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the population value.
        /// </summary>
        public double Population { get; set; }
    }
}
