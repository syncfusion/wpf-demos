#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace ChartAreaGridConfiguration
{
    public class DataViewModel
    {
        public DataViewModel()
        {
            this.power = new ObservableCollection<DataModel>();
            DateTime yr = new DateTime(2002, 5, 1);
            power.Add(new DataModel() { Year = yr.AddYears(0),  ger = 43, uk = 36, fra = 40 });
            power.Add(new DataModel() { Year = yr.AddYears(1),  ger = 45, uk = 32, fra = 43 });
            power.Add(new DataModel() { Year = yr.AddYears(2),  ger = 36, uk = 34, fra = 45 });
            power.Add(new DataModel() { Year = yr.AddYears(3),  ger = 41, uk = 41, fra = 43 });
            power.Add(new DataModel() { Year = yr.AddYears(4),  ger = 34, uk = 42, fra = 44 });
            power.Add(new DataModel() { Year = yr.AddYears(5),  ger = 34, uk = 42, fra = 48 });
            power.Add(new DataModel() { Year = yr.AddYears(6),  ger = 37, uk = 43, fra = 42 });
        }

        public ObservableCollection<DataModel> power { get; set; }

        public Array AlternateFillCollection
        {
            get
            {
                return Enum.GetValues(typeof(Syncfusion.Windows.Chart.AlternatingFillMode));
            }
        }

        public Array FillDirectionCollection
        {
            get
            {
                return Enum.GetValues(typeof(Orientation));
            }
        }
    }

    public class WatermarkVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Hidden;

        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }

        #endregion
    } 
}
