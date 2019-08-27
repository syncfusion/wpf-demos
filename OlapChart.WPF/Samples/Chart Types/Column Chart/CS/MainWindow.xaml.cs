#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace ColumnChart
{
    using System;
    using SampleUtils;

    /// <summary>
    /// This sample illustrates visualizing multi-dimensional OLAP data in different column chart types.
    /// It shows column, stacking, and stacking column 100 type charts.
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
                ViewModel.ConnectionString =  GetConnectionString();
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