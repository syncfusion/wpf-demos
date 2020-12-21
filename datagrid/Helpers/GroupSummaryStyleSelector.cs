#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;

namespace syncfusion.datagriddemos.wpf
{
    public class GroupSummaryStyleSelector : StyleSelector
    {
        SummariesDemo summariesDemo;
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (summariesDemo == null)
                summariesDemo = (SummariesDemo)Activator.CreateInstance(typeof(SummariesDemo));

            var summaryRecordEntry = item as SummaryRecordEntry;
            if (summaryRecordEntry.SummaryRow.ShowSummaryInRow)
                return summariesDemo.Resources["groupSummaryCell"] as Style;

            return summariesDemo.Resources["normalgroupSummaryCell"] as Style;
        }
    }

    
}