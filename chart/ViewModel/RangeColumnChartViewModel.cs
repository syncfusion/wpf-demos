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
    public class RangeColumnChartViewModel
    {
        public RangeColumnChartViewModel()
        {
            FinancialDatas = new ObservableCollection<RangeColumnChartModel>();
            FinancialDatas.Add(new RangeColumnChartModel(new DateTime(2010, 7, 1), 604, 595));
            FinancialDatas.Add(new RangeColumnChartModel(new DateTime(2011, 7, 1), 602, 595));
            FinancialDatas.Add(new RangeColumnChartModel(new DateTime(2012, 7, 1), 608, 594));
            FinancialDatas.Add(new RangeColumnChartModel(new DateTime(2013, 7, 1), 619, 604));
            FinancialDatas.Add(new RangeColumnChartModel(new DateTime(2014, 7, 1), 608, 594));
        }

        public ObservableCollection<RangeColumnChartModel> FinancialDatas
        {
            get;
            set;
        }
    }
}
