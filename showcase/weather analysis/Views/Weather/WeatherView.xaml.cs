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
    /// Interaction logic for WeatherView.xaml.
    /// </summary>
    public partial class WeatherView : UserControl
    {
        public WeatherView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            dayWeatherInfoView.Dispose();
            weatherTileView.Dispose();
            foreCastView.Dispose();
            dayDetailsView.Dispose();
            v_dayWeatherInfoView.Dispose();
            v_foreCastView.Dispose();
            v_weatherTileView.Dispose();
            v_dayDetailsView.Dispose();
        }
    }
}
