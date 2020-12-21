#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.datagriddemos.wpf
{
    public class TableSummaryStyleSelector : StyleSelector
    {
        SummariesDemo summariesDemo;
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (summariesDemo == null)
                summariesDemo = (SummariesDemo)Activator.CreateInstance(typeof(SummariesDemo));

            var summaryRecordEntry = item as SummaryRecordEntry;
            if (summaryRecordEntry.SummaryRow.ShowSummaryInRow)
                return summariesDemo.Resources["tableSummaryCell"] as Style;

            return summariesDemo.Resources["normaltableSummaryCell"] as Style;
        }
    }
}
