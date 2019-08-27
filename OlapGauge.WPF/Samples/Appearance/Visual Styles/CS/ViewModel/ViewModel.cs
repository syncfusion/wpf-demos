#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace VisualStyles.ViewModel
{
    using System;
    using System.Collections.Generic;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Windows.Gauge.Olap;

    public class ViewModel : NotificationObject, IDisposable
    {
        #region Field

        /// <summary>
        /// Specifies the connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager dataManager;
        private OlapGaugeVisualStyle skin = OlapGaugeVisualStyle.Metro;
        private DelegateCommand<object> skinSelectionDelegateCommand;

        #endregion

        #region Constructor

        public ViewModel()
        {
            if (ConnectionString != String.Empty)
            {
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
            set{
                dataManager = value;
            }
        }

        public DelegateCommand<object> SkinSelectionDelegateCommand
        {
            get
            {
                return skinSelectionDelegateCommand ?? new DelegateCommand<object>(SkinSelectionChanged);
            }
            set
            {
                skinSelectionDelegateCommand = value;
            }
        }

        public OlapGaugeVisualStyle Skin
        {
            get
            {
                return skin;
            }
            set
            {
                skin = value;
                RaisePropertyChanged("Skin");
                
            }
        }

       

        /// <summary>
        /// Gets the theme list.
        /// </summary>
        /// <value>The theme list.</value>
        public IEnumerable<string> ThemeList
        {
            get
            {
                return new List<string>() { "Blend", "Metro", "Office2010Black", "Office2010Blue", "Office2010Silver", "Office2013LightGray", "Office2013DarkGray", "Office2013White", "VisualStudio2013", "Office365", "Office2016White", "Office2016DarkGray", "Office2016Colorful", "VisualStudio2015", "SystemTheme" };
            }
        }
        #endregion

        #region Helper method

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing && dataManager != null)
                dataManager.Dispose();
        }

        private void SkinSelectionChanged(object parameter)
        {
            switch (parameter.ToString())
            {
                case "BlueOption":
                    Skin = OlapGaugeVisualStyle.Office2007Blue;
                    break;
                case "BlackOption":
                    Skin = OlapGaugeVisualStyle.Office2007Black;
                    break;
                case "SilverOption":
                    Skin = OlapGaugeVisualStyle.Office2007Silver;
                    break;
                case "BlendOption":
                    Skin = OlapGaugeVisualStyle.Blend;
                    break;
                case "O2003Option":
                    Skin = OlapGaugeVisualStyle.Office2003;
                    break;
                case "MetroOption":
                    Skin = OlapGaugeVisualStyle.Metro;
                    break;
                default:
                    Skin = OlapGaugeVisualStyle.Office2007Blue;
                    break;
            }
        }

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