#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections;
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
using Syncfusion.UI.Xaml.Utility;
using syncfusion.demoscommon.wpf;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for CutCopyPasteDemo.xaml
    /// </summary>
    public partial class CutCopyPasteDemo : DemoControl
    {
        public CutCopyPasteDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            //Release all managed resources
            if (this.datagrid != null)
            {
                this.datagrid.Dispose();
                this.datagrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if(this.CopyOptionComboBox != null)
            {
                this.CopyOptionComboBox.Dispose();
                this.CopyOptionComboBox = null;
            }

            if (this.PasteOptionComboBox != null)
            {
                this.PasteOptionComboBox.Dispose();
                this.PasteOptionComboBox = null;
            }

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.SelectionUnit != null)
                this.SelectionUnit = null;

            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.cmbSelectionMode != null)
                this.cmbSelectionMode = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            if (this.textBlock4 != null)
                this.textBlock4 = null;

            if (this.textBlock5 != null)
                this.textBlock5 = null;

            if (this.Clipboardcontent != null)
                this.Clipboardcontent = null;

            base.Dispose(disposing);
        }
    }
}
