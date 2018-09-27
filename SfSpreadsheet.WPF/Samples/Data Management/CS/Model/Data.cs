using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using System.Data.SqlServerCe;
using System.Reflection;
using System.IO;

namespace ImportDataTable.Model
{
    public class Data
    {
        public static DataTable GetDataTable(string tablename)
        {
            if (!LayoutControl.IsInDesignMode)
            {
                using (SqlCeConnection con = new SqlCeConnection(string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"))))
                {
                    con.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter(string.Format("SELECT * FROM {0}", tablename), con);
                    DataTable ds = new DataTable();
                    sda.Fill(ds);
                    return ds;
                }
            }

            return new DataTable();
        }

       
    }

}
