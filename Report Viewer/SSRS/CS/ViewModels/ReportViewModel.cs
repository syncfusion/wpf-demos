#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Input;
using System.Net;
using System.IO;
using Syncfusion.Windows.Reports.Viewer;
using System.Collections.Generic;
using Syncfusion.Windows.Reports;

namespace Syncfusion.Samples.ViewModel
{
    public class ReportViewModel 
    {
        public ReportModel Report { get; set; }
           
        #region Constructor

        public ReportViewModel()
        {
            this.Report = new ReportModel();
            this.Report.ReportPath = @"/SSRSSamples/Territory Sales";
            this.Report.ReportServerUrl = @"http://104.207.134.201/reportserver";
            this.Report.ProcessingMode = ProcessingMode.Remote;
            this.Report.ReportServerCredential = new System.Net.NetworkCredential("ssrs", "RDLReport1");
        }

        public void Loaded(object sender, RoutedEventArgs e)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                Window mainWindow = sender as Window;
                Syncfusion.Windows.Reports.Viewer.ReportViewer viewer = mainWindow.FindName("viewer") as Syncfusion.Windows.Reports.Viewer.ReportViewer;

                List<DataSourceCredentials> crdentials = new List<DataSourceCredentials>();

                foreach (var dataSource in viewer.GetDataSources())
                {
                    DataSourceCredentials credn = new DataSourceCredentials();
                    credn.Name = dataSource.Name;
                    credn.UserId = "ssrs1";
                    credn.Password = "RDLReport1";
                    crdentials.Add(credn);
                }

                viewer.SetDataSourceCredentials(crdentials);
                viewer.RefreshReport();
            }

            else
            {
                MessageBox.Show("Internet connection is required to run this sample", "SSRS Demo", MessageBoxButton.OK);
            }


        }

        private string GetFullPath(string report)
        {
            string templateDirectory = @"../../../../../../Common/Data/ReportTemplate/";
            string dir = new DirectoryInfo(templateDirectory).FullName;
            return System.IO.Path.Combine(dir, report);  
        }

        #endregion
    }
}
