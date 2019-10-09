#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace XAMLConfig
{
    using SampleUtils;
    using System.ComponentModel;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : SampleWindow, INotifyPropertyChanged
    {
        #region Members
        private string connectionString;
        #endregion

        #region Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            ConnectionString =  GetConnectionString();
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
    }
}