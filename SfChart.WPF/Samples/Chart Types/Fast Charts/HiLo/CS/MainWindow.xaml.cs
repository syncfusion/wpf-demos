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

namespace FastHiloChart
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
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
    }

    public class ViewModel
    {
        DateTime date = new DateTime(1999, 1, 1);

        public ViewModel()
        {
            List = new ObservableCollection<Model>();
            Random random = new Random();

            for (int k = 1; k <= 200; k++)
            {
                List.Add(new Model { Date = date.AddMonths(k), Stock = random.Next(30, 50), Price = random.Next(10, 30) });              
            }
        }

        public ObservableCollection<Model> List { get; set; }
    }
}
