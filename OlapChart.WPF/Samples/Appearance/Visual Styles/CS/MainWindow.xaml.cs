#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace VisualStyles
{
    using System;
    using System.Windows.Controls;
    using SampleUtils;
    using Syncfusion.SfSkinManager;

    /// <summary>
    /// Essential OLAP Chart for WPF provides various properties to customize the appearance of the plot area and data points.
    /// This sample also illustrates the customization of the following:
    /// 1.OLAP Chart Control->Border width and color,Background
    /// 2.OLAP Chart Plot Area->Background
    /// 3.OLAP Chart Axis->OLAP label fonts
    /// 4.Chart Series Segments->Color palettes,Segment symbols,Legend visibility,Border width and color
    /// Features:
    /// 1.Supports viewing OLAP data in an OLAP chart
    /// 2.Supports drilling up and down row and column elements
    /// 3.Supports customizing the borders, backgrounds, and font settings of an OLAP Chart
    /// Interactive Features:
    /// 1.The controls in "Border Settings" allow customization of the OLAP Chart border.
    /// 2.The controls in "Background Settings" allow the background of an OLAP Chart to be customized.
    /// 3.The controls in "Font Settings" allow the font of an OLAP Chart to be customized.
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
            this.InitializeComponent();
            this.comboBoxSkin.SelectedIndex = 1;
        }

        #endregion

        #region Event Handlers

        private void comboBoxSkin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
                SfSkinManager.SetVisualStyle(this.olapchart1, (VisualStyles)Enum.Parse(typeof(VisualStyles), (sender as ComboBox).SelectedItem.ToString()));
        }

        #endregion
    }
}