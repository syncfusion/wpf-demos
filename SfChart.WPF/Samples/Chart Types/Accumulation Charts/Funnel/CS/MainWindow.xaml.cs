using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace FunnelChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.list = new ObservableCollection<Data>();
            DateTime yr = new DateTime(2010, 5, 1);

            list.Add(new Data() { Category = "Iron",Percentage = 36});
            list.Add(new Data() { Category = "Zinc",Percentage = 32});
            list.Add(new Data() { Category = "Copper",Percentage = 34});
            list.Add(new Data() { Category = "Aluminium",Percentage = 41});
            list.Add(new Data() { Category = "Gold",Percentage = 42});
            list.Add(new Data() { Category = "Silver",Percentage = 42});
            list.Add(new Data() { Category = "Diamond",Percentage = 43});
        }

        public ObservableCollection<Data> list
        {
            get;
            set;
        }
    }

    public class Data
    {
        public String Category { get; set; }
        public double Percentage { get; set; }
    }
}
