#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class StackingBarChart3DViewModel
    {
        public StackingBarChart3DViewModel()
        {
            CategoricalDatas = new ObservableCollection<StackingBarChart3DModel>();

            CategoricalDatas.Add(new StackingBarChart3DModel(6, 11, 9, "2008"));
            CategoricalDatas.Add(new StackingBarChart3DModel(10, 13, 10, "2009"));
            CategoricalDatas.Add(new StackingBarChart3DModel(23, 15, 12, "2010"));
            CategoricalDatas.Add(new StackingBarChart3DModel(26, 21, 20, "2011"));
            CategoricalDatas.Add(new StackingBarChart3DModel(30, 25, 23, "2012"));
        }

        public ObservableCollection<StackingBarChart3DModel> CategoricalDatas
        {
            get;
            set;
        }
    }
}
