#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for StylingDemo.xaml
    /// </summary>
    public partial class StylingDemo : DemoControl
    {
        public StylingDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.sfGrid != null)
            {
                this.sfGrid.Dispose();
                this.sfGrid = null;
            }
            base.Dispose(disposing);
        }
    }
}
