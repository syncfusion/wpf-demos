#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.olapchartdemos.wpf
{
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Chart;
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows;
    using System.Windows.Controls;

    public class OrderReportCustomization : TargetedTriggerAction<OlapChart>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is SelectionChangedEventArgs)
            {
                ComboBox comboBox = (parameter as SelectionChangedEventArgs).Source as ComboBox;
                if (comboBox != null)
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    Target.OlapDataManager.SetCurrentReport(OlapReport(selectedValue));
                    Target.OlapDataManager.NotifyElementModified();
                    Target.ColorModel.Palette = ChartColorPalette.MixedFantasy;
                    Target.Legend.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// OLAP Report
        /// </summary>
        /// <returns>Returns the olap report.</returns>
        private OlapReport OlapReport(string productName)
        {
            OlapReport olapReport = new OlapReport();

            olapReport.Name = "ColumnChart";
            olapReport.CurrentCubeName = "Adventure Works";
            olapReport.ChartSettings.XAxisForeGround = System.Drawing.Color.DodgerBlue;
            olapReport.ChartSettings.YAxisForeGround = System.Drawing.Color.DodgerBlue;
            olapReport.ChartSettings.XAxisFontFace = FontStyles.Normal.ToString();
            olapReport.ChartSettings.YAxisFontFace = FontStyles.Normal.ToString();
            DimensionElement dimensionColumn = new DimensionElement();
            dimensionColumn.Name = "Product";
            dimensionColumn.AddLevel("Product Categories", "Category");

            if (productName != "All")
            {
                dimensionColumn.Hierarchy.LevelElements["Category"].IncludeAvailableMembers = true;
                dimensionColumn.Hierarchy.LevelElements["Category"].Add(productName);
            }

            MeasureElements meansureElements = new MeasureElements();
            meansureElements.Elements.Add(new MeasureElement() { Name = "Reseller Order Quantity" });

            DimensionElement dimensionRow = new DimensionElement();
            dimensionRow.Name = "Date";
            dimensionRow.AddLevel("Fiscal", "Fiscal Year");

            olapReport.CategoricalElements.Add(dimensionColumn);
            olapReport.CategoricalElements.Add(meansureElements);
            olapReport.SeriesElements.Add(dimensionRow);

            return olapReport;
        }
    }
}
