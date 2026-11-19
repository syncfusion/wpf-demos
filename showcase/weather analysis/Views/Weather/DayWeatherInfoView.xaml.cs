using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for DayWeatherInfoView.xaml.
    /// </summary>
    public partial class DayWeatherInfoView : UserControl
    {
        public DayWeatherInfoView()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            historicalWView.Dispose();
            hourlyDetailView.Dispose();
            hourlySummaryView.Dispose();

            if (innerTabcontrol != null)
            {
                innerTabcontrol.Dispose();
                innerTabcontrol = null;
            }

            if (this.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }
        }
    }
}
