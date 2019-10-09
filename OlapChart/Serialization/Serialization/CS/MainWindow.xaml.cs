#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWindow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace Serialization
{
    using SampleUtils;

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