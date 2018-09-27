using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Shared;

namespace CalendarCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        private void excludeWeekendsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.SelectedIndex == 0)
                Gantt.ExcludeWeekends = false;
            else
                Gantt.ExcludeWeekends = true;
        }

        private void showWeekendsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.SelectedIndex == 0)
                Gantt.ShowWeekends = false;
            else
                Gantt.ShowWeekends = true;
        }
        private void weekendsComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            List<Days> days = new List<Days>();
            var value = list.SelectedItems.Cast<Days>();
            if(list.SelectedItems.Count>0)
            {
                for (int j = 0; j < list.SelectedItems.Count; j++)
                {
                    days.Add(value.ElementAt(j));
                }
            }           
            if(days.Count>0)
                Gantt.Weekends = days.Aggregate((i, t) => i | t);
        }

        private void weekendsComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            weekendsComboBox.SelectedItems.Add(Days.Sunday);
            weekendsComboBox.SelectedItems.Add(Days.Saturday);
        }
    }
}
