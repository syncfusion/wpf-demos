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
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Globalization;
using System.Windows;
using System.Windows.Interop;
using System.Drawing;
using System.Windows.Media;

namespace MenuMerging
{
    public class CollectionConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                ViewModel vmodel = App.Current.MainWindow.DataContext as ViewModel;
                if (vmodel != null)
                {
                    if (vmodel.OtherCommands.Count > 0)
                    {
                        return vmodel.OtherCommands[0].Commands;
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ImageConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string imageSource = value.ToString();

                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Width = 16;
                image.Height = 16;
                image.Source = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
                return image;
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
