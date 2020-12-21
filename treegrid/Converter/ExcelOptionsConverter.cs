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
    public class ExcelExportingOptionsWrapper : DependencyObject
    {
        public bool CanCustomizeStyle
        {
            get { return (bool)GetValue(CanCustomizeStyleProperty); }
            set { SetValue(CanCustomizeStyleProperty, value); }
        }

        public static readonly DependencyProperty CanCustomizeStyleProperty =
            DependencyProperty.Register("CanCustomizeStyle", typeof(bool), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(false));

        public bool AllowOutlining
        {
            get { return (bool)GetValue(AllowOutliningProperty); }
            set { SetValue(AllowOutliningProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllowOutlining.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowOutliningProperty =
            DependencyProperty.Register("AllowOutlining", typeof(bool), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(true));

        public int NodeExpandModeIndex
        {
            get { return (int)GetValue(NodeExpandModeIndexProperty); }
            set { SetValue(NodeExpandModeIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NodeExpandModeIndexProperty =
            DependencyProperty.Register("NodeExpandModeIndex", typeof(int), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(1));


        public bool CanExportHyperLink
        {
            get { return (bool)GetValue(CanExportHyperLinkProperty); }
            set { SetValue(CanExportHyperLinkProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CanExportHyperLink.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanExportHyperLinkProperty =
            DependencyProperty.Register("CanExportHyperLink", typeof(bool), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(true));

        public bool isgridLinesVisible
        {
            get { return (bool)GetValue(isgridLinesVisibleProperty); }
            set { SetValue(isgridLinesVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for isGridLinesVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty isgridLinesVisibleProperty =
            DependencyProperty.Register("isgridLinesVisible", typeof(bool), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(true));

        public bool AllowIndentColumn
        {
            get { return (bool)GetValue(AllowIndentColumnProperty); }
            set { SetValue(AllowIndentColumnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllowIndentColumn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowIndentColumnProperty =
            DependencyProperty.Register("AllowIndentColumn", typeof(bool), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(true));



    }
}
