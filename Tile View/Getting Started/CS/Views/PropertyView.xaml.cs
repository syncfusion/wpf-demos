#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TileViewConfigurationDemo
{
    /// <summary>
    /// Interaction logic for PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();
            row.MinValue = 3;
            col.MinValue = 3;
            AnimationSpan.MinValue = new TimeSpan(0, 0, 0, 0, 1);
            AnimationSpan.MaxValue = new TimeSpan(0, 0, 0, 30, 1);
        }
    }

    public class CloseModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "Hide")
            {
                return CloseMode.Hide;
            }

            return CloseMode.Delete;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString() == "Delete")
            {
                return CloseMode.Delete;
            }

            return CloseMode.Hide;
        }
    }
}
