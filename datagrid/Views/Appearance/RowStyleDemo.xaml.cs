#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
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

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for RowStyleDemo.xaml
    /// </summary>
    public partial class RowStyleDemo : DemoControl
    {
        public RowStyleDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.SfGrid != null)
            {
                //Release managed resources in EmployeeInfoViewModel.
                if (SfGrid.DataContext != null)
                {
                    var dataContext = SfGrid.DataContext as EmployeeInfoViewModel;
                    dataContext.Dispose();
                }
                this.SfGrid.Dispose();
                this.SfGrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}
