using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// A Custom <see cref="Frame"/> control designed to host demo content within the sample browser. it is configured to prevent its content from automatically inheriting certain dependency properties. 
    /// </summary>
    public class DemosFrame : Frame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemosFrame"/> class.
        /// </summary>
        public DemosFrame()
        {
            this.InheritanceBehavior = System.Windows.InheritanceBehavior.SkipToThemeNext;
        }
    }
}
