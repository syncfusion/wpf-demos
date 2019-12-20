#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="Enum.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace Appearance
{
    using SampleUtils;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow1 : SampleWindow
    {
        #region Constructor

        public MainWindow1()
        {
            ViewModel.ViewModel.ConnectionString = GetConnectionString();
            InitializeComponent();
        }

        #endregion
    }
}