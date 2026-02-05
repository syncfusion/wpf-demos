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
    /// Interaction logic for HistoricalWeatherView.xaml.
    /// </summary>
    public partial class HistoricalWeatherView : UserControl
    {
        public HistoricalWeatherView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            rainfallChart.Dispose();
            snowChart.Dispose();
            tempChart.Dispose();
            historicTabControl.Dispose();
            if (this.DataContext is HistoricalWeatherViewModel historicalWeatherViewModel)
            {
                historicalWeatherViewModel.Dispose();
            }
        }
    }
}
