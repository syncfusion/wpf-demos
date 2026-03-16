#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.ComponentModel;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for XAMLConfiguration.xaml
    /// </summary>
    public partial class XAMLConfiguration : DemoControl, INotifyPropertyChanged
    {
        #region Members
        private string connectionString;
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="XAMLConfiguration"/> class.
        /// </summary>
        public XAMLConfiguration()
        {
            InitializeComponent();
            this.DataContext = this;
            //ConnectionString = KPIModel.Initialize();
            ConnectionString = "Data Source=http://bi.syncfusion.com/olap/msmdpump.dll; Initial Catalog=Adventure Works DW 2008 SE;";
        }

        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; OnPropertyChanged("ConnectionString"); }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.DataContext = null;
            if (this.olapGrid != null)
            {
                this.olapGrid.Dispose();
                this.olapGrid = null;
            }
            base.Dispose(disposing);
        }
    }
}
