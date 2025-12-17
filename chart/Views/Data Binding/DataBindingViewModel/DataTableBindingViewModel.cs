using System;
using System.Data;

namespace syncfusion.chartdemos.wpf
{
    public class DataTableBindingViewModel : IDisposable
    {
        public DataTable ChartDataTable { get; set; }
        
        public DataTable ChartDataTable2 { get; set; }

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

        public void Dispose()
        {
            if(ChartDataTable != null)
                ChartDataTable.Clear();

            if(ChartDataTable2 != null)
                ChartDataTable2.Clear();
        }
    }
}
