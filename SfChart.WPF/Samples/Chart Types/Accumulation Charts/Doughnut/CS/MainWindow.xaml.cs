using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DoughnutChart
{   
    public partial class MainWindow : SampleLayoutWindow
    {
        DoughnutSeriesDemo doughnutSeries = new DoughnutSeriesDemo();

        MultipleDoughnutSeriesDemo multipleDoughnutSeries = new MultipleDoughnutSeriesDemo();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            if (contentcontrol != null && combobox != null)
            {
                if (combobox.SelectedIndex == 0)
                {
                    contentcontrol.Content = new DoughnutSeriesDemo();
                }
                else if (combobox.SelectedIndex == 1)
                {
                    contentcontrol.Content = new MultipleDoughnutSeriesDemo();
                }
            }
        }
    }

    public class Model
    {
        public string Category { get; set; }

        public double Percentage { get; set; }
    }

    public class Populations
    {
        public string Continent { get; set; }

        public string Countries { get; set; }

        public string States { get; set; }

        public double PopulationinStates { get; set; }

        public double PopulationinCountries { get; set; }

        public double PopulationinContinents { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Tax = new List<Model>();

            Tax.Add(new Model() { Category = "Total License", Percentage = 20d });
            Tax.Add(new Model() { Category = "Other", Percentage = 23d });
            Tax.Add(new Model() { Category = "Sales and Gross Receipt", Percentage = 12d });
            Tax.Add(new Model() { Category = "Corporation Net Income", Percentage = 28d });
            Tax.Add(new Model() { Category = "Individual Income", Percentage = 10d });
            Tax.Add(new Model() { Category = "Sales", Percentage = 10d });

            this.Population = new List<Populations>();

            Population.Add(new Populations() { Continent = "Asia", Countries = "China", States = "Taiwan", PopulationinContinents = 50.02, PopulationinCountries = 26.02, PopulationinStates = 18.02 });
            Population.Add(new Populations() { Continent = "Africa", Countries = "India", States = "Shandong", PopulationinContinents = 20.81, PopulationinCountries = 24, PopulationinStates = 8 });
            Population.Add(new Populations() { Continent = "Europe", Countries = "Nigeria", States = "Uttar Pradesh", PopulationinContinents = 15.37, PopulationinCountries = 12.81, PopulationinStates = 14.5 });
            Population.Add(new Populations() { Countries = "Ethiopia", States = "Maharashtra", PopulationinCountries = 8, PopulationinStates = 9.5 });
            Population.Add(new Populations() { Countries = "Germany", States = "Kano", PopulationinCountries = 8.37, PopulationinStates = 7.81 });
            Population.Add(new Populations() { Countries = "Turkey", States = "Lagos", PopulationinCountries = 7, PopulationinStates = 5 });
            Population.Add(new Populations() { States = "Oromia", PopulationinStates = 5 });
            Population.Add(new Populations() { States = "Amhara", PopulationinStates = 3 });
            Population.Add(new Populations() { States = "Hessen", PopulationinStates = 5.37 });
            Population.Add(new Populations() { States = "Bayern", PopulationinStates = 3 });
            Population.Add(new Populations() { States = "Istanbul", PopulationinStates = 4.5 });
            Population.Add(new Populations() { States = "Ankara", PopulationinStates = 2.5 });            
        }

        public IList<Model> Tax
        {
            get;
            set;
        }

        public IList<Populations> Population
        {
            get;
            set;
        }
    }
    public class Labelconvertor : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return String.Format("{0} %", value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }

    public class LegendConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
