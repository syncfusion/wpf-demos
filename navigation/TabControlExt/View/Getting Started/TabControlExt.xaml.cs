#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows.Data;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for TabControlExt.xaml
    /// </summary>
    public partial class TabControlExtDemosView : DemoControl
    {
        public TabControlExtDemosView()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.TabItemExtGrid.Children.Clear();
            if (this.Tab != null)
            {                         
                BindingOperations.ClearAllBindings(Tab);
                this.Tab.Dispose();
                this.Tab = null;
               
            }
            base.Dispose(disposing);
        }
    }
}