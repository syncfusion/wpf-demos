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
using Syncfusion.Windows.Primitives;

namespace SfRatingDemo
{
    /// <summary>
    /// Interaction logic for RatingControlDemo.xaml
    /// </summary>
    public partial class RatingControlDemo : UserControl
    {
        public RatingControlDemo()
        {
            InitializeComponent();
        }

        private void precision_Loaded_1(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).ItemsSource = Enum.GetValues(typeof(Precision));
            ((ComboBox)sender).SelectedIndex = 0;
        }
    }
}
