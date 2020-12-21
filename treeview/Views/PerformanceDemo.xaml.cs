#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Animation;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for PerformanceDemo.xaml
    /// </summary>
    public partial class PerformanceDemo : DemoControl
    {
        public PerformanceDemo()
        {
            InitializeComponent();
        }
		
		public PerformanceDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
		
        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeView != null)
            {
                this.treeView.Dispose();
                this.treeView = null;
            }
            if(this.loadingIndicator != null)
            {
                this.loadingIndicator.Dispose();
                this.loadingIndicator = null;
            }
            base.Dispose(disposing);
        }
    }
}
