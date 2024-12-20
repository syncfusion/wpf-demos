#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for VirtualKPI.xaml
    /// </summary>
    public partial class VirtualKPI : DemoControl
    {
        public VirtualKPI()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as VirtualKPIViewModel).Dispose();

            if (this.olapClient1 != null)
                this.olapClient1 = null;

            base.Dispose(disposing);
        }
    }
}
