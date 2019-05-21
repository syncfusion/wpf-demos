#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

namespace SelectionBehavior
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton select = sender as RadioButton;
            if((bool)select.IsChecked)
            {
                selection.EnableSeriesSelection = false;
                selection.EnableSegmentSelection = true;               
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            RadioButton select = sender as RadioButton;
            if ((bool)select.IsChecked)
            {
                selection.EnableSegmentSelection = false;
                selection.EnableSeriesSelection = true;                                              
            }
        }

        private void chart_SelectionChanged(object sender, ChartSelectionChangedEventArgs e)
        {
            if (e.IsDataPointSelection && e.SelectedSeries!=null)
            {
                if (e.SelectedSeries.Label == "2013")
                {
                    column1.SelectedIndex = -1;
                }
                else
                    column.SelectedIndex = -1;
            }
           
        }

        private void selectionModeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Convert.ToString(selectionModeCombo.SelectedValue) == "MouseMove")
            {
                selectionStyleCombo.SelectedItem = "Single";
                selectionStyleCombo.Opacity = 0.2;
                selectionStyleTextBlock.Opacity = 0.2;
                selectionStyleCombo.IsEnabled = false;
            }
            else
            {
                selectionStyleCombo.Opacity = 1;
                selectionStyleTextBlock.Opacity = 1;
                selectionStyleCombo.IsEnabled = true;
            }
        }
    }

    public class Sales
    {
        public double Year2013
        {
            get;
            set;
        }
        public double Year2014
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }      
    }

    public class SeriesSelectionChartViewModel
    {
        public ObservableCollection<Sales> SalesCollection
        {
            get;
            set;
        }
        public SeriesSelectionChartViewModel()
        {
            SalesCollection = new ObservableCollection<Sales>();
            SalesCollection.Add(new Sales() { Category = "Samsung", Year2013 = 32.5, Year2014 = 28.0 });
            SalesCollection.Add(new Sales() { Category = "Apple", Year2013 = 16.6, Year2014 = 16.4 });
            SalesCollection.Add(new Sales() { Category = "Sony", Year2013 = 4.1, Year2014 = 3.9 });
            SalesCollection.Add(new Sales() { Category = "LG", Year2013 = 4.3, Year2014 = 6.0 });
            SalesCollection.Add(new Sales() { Category = "ZTE", Year2013 = 3.2, Year2014 = 3.1 });
        }

        public Array SelectionModes
        {
            get
            {
                return Enum.GetValues(typeof(Syncfusion.UI.Xaml.Charts.SelectionMode));
            }
        }
        public Array SelectionStyles
        {
            get
            {
                return Enum.GetValues(typeof(SelectionStyle));
            }
        }
    }
    
}
