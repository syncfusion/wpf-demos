#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class MDIDemo : DemoControl
    {
        public MDIDemo()
        {
            InitializeComponent();
        }

        public MDIDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dockingManager != null)
            {
                this.dockingManager.Dispose();
                this.dockingManager = null;
            }

            if (this.combo != null)
            {
                this.combo.Dispose();
                this.combo = null;
            }

            if (this.MDILayout_selection != null)
            {
                this.MDILayout_selection.Dispose();
                this.MDILayout_selection = null;
            }

            if (this.Resources != null)
            {
                this.Resources.Clear();
            }

            base.Dispose(disposing);
        }
    }
}
