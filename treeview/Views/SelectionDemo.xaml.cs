#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for SelectionDemo.xaml
    /// </summary>
    public partial class SelectionDemo : DemoControl
    {
        public SelectionDemo()
        {
            InitializeComponent();
        }

		public SelectionDemo(string themename) : base(themename)
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

            if (this.label1 != null)
                this.label1 = null;

            if (this.selectionMode != null)
                this.selectionMode = null;

            if (this.label2 != null)
                this.label2 = null;

            if (this.listView != null)
                this.listView = null;

            base.Dispose(disposing);
        }
    }
}
