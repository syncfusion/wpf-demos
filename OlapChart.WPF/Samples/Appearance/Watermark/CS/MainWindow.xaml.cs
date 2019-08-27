#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace ChartWaterMark
{
    using SampleUtils;

    /// <summary>
    /// This sample illustrates the insertion of a text watermark or an image watermark into the background of a chart.
    /// Appearance aspects such as alignment font and opacity can be customized.
    /// Features:
    /// 1.Support for text and image watermarks
    /// 2.Support for customizing alignment, font style, interior color, and opacity of watermarked text
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