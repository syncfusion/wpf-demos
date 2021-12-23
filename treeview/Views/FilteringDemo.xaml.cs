#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using syncfusion.demoscommon.wpf;

namespace syncfusion.treeviewdemos.wpf
{
    /// <summary>
    /// Interaction logic for FilteringDemo.xaml
    /// </summary>
    public partial class FilteringDemo : DemoControl
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="FilteringDemo"/> class.
        /// </summary>
        public FilteringDemo()
        {
            InitializeComponent();
        }
		
		public FilteringDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (treeView != null)
            {
                this.treeView.Dispose();
                this.treeView = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            base.Dispose(disposing);
        }
    }
}
