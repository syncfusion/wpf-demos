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
    using Syncfusion.Windows.Client.Olap;
    using System.Windows.Controls;
    using System.IO;
    using System.Data.SqlServerCe;
    using System.Data;
    using System.Windows;
    using SampleUtils;
    using Microsoft.Xaml.Behaviors;

    public class ReportChangedAction : TargetedTriggerAction<OlapClient>, IDisposable
    {
        private SqlCeConnection con;
        public ReportChangedAction()
        {
            try
            {
                this.con = new SqlCeConnection();
                string dbConString = "";
                if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
                {
                    dbConString = System.IO.Path.GetFullPath(@"..\..\common\Assets\Common\Data\OfflineCube\");
                }
                else
                {
                    dbConString = System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Common\Data\OfflineCube\");
                }
                dbConString = dbConString.Remove(dbConString.LastIndexOf(@"\")) + @"\ReportsTable.sdf;Persist Security Info=False";
                this.con.ConnectionString = "DataSource=" + dbConString;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error in DB connection");
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected override void Invoke(object parameter)
        {
            SelectionChangedEventArgs eventArgs = parameter as SelectionChangedEventArgs;
            try
            {
                ComboBox reports = eventArgs.OriginalSource as ComboBox;
                if (reports != null && reports.Items.Count > 0)
                {
                    string reportname = reports.SelectedItem as string;
                    Stream reportStream = null;
                    this.con.Open();

                    SqlCeDataAdapter da = new SqlCeDataAdapter("Select * from ReportsTable", this.con);
                    DataSet dSet = new DataSet();
                    da.Fill(dSet);
                    DataTable table = dSet.Tables[0];

                    foreach (DataRow row in table.Rows)
                    {
                        if ((row.ItemArray[0] as string).Equals(reportname))
                        {
                            reportStream = new MemoryStream(row.ItemArray[1] as byte[]);
                            break;
                        }
                    }
                    this.Target.LoadReportStream(reportStream);
                    this.con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in read from DB");
            }
        }
        private void Dispose(bool disposing)
        {
            if (disposing && this.con != null)
                this.con.Dispose();
        }
    }
}
