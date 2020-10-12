#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapgaugedemos.wpf
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    public class KPIViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Specifies the connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager dataManager;
        private DelegateCommand<object> reportSelectionDelegateCommand;
        private bool scenario1 = true;
        private bool scenario2;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="KPIViewModel"/> class.
        /// </summary>
        public KPIViewModel()
        {
            if (ConnectionString != string.Empty)
            {
                if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
                {
                    ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
                }
                else
                {
                    ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
                }
                dataManager = new OlapDataManager(ConnectionString);
                dataManager.SetCurrentReport(LoadOlapData());
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the OlapDataManager.
        /// </summary>
        /// <value>The OlapDataManager.</value>
        public OlapDataManager DataManager
        {
            get
            {
                return dataManager;
            }
            set
            {
                dataManager = value;
            }
        }

        /// <summary>
        /// Gets or sets the report selection delegate command.
        /// </summary>
        /// <value>The report selection delegate command.</value>
        public DelegateCommand<object> ReportSelectionDelegateCommand
        {
            get
            {
                return reportSelectionDelegateCommand ?? new DelegateCommand<object>(ReportSelection);
            }
            set
            {
                reportSelectionDelegateCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KPIViewModel"/> is Report 1.
        /// </summary>
        /// <value><c>true</c> if Report 1; otherwise, <c>false</c>.</value>
        public bool Scenario1
        {
            get
            {
                return scenario1;
            }
            set
            {
                scenario1 = value;
                RaisePropertyChanged("Scenario1");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KPIViewModel"/> is Report 2.
        /// </summary>
        /// <value><c>true</c> if Report 2; otherwise, <c>false</c>.</value>
        public bool Scenario2
        {
            get
            {
                return scenario2;
            }
            set
            {
                scenario2 = value;
                RaisePropertyChanged("Scenario2");
            }
        }
        #endregion

        #region Helper method

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Reports the selection.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void ReportSelection(object parameter)
        {
            if (parameter.ToString() == "Scenario1")
            {
                DataManager.SetCurrentReport(LoadOlapData());
                Scenario1 = true; Scenario2 = false;
            }
            else
            {
                DataManager.SetCurrentReport(LoadOlapData1());
                Scenario1 = false; Scenario2 = true;
            }
        }

        /// <summary>
        /// Scenario1 - Report
        /// </summary>
        /// <returns></returns>
        OlapReport LoadOlapData()
        {
            OlapReport report = new OlapReport();
            report.CurrentCubeName = "Adventure Works";

            KpiElements kpiElement = new KpiElements();
            kpiElement.Elements.Add(new KpiElement { Name = "Revenue", ShowKPIGoal = true, ShowKPIStatus = true, ShowKPIValue = true, ShowKPITrend = true });

            DimensionElement dimensionElement1 = new DimensionElement();
            DimensionElement dimensionElement2 = new DimensionElement();
            DimensionElement dimensionElement3 = new DimensionElement();


            dimensionElement1.Name = "Date";
            dimensionElement1.AddLevel("Fiscal Year", "Fiscal Year");
            dimensionElement1.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2004");
            dimensionElement1.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;

            dimensionElement2.Name = "Sales Channel";
            dimensionElement2.AddLevel("Sales Channel", "Sales Channel");
            dimensionElement2.Hierarchy.LevelElements["Sales Channel"].Add("Reseller");
            dimensionElement2.Hierarchy.LevelElements["Sales Channel"].IncludeAvailableMembers = true;

            dimensionElement3.Name = "Product";
            dimensionElement3.AddLevel("Product Model Lines", "Product Line");

            report.CategoricalElements.Add(new Item { ElementValue = dimensionElement2 });
            report.CategoricalElements.Add(new Item { ElementValue = dimensionElement1 });
            report.CategoricalElements.Add(new Item { ElementValue = kpiElement });
            report.SeriesElements.Add(new Item { ElementValue = dimensionElement3 });
            return report;
        }

        /// <summary>
        /// Scenario2 - Report
        /// </summary>
        /// <returns></returns>
        OlapReport LoadOlapData1()
        {
            OlapReport report = new OlapReport();
            report.CurrentCubeName = "Adventure Works";

            KpiElements kpiElement = new KpiElements();
            kpiElement.Elements.Add(new KpiElement { Name = "Revenue", ShowKPIGoal = true, ShowKPIStatus = true, ShowKPIValue = true, ShowKPITrend = true });

            DimensionElement dimensionElement1 = new DimensionElement();
            DimensionElement dimensionElement2 = new DimensionElement();

            dimensionElement1.Name = "Date";
            dimensionElement1.AddLevel("Fiscal Year", "Fiscal Year");

            dimensionElement2.Name = "Product";
            dimensionElement2.AddLevel("Product Categories", "Category");

            report.CategoricalElements.Add(new Item { ElementValue = dimensionElement1 });
            report.CategoricalElements.Add(new Item { ElementValue = kpiElement });
            report.SeriesElements.Add(new Item { ElementValue = dimensionElement2 });
            return report;
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing && dataManager != null)
                dataManager.Dispose();
        }
        #endregion
    }
}
