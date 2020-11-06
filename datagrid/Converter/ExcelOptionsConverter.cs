#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.datagriddemos.wpf
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

        public static readonly DependencyProperty AllowOutliningProperty =
            DependencyProperty.Register("AllowOutlining", typeof(bool), typeof(ExcelExportingOptionsWrapper), new PropertyMetadata(true));
    }
}
