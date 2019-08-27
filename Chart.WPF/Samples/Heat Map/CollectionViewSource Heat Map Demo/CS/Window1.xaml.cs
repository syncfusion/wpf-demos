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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Globalization;
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.Shared;

namespace CollectionViewSource
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //Call to inlize ythe control with Default Values
            this.InitilizeControl();

        }
        #region Helper Methods
        private void InitilizeControl()
        {
            this.heatMap.AddHandler(HeatMapItem.MouseMoveEvent, new MouseEventHandler(this.heatMapItem_MouseEnter));

            sliderColor.Maximum = 100000.0;
            sliderColor.Minimum = 42433.0;
        }
        #endregion
        List<DependencyObject> hitTestList = new List<DependencyObject>();
        #region Events

        //Raised When Mouse is entered inside HeatMapItem
        private void heatMapItem_MouseEnter(object sender, MouseEventArgs e)
        {
            hitTestList.Clear();
            Point pt = e.GetPosition(sender as IInputElement);
            
            VisualTreeHelper.HitTest(
                sender as Visual,
                null,
                CollectAllVisuals_Callback,
                new PointHitTestParameters(pt));
            hitTestList.Reverse();

            HeatMapItem item = null;
            foreach (DependencyObject element in hitTestList)
            {
                if (element.GetType().Name.Equals("Border"))
                {
                    item = ((Border)element).TemplatedParent as HeatMapItem;
                    if (item != null)
                    {
                        RegionalSales rr = item.Header as RegionalSales;
                        this.txtName.Text = rr.Name;
                        this.txtCountry.Text = rr.Country;
                        this.txtSales.Text = string.Format("${0}", rr.Sales);
                        this.txtExpense.Text = string.Format("${0}", rr.Expense);
                    }
                }
            }
        }

        HitTestResultBehavior CollectAllVisuals_Callback(HitTestResult result)
        {
            if (result == null || result.VisualHit == null)
                return HitTestResultBehavior.Stop;

            hitTestList.Add(result.VisualHit);
            return HitTestResultBehavior.Continue;
        }
     //Raised when Slider value gets changed
        private void sliderColor_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            double val = (e.NewValue  / sliderColor.Maximum) * 100;            
            this.heatMap.MedianWeight = (int)val ;
            double sliderWidth = this.sliderColor.Width;
            double sliderHeight = this.sliderColor.Height;
            //New LinearGradientBrush is Declared
            LinearGradientBrush brush = new LinearGradientBrush();
            brush.StartPoint = new Point(0, 0.5);
            brush.EndPoint = new Point(1, 0.5);
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.LowestWeightColor, Offset = 0 });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.MedianWeightColor, Offset = (((double)this.heatMap.MedianWeight / 100)) });
            brush.GradientStops.Add(new GradientStop() { Color = this.heatMap.HighestWeightColor, Offset = 1 });
            //Sets the slider background
            this.sliderColor.Background = brush;
        }
        #endregion
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.highColorValue.Content += this.heatMap.ColorWeightsInfo.HighestValue.ToString();
            this.lowColorValue.Content += this.heatMap.ColorWeightsInfo.LowestValue.ToString();
        }
    }   
}
