#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string name = value.ToString();
            string filePath = @"/syncfusion.demoscommon.wpf;component/Assets/People/";

            if (name == "10000")
            {
                return filePath + "People_Circle14.png";
            }
            else if (name == "10001")
            {
                return filePath + "People_Circle17.png";
            }
            else if (name == "10002")
            {
                return filePath + "People_Circle1.png";
            }
            else if (name == "10003")
            {
                return filePath + "People_Circle16.png";
            }
            else if (name == "10004")
            {
                return filePath + "People_Circle0.png";
            }
            else if (name == "10005")
            {
                return filePath + "People_Circle15.png";
            }
            else if (name == "10006")
            {
                return filePath + "People_Circle5.png";
            }
            else if (name == "10007")
            {
                return filePath + "People_Circle26.png";
            }
            else if (name == "10008")
            {
                return filePath + "People_Circle26.png";
            }
            else if (name == "1009")
            {
                return filePath + "People_Circle8.png";
            }
            else if (name == "10011")
            {
                return filePath + "People_Circle27.png";
            }
            else if (name == "10012")
            {
                return filePath + "People_Circle3.png";
            }
            else if (name == "10013")
            {
                return filePath + "People_Circle21.png";
            }
            else if (name == "10014")
            {
                return filePath + "People_Circle23.png";
            }
            else if (name == "10015")
            {
                return filePath + "People_Circle18.png";
            }
            else if (name == "10016")
            {
                return filePath + "People_Circle2.png";
            }
            else
                return filePath + "People_Circle25.png";
             
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
