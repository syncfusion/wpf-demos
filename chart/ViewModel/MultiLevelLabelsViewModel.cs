#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class MultiLevelLabelsViewModel
    {
        public ObservableCollection<MultiLevelLabelsModel> Collection { get; set; }

        public Array ColorArray
        {
            get
            {
                return new String[] { "Gray", "Black", "Red", "Brown" };
            }
        }


        public MultiLevelLabelsViewModel()
        {
            Collection = new ObservableCollection<MultiLevelLabelsModel>();

            Collection.Add(new MultiLevelLabelsModel() { Month = "Jan", Temperature = 33 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Feb", Temperature = 37 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Mar", Temperature = 39 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Apr", Temperature = 43 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "May", Temperature = 45 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Jun", Temperature = 43 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Jul", Temperature = 41 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Aug", Temperature = 40 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Sep", Temperature = 39 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Oct", Temperature = 39 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Nov", Temperature = 34 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Dec", Temperature = 33 });

        }
    }
}
