#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace ExportingGrid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.MDXQueryBuilder;
    using System.IO;
    using Syncfusion.Windows.Shared;
    using SampleUtils;
    using System.Threading;
    using Microsoft.Win32;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Grid.Olap;
    using System.Windows.Controls.Primitives;
    using System.Reflection;
    using Syncfusion.Windows.Grid.Olap.Converter;
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : SampleWindow 
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
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
