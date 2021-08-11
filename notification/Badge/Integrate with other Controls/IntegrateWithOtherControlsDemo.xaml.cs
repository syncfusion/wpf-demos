#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using System;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class IntegrateWithOtherControlsDemo : DemoControl
    {
        public IntegrateWithOtherControlsDemo()
        {
            InitializeComponent();
        }

        public IntegrateWithOtherControlsDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Dispose the data context objects.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (DataContext is IDisposable disposable)
            {
                disposable.Dispose();
            }
            if (this.dockingManager != null)
            {
                this.dockingManager.Dispose();
                this.dockingManager = null;
            }
            if (this.ribbon != null)
            {
                this.ribbon.Dispose();
                this.ribbon = null;
            }
            base.Dispose(disposing);
        }
    }
}
