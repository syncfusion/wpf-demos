#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for WeatherTile.xaml.
    /// </summary>
    public partial class WeatherTile : UserControl
    {
        public WeatherTile()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            if (this.DataContext is TodayWeatherTileViewModel todayWeatherTileViewModel)
                todayWeatherTileViewModel.Dispose();
        }
    }
}
