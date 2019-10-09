#region Copyright
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ChartAnimations
{
    using System;
    using SampleUtils;

    /// <summary>
    /// This sample illustrates visualizing multi-dimensional OLAP data in different column chart types.
    /// It shows column, stacking, and stacking column 100 type charts.
    /// Features:
    /// 1.Support for plotting OLAP data into different types of column charts
    /// 2.Support for drilling up and down row and column elements
    /// Interactive Features:
    /// 1.The Show Legend check box allows showing or hiding a legend.
    /// 2.The Series Type combo box allows selecting different column types for a series.
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
                ViewModel.ConnectionString = GetConnectionString();
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