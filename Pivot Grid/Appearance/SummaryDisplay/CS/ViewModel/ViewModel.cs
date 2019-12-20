#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace SummaryDisplayOption.ViewModel
{
    using Model;

    public class ViewModel
    {
        private object productSalesData;

        public object ProductSalesData
        {
            get
            {
                this.productSalesData = this.productSalesData ?? ProductSales.GetSalesData();
                return this.productSalesData;
            }
            set { this.productSalesData = value; }
        }

        public string[] DisplayOption
        {
            get
            {
                string[] option = {"None","All","Summaries","Calculations","GrandTotals","Summaries and Calculations","Summaries and GrandTotals","Calculations and GrandTotals" };
                return option;
            }
        }
    }
}