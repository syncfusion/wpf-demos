#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for TileViewVirtualization.xaml
    /// </summary>
    public partial class TileViewVirtualizationDemo : DemoControl
    {
        public TileViewVirtualizationDemo()
        {
            InitializeComponent();
           
        }
        public TileViewVirtualizationDemo(string themename): base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();
            
            if (this.tileViewControl != null)
            {
                this.tileViewControl.Dispose();
                this.tileViewControl = null;
            }

            var viewmodel = this.DataContext as TileViewVirtualizationViewModel;
            if (viewmodel != null)
            {
                viewmodel.EmployeeDetails = null;
                viewmodel.LoadTileViewItems = null;
                viewmodel = null;
            }

            if (this.virtualizationGrid != null)
            {
                this.virtualizationGrid.Children.Clear();
                this.virtualizationGrid = null;
            }

            this.DataContext = null;
            base.Dispose(disposing);
        }
    }
}
