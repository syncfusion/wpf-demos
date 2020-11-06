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
    using System.Collections.Generic;
    using Syncfusion.Windows.Gauge;
    using System.Collections;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    public class OlapGaugeFrameType : List<GaugeFrameType>
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OlapGaugeFrameType"/> class.
        /// </summary>
        public OlapGaugeFrameType()
        {
            Add(GaugeFrameType.CircularCenterGradient);
            Add(GaugeFrameType.CircularWithDarkOuterFrames);
            Add(GaugeFrameType.FullCircle);
            Add(GaugeFrameType.HalfCircle);
        }

        #endregion

        #region Helper Methods

        internal static IEnumerable GetGaugeFrameType()
        {
            return new OlapGaugeFrameType();
        }

        #endregion
    }

    class CustomizationViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Specifies the connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager dataManager;
        private IEnumerable gaugeframeType;
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationViewModel"/> class.
        /// </summary>
        public CustomizationViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = CustomizationModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = CustomizationModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            if (ConnectionString != string.Empty)
            {   
                this.dataManager = new OlapDataManager(ConnectionString);
                this.dataManager.SetCurrentReport(LoadOlapData());
            }
            gaugeframeType = OlapGaugeFrameType.GetGaugeFrameType();
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
                return this.dataManager;
            }
            set
            {
                this.dataManager = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the gauge frame.
        /// </summary>
        /// <value>The type of the gauge frame.</value>
        public IEnumerable GaugeFrameType
        {
            get
            {
                return gaugeframeType;
            }
            set
            {
                gaugeframeType = value;
                RaisePropertyChanged("GaugeFrameType");
            }
        }

        #endregion

        #region Helper Methods
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing && this.dataManager != null)
                this.dataManager.Dispose();
        }

        private OlapReport LoadOlapData()
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
            dimensionElement1.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2002");
            dimensionElement1.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionElement1.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2003");
            dimensionElement1.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;


            dimensionElement2.Name = "Sales Channel";
            dimensionElement2.AddLevel("Sales Channel", "Sales Channel");
            dimensionElement2.Hierarchy.LevelElements["Sales Channel"].Add("Reseller");
            dimensionElement2.Hierarchy.LevelElements["Sales Channel"].IncludeAvailableMembers = true;

            dimensionElement3.Name = "Product";
            dimensionElement3.AddLevel("Product Model Lines", "Product Line");
            dimensionElement3.Hierarchy.LevelElements["Product Line"].Add("Road");
            dimensionElement3.Hierarchy.LevelElements["Product Line"].IncludeAvailableMembers = true;

            report.CategoricalElements.Add(new Item { ElementValue = dimensionElement2 });
            report.CategoricalElements.Add(new Item { ElementValue = dimensionElement1 });
            report.CategoricalElements.Add(new Item { ElementValue = kpiElement });
            report.SeriesElements.Add(new Item { ElementValue = dimensionElement3 });
            return report;
        }
        #endregion
    }
}
