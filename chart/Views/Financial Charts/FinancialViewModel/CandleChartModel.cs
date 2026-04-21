#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a candlestick data point with OHLC values.</summary>
    public class CandleChartModel
    {
        /// <summary>Gets or sets the trading date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the high price.</summary>
        public double High { get; set; }

        /// <summary>Gets or sets the low price.</summary>
        public double Low { get; set; }

        /// <summary>Gets or sets the open price.</summary>
        public double Value { get; set; }

        /// <summary>Gets or sets the close price.</summary>
        public double Size { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CandleChartModel"/> class with ohlc values.
        /// </summary>
        /// <param name="date">Represents the date.</param>
        /// <param name="high">Represents the high value.</param>
        /// <param name="low">Represents the low value.</param>
        /// <param name="open">Represents the open value.</param>
        /// <param name="close">Represents the close value.</param>
        public CandleChartModel(DateTime date, double high, double low, double open, double close)
        {
            Date = date;
            High = high;
            Low = low;
            Value = open;
            Size = close;
        }
    }
}
