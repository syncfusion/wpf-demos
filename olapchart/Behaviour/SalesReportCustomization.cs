#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using Syncfusion.Windows.Chart.Olap;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Chart;
    using System.Windows;
    using Microsoft.Xaml.Behaviors;

    public class SalesReportCustomization : TargetedTriggerAction<OlapChart>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is System.Windows.Controls.SelectionChangedEventArgs)
            {
                string selectedValue = ((parameter as System.Windows.Controls.SelectionChangedEventArgs).Source as System.Windows.Controls.ComboBox).SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                this.Target.OlapDataManager.SetCurrentReport(OlapReport(selectedValue));
                this.Target.OlapDataManager.NotifyElementModified();
            }
            this.Target.Legend = new ChartLegend();
            this.Target.ColorModel.Palette = Syncfusion.Windows.Chart.ChartColorPalette.MixedFantasy;
            this.Target.ChartType = ChartTypes.Bar;
        }

        /// <summary>
        /// OLAP Report
        /// </summary>
        /// <returns>Returns the olap report.</returns>
        private OlapReport OlapReport(string year)
        {
            OlapReport olapReport = new OlapReport();

            olapReport.Name = "BarChartReport";
            olapReport.CurrentCubeName = "Adventure Works";
            olapReport.ChartSettings.XAxisForeGround = System.Drawing.Color.DodgerBlue;
            olapReport.ChartSettings.YAxisForeGround = System.Drawing.Color.DodgerBlue;
            olapReport.ChartSettings.XAxisFontFace = FontStyles.Normal.ToString();
            olapReport.ChartSettings.YAxisFontFace = FontStyles.Normal.ToString();
            DimensionElement dimensionRow = new DimensionElement();
            dimensionRow.Name = "Product";
            dimensionRow.AddLevel("Subcategory", "Subcategory");

            MeasureElements meansureElements = new MeasureElements();
            meansureElements.Elements.Add(new MeasureElement() { Name = "Internet Sales Amount" });

            DimensionElement dimensionColumn = new DimensionElement();
            dimensionColumn.Name = "Date";
            dimensionColumn.AddLevel("Fiscal", "Fiscal Year");
            dimensionColumn.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionColumn.Hierarchy.LevelElements["Fiscal Year"].Add(year);

            DimensionElement excludedDimensions = new DimensionElement();
            excludedDimensions.Name = "Product";
            excludedDimensions.AddLevel("Subcategory", "Subcategory");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].IncludeAvailableMembers = true;
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Helmets");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Vests");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Jerseys");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Mountain Bikes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Mountain Frames");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Road Bikes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Tires and Tubes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Touring Bikes");
            excludedDimensions.Hierarchy.LevelElements["Subcategory"].Add("Shorts");

            olapReport.CategoricalElements.Add(meansureElements);
            olapReport.CategoricalElements.Add(dimensionColumn);
            olapReport.SeriesElements.Add(dimensionRow, excludedDimensions);

            return olapReport;
        }
    }
}
