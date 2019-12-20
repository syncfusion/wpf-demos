#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace StackingColumn100Chart
{
    public class CategoryDataViewModel
    {
        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryData>();
            CategoricalDatas.Add(new CategoryData(6, 7, 5, "2008"));
            CategoricalDatas.Add(new CategoryData(10, 13, 10, "2009"));
            CategoricalDatas.Add(new CategoryData(23, 15, 12, "2010"));
            CategoricalDatas.Add(new CategoryData(26, 21, 20, "2011"));
            CategoricalDatas.Add(new CategoryData(30, 25, 23, "2012"));
        }

        public ObservableCollection<CategoryData> CategoricalDatas
        {
            get;
            set;
        }
    }
}
