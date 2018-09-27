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
using System.Reflection;
using Syncfusion.Windows.Controls.Input;
using System.Windows.Threading;
using System.Globalization;

namespace SfMaskedEditDemo
{
    /// <summary>
    /// Interaction logic for MaskedEditDemo.xaml
    /// </summary>
    public partial class MaskedEditDemo : UserControl
    {
        public MaskedEditDemo()
        {
            InitializeComponent();
            deptime.Value = DateTime.Now.ToString("hh:mm:ss tt", new CultureInfo("en-US").DateTimeFormat);
        }

        private void culture_Loaded_1(object sender, RoutedEventArgs e)
        {
            List<CultureInfo> culturelist = new List<CultureInfo>();
            culturelist.Add(new CultureInfo("en-US"));
            culturelist.Add(new CultureInfo("en-IN"));
            culturelist.Add(new CultureInfo("de-DE"));
            culturelist.Add(new CultureInfo("uk-UA"));
            culturelist.Add(new CultureInfo("vi-VN"));
            culturelist.Add(new CultureInfo("ja-JP"));
            culturelist.Add(new CultureInfo("fr-FR"));
            ((ComboBox)sender).ItemsSource = culturelist;
            ((ComboBox)sender).SelectedIndex = 0;
        }

        private void Validation_Loaded_1(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).ItemsSource = Enum.GetValues(typeof(InputValidationMode));
            ((ComboBox)sender).SelectedIndex = 0;
        }
    }
}
