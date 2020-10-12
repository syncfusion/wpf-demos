#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Reports;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class CalculatedMembersViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatedMembersViewModel"/> class.
        /// </summary>
        public CalculatedMembersViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = CalculatedMembersModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = CalculatedMembersModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            this.olapDataManager = new OlapDataManager(ConnectionString);
            this.olapDataManager.SetCurrentReport(CalculatedReport());
        }
        #endregion

        #region Properties
        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }
        #endregion

        #region Sample Report
        private OlapReport CalculatedReport()
        {
            OlapReport olapReport = new OlapReport() { Name = "Calc.Report" };
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement internalDimension = new DimensionElement();
            internalDimension.Name = "Product";
            internalDimension.AddLevel("Product Categories", "Category");
            internalDimension.Hierarchy.LevelElements[0].Add(new MemberElement { Name = "Bikes" });

            //// Calculated Measure
            CalculatedMember calculatedMeasure1 = new CalculatedMember();
            calculatedMeasure1.Name = "Order on Discount";
            calculatedMeasure1.Expression = "[Measures].[Order Quantity] + ([Measures].[Order Quantity] * 0.10)";
            calculatedMeasure1.AddElement(new MeasureElement { Name = "Order Quantity" });
            calculatedMeasure1.FormatString = "Percent";

            //// Calculated Measure
            CalculatedMember calculatedMeasure2 = new CalculatedMember();
            calculatedMeasure2.Name = "Sales Range";
            calculatedMeasure2.AddElement(new MeasureElement { Name = "Sales Amount" });
            calculatedMeasure2.Expression = "IIF([Measures].[Sales Amount]>200000,\"High\",\"Low\")";

            // Calculated Dimension
            CalculatedMember calculateDimension = new CalculatedMember();
            calculateDimension.Name = "Bikes & Components";
            calculateDimension.Expression = "([Product].[Product Categories].[Category].[Bikes] + [Product].[Product Categories].[Category].[Components] )";
            calculateDimension.AddElement(internalDimension);

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Sales Amount" });
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Order Quantity" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            // Adding Calculated members in calculated member collection
            olapReport.CalculatedMembers.Add(calculatedMeasure1);
            olapReport.CalculatedMembers.Add(calculateDimension);
            olapReport.CalculatedMembers.Add(calculatedMeasure2);

            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            olapReport.CategoricalElements.Add(calculatedMeasure1);
            olapReport.CategoricalElements.Add(calculatedMeasure2);

            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SeriesElements.Add(calculateDimension);

            return olapReport;
        }
        #endregion
    }
}
