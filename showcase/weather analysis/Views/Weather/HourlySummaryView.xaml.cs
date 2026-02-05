#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for HourlySummaryView.xaml.
    /// </summary>
    public partial class HourlySummaryView : UserControl
    {
        public HourlySummaryView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            sfChart.Dispose();
            if (this.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }
        }
    }
}
