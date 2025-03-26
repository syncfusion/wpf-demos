#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;

namespace syncfusion.invoice.wpf
{
    public class Invoice : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new Invoice());
            return productdemos;
        }
    }
    public class Invoice : ProductDemo
    {
        public Invoice()
        {
            this.Product = "XlsIO";
            this.ProductCategory = "File Format";
            this.Demos = new List<DemoInfo>();

            //this.Demos.Add(new DemoInfo()
            //{
            //    SampleName = "Budget Planner",
            //    GroupName = "PRODUCT SHOWCASE",
            //    Description = "This sample demonstrates how to create a simple Budget planner using XlsIO.",
            //    DemoViewType = typeof(BudgetPlanner)
            //});
        }
    }
}

