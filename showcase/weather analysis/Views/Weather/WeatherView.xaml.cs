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
