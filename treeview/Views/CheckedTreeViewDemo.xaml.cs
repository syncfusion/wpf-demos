#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for CheckedTreeViewDemo.xaml
    /// </summary>
    public partial class CheckedTreeViewDemo : DemoControl
    {
        #region Constructor

        public CheckedTreeViewDemo()
        {
            InitializeComponent();
        }
		
		public CheckedTreeViewDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
		
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeView != null)
            {
                this.treeView.Dispose();
                this.treeView = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.listView != null)
                this.listView = null;

            if (this.label != null)
                this.label = null;

            base.Dispose(disposing);
        }
    }
}
