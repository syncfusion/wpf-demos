#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoRowHeightDemo.xaml
    /// </summary>
    public partial class AutoRowHeightDemo : DemoControl
    {               
        public AutoRowHeightDemo(string themename) : base(themename)
        {
            InitializeComponent();                    
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.syncgrid != null)
            {
                this.syncgrid.Dispose();
                this.syncgrid = null;
            }

            base.Dispose(disposing);
        }
    }
}
