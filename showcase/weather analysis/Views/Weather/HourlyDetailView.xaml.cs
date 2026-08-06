
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for HourlyDetailView.xaml.
    /// </summary>
    public partial class HourlyDetailView : UserControl
    {
        public HourlyDetailView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            if (forecastList != null)
            {
                forecastList.ItemsSource = null;
                forecastList = null;
            }

            if (this.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }
        }
    }
}
