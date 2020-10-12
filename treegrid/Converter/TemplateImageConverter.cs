#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace syncfusion.treegriddemos.wpf
{
    public class TemplateImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dataContextHelper = value as TreeGridDataContextHelper;           
            var record = dataContextHelper.Record as FileInfoModel;
            if (record.FileType == "Drive")
                return new BitmapImage(new Uri(@"/syncfusion.treegriddemos.wpf;component/Assets/treegrid/DriveNode.png", UriKind.Relative));
            else if (record.FileType == "Directory")
                return new BitmapImage(new Uri(@"/syncfusion.treegriddemos.wpf;component/Assets/treegrid/folder.png", UriKind.Relative));
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
