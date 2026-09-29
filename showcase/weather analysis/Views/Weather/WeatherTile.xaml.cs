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
