#region Copyright
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Reports_as_Stream
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using Syncfusion.Windows.Shared;
    using System.ComponentModel;
    /// <summary>
    /// Interaction logic for RenameReportWindow.xaml
    /// </summary>
#if SyncfusionFramework4_0
    [DesignTimeVisible(false)]
#endif
    public partial class ReportNameWindow : Window
    {
        #region Variable
        List<string> reportNames;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ReportNameWindow"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public ReportNameWindow(List<string> names)
        {
            InitializeComponent();
            reportNames = names;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportNameWindow"/> class.
        /// </summary>
        public ReportNameWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the name of the report.
        /// </summary>
        /// <value>The name of the report.</value>
        public string ReportName
        {
            get
            {
                return this.txtReportName.Text;
            }

            set
            {
                this.txtReportName.Text = value;
            }
        }


        #endregion

        #region Events
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            string s = (from report in this.reportNames where report.ToLower() == this.ReportName.ToLower() select report).SingleOrDefault();
            if (s == null || s == string.Empty)//this.reportNames.Contains(this.ReportName.ToLower())
            {
                if (this.ReportName != string.Empty)
                {
                    this.DialogResult = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Report name should not be empty, \n Please enter a valid name", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("The Specified Name already exists,\n Please specify a new name for the report", "Report", MessageBoxButton.OK, MessageBoxImage.Information);
                this.txtReportName.SelectAll();
                this.txtReportName.Focus();
            }
        }
        #endregion
    }
}
