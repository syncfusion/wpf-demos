#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NestedDockingManager : DemoControl
    {
        public NestedDockingManager()
        {
            InitializeComponent(); 
        }

        public NestedDockingManager(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.clientdockingManager != null)
            {
                this.clientdockingManager.Dispose();
                this.clientdockingManager = null;
            }
            if (this.toolbox != null)
            {
                this.toolbox.Dispose();
                this.toolbox = null;
            }
            if (this.childToolbox != null)
            {
                this.childToolbox.Dispose();
                this.childToolbox = null;
            }
            if (this.dockingManager1 != null)
            {
                this.dockingManager1.Dispose();
                this.dockingManager1 = null;
            }
            if (this.dockingManager2 != null)
            {
                this.dockingManager2.Dispose();
                this.dockingManager2 = null;
            }
            if (this.dockingManager3 != null)
            {
                this.dockingManager3.Dispose();
                this.dockingManager3 = null;
            }
            if (this.dockingManager4 != null)
            {
                this.dockingManager4.Dispose();
                this.dockingManager4 = null;
            }
            base.Dispose(disposing);
        }
    }
}
