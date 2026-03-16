#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
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
using System.Windows.Shapes;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for CellSelectionDemo.xaml
    /// </summary>
    public partial class CellSelectionDemo : DemoControl
    {
        public CellSelectionDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            // Release all managed resources            
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }
            if (this.colorPicker != null)
            {
                this.colorPicker.Dispose();
                this.colorPicker = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as EmployeeInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.textBlock3 != null)
                this.textBlock3 = null;

            if (this.cmbSelectionMode != null)
                this.cmbSelectionMode = null;

            base.Dispose(disposing);
        }
    }
}