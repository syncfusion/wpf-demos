#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelLikeFilteringDemo.xaml
    /// </summary>
    public partial class ExcelLikeFilteringDemo : DemoControl
    {
        public ExcelLikeFilteringDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }
            base.Dispose(disposing);
        }
    }
}
