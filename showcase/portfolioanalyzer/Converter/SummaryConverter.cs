#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using System;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.portfolioanalyzerdemo.wpf
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
                        return group.Key + "-" + group.ItemsCount + " Items";
                    }

                case "QuoteChange":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "QuoteChange");
                        var summaryValue = summaryEntry.AggregateValues["DayChangeTotal"];
                        var formattedSummaryValue = string.Format("${0:#,#.00}", summaryValue);
                        return formattedSummaryValue;
                    }

                case "QuotePercentChange":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "QuotePercentChange");
                        var summaryValue = summaryEntry.AggregateValues["Average"];
                        var formattedSummaryValue = string.Format("{0:#,#.00}%", summaryValue);
                        return formattedSummaryValue;
                    }

                case "Quantity":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "Quantity");
                        var summaryValue = summaryEntry.AggregateValues["Sum"];
                        var formattedSummaryValue = string.Format("{0} Items", summaryValue);
                        return formattedSummaryValue;
                    }

                case "Price":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "Price");
                        var summaryValue = summaryEntry.AggregateValues["Sum"];
                        var formattedSummaryValue = string.Format("${0}", summaryValue);
                        return formattedSummaryValue;
                    }

                case "Volume":
                    {
                        var summaryEntry = group.SummaryDetails.SummaryValues.Find(item => item.Name == "Volume");
                        var summaryValue = summaryEntry.AggregateValues["Average"];
                        var formattedSummaryValue = string.Format("{0}", summaryValue);
                        return formattedSummaryValue;
                    }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
