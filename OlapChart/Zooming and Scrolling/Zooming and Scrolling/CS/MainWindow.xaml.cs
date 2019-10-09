#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace ZoomingandScrolling
{
    using SampleUtils;

    /// <summary>
    /// This sample illustrates the zooming and scrolling features supported in an OLAP chart.
    /// Zooming can be achieved in two ways:
    /// 1.By the end user invoking the built-in zooming tool via the context menu
    /// 2.By the end user employing the ZoomIn and ZoomOut commands when associated with key gestures
    /// Interactive Features:
    /// 1.The check box called Show ZoomButton enables or disables the Chart Zooming Toolkit.
    /// 2.The combo box called ZoomIn Keys selects the key gestures for zooming in.
    /// 3.The combo box called ZoomOut Keys selects the key gestures for zooming out
    /// 4.The combo box called ZoomFactorX selects the zoom factor for the primary axis.
    /// 5.The ZoomFactorY combo box selects the zoom factor for the secondary axis.
    /// </summary>
    public partial class MainWindow : SampleWindow
    {
        #region Initialization

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