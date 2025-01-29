#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
        public ObservableCollection<WaterfallModel> RevenueDetails { get; set; }
        public ObservableCollection<WaterfallModel> Sales { get; set; }
        public ObservableCollection<WaterfallModel> NewSales { get; set; }

        public WaterfallViewModel()
        {
            this.RevenueDetails = new ObservableCollection<WaterfallModel>();
            this.Sales = new ObservableCollection<WaterfallModel>();
            this.NewSales = new ObservableCollection<WaterfallModel>();

            RevenueDetails.Add(new WaterfallModel() { Department = "Jan", Value = 25 });
            RevenueDetails.Add(new WaterfallModel() { Department = "Feb", Value = 22.5 });
            RevenueDetails.Add(new WaterfallModel() { Department = "Mar", Value = -10 });
            RevenueDetails.Add(new WaterfallModel() { Department = "April", Value = 23 });
            RevenueDetails.Add(new WaterfallModel() { Department = "May", Value = 7 });
            RevenueDetails.Add(new WaterfallModel() { Department = "June", Value = -15 });
            RevenueDetails.Add(new WaterfallModel() { Department = "July", Value = -8 });
            RevenueDetails.Add(new WaterfallModel() { Department = " August", Value = -6 });
            RevenueDetails.Add(new WaterfallModel() { Department = "Sep", Value = -9 });
            RevenueDetails.Add(new WaterfallModel() { Department = "Oct", Value = 22.5 });
            RevenueDetails.Add(new WaterfallModel() { Department = "Nov", Value = 12 });
            RevenueDetails.Add(new WaterfallModel() { Department = " Dec", Value = -30 });
            RevenueDetails.Add(new WaterfallModel() { Department = " Total", Value = 34, IsSummary = true });

            Sales.Add(new WaterfallModel() { Department = "Income", Value = 46 });
            Sales.Add(new WaterfallModel() { Department = "Sales", Value = -14 });
            Sales.Add(new WaterfallModel() { Department = "Research", Value = -9 });
            Sales.Add(new WaterfallModel() { Department = "Other Income", Value = 15 });
            Sales.Add(new WaterfallModel() { Department = "Gross Profit", Value = 38, IsSummary = true });
            Sales.Add(new WaterfallModel() { Department = "Expense", Value = -13 });
            Sales.Add(new WaterfallModel() { Department = "Tax", Value = -8 });
            Sales.Add(new WaterfallModel() { Department = "Net Profit", Value = 17, IsSummary = true });

            NewSales.Add(new WaterfallModel() { Department = "Income", Value = 47 });
            NewSales.Add(new WaterfallModel() { Department = "Sales", Value = -15 });
            NewSales.Add(new WaterfallModel() { Department = "Research", Value = -8 });
            NewSales.Add(new WaterfallModel() { Department = "Other Income", Value = 18 });
            NewSales.Add(new WaterfallModel() { Department = "Gross Profit", Value = 34, IsSummary = true });
            NewSales.Add(new WaterfallModel() { Department = "Expense", Value = -12 });
            NewSales.Add(new WaterfallModel() { Department = "Tax", Value = -6 });
            NewSales.Add(new WaterfallModel() { Department = "Net Profit", Value = 11, IsSummary = true });
        }
    }
}
