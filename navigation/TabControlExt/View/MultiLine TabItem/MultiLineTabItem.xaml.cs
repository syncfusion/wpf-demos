#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window.xaml
    /// </summary>
    public partial class MultilineTabItemsDemosView : DemoControl
    {
        public MultilineTabItemsDemosView()
        {
            InitializeComponent();
        }
        public MultilineTabItemsDemosView(string themename):base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.tabControlExt != null)
            {
                this.tabControlExt.Dispose();
                this.tabControlExt = null;
            }

            if (this.tabControlExt1 != null)
            {
                this.tabControlExt1.Dispose();
                this.tabControlExt1 = null;
            }

            if (this.tabControlExt2 != null)
            {
                this.tabControlExt2.Dispose();
                this.tabControlExt2 = null;
            }

            if (this.tabControlExt3 != null)
            {
                this.tabControlExt3.Dispose();
                this.tabControlExt3 = null;
            }

            if (this.tabControlExt4 != null)
            {
                this.tabControlExt4.Dispose();
                this.tabControlExt4 = null;
            }

            base.Dispose(disposing);
        }
    }
}
