#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using System;
    using SampleUtils;
    using Syncfusion.Olap.Reports;

    public class OlapGridDemoModel : SampleWindow
    {
        public static OlapReport Report()
        {
            OlapReport olapReport = new OlapReport() { Name = "GridReport" };
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement internalDimension = new DimensionElement();
            internalDimension.Name = "Product";
            internalDimension.AddLevel("Product Categories", "Category");
            internalDimension.Hierarchy.LevelElements[0].Add(new MemberElement { Name = "Bikes" });

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Sales Amount" });
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Order Quantity" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            DimensionElement dimensionElementSlicer = new DimensionElement();
            dimensionElementSlicer.Name = "Sales Channel";
            dimensionElementSlicer.AddLevel("Sales Channel", "Sales Channel");

            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);

            //Adding Slicer Elements
            olapReport.SlicerElements.Add(dimensionElementSlicer);


            return olapReport;
        }
    }
}
