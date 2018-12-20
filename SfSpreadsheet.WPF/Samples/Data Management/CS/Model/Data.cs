#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
            using (SqlCeConnection con = new SqlCeConnection(string.Format(@"Data Source = {0}", @"..\..\..\..\..\..\Common\Data\Northwind.sdf")))
            {
                con.Open();
                SqlCeDataAdapter sda = new SqlCeDataAdapter(string.Format("SELECT * FROM {0}", tablename), con);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                return ds;
            }
        }

       
    }

}
