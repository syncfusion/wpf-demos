#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace ReportInFile
{
    using System;
    using System.Windows;
    using SampleUtils;
    
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SampleWindow
    {
        #region Constructor
        public Window1()
        {
            try
            {
                ViewModel.ViewModel.ConnectionString = GetConnectionString();
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data will not be loaded properly");
            }
        }
        #endregion
    }
}