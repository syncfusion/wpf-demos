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
    /// Interaction logic for DayWeatherInfoView.xaml.
    /// </summary>
    public partial class DayWeatherInfoView : UserControl
    {
        public DayWeatherInfoView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            historicalWView.Dispose();
            hourlyDetailView.Dispose();
            hourlySummaryView.Dispose();

            if (innerTabcontrol != null)
            {
                innerTabcontrol.Dispose();
                innerTabcontrol = null;
            }

            if (this.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }
        }
    }
}
