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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections.ObjectModel;
    [ Serializable ]
    public sealed class DashboardReport
        : NotificationHelper
    {
        #region [ Members ]
        
        private Tiles tiles;

        private Reports reports;

        private string name;

        #endregion

        #region [ Constructor ]

        public DashboardReport()
        {
            this.tiles = new Tiles();
            this.reports = new Reports();
            this.name = "New Dashboard";
        }

        #endregion

        #region [ Properties ]

        public string Name
        {
            get { return this.name; }
            set { this.name = value; this.OnPropertyChanged("Name"); }
        }

        public Tiles Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; this.OnPropertyChanged("Tiles"); }
        }

        public Reports Reports
        {
            get { return this.reports; }
            set { this.reports = value; this.OnPropertyChanged("Reports"); }
        }

        #endregion
    }

    [ Serializable ]
    public class Tile
        : NotificationHelper
    {
        #region [ Members ]

        private Report report;

        private string name;

        private string header;

        private string controlType;

        private string controlSubType;

        private Syncfusion.Windows.Shared.TileViewItemState tileState;
        
        #endregion

        #region [ Constructor ]

        public Tile()
        {
            this.report = new Report();
        }

        #endregion

        #region [ Properties ]

        public Report Report
        {
            get { return this.report; }
            set { this.report = value; this.OnPropertyChanged("Report"); }
        }

        /// <summary>
        /// Gets or sets the tile name. It is also considered as the name of the control hosted into that tile if required for cross-reference.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { this.name = value; this.OnPropertyChanged("Name"); }
        }

        public string Header
        {
            get { return this.header; }
            set { this.header = value; this.OnPropertyChanged("Header"); }
        }

        public string ControlType
        {
            get { return this.controlType; }
            set { this.controlType = value; this.OnPropertyChanged("ControlType"); }
        }

        public string ControlSubType
        {
            get { return this.controlSubType; }
            set { this.controlSubType = value; this.OnPropertyChanged("ControlSubType"); }
        }
        
        public Syncfusion.Windows.Shared.TileViewItemState TileState
        {
            get { return this.tileState; }
            set { this.tileState = value; this.OnPropertyChanged("TileState"); }
        }

        #endregion
    }

    [ Serializable ]
    public sealed class Report
        : NotificationHelper
    {
        #region [ Members ]

        private string reportName;

        private string reportFileName;

        #endregion

        #region [ Properties ]
        
        public string ReportName
        {
            get { return this.reportName; }
            set { this.reportName = value; this.OnPropertyChanged("ReportName"); }
        }

        public string ReportFileName
        {
            get { return this.reportFileName; }
            set { this.reportFileName = value; this.OnPropertyChanged("ReportFileName"); }
        } 

        #endregion
    }

    [ Serializable ]
    public sealed class Tiles
        : ObservableCollection<Tile>
    {
    }

    [ Serializable ]
    public sealed class Reports
        : ObservableCollection<Report>
    {
    }
}
