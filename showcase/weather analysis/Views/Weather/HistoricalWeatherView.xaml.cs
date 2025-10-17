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
