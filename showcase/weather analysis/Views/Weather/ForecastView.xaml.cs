#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for ForecastView.xaml.
    /// </summary>
    public partial class ForecastView : UserControl
    {
        public ForecastView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            if (this.DataContext is DailyForecastViewModel dailyForecastViewModel)
            {
                dailyForecastViewModel.Dispose();
            }

            if (forecastList != null)
            {
                forecastList.ItemsSource = null;
                forecastList = null;
            }
        }
    }
}
