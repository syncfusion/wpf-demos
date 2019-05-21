#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;

namespace AxisDateTimeRangeDemo
{
    public class SampleBehavior : Behavior<MainWindow>
    {
        DataViewModel view = new DataViewModel();
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.lblformat.ItemsSource = new string[] { "g", "MMM/dd/yyyy", "MMM/dd", "MM/dd/yyyy", "MM/dd", "hh:mm:ss", "MM/yyyy" };
            this.AssociatedObject.RangeDt.ItemsSource = new string[] { "Years of Data", "Months of Data", "Days of Data", "Hours of Data", "Minutes of Data" };
            this.AssociatedObject.rangedate.ItemsSource = new string[] { "3/19/2005 , 3/24/2011", "1/1/2005 , 1/1/2013" };
            this.AssociatedObject.Intertxt.ItemsSource = new string[] { "732:0:0:0", "366:0:0:0", "183:0:0:0" };
            this.AssociatedObject.PrimaryAxis.IsAutoSetRange = false;
            this.AssociatedObject.PrimaryAxis.Header = "Sales across Years";
            this.AssociatedObject.PrimaryAxis.DateTimeInterval = new TimeSpan(366, 0, 0, 0);
            this.AssociatedObject.PrimaryAxis.IsAutoSetRange = true;
            this.AssociatedObject.RangeDt.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(RangeDt_SelectionChanged);
            this.AssociatedObject.rangechk.Checked += new System.Windows.RoutedEventHandler(rangechk_Checked);
            this.AssociatedObject.rangechk.Unchecked += new System.Windows.RoutedEventHandler(rangechk_Unchecked);
            
        }

       

        void rangechk_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.rangedate.SelectedIndex = 0;            
        }

        void rangechk_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
        }

        void RangeDt_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (this.AssociatedObject.RangeDt.SelectedIndex)
            {
                case 0:
                    this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
                    this.AssociatedObject.rangedate.ItemsSource = new string[] { "3/19/2005 , 3/24/2011", "1/1/2005 , 1/1/2013" };
                    this.AssociatedObject.rangedate.SelectedIndex = 0;
                    this.AssociatedObject.Intertxt.ItemsSource = new string[] { "732:0:0:0", "366:0:0:0", "183:0:0:0" };
                    this.AssociatedObject.PrimaryAxis.LabelDateTimeFormat = "g";
                    this.AssociatedObject.Intertxt.SelectedIndex = 0;
                    if (this.AssociatedObject.PrimaryAxis.IsAutoSetRange == true)
                    {
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = false;
                        this.AssociatedObject.PrimaryAxis.DateTimeInterval = new TimeSpan(366, 0, 0, 0);
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = true;
                    }
                    this.AssociatedObject.PrimaryAxis.Header = "Sales across Years";
                    this.AssociatedObject.CarSeries.DataSource = view.AcrossYears;
                    break;
                case 1:
                    this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
                    this.AssociatedObject.rangedate.ItemsSource = new string[] { "1/1/2006 , 11/17/2006", "1/1/2006 , 6/10/2006" };
                    this.AssociatedObject.rangedate.SelectedIndex = 0;
                    this.AssociatedObject.CarSeries.DataSource = view.AcrossMonths;
                    this.AssociatedObject.Intertxt.ItemsSource = new string[] { "80:0:0:0", "40:0:0:0", "20:0:0:0" };
                    this.AssociatedObject.PrimaryAxis.LabelDateTimeFormat = "MMM/dd/yyyy";
                    this.AssociatedObject.Intertxt.SelectedIndex = 0;
                    if (this.AssociatedObject.PrimaryAxis.IsAutoSetRange == true)
                    {
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = false;
                        this.AssociatedObject.PrimaryAxis.DateTimeInterval = new TimeSpan(80, 0, 0, 0);
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = true;
                    }
                    this.AssociatedObject.PrimaryAxis.Header = "Sales across Months";
                    break;
                case 2:
                    this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
                    this.AssociatedObject.rangedate.ItemsSource = new string[] { "1/1/2006 , 1/10/2006","1/1/2006 , 1/7/2006"  };
                    this.AssociatedObject.rangedate.SelectedIndex = 0;
                    this.AssociatedObject.CarSeries.DataSource = view.Days;
                    this.AssociatedObject.Intertxt.ItemsSource = new string[] { "3:0:0:0", "2:0:0:0", "1:0:0:0" };
                    this.AssociatedObject.PrimaryAxis.LabelDateTimeFormat = "mm/dd/yyyy";
                    this.AssociatedObject.Intertxt.SelectedIndex = 0;
                    if (this.AssociatedObject.PrimaryAxis.IsAutoSetRange == true)
                    {
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = false;
                        this.AssociatedObject.PrimaryAxis.DateTimeInterval = new TimeSpan(3, 0, 0, 0);
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = true;
                    }
                    this.AssociatedObject.PrimaryAxis.Header = "Sales across Days";
                    break;
                case 3:
                    this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
                    this.AssociatedObject.rangedate.ItemsSource = new string[] {"1/1/2006 12:00 AM , 1/1/2006 12:00 PM","1/1/2006 12:00 AM , 1/1/2006 6:00 PM"  }; 
                    this.AssociatedObject.rangedate.SelectedIndex = 0;
                    this.AssociatedObject.CarSeries.DataSource = view.Hours;
                    this.AssociatedObject.Intertxt.ItemsSource = new string[] { "0:2:0:0", "0:1:30:0", "0:1:0:0" };
                    this.AssociatedObject.PrimaryAxis.LabelDateTimeFormat = "hh:mm:ss";
                    this.AssociatedObject.Intertxt.SelectedIndex = 0;
                    if (this.AssociatedObject.PrimaryAxis.IsAutoSetRange == true)
                    {
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = false;
                        this.AssociatedObject.PrimaryAxis.DateTimeInterval = new TimeSpan(0, 2, 0, 0);
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = true;
                    }
                    this.AssociatedObject.PrimaryAxis.Header = "Sales across Hours";
                    break;
                case 4:
                    this.AssociatedObject.PrimaryAxis.Interval = double.NaN;
                    this.AssociatedObject.rangedate.ItemsSource = new string[] { "1/1/2006 1:00 AM , 1/1/2006 1:12 AM", "1/1/2006 1:00 AM , 1/1/2006 1:8 AM" };
                    this.AssociatedObject.rangedate.SelectedIndex = 0;
                    this.AssociatedObject.CarSeries.DataSource = view.Minutes;
                    this.AssociatedObject.Intertxt.ItemsSource = new string[] { "0:0:4:00", "0:0:2:0", "0:0:1:0" };
                    this.AssociatedObject.PrimaryAxis.LabelDateTimeFormat = "hh:mm:ss";
                    this.AssociatedObject.Intertxt.SelectedIndex = 0;
                    if (this.AssociatedObject.PrimaryAxis.IsAutoSetRange == true)
                    {
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = false;
                        this.AssociatedObject.PrimaryAxis.DateTimeInterval = new TimeSpan(0, 0, 4, 0);
                        this.AssociatedObject.PrimaryAxis.IsAutoSetRange = true;
                    }
                    this.AssociatedObject.PrimaryAxis.Header = "Sales across Minutes";
                    break;
                default:
                    break;
            }
        }

        
    }
}
