using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Convert between boolean and visibility
    /// </summary>
    public sealed class BooleanToVisibilityConverter : BoolToObjectConverter
    {
        /// <summary>
        /// a constructor to Convert between boolean and visibility
        /// </summary>
        public BooleanToVisibilityConverter()
        {
            TrueValue = Visibility.Visible;
            FalseValue = Visibility.Collapsed;
        }
    }
}