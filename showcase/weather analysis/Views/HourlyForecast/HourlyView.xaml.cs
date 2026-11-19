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
