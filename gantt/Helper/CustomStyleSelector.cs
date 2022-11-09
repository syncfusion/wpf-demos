#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Gantt.Chart;
using System.Windows;

namespace syncfusion.ganttdemos.wpf
{
    public class CustomStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            StripLine info = item as StripLine;
            if (info.StartDate == new DateTime(2012, 6, 18) || info.StartDate == new DateTime(2012, 7, 16) || info.StartDate == new DateTime(2012, 9, 3) || info.StartDate == new DateTime(2012, 9, 10) || info.StartDate == new DateTime(2012, 9, 24) || info.StartDate == new DateTime(2012, 10, 8) || info.StartDate == new DateTime(2012, 12, 3) || info.StartDate == new DateTime(2012, 11, 12))
                return GanttDictionaries.GanttStyleDictionary["strip"] as Style;
            return base.SelectStyle(item, container);
        }
    }
}
