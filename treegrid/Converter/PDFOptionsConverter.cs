#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.treegriddemos.wpf
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


        public bool CanExportFormat
        {
            get { return (bool)GetValue(CanExportFormatProperty); }
            set { SetValue(CanExportFormatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportGroup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExportFormatProperty =
            DependencyProperty.Register("CanExportFormat", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


        public bool CanExportLink
        {
            get { return (bool)GetValue(CanExportLinkProperty); }
            set { SetValue(CanExportLinkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportGroupSummary.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExportLinkProperty =
            DependencyProperty.Register("CanExportLink", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));

        public bool CanCustomizeColumns
        {
            get { return (bool)GetValue(CanCustomizeColumnsProperty); }
            set { SetValue(CanCustomizeColumnsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportTableSummary.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanCustomizeColumnsProperty =
            DependencyProperty.Register("CanCustomizeColumns", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(true));


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



        public bool CanAddHeaderAndFooter
        {
            get { return (bool)GetValue(CanAddHeaderAndFooterProperty); }
            set { SetValue(CanAddHeaderAndFooterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanAddHeaderAndFooter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanAddHeaderAndFooterProperty =
            DependencyProperty.Register("CanAddHeaderAndFooter", typeof(bool), typeof(PDFExportingOptionsWrapper), new PropertyMetadata(false));


    }
}
