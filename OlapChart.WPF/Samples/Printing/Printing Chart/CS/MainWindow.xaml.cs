#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace PrintingChart
{
    using SampleUtils;

    /// <summary>
    /// This sample demonstrates the printing features of an OLAP Chart, which allows printing in color mode or black-and-white mode.
    /// It also allows printing a specified part of a chart by using the cropping feature.
    /// Features:
    /// 1.Printing a chart in color mode or black-and-white mode
    /// 2.Support for printing a specified part of a chart
    ///Interactive Features:
    ///1.The Print button prints the chart.
    ///2.>The Print Mode button selects the print mode of a chart. 
    /// </summary>
    public partial class MainWindow : SampleWindow
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            ViewModel.ViewModel.ConnectionString = GetConnectionString();
            InitializeComponent();
        }

        #endregion
    }
}