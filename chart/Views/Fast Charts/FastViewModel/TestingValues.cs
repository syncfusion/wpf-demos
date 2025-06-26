#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.chartdemos.wpf
{
    public class TestingValues
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public class FinancialDataModel
    {
        public DateTime Date { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }

        public FinancialDataModel()
        {
        }
        public FinancialDataModel(DateTime date, double x, double y, double y1, double y2, double y3)
        {
            Date = date;
            X = x;
            Y = y;
            Y1 = y1;
            Y2 = y2;
            Y3 = y3;
        }
    }
}
