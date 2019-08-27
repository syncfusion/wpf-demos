#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Syncfusion.Windows.Chart;

namespace ChartTooltips
{
    
    public class ServerList
    {
       public ServerList()
        {
            this.ToolTipModel = new ObservableCollection<ServerInfoModel>();
            DateTime dt = new DateTime(2012, 1, 1);
            ToolTipModel.Add(new ServerInfoModel() { Id = 0, Day = dt, Server1Perf = 20, Server2Perf = 50 });
            ToolTipModel.Add(new ServerInfoModel() { Id = 1, Day = dt.AddMonths(1), Server1Perf = 40, Server2Perf = 60 });
            ToolTipModel.Add(new ServerInfoModel() { Id = 2, Day = dt.AddMonths(2), Server1Perf = 80, Server2Perf = 60 });
            ToolTipModel.Add(new ServerInfoModel() { Id = 3, Day = dt.AddMonths(3), Server1Perf = 70, Server2Perf = 40 });
            ToolTipModel.Add(new ServerInfoModel() { Id = 4, Day = dt.AddMonths(4), Server1Perf = 50, Server2Perf = 90 });
            ToolTipModel.Add(new ServerInfoModel() { Id = 5, Day = dt.AddMonths(5), Server1Perf = 60, Server2Perf = 80 });
            
        }

        public ObservableCollection<ServerInfoModel> ToolTipModel { get; set; }
    }


    #region Converters
    public class TooltipConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null && value is ChartSegment)
                return String.Empty;

            ChartSegment seg = value as ChartSegment;
            return seg.Series.Label;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class ToolTipConv : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool val = (bool)value;
            String tooltiptype = (String)parameter;

            if (tooltiptype == "Chart")
            {
                if (val)
                {
                    string tooltip = "Chart ToolTip";
                    return tooltip;
                }
                else
                {
                    return null;
                }
            }

            if (tooltiptype == "ChartLegend")
            {
                if (val)
                {
                    string tooltip = "Chart Legend ToolTip";
                    return tooltip;
                }
                else
                {
                    return null;
                }
            }

            if (tooltiptype == "ChartArea")
            {
                if (val)
                {
                    string tooltip = "Chart Area ToolTip";
                    return tooltip;
                }
                else
                {
                    return null;
                }
            }

            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion

}
