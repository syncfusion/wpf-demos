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
    using System.Data.OleDb;
    using System.Data;
    using SampleUtils;
    using System.Text;

    internal class TransactionModel : IDisposable
    {
        #region Members

        internal StringBuilder SqlQuery;
        private OleDbConnection dbConnection;

        #endregion

        #region Constructor

        public TransactionModel()
        {
            this.SqlQuery = new StringBuilder("Select Country,State,City,Year,Semester,Quarter,Month,Date,ProductCategory,ProductSubCategory,ProductName,Quantity from [Sheet1$]");
            try
            {
                string path = "";
                if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
                {
                    path = System.IO.Path.GetFullPath(@"..\..\common\Assets\");
                }
                else
                {
                    path = System.IO.Path.GetFullPath(@"..\..\..\common\Assets\");
                }
                this.dbConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + "\\Common\\Data\\Sales DB.xls;Extended Properties=Excel 8.0;");
            }
            catch
            {
                //Return
            }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal DataTable GetItemsSource()
        {
            if (this.dbConnection.State != ConnectionState.Open)
            {
                this.dbConnection.Open();
            }
            OleDbDataAdapter DbAdapter = new OleDbDataAdapter(this.SqlQuery.ToString(), this.dbConnection);
            DataSet SalesDataset = new DataSet();
            DbAdapter.Fill(SalesDataset, "Sales");
            this.dbConnection.Close();
            this.SqlQuery.Remove(0, this.SqlQuery.Length);
            return SalesDataset.Tables[0];
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.dbConnection != null)
                this.dbConnection.Dispose();
        }

        #endregion
    }
}
