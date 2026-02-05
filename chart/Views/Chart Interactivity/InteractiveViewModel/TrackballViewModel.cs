#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class TrackballViewModel : IDisposable
    {
        public ObservableCollection<TrackballModel> SalesData { get; set; }
        public DateTime Minimum { get; set; }
        public DateTime Maximum { get; set; }
        public TrackballViewModel()
        {
            Minimum = new DateTime(2000, 2, 11);
            Maximum = new DateTime(2006, 2, 11);

            SalesData = new ObservableCollection<TrackballModel>();
            SalesData.Add(new TrackballModel() { Date = new DateTime(2000, 2, 11), Person1 = 15, Person2 = 39, Person3 = 60 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2000, 9, 14), Person1 = 20, Person2 = 30, Person3 = 55 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2001, 2, 11), Person1 = 25, Person2 = 28, Person3 = 48 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2001, 9, 16), Person1 = 21, Person2 = 35, Person3 = 57 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2002, 2, 7), Person1 = 13, Person2 = 39, Person3 = 62 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2002, 9, 7), Person1 = 18, Person2 = 41, Person3 = 64 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2003, 2, 11), Person1 = 24, Person2 = 45, Person3 = 57 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2003, 9, 14), Person1 = 23, Person2 = 48, Person3 = 53 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2004, 2, 6), Person1 = 19, Person2 = 54, Person3 = 63 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2004, 9, 6), Person1 = 31, Person2 = 55, Person3 = 50 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2005, 2, 11), Person1 = 39, Person2 = 57, Person3 = 66 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2005, 9, 11), Person1 = 50, Person2 = 60, Person3 = 65 });
            SalesData.Add(new TrackballModel() { Date = new DateTime(2006, 2, 11), Person1 = 24, Person2 = 60, Person3 = 79 });
        }

        public void Dispose()
        {
           if(SalesData != null)
                SalesData.Clear();
        }
    }
}
