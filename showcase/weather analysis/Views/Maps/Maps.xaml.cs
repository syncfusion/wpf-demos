using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for Maps.xaml
    /// </summary>
    public partial class Maps : UserControl
    {
        public Maps()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            map.Dispose();
            if (this.DataContext is MapsViewModel mapsViewModel)
                mapsViewModel.Dispose();
        }
    }
}
