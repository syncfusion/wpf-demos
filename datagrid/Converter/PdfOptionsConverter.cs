#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
{
    public class PDFExportingOptionsWrapper : DependencyObject
    {
        public bool IsAutoColumnWidth
        {
            get { return (bool)GetValue(IsAutoColumnWidthProperty); }
            set { SetValue(IsAutoColumnWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAutoColumnWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAutoColumnWidthProperty =
            DependencyProperty.Register("IsAutoColumnWidth", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


        public bool IsAutoRowHeight
        {
            get { return (bool)GetValue(IsAutoRowHeightProperty); }
            set { SetValue(IsAutoRowHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAutoRowHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAutoRowHeightProperty =
            DependencyProperty.Register("IsAutoRowHeight", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


        public bool CanExportGroup
        {
            get { return (bool)GetValue(CanExportGroupProperty); }
            set { SetValue(CanExportGroupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportGroup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExportGroupProperty =
            DependencyProperty.Register("CanExportGroup", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


        public bool CanExportGroupSummary
        {
            get { return (bool)GetValue(CanExportGroupSummaryProperty); }
            set { SetValue(CanExportGroupSummaryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportGroupSummary.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExportGroupSummaryProperty =
            DependencyProperty.Register("CanExportGroupSummary", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));

        public bool CanExportTableSummary
        {
            get { return (bool)GetValue(CanExportTableSummaryProperty); }
            set { SetValue(CanExportTableSummaryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportTableSummary.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExportTableSummaryProperty =
            DependencyProperty.Register("CanExportTableSummary", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


        public bool CanRepeatHeader
        {
            get { return (bool)GetValue(CanRepeatHeaderProperty); }
            set { SetValue(CanRepeatHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanRepeatHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanRepeatHeaderProperty =
            DependencyProperty.Register("CanRepeatHeader", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


        public bool IsFitAllColumns
        {
            get { return (bool)GetValue(IsFitAllColumnsProperty); }
            set { SetValue(IsFitAllColumnsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFitAllColumns.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFitAllColumnsProperty =
            DependencyProperty.Register("IsFitAllColumns", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(false));

    }
}
