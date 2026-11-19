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
