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
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;

    public class ReportCustomization : TargetedTriggerAction<OlapChart>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is SelectionChangedEventArgs)
            {
                var comboBox = (parameter as SelectionChangedEventArgs).Source as ComboBox;
                if (comboBox != null)
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    Target.OlapDataManager.SetCurrentReport(OlapReport(selectedValue));
                    Target.Legend.RowsCount = comboBox.SelectedIndex == 0 ? 2 : 1;
                }
                Target.Legend.Visibility = Visibility.Visible;
                Target.ChartType = Syncfusion.Windows.Chart.ChartTypes.Line;
                Target.OlapDataManager.NotifyElementModified();
            }
        }

        /// <summary>
        /// OLAP Report.
        /// </summary>
        /// <returns>Returns the olap report.</returns>
        private OlapReport OlapReport(string countryName)
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";
            olapReport.ChartSettings.BorderColor = System.Drawing.Color.FromArgb(204, 204, 204);
            olapReport.ChartSettings.StrokeThickness = 1;
            olapReport.ChartSettings.XAxisForeGround = System.Drawing.Color.DodgerBlue;
            olapReport.ChartSettings.YAxisForeGround = System.Drawing.Color.DodgerBlue;
            olapReport.ChartSettings.XAxisFontFace = FontStyles.Normal.ToString();
            olapReport.ChartSettings.YAxisFontFace = FontStyles.Normal.ToString();
            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the dimension Element name
            dimensionElementColumn.Name = "Customer";
            // Adding level Element along with Hierarchy Element
            dimensionElementColumn.AddLevel("Customer Geography", "Country");
            if (countryName != "All")
            {
                dimensionElementColumn.Hierarchy.LevelElements["Country"].IncludeAvailableMembers = true;
                dimensionElementColumn.Hierarchy.LevelElements["Country"].Add(countryName);
            }

            DimensionElement dimensionElementColumnMonth = new DimensionElement();
            // Specifying the dimension Element name
            dimensionElementColumnMonth.Name = "Date";
            // Adding level Element along with Hierarchy Element
            dimensionElementColumnMonth.AddLevel("Month of Year", "Month of Year");

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the measure elements
            measureElementColumn.Elements.Add(new MeasureElement { UniqueName = "[Measures].[Growth in Customer Base]" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the dimension Element name
            dimensionElementRow.Name = "Date";
            // Adding level Element along with Hierarchy Element
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            dimensionElementRow.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionElementRow.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2004");

            // Adding the Column Elements
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding the Measure Elements
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding the month column
            olapReport.CategoricalElements.Add(dimensionElementRow);
            // Adding the Row Elements
            olapReport.SeriesElements.Add(dimensionElementColumnMonth);
            return olapReport;
        }
    }
}
