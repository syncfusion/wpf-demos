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

namespace ColumnChart
{
    public class CategoryDataViewModel
    {
        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryData>();

            CategoricalDatas.Add(new CategoryData(7, 5, "2008"));
            CategoricalDatas.Add(new CategoryData(13, 10, "2009"));
            CategoricalDatas.Add(new CategoryData(15, 12, "2010"));
            CategoricalDatas.Add(new CategoryData(21, 20, "2011"));
            CategoricalDatas.Add(new CategoryData(25, 23, "2012"));
        }

        public ObservableCollection<CategoryData> CategoricalDatas
        {
            get;
            set;
        }
    }
}
