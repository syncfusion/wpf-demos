#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class EmptyPointSupportViewModel : NotificationObject
    {
        public List<EmptyPointSupportModel> Data { get; set; }

        public Array ColorArray
        {
            get
            {
                return new String[] { "Blue", "Green", "Orange", "Purple", "RoyalBlue" };
            }
        }

        private object emptyPointInteriorItem;

        public object EmptyPointInteriorItem
        {
            get
            {
                return emptyPointInteriorItem;
            }

            set
            {
                emptyPointInteriorItem = value;
                RaisePropertyChanged(nameof(this.EmptyPointInteriorItem));
            }
        }

        public EmptyPointSupportViewModel()
        {
            Data = new List<EmptyPointSupportModel>();
            Data.Add(new EmptyPointSupportModel("1984", double.NaN));
            Data.Add(new EmptyPointSupportModel("1985", 2));
            Data.Add(new EmptyPointSupportModel("1986", 1));
            Data.Add(new EmptyPointSupportModel("1987", null));
            Data.Add(new EmptyPointSupportModel("1988", 3));
            Data.Add(new EmptyPointSupportModel("1989", double.NaN));
            Data.Add(new EmptyPointSupportModel("1990", 1));
            Data.Add(new EmptyPointSupportModel("1991", null));
            Data.Add(new EmptyPointSupportModel("1992", 1));
            Data.Add(new EmptyPointSupportModel("1993", 4));
        }
    }
}
