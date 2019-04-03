#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace TransactionView.Model
{
    using System;
    using System.Data.OleDb;
    using System.Data;
    using SampleUtils;
    using System.Text;

    internal class Model : IDisposable
    {
        #region Members

        internal StringBuilder SqlQuery;
        private OleDbConnection dbConnection;

        #endregion

        #region Constructor

        public Model()
        {
            this.SqlQuery = new StringBuilder("Select Country,State,City,Year,Semester,Quarter,Month,Date,ProductCategory,ProductSubCategory,ProductName,Quantity from [Sheet1$]");
            try
            {
                this.dbConnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + SampleSourceHelper.GetSamplePath() + "\\Common\\Data\\Sales DB.xls;Extended Properties=Excel 8.0;");
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