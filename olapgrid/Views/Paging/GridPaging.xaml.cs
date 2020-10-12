#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for GridPaging.xaml
    /// </summary>
    public partial class GridPaging : DemoControl
    {
        public GridPaging()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as GridPagingViewModel).Dispose();
            this.DataContext = null;
            if (this.olapGrid1 != null)
            {
                this.olapGrid1.Dispose();
                this.olapGrid1 = null;
            }
            base.Dispose(disposing);
        }
    }
}
