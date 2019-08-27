#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;
using System.Windows.Media.Imaging;

namespace WindowsExplorerDemo
{
    public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DriveInfo)
            {
                DriveInfo info = value as DriveInfo;
                if (info.IsReady)
                {
                    return "CD_Drive.png";
                }
                else
                {
                    return "dvddrive.png";
                }
            }
            else
            {

                return "folder.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ImageTruncater : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "CD_Drive.png";
            }
            else if (value is BitmapImage)
            {
                if (value.ToString().Contains("folder"))
                {
                    return "folderopen.png";
                }
                return value;
            }
            else
            {
                return "folderopen.png";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
