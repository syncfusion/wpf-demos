#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Exposes DataTables for demonstrating direct data binding to charts.</summary>
    public class DataTableBindingViewModel : IDisposable
    {
        /// <summary>Gets or sets the primary product data table.</summary>
        public DataTable ChartDataTable { get; set; }

        /// <summary>Gets or sets the secondary product data table.</summary>
        public DataTable ChartDataTable2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataTableBindingViewModel"/> class.
        /// </summary>
        public DataTableBindingViewModel()
        {
            ChartDataTable = new DataTable();
            ChartDataTable.Columns.Add("Product", typeof(string));
            ChartDataTable.Columns.Add("Percentage", typeof(double));
            ChartDataTable.Rows.Add("Earphone", 80);
            ChartDataTable.Rows.Add("Smartwatch", 75);
            ChartDataTable.Rows.Add("Charger", 60);
            ChartDataTable.Rows.Add("Data Cable", 65);

            ChartDataTable2 = new DataTable();
            ChartDataTable2.Columns.Add("Product", typeof(string));
            ChartDataTable2.Columns.Add("Percentage", typeof(double));
            ChartDataTable2.Rows.Add("Earphone", 77);
            ChartDataTable2.Rows.Add("Smartwatch", 70);
            ChartDataTable2.Rows.Add("Charger", 55);
            ChartDataTable2.Rows.Add("Data Cable", 60);
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(ChartDataTable != null)
                ChartDataTable.Clear();

            if(ChartDataTable2 != null)
                ChartDataTable2.Clear();
        }
    }
}
