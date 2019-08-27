#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlServerCe;

namespace DetailsViewDataTableBinding
{
    public class ViewModel : NotificationObject
    {
        string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            DataCollection = GetDataTable();
        }

        private DataTable _dataCollection;

        /// <summary>
        /// Gets or sets the data collection.
        /// </summary>
        /// <value>The data collection.</value>
        public DataTable DataCollection
        {
            get { return _dataCollection; }
            set { _dataCollection = value; }
        }

        /// <summary>
        /// Gets the data table.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataSet ds = new DataSet();
            if (!LayoutControl.IsInDesignMode)
            {
                connectionString = string.Format(@"Data Source = {0}", LayoutControl.FindFile("Northwind.sdf"));
                using (SqlCeConnection con = new SqlCeConnection(connectionString))
                {

                    con.Open();
                    SqlCeDataAdapter sda = new SqlCeDataAdapter("SELECT * FROM Suppliers", con);
                    sda.Fill(ds, "Suppliers");
                }

                using (SqlCeConnection con1 = new SqlCeConnection(connectionString))
                {
                    con1.Open();
                    SqlCeDataAdapter sda1 = new SqlCeDataAdapter("SELECT * FROM Products", con1);
                    sda1.Fill(ds, "Products");
                }
                ds.Relations.Add(new DataRelation("Supplier_Product", ds.Tables[0].Columns["Supplier ID"], ds.Tables[1].Columns["Supplier ID"]));
            }
            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
    }
}
