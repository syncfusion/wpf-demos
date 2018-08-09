using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Gantt.Chart;
using System.Windows;

namespace GanttStripLine
{
    public class CustomStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            StripLine info = item as StripLine;
            if (info.StartDate == new DateTime(2012, 6, 18) || info.StartDate == new DateTime(2012, 7, 16) || info.StartDate == new DateTime(2012, 9, 3) || info.StartDate == new DateTime(2012, 9, 10) || info.StartDate == new DateTime(2012, 9, 24) || info.StartDate == new DateTime(2012, 10, 8) || info.StartDate == new DateTime(2012, 12, 3) || info.StartDate == new DateTime(2012, 11, 12))
                return Application.Current.Resources["strip"] as Style;
            return base.SelectStyle(item, container);
        }
    }
}
