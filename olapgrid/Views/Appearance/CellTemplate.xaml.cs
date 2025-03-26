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
    /// Interaction logic for CellTemplate.xaml
    /// </summary>
    public partial class CellTemplate : DemoControl
    {
        public CellTemplate()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Relase all resources
            if (this.olapGrid1 != null)
            {
                (olapGrid1.DataContext as CellTemplateViewModel).Dispose();
                olapGrid1.DataContext = null;
                this.olapGrid1.Dispose();
                this.olapGrid1 = null;
            }
            base.Dispose(disposing);
        }
    }
}
