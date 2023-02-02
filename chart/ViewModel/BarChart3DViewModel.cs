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
    public class BarChart3DViewModel
    {
        public BarChart3DViewModel()
        {
            CategoricalDatas = new ObservableCollection<BarChart3DModel>();

            CategoricalDatas.Add(new BarChart3DModel(7, 5, "2008"));
            CategoricalDatas.Add(new BarChart3DModel(13, 10, "2009"));
            CategoricalDatas.Add(new BarChart3DModel(15, 12, "2010"));
            CategoricalDatas.Add(new BarChart3DModel(21, 20, "2011"));
            CategoricalDatas.Add(new BarChart3DModel(25, 23, "2012"));
        }

        public ObservableCollection<BarChart3DModel> CategoricalDatas
        {
            get;
            set;
        }
    }
}
