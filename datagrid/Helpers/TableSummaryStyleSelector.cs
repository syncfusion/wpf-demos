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
