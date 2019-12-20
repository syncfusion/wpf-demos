#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace DatePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            (this.DataContext as DatePickerProperties).PropertyChanged += DatePickerDemo_PropertyChanged;
        }

        private new void Loaded(object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).SelectedIndex = 0;
        }

        void SelectorFormatStringChanged(object sender, SelectionChangedEventArgs e)
        {
            string formatstring = ((sender as ComboBox).SelectedItem as ComboBoxItem).Tag.ToString();
            if (DP1 != null)
                DP1.SelectorFormatString = formatstring;
            if (DP2 != null)
                DP2.SelectorFormatString = formatstring;
        }

        void DatePickerDemo_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Format")
            {
                if (DP2 != null)
                    DP2.FormatString = (sender as DatePickerProperties).Format;
                if (DP1 != null)
                    DP1.FormatString = (sender as DatePickerProperties).Format;
            }
        }
    }

    public class DatePickerProperties : NotificationObject
    {
        private String formatString = "d";

        public String Format
        {
            get { return formatString; }
            set { formatString = value; RaisePropertyChanged("Format"); }
        }
    }

    public class NotificationObject : INotifyPropertyChanged
    {
        public void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class FormatStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is ComboBoxItem)
            {
                ComboBoxItem item = value as ComboBoxItem;
                return item.Tag.ToString();
            }
            return "N";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value is ComboBoxItem)
            {
                ComboBoxItem item = value as ComboBoxItem;
                return item.Tag.ToString();
            }
            return "N";
        }
    }
}
