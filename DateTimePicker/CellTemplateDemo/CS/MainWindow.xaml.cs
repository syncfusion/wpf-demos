#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace CellTemplateDemo
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

    public class DayCellTemplateSelector : DataTemplateSelector
    {
        private ResourceDictionary dictionary;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (dictionary == null)
            {
                dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("CellTemplateDemo;component/Templates.xaml", UriKind.RelativeOrAbsolute);
            }

            var dateTime = ((DateTimeWrapper)item).DateTime;
            if (dateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                return dictionary["DayCellTemplate0"] as DataTemplate;
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Monday)
            {
                return dictionary["DayCellTemplate1"] as DataTemplate;
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Tuesday)
            {
                return dictionary["DayCellTemplate2"] as DataTemplate;
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Wednesday)
            {
                return dictionary["DayCellTemplate3"] as DataTemplate;
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Thursday)
            {
                return dictionary["DayCellTemplate4"] as DataTemplate;
            }
            else if (dateTime.DayOfWeek == DayOfWeek.Friday)
            {
                return dictionary["DayCellTemplate5"] as DataTemplate;
            }
            else
            {
                return dictionary["DayCellTemplate6"] as DataTemplate;
            }
        }


    }



    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        private ResourceDictionary dictionary;
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (dictionary == null)
            {
                dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("CellTemplateDemo;component/Templates.xaml", UriKind.RelativeOrAbsolute);
            }

            var dateTime = ((DateTimeWrapper)item).DateTime;
            if (dateTime.Month == DateTime.Now.Month)
            {
                return dictionary["MonthCellTemplate0"] as DataTemplate;
            }
            else
            {
                if (dateTime.Month % 4 == 0)
                {
                    return dictionary["MonthCellTemplate1"] as DataTemplate;
                }
            }
            return dictionary["Default"] as DataTemplate;

        }


    }

    public class MeridienCellTemplateSelector : DataTemplateSelector
    {
        private ResourceDictionary dictionary;

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (dictionary == null)
            {
                dictionary = new ResourceDictionary();
                dictionary.Source = new Uri("CellTemplateDemo;component/Templates.xaml", UriKind.RelativeOrAbsolute);
            }

            var dateTime = (DateTimeWrapper)item;

            if (dateTime.AmPmString == "AM")
            {
                return dictionary["AM"] as DataTemplate;
            }
            else
            {

                return dictionary["PM"] as DataTemplate;
            }
        }

    }
}
