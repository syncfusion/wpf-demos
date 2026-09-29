#region Copyright Syncfusion Inc. 2001 - 2026
// Copyright Syncfusion Inc. 2001 - 2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for TreeGridDataPagingDemo.xaml
    /// </summary>
    public partial class TreeGridPagingDemo : DemoControl
    {
        public TreeGridPagingDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            if (this.treeGridArea != null)
                this.treeGridArea = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;
            
            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.treeGridViewTypeComboBox != null)
               this.treeGridViewTypeComboBox = null;

            if (this.orientationComboBox != null)
                this.orientationComboBox = null;

            if (this.expandButton != null)
               this.expandButton = null;

            if (this.collapseButton != null)
               this.collapseButton = null;

            base.Dispose(disposing);
        }
    }
}