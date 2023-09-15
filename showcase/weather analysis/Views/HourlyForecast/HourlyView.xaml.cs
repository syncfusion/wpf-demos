#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for HourlyView.xaml
    /// </summary>
    public partial class HourlyView : UserControl
    {
        public HourlyView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            if (forecastList.DataContext is HourlyForecastViewModel hourlyForecastViewModel)
            {
                hourlyForecastViewModel.Dispose();
            }

            if (hourlyDataGrid.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }

            if (forecastList != null)
            {
                forecastList.ItemsSource = null;
                forecastList = null;
            }

            hourlyDataGrid.Dispose();
        }
    }
}
