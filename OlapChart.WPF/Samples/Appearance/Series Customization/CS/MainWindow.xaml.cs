#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace SeriesCustomization
{
    using System;
    using SampleUtils;

    /// <summary>
    /// Essential OLAP Chart for WPF provides support for customizing a chart series using series template binding.
    /// This sample illustrates the custom appearance of a series
    /// Features:
    /// 1.Support for different colors for different series
    /// 2.Support for cylindrical style for a series
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
                ViewModel.ViewModel.ConnectionString = GetConnectionString();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
        #endregion
    }
}