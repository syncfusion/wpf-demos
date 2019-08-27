#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSeriesDemo
{
    public class ViewModelScatter : ObservableCollection<ScatterDataValues>
    {
        public ViewModelScatter()
        {
            DateTime date = new DateTime(2014, 1, 1);

            Add(new ScatterDataValues(date.AddMonths(0), 62, 6));
            Add(new ScatterDataValues(date.AddMonths(1), 50, 12));
            Add(new ScatterDataValues(date.AddMonths(2), 17, 2));
            Add(new ScatterDataValues(date.AddMonths(3), 34, 7));
            Add(new ScatterDataValues(date.AddMonths(4), 70, 15));
            Add(new ScatterDataValues(date.AddMonths(5), 22, 8));
            Add(new ScatterDataValues(date.AddMonths(6), 48, 3));
            Add(new ScatterDataValues(date.AddMonths(7), 53, 10));
            Add(new ScatterDataValues(date.AddMonths(8), 48, 14));
            Add(new ScatterDataValues(date.AddMonths(9), 35, 12));
            Add(new ScatterDataValues(date.AddMonths(10), 16, 6));
            Add(new ScatterDataValues(date.AddMonths(11), 55, 7));
        }
    }

    public class ViewModelColumn : ObservableCollection<DataValuesColumn>
    {
        public ViewModelColumn()
        {
            Add(new DataValuesColumn("State 1", "2009", 100, 18));
            Add(new DataValuesColumn("State 2", "2010", 100, 23));
            Add(new DataValuesColumn("State 3", "2011", 100, 26));
            Add(new DataValuesColumn("State 4", "2012", 100, 18));
            Add(new DataValuesColumn("State 5", "2013", 100, 24));
        }
    }

    public class ViewModelColumn1 : ObservableCollection<DataValuesColumn1>
    {
        public ViewModelColumn1()
        {
            Add(new DataValuesColumn1("Quarter 1", "2009", 100, 18));
            Add(new DataValuesColumn1("Quarter 2", "2010", 100, 23));
            Add(new DataValuesColumn1("Quarter 3", "2011", 100, 26));
            Add(new DataValuesColumn1("Quarter 4", "2012", 100, 24));
        }
    }

    public class ViewModelBar : ObservableCollection<DataValuesBar>
    {
        public ViewModelBar()
        {
            Add(new DataValuesBar("Convertible", 150, 350));
            Add(new DataValuesBar("Sedan", 220, 450));
            Add(new DataValuesBar("Hatchback", 100, 550));
            Add(new DataValuesBar("SUV", 240, 400));
            Add(new DataValuesBar("Truck", 180, 14));
        }
    }

    public class ViewModelSpline : ObservableCollection<DataValuesSpline>
    {
        public ViewModelSpline()
        {
            DateTime date = new DateTime(2014, 1, 1);

            Add(new DataValuesSpline(date.AddMonths(0), 6, -5, 64));
            Add(new DataValuesSpline(date.AddMonths(1), 7, 0.1, 30));
            Add(new DataValuesSpline(date.AddMonths(2), 8, 10, 22));
            Add(new DataValuesSpline(date.AddMonths(3), 10, 15, 19));
            Add(new DataValuesSpline(date.AddMonths(4), 13, 20, 20));
            Add(new DataValuesSpline(date.AddMonths(5), 17, 25, 34));
            Add(new DataValuesSpline(date.AddMonths(6), 18, 20, 45));
            Add(new DataValuesSpline(date.AddMonths(7), 17, 15, 47));
            Add(new DataValuesSpline(date.AddMonths(8), 14, 10, 55));
            Add(new DataValuesSpline(date.AddMonths(9), 12, 0, 60));
            Add(new DataValuesSpline(date.AddMonths(10), 8, -4, 64));
            Add(new DataValuesSpline(date.AddMonths(11), 8, -8, 68));
        }
    }
}
