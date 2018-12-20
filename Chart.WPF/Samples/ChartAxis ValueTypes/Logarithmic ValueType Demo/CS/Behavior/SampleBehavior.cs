#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace LogarithmicValueRangeDemo
{
    public class SampleBehavior:Behavior<MainWindow>
    {
        DataViewModel view = new DataViewModel();
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.datacmb.ItemsSource = new string[] { "Data in Billions", "Data in Millions", "Data in Thousands" };
            this.AssociatedObject.datacmb.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(datacmb_SelectionChanged);
        }

        void datacmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            switch (this.AssociatedObject.datacmb.SelectedIndex)
            {
                case 0:
                    this.AssociatedObject.CarSeries.DataSource = view.SalesDetails;
                    break;
                case 1:
                    this.AssociatedObject.CarSeries.DataSource = view.Sales1Details;
                    break;
                case 2:
                    this.AssociatedObject.CarSeries.DataSource = view.Sales2Details;
                    break;
                default:
                    break;
            }
        }

        
    }
}
