using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for HourlySummaryView.xaml.
    /// </summary>
    public partial class HourlySummaryView : UserControl
    {
        public HourlySummaryView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            sfChart.Dispose();
            if (this.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }
        }
    }
}
