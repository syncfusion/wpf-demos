#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.chartdemos.wpf
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
}
