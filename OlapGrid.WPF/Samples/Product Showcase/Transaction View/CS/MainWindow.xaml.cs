#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace TransactionView
{
    using System;
    using System.Windows;
    using SampleUtils;

    /// <summary>
    /// This sample demonstrates to the complete details of a particular value cell.
    /// In this sample, when you click on a value cell, it displayed the entire data of current cell in a new gird.
    /// </summary>
    public partial class MainWindow : SampleWindow
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            try
            {
                //// creating the connection string using off-line cube
                ViewModel.ViewModel.ConnectionString = ConnectionStringforTransactionView();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion
    }
}