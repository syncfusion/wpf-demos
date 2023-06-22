#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class DataTableBindingViewModel
    {
        public DataTable ChartDataTable { get; set; }
        public DataTable ChartDataTable2 { get; set; }

        public DataTableBindingViewModel()
        {
            ChartDataTable = new DataTable();

            ChartDataTable.Columns.Add("Product", typeof(string));
            ChartDataTable.Columns.Add("Percentage", typeof(double));

            ChartDataTable.Rows.Add("Data Cable", 65);
            ChartDataTable.Rows.Add("Charger", 60);
            ChartDataTable.Rows.Add("Smartwatch", 75);
            ChartDataTable.Rows.Add("Earphone", 80);

            ChartDataTable2 = new DataTable();

            ChartDataTable2.Columns.Add("Product", typeof(string));
            ChartDataTable2.Columns.Add("Percentage", typeof(double));

            ChartDataTable2.Rows.Add("Data Cable", 60);
            ChartDataTable2.Rows.Add("Charger", 55);
            ChartDataTable2.Rows.Add("Smartwatch", 70);
            ChartDataTable2.Rows.Add("Earphone", 77);
        }
    }
}
