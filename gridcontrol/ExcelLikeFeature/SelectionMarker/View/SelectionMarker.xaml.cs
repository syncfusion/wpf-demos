#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for SelectionMarker.xaml
    /// </summary>
    public partial class SelectionMarker : DemoControl
    {
        public SelectionMarker()
        {
            InitializeComponent();
            sampleGrid1.Model.RowCount = 30;
            sampleGrid1.Model.ColumnCount = 25;
            sampleGrid1.Model.ColumnWidths.SetHidden(5, 10, true);
            sampleGrid1.Model.Options.HiddenBorderBrush = Brushes.Black;
            sampleGrid1.Model.Options.HiddenBorderThickness = 2d;
            sampleGrid1.Model.Options.AllowExcelLikeResizing = true;
        }
        public SelectionMarker(string themename) : base(themename)
        {
            InitializeComponent();
            sampleGrid1.Model.RowCount = 30;
            sampleGrid1.Model.ColumnCount = 25;
            sampleGrid1.Model.ColumnWidths.SetHidden(5, 10, true);
            sampleGrid1.Model.Options.HiddenBorderBrush = Brushes.Black;
            sampleGrid1.Model.Options.HiddenBorderThickness = 2d;
            sampleGrid1.Model.Options.AllowExcelLikeResizing = true;
        }
        protected override void Dispose(bool disposing)
        {
            if (this.sampleGrid1 != null)
            {
                this.sampleGrid1.Dispose();
                this.sampleGrid1 = null;
            }
            base.Dispose(disposing);
        }
    }
}
