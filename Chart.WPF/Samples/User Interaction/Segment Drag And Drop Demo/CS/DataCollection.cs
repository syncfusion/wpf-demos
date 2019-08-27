#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace SegmentDragAndDrop
{
    #region DataModel
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }

    }

    public class DataColl
    {
        public DataColl()
        {
            this.SegmentModel = new ObservableCollection<Data>();
            this.SegmentModel.Add(new Data() { X = "Jan", Y = 15, Y1 = 25, Y2 = 35, Y3 = 30 });
            this.SegmentModel.Add(new Data() { X = "Apr", Y = 25, Y1 = 35, Y2 = 40, Y3 = 20 });
            this.SegmentModel.Add(new Data() { X = "Jul", Y = 40, Y1 = 5, Y2 = 45, Y3 = 40 });
            this.SegmentModel.Add(new Data() { X = "Oct", Y = 30, Y1 = 13, Y2 = 49, Y3 = 15 });
            this.SegmentModel.Add(new Data() { X = "Dec", Y = 20, Y1 = 22, Y2 = 41, Y3 = 30 });
        }

        public ObservableCollection<Data> SegmentModel { get; set; }
    }

    #endregion
}
