#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace GridLayout
{
    using System;
    using SampleUtils;

    /// <summary>
    /// This sample Demonstrates to show the different Grid layouts available in the OLAP Grid.
    ///             1. Normal GridLayout - The child member of the drill down element will be displayed in next column.
    ///             2. Normal Top Summary Grid layout - The child member of the drill down element will be displayed in next column with Top Positioned Summary.
    ///             3. Excel Like GridLayout - The child member of the drill down element will be displayed within the same column.
    ///             4. No summaries Grid Layout - The members in the OLAP Grid will be displayed with out the summary column/ summary row.
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