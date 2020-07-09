#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Primitives;
using Syncfusion.Windows.Shared;
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

namespace TemplateCustomization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    /// <summary>
    /// Represents a class that provides the template selector for the timepicker cell.
    /// </summary>
    public class MeridienCellTemplateSelector : DataTemplateSelector
    {
        private ResourceDictionary dictionary;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (dictionary == null)
            {
                dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("TemplateCustomization;component/Templates.xaml", UriKind.RelativeOrAbsolute);
            }

            var dateTime = (DateTimeWrapper)item;

            if (dateTime.AmPmString == "AM")
                return dictionary["AM"] as DataTemplate;
            else
                return dictionary["PM"] as DataTemplate;
        }
    }
}
