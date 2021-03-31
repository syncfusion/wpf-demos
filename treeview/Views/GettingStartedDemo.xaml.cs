#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for GettingStartedDemo.xaml
    /// </summary>
    public partial class GettingStartedDemo : DemoControl
    {
        public GettingStartedDemo()
        {
            InitializeComponent();
        }
		
		public GettingStartedDemo(string themename) : base(themename)
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

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            if (this.textBlock4 != null)
                this.textBlock4 = null;

            if (this.textBlock5 != null)
                this.textBlock5 = null;

            if (this.textBlock6 != null)
                this.textBlock6 = null;

            if (this.textBlock6 != null)
                this.textBlock6 = null;

            if (this.textBlock7 != null)
                this.textBlock7 = null;

            if (this.textBlock8 != null)
                this.textBlock8 = null;

            if (this.showlines != null)
                this.showlines = null;

            if (this.enableAnimation != null)
                this.enableAnimation = null;

            if (this.expandBtn != null)
                this.expandBtn = null;

            if (this.collapseBtn != null)
                this.collapseBtn = null;

            base.Dispose(disposing);
        }
    }
}
