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
using Syncfusion.Windows.Chart;
using System.Windows.Controls;

namespace AxisDoubleRangeDemo
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
            this.AssociatedObject.serdata.ItemsSource = new string[] { "Data in Billions", "Data in Millions", "Data in Thousands" };
            this.AssociatedObject.rangecmb.ItemsSource = new string[] { "0,100000000000","0,150000000000" };
            this.AssociatedObject.interv.ItemsSource = new string[] { "25000000000", "50000000000" };
           // this.AssociatedObject.rangecmb.SelectedIndex = 0;
            //this.AssociatedObject.SecondaryAxis.IsAutoSetRange = false;
            //this.AssociatedObject.SecondaryAxis.Interval = 40000000000;
            //this.AssociatedObject.SecondaryAxis.IsAutoSetRange = true;
            this.AssociatedObject.serdata.SelectionChanged += new SelectionChangedEventHandler(serdata_SelectionChanged);
            this.AssociatedObject.isauto.Unchecked += new System.Windows.RoutedEventHandler(isauto_Unchecked);
        }

        void isauto_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.rangecmb.SelectedIndex = 0;
            switch (this.AssociatedObject.serdata.SelectedIndex)
            {
                case 0:
                    this.AssociatedObject.SecondaryAxis.Range = new DoubleRange(0, 150000000000);
                    break;
            }
        }

        void serdata_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (this.AssociatedObject.serdata.SelectedIndex)
            {
                case 0:
                    this.AssociatedObject.GrainSeries.DataSource = view.SalesDetails;
                    this.AssociatedObject.rangecmb.ItemsSource = new string[] { "0,10000000000","0,150000000000" };
                    this.AssociatedObject.rangecmb.SelectedIndex = 0;
                    this.AssociatedObject.interv.ItemsSource = new string[] { "25000000000", "50000000000" };
                    this.AssociatedObject.SecondaryAxis.DoubleDisplayUnit = Syncfusion.Windows.Chart.DoubleUnits.Billions;
                    break;
                case 1:
                    this.AssociatedObject.rangecmb.ItemsSource = new string[] { "0,100000000", "0,150000000" };
                    this.AssociatedObject.rangecmb.SelectedIndex = 0;
                    this.AssociatedObject.interv.ItemsSource = new string[] { "25000000", "50000000" };
                    this.AssociatedObject.GrainSeries.DataSource = view.MillionDetails;                   
                    this.AssociatedObject.SecondaryAxis.DoubleDisplayUnit = Syncfusion.Windows.Chart.DoubleUnits.Millions;
                    break;
                case 2:
                    this.AssociatedObject.rangecmb.ItemsSource = new string[] { "0,10000", "0,15000" };
                    this.AssociatedObject.rangecmb.SelectedIndex = 0;
                    this.AssociatedObject.interv.ItemsSource = new string[] {  "2500","5000"};
                    this.AssociatedObject.GrainSeries.DataSource = view.KDetails;                    
                    this.AssociatedObject.SecondaryAxis.DoubleDisplayUnit = Syncfusion.Windows.Chart.DoubleUnits.Thousands;
                    break;
                default:
                    break;
            }
        }

        
    }
}
