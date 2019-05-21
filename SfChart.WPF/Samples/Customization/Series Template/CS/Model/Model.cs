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
using System.Threading.Tasks;

namespace CustomSeriesDemo
{
    public class DataValuesBar
    {
        public String Month { get; set; }

        public double Value1 { get; set; }

        public decimal Value2 { get; set; }

        public DataValuesBar(string month, double value1, decimal value2)
        {
            Month = month;
            Value1 = value1;
            Value2 = value2;
        }
    }

    public class ScatterDataValues
    {
        public DateTime Year { get; set; }

        public double Count { get; set; }

        public double Variation { get; set; }

        public ScatterDataValues(DateTime year, double count, double variation)
        {
            Year = year;
            Count = count;
            Variation = variation;
        }
    }

    public class DataValuesColumn
    {
        public String Gadget { get; set; }

        public String Month { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public DataValuesColumn(string gadget, string month, double value1, double value2)
        {
            Gadget = gadget;
            Value1 = value1;
            Value2 = value2;
            Month = month;
        }
    }

    public class DataValuesColumn1
    {
        public String Gadget { get; set; }

        public String Month { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public DataValuesColumn1(string gadget, string month, double value1, double value2)
        {
            Gadget = gadget;
            Value1 = value1;
            Value2 = value2;
            Month = month;
        }
    }

    public class DataValuesSpline
    {
        public DateTime Month { get; set; }

        public double Value1 { get; set; }

        public double Value2 { get; set; }

        public double Value3 { get; set; }

        public DataValuesSpline(DateTime month, double value1, double value2, double value3)
        {
            Month = month;
            Value1 = value1;
            Value2 = value2;
            Value3 = value3;
        }
    }
}
