#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Reports_as_Stream.ViewModel
{
    using System;
    using System.Collections.Generic;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;
    using System.Data.SqlServerCe;
    using SampleUtils;
    using System.Windows;
    using System.Data;
    using System.IO;
    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class ViewModel : Syncfusion.Windows.Shared.NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;

        private DelegateCommand<object> saveCommand;
        private List<string> reportNames;

        private OlapDataManager olapDataManager;
        private SqlCeConnection con;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            try
            {
                this.olapDataManager = new OlapDataManager(ViewModel.ConnectionString);
                this.con = new SqlCeConnection();
                string dbConString = SampleSourceHelper.GetOfflineCubeLocation();
                dbConString = dbConString.Remove(dbConString.LastIndexOf(@"\")) + @"\ReportsTable.sdf;Persist Security Info=False";
                this.con.ConnectionString = "DataSource=" + dbConString;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in DB connection");
            }
        }
        #endregion

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public List<string> ReportNames
        {
            get
            {
                this.reportNames = this.reportNames ?? this.LoadReportNames();
                return this.reportNames;
            }
        }

        public DelegateCommand<object> SaveClick
        {
            get
            {
                this.saveCommand = this.saveCommand ?? new DelegateCommand<object>(DoSaveProcess);
                return this.saveCommand;
            }
            set { this.saveCommand = value; }
        }

        #endregion

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #region Helper Methods
        private void DoSaveProcess(object parm)
        {
            try
            {
                MemoryStream reportStream = null;
                if (this.ClientDataManager != null && this.ClientDataManager.Reports.Count > 0)
                {
                    Stream stream = this.ClientDataManager.GetReportAsStream();

                    if (stream != null)
                    {
                        reportStream = stream as MemoryStream;
                        ReportNameWindow saveReport = new ReportNameWindow(this.ReportNames);
                        saveReport.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        saveReport.Owner = App.Current.Windows[0];
                        if (saveReport.ShowDialog() == true)
                        {
                            string repotName = saveReport.ReportName;

                            this.con.Open();
                            SqlCeCommand cmd1 = new SqlCeCommand("insert into ReportsTable Values(@ReportName,@Report)", this.con);
                            cmd1.Parameters.Add("@ReportName", repotName);
                            cmd1.Parameters.Add("@Report", reportStream.ToArray());
                            cmd1.ExecuteNonQuery();
                            this.con.Close();
                            this.ReportNames.Add(saveReport.ReportName);
                            ((MainWindow)System.Windows.Application.Current.MainWindow).Load.Items.Refresh();
                            ((MainWindow)System.Windows.Application.Current.MainWindow).Load.ItemsSource = this.ReportNames;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error in save to DB");
            }
        }

        private List<string> LoadReportNames()
        {
            List<string> names = new List<string>();
            try
            {
                this.con.Open();
                SqlCeDataAdapter da = new SqlCeDataAdapter("Select * from ReportsTable", this.con);
                DataSet dSet = new DataSet();
                da.Fill(dSet);
                DataTable table = dSet.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    names.Add(row.ItemArray[0] as string);
                }
                this.con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in read from DB");
            }

            return names;
        }


        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.con != null)
                    this.con.Dispose();
                if (this.olapDataManager != null)
                    this.olapDataManager.Dispose();
            }
        }
        #endregion
    }
}
