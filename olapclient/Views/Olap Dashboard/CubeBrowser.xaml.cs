#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for CubeBrowser.xaml
    /// </summary>
    public partial class CubeBrowser : DemoControl
    {
        public CubeBrowser()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as CubeBrowserViewModel).Dispose();

            if (this.olapGrid != null)
            {
                this.olapGrid.Dispose();
                this.olapGrid = null;
            }
          
            base.Dispose(disposing);
        }
    }
}
