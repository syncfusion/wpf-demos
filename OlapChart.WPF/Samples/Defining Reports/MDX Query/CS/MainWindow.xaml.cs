#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="MainWIndow.xaml.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace MdxQuery
{
    using System;
    using SampleUtils;

    /// <summary>
    /// Essential OLAP Chart for Web has the ability to load OLAP data by directly passing the Mdx query to the OLAP Data Manager. 
    /// The ExecuteCellSet() method will process the query and provide the cell set. The following types define an Mdx query in code:
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