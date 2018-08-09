using Syncfusion.UI.Xaml.Charts;
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

namespace StepAreaChart
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

    public class Model
    {
        public string Brand { get; set; }

        public double ItemsCount { get; set; }

        public double ItemsCount1 { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.SneakersDetail = new ObservableCollection<Model>();

            SneakersDetail.Add(new Model() { Brand = "Adidas", ItemsCount = 30,ItemsCount1=20 });
            SneakersDetail.Add(new Model() { Brand = "Nike", ItemsCount = 27 ,ItemsCount1=14});
            SneakersDetail.Add(new Model() { Brand = "Reebok", ItemsCount = 44,ItemsCount1=20 });
            SneakersDetail.Add(new Model() { Brand = "Fila", ItemsCount = 28 ,ItemsCount1=10});
            SneakersDetail.Add(new Model() { Brand = "Puma", ItemsCount = 20 ,ItemsCount1=8});
        }

        public ObservableCollection<Model> SneakersDetail { get; set; }
    }
}
