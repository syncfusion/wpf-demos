#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
    public class CellMergeImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string name = value.ToString();
            string filePath = @"/syncfusion.demoscommon.wpf;component/Assets/People/";

            if (name == "FRANS")
            {
                return filePath + "People_Circle14.png";
            }
            else if (name == "VAFFE")
            {
                return filePath + "People_Circle17.png";
            }
            else if (name == "MEREP")
            {
                return filePath + "People_Circle1.png";
            }
            else if (name == "FOLKO")
            {
                return filePath + "People_Circle16.png";
            }
            else if (name == "WELLI")
            {
                return filePath + "People_Circle0.png";
            }
            else if (name == "SIMOB")
            {
                return filePath + "People_Circle15.png";
            }
            else if (name == "WARTH")
            {
                return filePath + "People_Circle5.png";
            }
            else if (name == "FRANS")
            {
                return filePath + "People_Circle26.png";
            }
            else if (name == "MORGK")
            {
                return filePath + "People_Circle26.png";
            }
            else if (name == "ANTON")
            {
                return filePath + "People_Circle8.png";
            }
            else if (name == "FURIB")
            {
                return filePath + "People_Circle27.png";
            }
            else if (name == "SEVES")
            {
                return filePath + "People_Circle3.png";
            }
            else if (name == "RICSU")
            {
                return filePath + "People_Circle21.png";
            }
            else if (name == "BERGS")
            {
                return filePath + "People_Circle23.png";
            }
            else if (name == "BOLID")
            {
                return filePath + "People_Circle18.png";
            }
            else if (name == "BLONP")
            {
                return filePath + "People_Circle2.png";
            }
            else if (name == "LINOD")
            {
                return filePath + "People_Circle31.png";
            }
            else if (name == "FOLIG")
            {
                return filePath + "People_Circle31.png";
            }
            else if (name == "PICCO")
            {
                return filePath + "People_Circle32.png";
            }
            else if (name == "RISCU")
            {
                return filePath + "People_Circle33.png";
            }

            return filePath + "People_Circle34.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
