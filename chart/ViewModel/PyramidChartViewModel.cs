#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class PyramidChartViewModel
    {
        public PyramidChartViewModel()
        {
            this.Tax = new List<PyramidChartModel>();


            Tax.Add(new PyramidChartModel() { Category = "Total License", Percentage = 20d });
            Tax.Add(new PyramidChartModel() { Category = "Other", Percentage = 23d });
            Tax.Add(new PyramidChartModel() { Category = "Sales and Gross Receipt", Percentage = 12d });
            Tax.Add(new PyramidChartModel() { Category = "Corporation Net Income", Percentage = 28d });
            Tax.Add(new PyramidChartModel() { Category = "Individual Income", Percentage = 10d });
            Tax.Add(new PyramidChartModel() { Category = "Sales", Percentage = 10d });
        }

        public IList<PyramidChartModel> Tax
        {
            get;
            set;
        }
    }
}
