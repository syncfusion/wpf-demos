#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.surfacechartdemos.wpf
{
    /// <summary>
    /// Interaction logic for SurfaceandWireframeSurface.xaml
    /// </summary>
    public partial class SurfaceandWireframeSurface : DemoControl
    {
        public SurfaceandWireframeSurface()
        {
            InitializeComponent();
        }

        public SurfaceandWireframeSurface (string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method to dispose the Surface chart control instance.
        /// </summary>
        /// <param name="disposing">Indicates whether to release managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.surfaceChart != null)
            {
                this.surfaceChart.Dispose();
                this.surfaceChart = null;
            }
        }
    }
}