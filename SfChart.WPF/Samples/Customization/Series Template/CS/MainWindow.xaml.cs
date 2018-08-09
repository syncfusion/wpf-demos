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
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;

namespace CustomSeriesDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            ComboBox.SelectedIndex = 0;
        }

        private void ComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBoxIndex = (sender as ComboBox).SelectedIndex;

            if (comboBoxIndex == 0)
                ContentControl.Content = new ColumnSeries();
            else if (comboBoxIndex == 2)
                ContentControl.Content = new ScatterSeries();
           else if (comboBoxIndex == 3)
                ContentControl.Content = new SplineSeries();
           else if (comboBoxIndex == 1)
                ContentControl.Content = new CustomBarSeries(); 
        }
    }

    
    internal static class ChartDictionary
    {
        internal static ResourceDictionary GenericDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/CustomSeriesDemo;component/Resources/CustomTemplate.xaml", UriKind.Relative)
        };
    }
}
