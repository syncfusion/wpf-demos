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

namespace ParetoChartDemo
{
    public class DataCollection : ObservableCollection<Data>
    {
        public DataCollection()
        {
            this.DataCollect = new ObservableCollection<Data>();
            this.DataCollect.Add(new Data() { X = "D1", Y = 120, Y1 = 40 });
            this.DataCollect.Add(new Data() { X = "D2", Y = 60, Y1 = 60 });
            this.DataCollect.Add(new Data() { X = "D3", Y = 50, Y1 = 70 });
            this.DataCollect.Add(new Data() { X = "D4", Y = 40, Y1 = 80 });
            this.DataCollect.Add(new Data() { X = "D5", Y = 30, Y1 = 90 });
            this.DataCollect.Add(new Data() { X = "D6", Y = 20, Y1 = 95 });
        }

        public ObservableCollection<Data> DataCollect { get; set; }
    }
}
