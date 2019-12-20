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
using PortfolioAnalyzer.Model;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PortfolioAnalyzer.Infrastructure;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Input;
using System.Globalization;
using Syncfusion.Data;

namespace PortfolioAnalyzer.PortfolioGridModule
{    
    public class SummaryConverter : IValueConverter
    {        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var group = (value as Group);

            switch (parameter.ToString())
            {
                case "Caption":
                    {
                        return group.Key+"-"+group.ItemsCount+" Items";
                    }
                    break;
                case "QuoteChange":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "QuoteChange");
                        var summaryValue = summaryEntry.AggregateValues["DayChangeTotal"];
                        var formattedSummaryValue = string.Format("${0:#,#.00}", summaryValue);
                        return formattedSummaryValue;
                        break;
                    }

                case "QuotePercentChange":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "QuotePercentChange");
                        var summaryValue = summaryEntry.AggregateValues["Average"];
                        var formattedSummaryValue = string.Format("{0:#,#.00}%", summaryValue);
                        return formattedSummaryValue;
                    }
                    break;
                case "Quantity":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "Quantity");
                        var summaryValue = summaryEntry.AggregateValues["Sum"];
                        var formattedSummaryValue = string.Format("{0} Items", summaryValue);
                        return formattedSummaryValue;
                    }
                    break;
                case "Price":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "Price");
                        var summaryValue = summaryEntry.AggregateValues["Sum"];
                        var formattedSummaryValue = string.Format("${0}", summaryValue);
                        return formattedSummaryValue;
                    }
                    break;
                case "Volume":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "Volume");
                        var summaryValue = summaryEntry.AggregateValues["Average"];
                        var formattedSummaryValue = string.Format("{0}", summaryValue);
                        return formattedSummaryValue;
                    }
                    break;

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BoolToDoubleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
                return 0.3d;
            else
                return 1d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
