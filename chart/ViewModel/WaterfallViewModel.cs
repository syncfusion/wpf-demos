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
    public class WaterfallViewModel
    {
        public WaterfallViewModel()
        {
            this.RevenueDetails = new ObservableCollection<WaterfallModel>();

            RevenueDetails.Add(new WaterfallModel() { Category = "Sales", Value = 165 });
            RevenueDetails.Add(new WaterfallModel() { Category = "Staff", Value = -47 });
            RevenueDetails.Add(new WaterfallModel() { Category = "Balance", Value = -58, IsSummary = true });
            RevenueDetails.Add(new WaterfallModel() { Category = "Others", Value = 15 });
            RevenueDetails.Add(new WaterfallModel() { Category = "Tax", Value = -20 });
            RevenueDetails.Add(new WaterfallModel() { Category = "Profit", Value = 45, IsSummary = true });
            RevenueDetails.Add(new WaterfallModel() { Category = "Intentory", Value = -10 });
            RevenueDetails.Add(new WaterfallModel() { Category = "Marketing", Value = -25 });
            RevenueDetails.Add(new WaterfallModel() { Category = " Net Income", Value = 25, IsSummary = true });
        }

        public ObservableCollection<WaterfallModel> RevenueDetails { get; set; }
    }
}
