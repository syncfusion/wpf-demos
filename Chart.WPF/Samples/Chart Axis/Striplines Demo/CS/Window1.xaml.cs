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
using Syncfusion.Windows.Chart;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Collections.ObjectModel;
namespace StripLines
{

    public partial class Window1 : Window
    {
        #region Constructor
        /// <summary>
        /// Contrcutor for window1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>  
        public Window1()
        {
            InitializeComponent();
            this.SeriesDataSource();
           
            ChartStripLine cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Offset = (int)this.cmboffset.SelectedItem;
            cs.Width = (int)this.cmbStripWidth.SelectedItem;
            cs.RepeatEvery = (int)this.cmbstripRPFreq.SelectedItem;
            cs.Interior = conv.ConvertFromString(this.xStripInteriorOptions.SelectedItem.ToString().Trim()) as SolidColorBrush;
            cs.Text = new FormattedText(txtXStriplinetext.Text, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.Black);
            cs.TextRotationAngle = (int)txtRotationAngle.Value;           
            chart1.Areas[0].PrimaryAxis.StripLines.Add(cs);
        }
        #endregion

        #region Helper Methods
        #region DataPoints
        private void SeriesDataSource()
        {
            ///Data source for series     
            this.chart1.Areas[0].Series[0].DataSource = this.GetSampleData();
            //Binding X with  Day
            this.chart1.Areas[0].Series[0].BindingPathX = "Day";
            //Binding Y with  Production
            this.chart1.Areas[0].Series[0].BindingPathsY = new string[] { "Production" };

            this.chart1.Areas[0].SecondaryAxis.LabelFormat = "0`F";
            //adding combo Items
            foreach (MemberInfo info in typeof(Colors).GetMembers())
            {
                if (info is PropertyInfo)
                {
                    PropertyInfo pi = info as PropertyInfo;
                    xStripInteriorOptions.Items.Add(pi.Name);
                    yStripInteriorOptions.Items.Add(pi.Name);
                }
            }
            cmboffset.ItemsSource = new int[] { 0, 1, 2 };
            cmbStripWidth.ItemsSource = new int[] { 1, 2 };
            cmbstripRPFreq.ItemsSource = new int[] { 1, 2, 3, 4 };

            cmbstripPosition.ItemsSource = new int[] { 40, 50 };
            cmbstripLength.ItemsSource = new int[] { 10, 20 };
            cmbstripYRPFreq.ItemsSource = new int[] { 30, 40 };


        }
        #endregion

        ///Summary
        ///Add striplines to X and Y axis
        ///Summary
        BrushConverter conv = new BrushConverter();
        public void DefaultStriplines()
        {
            //Create a new Stripline
            ChartStripLine csX = new ChartStripLine();
            //Set whether this need to started from X Axis
            csX.StartFromAxis = true;
            //Set the offset from where this stripline should be placed
            csX.Offset = 2;
            //Set the width of the stripline
            csX.Width =20;
            //Set the interior of the stripline
            csX.Interior = this.Resources["imgBrush"] as ImageBrush;
            csX.IsPixelWidth = true;
            //Set the FormattedText of the Stripline
            csX.Text = new FormattedText("", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.Black);
            //Add the stripline to the Axis stripline collection
            chart1.Areas[0].PrimaryAxis.StripLines.Add(csX);

            //Create a new Stripline
            ChartStripLine csY = new ChartStripLine();
            //Set whether this need to started from X Axis
            csY.StartFromAxis = false;
            //Set the starting position of the stripline. This need to mentioned when the StartFromAxis is set as false
            csY.Start = 95;
            //Set the width of the stripline
            csY.Width = 2;
            //Set the interior of the stripline
            csY.Interior = App.Current.Resources["StriplineYInterior"] as LinearGradientBrush;
            //Set the FormattedText of the Stripline
            csY.Text = new FormattedText("Historical High - 95'F", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);
            //Add the stripline to the Axis stripline collection
            chart1.Areas[0].SecondaryAxis.StripLines.Add(csY);
        }
        #endregion

        #region Events
        /// <summary>
        /// Event for setting primaryaxis stripLine properties like offset,Width,Interior,RepeatEvery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void butaddstripline_Click(object sender, RoutedEventArgs e)
        {
            // Add a stripline along the x axis       
            //if (chart1.Areas[0].PrimaryAxis.StripLines.Count == 0)
            //    return;
            ChartStripLine cs = new ChartStripLine();//chart1.Areas[0].PrimaryAxis.StripLines[0];
            cs.StartFromAxis = true;
            cs.Offset = (int)this.cmboffset.SelectedItem;
            cs.Width = (int)this.cmbStripWidth.SelectedItem;
            cs.RepeatEvery = (int)this.cmbstripRPFreq.SelectedItem;
            cs.Interior = conv.ConvertFromString(this.xStripInteriorOptions.SelectedItem.ToString().Trim()) as SolidColorBrush;
            cs.Text = new FormattedText(txtXStriplinetext.Text, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.Black);
            cs.TextRotationAngle = (int)txtRotationAngle.Value;
            //SetXAxisStripLine();

            //// First clearing the existing strip lines (but this is not mandatory)
            //if (chart1.Areas[0].PrimaryAxis.StripLines.Count > 1)
            //    chart1.Areas[0].PrimaryAxis.StripLines.RemoveAt(1);

            chart1.Areas[0].PrimaryAxis.StripLines.Add(cs);
            return;
        }

        /// <summary>
        /// Event for setting secondary stripLine properties like offset,Width,Interior,RepeatEvery.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butaddYstripline_Click(object sender, RoutedEventArgs e)
        {
            // Add a stripline along the y axis
            ChartStripLine cs = new ChartStripLine();
            cs.StartFromAxis = false;
            cs.Start = (int)this.cmbstripPosition.SelectedItem;
            cs.Width = (int)this.cmbstripLength.SelectedItem;
            cs.RepeatEvery = (int)this.cmbstripYRPFreq.SelectedItem;
            cs.RepeatUntil = 100;
            cs.Interior = conv.ConvertFromString(this.yStripInteriorOptions.SelectedItem.ToString().Trim()) as SolidColorBrush;
            cs.Text = new FormattedText(txtStriplineYtext.Text, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, new Typeface("Arial"), 20, Brushes.Black);
            cs.TextRotationAngle = (int)this.txtRotationAngle1.Value;
            // First clearing the existing strip lines (but this is not mandatory)
            if (chart1.Areas[0].SecondaryAxis.StripLines.Count > 1)
                chart1.Areas[0].SecondaryAxis.StripLines.RemoveAt(1);
            chart1.Areas[0].SecondaryAxis.StripLines.Add(cs);
            return;

        }
        #region ClearStripLines
        private void butClearAll_Click(object sender, RoutedEventArgs e)
        {
            this.chart1.Areas[0].PrimaryAxis.StripLines.Clear();
            this.chart1.Areas[0].SecondaryAxis.StripLines.Clear();
        }
        #endregion
        #endregion

        #region Production
        /// <summary>
        /// Data Collection added with Day, Production
        /// </summary>
        /// <returns></returns>
        public List<ProductionInfo> GetSampleData()
        {
            List<ProductionInfo> list = new List<ProductionInfo>();
            DateTime dt = new DateTime(2009, 1, 5);

            list.Add(new ProductionInfo() { Day = dt, Production = 92 });
            list.Add(new ProductionInfo() { Day = dt.AddDays(1), Production = 75 });
            list.Add(new ProductionInfo() { Day = dt.AddDays(2), Production = 77 });
            list.Add(new ProductionInfo() { Day = dt.AddDays(3), Production = 95 });
            list.Add(new ProductionInfo() { Day = dt.AddDays(4), Production = 70 });
            list.Add(new ProductionInfo() { Day = dt.AddDays(5), Production = 55 });
            list.Add(new ProductionInfo() { Day = dt.AddDays(6), Production = 40 });

            return list;
        }
        #endregion

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                ChartStripLine sp = new ChartStripLine();
                chart1.Areas[0].SecondaryAxis.StripLines.Clear();
                chart1.Areas[0].PrimaryAxis.StripLines.Clear();

                List<ProductionInfo> source = chart1.Areas[0].Series[0].DataSource as List<ProductionInfo>;
                //chart1.Areas[0].Series[0].Type = ChartTypes.Column;

                foreach (ProductionInfo item in source)
                {
                    // add strip lines to YAxis
                    sp = new ChartStripLine();
                    sp.IsSegmented = true;
                    sp.Start = item.Production;
                    sp.Width = 4;
                    sp.Interior = App.Current.Resources["StriplineYInterior"] as LinearGradientBrush;
                    sp.StartFromAxis = false;
                    sp.SegmentStartValue = item.Day.ToOADate() - 1;
                    sp.SegmentEndValue = item.Day.ToOADate();

                    sp.Text = new FormattedText(item.Production.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);


                    chart1.Areas[0].SecondaryAxis.StripLines.Add(sp);


                    //add strip lines to XAxis
                    sp = new ChartStripLine();
                    sp.IsSegmented = true;
                    sp.Start = item.Day.ToOADate();
                    sp.Width = 4;
                    sp.Interior = App.Current.Resources["StriplineXInterior"] as LinearGradientBrush;
                    sp.StartFromAxis = false;
                    sp.SegmentStartValue = item.Production - 15;
                    sp.SegmentEndValue = item.Production;
                    if (source.IndexOf(item) != 0)
                        sp.Text = new FormattedText(item.Day.DayOfWeek.ToString(), CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 10, Brushes.Black);

                    chart1.Areas[0].PrimaryAxis.StripLines.Add(sp);

                }

            }
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            if (checkBox1.IsChecked == false)
            {
                chart1.Areas[0].SecondaryAxis.StripLines.Clear();
                chart1.Areas[0].PrimaryAxis.StripLines.Clear();
            }
        }

        private void pixelwidth_Checked(object sender, RoutedEventArgs e)
        {
            if (chart1 != null)
            {
                foreach (ChartAxis axis in chart1.Areas[0].Axes)
                {
                    foreach (ChartStripLine line in axis.StripLines)
                    {
                        line.IsPixelWidth = true;
                    }
                }
            }
        }

        private void pixelwidth_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (ChartAxis axis in chart1.Areas[0].Axes)
            {
                foreach (ChartStripLine line in axis.StripLines)
                {
                    line.IsPixelWidth = false;
                }
            }
        }


    }

    #region Data
    public class ProductionInfo
    {
        public DateTime Day { get; set; }
        public int Production { get; set; }
    }
    #endregion
}
