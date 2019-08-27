#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.UI.Xaml.Charts;
using System.Windows;

namespace AxisConfiguration
{
    public class CategoryDataViewModel
    {
        public CategoryDataViewModel()
        {
            CategoricalDatas = new ObservableCollection<CategoryData>();
            CategoricalDatas.Add(new CategoryData("Metal", 5));
            CategoricalDatas.Add(new CategoryData("Copper", 10));
            CategoricalDatas.Add(new CategoryData("Silver", 15));
            CategoricalDatas.Add(new CategoryData("Iron", 20));
            CategoricalDatas.Add(new CategoryData("Zinc", 20));
            CategoricalDatas.Add(new CategoryData("Gold", 35));
            CategoricalDatas.Add(new CategoryData("Platinum", 20));
            CategoricalDatas.Add(new CategoryData("Chromium", 40));
            CategoricalDatas.Add(new CategoryData("Titanium", 20));
            CategoricalDatas.Add(new CategoryData("Uranium", 15));
            CategoricalDatas.Add(new CategoryData("Nickel", 40));
        }

        public ObservableCollection<CategoryData> CategoricalDatas
        {
            get;
            set;
        }

        public Array DrawingMode
        {
            get 
            {
                return Enum.GetValues(typeof(LabelPlacement)); 
            }

        }

        public Array LabelPosition
        {
            get 
            {
                return Enum.GetValues(typeof(AxisElementPosition)); 
            }
        }

        public Array AxisHeaderPosition
        {
            get
            {
                return Enum.GetValues(typeof(AxisHeaderPosition));
            }
        }

        public Array LabelsIntersectAction
        {
            get 
            {
                return Enum.GetValues(typeof(AxisLabelsIntersectAction));
            }
        }

        public Array AxisVisibility
        {
            get 
            {
                return Enum.GetValues(typeof(Visibility)); 
            }
        }

        public Array RangePadding
        {
            get 
            {
                return Enum.GetValues(typeof(NumericalPadding)); 
            }
        }

        public Array EdgeLabelsDrawingMode
        {
            get 
            {
                return Enum.GetValues(typeof(EdgeLabelsDrawingMode)); 
            }
        }
    }
}
