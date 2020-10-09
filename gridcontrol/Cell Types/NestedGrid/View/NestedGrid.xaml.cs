#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using System.Windows.Media;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for NestedGrid.xaml
    /// </summary>

    public partial class NestedGrid : DemoControl
    {

        public NestedGrid()
        {
            InitializeComponent();
            // An Optimization. Allow live controls inside cell to be reused when scrolled out of view.
        }

        public NestedGrid(string themename) : base(themename)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.grid.MouseControllerDispatcher.TrackMouse = this.grid.GetClipRect(ScrollAxisRegion.Body, ScrollAxisRegion.Body);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }

    }
}