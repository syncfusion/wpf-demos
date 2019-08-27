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
using System.Collections.ObjectModel;
using PortfolioManager1.Helpers;
using System.Xml.Serialization;
using System.IO;
using Syncfusion.Windows.Controls.Grid;

namespace PortfolioManager1.Behaviors
{
    public class PerformanceChartBehavior : Behavior<Chart>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(delegate() { CustomizePerformanceChart(); }));
        }

        private void CustomizePerformanceChart()
        {
            DateTime MonthsMax = DateTime.Now;
            DateTime MonthsMin = DateTime.Now.AddMonths(-12);
            this.AssociatedObject.Areas[0].ColorModel.Palette = ChartColorPalette.Office2007Blue;
            this.AssociatedObject.Areas[0].PrimaryAxis.ValueType = ChartValueType.DateTime;
            this.AssociatedObject.Areas[0].PrimaryAxis.DateTimeRange = new DateTimeRange(MonthsMin, MonthsMax);
            this.AssociatedObject.Areas[0].SecondaryAxis.DesiredIntervalsCount = 5;
            ObservableCollection<Performance> seriesData1 = new ObservableCollection<Performance>();
            //foreach (Queries.DateAssetValue value in Queries.GetDateAndAssetValue("AmericanFunds", MonthsMin, MonthsMax))
            //    seriesData1.Add(new Performance(value.Date, Convert.ToDouble(value.AssetValue)));
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<Performance>));
            TextReader reader1 = new StreamReader(LayoutControl.FindFile("AmericanFundsPerf.xml"));
            seriesData1 = (ObservableCollection<Performance>)serializer.Deserialize(reader1);
            reader1.Close();

            this.AssociatedObject.Areas[0].Series["AmericanFunds"].DataSource = seriesData1;
            this.AssociatedObject.Areas[0].Series["AmericanFunds"].BindingPathX = "Date";
            this.AssociatedObject.Areas[0].Series["AmericanFunds"].BindingPathsY = new string[] { "AssetValue" };
            this.AssociatedObject.Areas[0].Series["AmericanFunds"].Label = "AmericanFunds";
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
