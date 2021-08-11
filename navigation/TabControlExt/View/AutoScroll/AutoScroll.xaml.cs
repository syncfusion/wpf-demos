#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;


namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for AutoScroll.xaml
    /// </summary>
    public partial class AutoScrollDemosView : DemoControl
    {
        public AutoScrollDemosView()
        {
            InitializeComponent();
        }

        public AutoScrollDemosView(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.TabControl != null)
            {
                this.TabControl.Dispose();
                this.TabControl = null;
            }

            base.Dispose(disposing);
        }
    }
}
