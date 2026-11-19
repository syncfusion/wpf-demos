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
    /// Represents a model used for zoomable sunburst chart visualization.
    /// </summary>
    public class ZoomableSunburstModel
    {
        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the job description.
        /// </summary>
        public string JobDescription { get; set; }

        /// <summary>
        /// Gets or sets the job group.
        /// </summary>
        public string JobGroup { get; set; }

        /// <summary>
        /// Gets or sets the job role.
        /// </summary>
        public string JobRole { get; set; }

        /// <summary>
        /// Gets or sets the number of employees.
        /// </summary>
        public double EmployeesCount { get; set; }
    }
}
