#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace FastRangeAreaChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Model
    {
        public DateTime Date { get; set; }
        public double LowTemperature { get; set; }
        public double HighTemperature { get; set; }
    }

    public class ViewModel
    {
        DateTime date = new DateTime(2017, 1, 1);

        public ViewModel()
        {
            List = new ObservableCollection<Model>();
            Random random = new Random();

            double value = 0d;

            for (int k = 1; k < 365; k++)
            {
                if(k==1)
                {
                    value = 20d;
                }
                if (k == 15)
                {
                    value = 21d;
                }
                else if (k == 30)
                {
                    value = 22d;
                }
                else if (k == 45)
                {
                    value = 23d;
                }
                else if (k == 60)
                {
                    value = 24d;
                }
                else if (k == 75)
                {
                    value = 25d;
                }
                else if (k == 90)
                {
                    value = 26d;
                }
                else if (k == 105)
                {
                    value = 27d;
                }
                else if (k == 120)
                {
                    value = 28d;
                }
                else if (k == 135)
                {
                    value = 29d;
                }
                else if (k == 150)
                {
                    value = 28d;
                }
                else if (k == 165)
                {
                    value = 27d;
                }
                else if (k == 180)
                {
                    value = 26d;
                }
                else if (k == 195)
                {
                    value = 25d;
                }
                else if (k == 210)
                {
                    value = 24d;
                }
                else if (k == 225)
                {
                    value = 23d;
                }
                else if (k == 240)
                {
                    value = 22d;
                }
                else if (k == 255)
                {
                    value = 21d;
                }
                else if (k == 260)
                {
                    value = 20d;
                }
                else if (k == 275)
                {
                    value = 20d;
                }
                else if (k == 290)
                {
                    value = 19d;
                }
                else if (k == 305)
                {
                    value = 19d;
                }
                else if (k == 320)
                {
                    value = 18d;
                }
                else if (k == 335)
                {
                    value = 18d;
                }
                else if (k == 350)
                {
                    value = 17d;
                }

                if (random.NextDouble() > 0.5)
                {
                    value += random.NextDouble();
                }
                else
                {
                    value -= random.NextDouble();
                }

                List.Add(new Model { Date = date.AddDays(k - 1), HighTemperature = value + 2, LowTemperature = value - 2 });        
            }
        }

        public ObservableCollection<Model> List { get; set; }
    }
    
    public class DegreeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var roundValue = string.Format("{0:0.00}", double.Parse(value.ToString()));
            return roundValue + " °C";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

    public class DateFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((FastRangeAreaChart.Model)((Syncfusion.UI.Xaml.Charts.ChartPointInfo)value).Item).Date.ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
