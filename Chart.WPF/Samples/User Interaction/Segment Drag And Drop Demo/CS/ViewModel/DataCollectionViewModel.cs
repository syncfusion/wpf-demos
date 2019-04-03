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
using Syncfusion.Windows.Chart;

namespace SegmentDragAndDrop
{
    #region DataViewModel
    

    public class DataColl
    {
        public DataColl()
        {
            this.SegmentModel = new ObservableCollection<Data>();
            this.SegmentModel.Add(new Data() { X = "Jan", Y = 15, Y1 = 35, Y2 = 35, Y3 = 30 });
            this.SegmentModel.Add(new Data() { X = "Apr", Y = 25, Y1 = 40, Y2 = 40, Y3 = 20 });
            this.SegmentModel.Add(new Data() { X = "Jul", Y = 40, Y1 = 65, Y2 = 45, Y3 = 40 });
            this.SegmentModel.Add(new Data() { X = "Oct", Y = 30, Y1 = 43, Y2 = 49, Y3 = 15 });
            this.SegmentModel.Add(new Data() { X = "Dec", Y = 20, Y1 = 32, Y2 = 41, Y3 = 30 });
        }

        public ObservableCollection<Data> SegmentModel { get; set; }

        public Array charttypecollection
        {
            get { return new ChartTypes[] { ChartTypes.Bar, ChartTypes.Bubble, ChartTypes.Column, ChartTypes.Gantt, ChartTypes.Tornado, ChartTypes.RangeColumn, ChartTypes.Renko, ChartTypes.StackingColumn, ChartTypes.StackingBar }; }
        }
    }

    #endregion
}
