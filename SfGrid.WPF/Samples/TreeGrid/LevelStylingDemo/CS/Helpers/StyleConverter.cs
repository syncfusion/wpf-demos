#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LevelStylingDemo
{
    internal class StyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((value as TreeNode).Level == 0)
                return new SolidColorBrush(Colors.SkyBlue);
            else if ((value as TreeNode).Level == 1)
                return new SolidColorBrush(Color.FromArgb(255, 255, 211, 86));
            else if ((value as TreeNode).Level == 2)
                return new SolidColorBrush(Colors.LightGreen);
            else if ((value as TreeNode).Level == 3)
                return new SolidColorBrush(Colors.Bisque);
            else if ((value as TreeNode).Level == 4)
                return new SolidColorBrush(Colors.Pink);
            return new SolidColorBrush();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
