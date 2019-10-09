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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace CustomIntellisenseDemo
{

    public partial class IntellisenseItemProperties : Window
    {
        public IntellisenseItemProperties()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image Files |*.png;*.bmp;*.gif; *.jpg";
            fileDialog.Multiselect = false;
            if ((bool)fileDialog.ShowDialog())
            {
                txtIcon.SetValue(TextBox.TextProperty, fileDialog.FileName);
            }
        }

        private void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(text.Text))
                buttonok.IsEnabled = false;
            else
                buttonok.IsEnabled = true;
        }
    }

    public class BitmapImageToTextConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is BitmapImage)
            {
                BitmapImage image = value as BitmapImage;
                return image.UriSource.LocalPath;
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString().Trim() != string.Empty)
            {
                return new BitmapImage(new Uri(value.ToString()));
            }
            return null;
        }

        #endregion
    }

}
