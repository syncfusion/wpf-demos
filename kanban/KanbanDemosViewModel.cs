#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.kanbandemos.wpf
{
    public class KanbanDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new KanbanProductDemos());
            return productdemos;
        }
    }

    public class KanbanProductDemos : ProductDemo
    {
        public KanbanProductDemos()
        {
            this.Product = "Kanban";
            this.ProductCategory = "DATA VISUALIZATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "KANBAN BOARD", Description = "This sample demonstrates the kanban with columns. By default, the columns are sized smartly to arrange the default elements of the cards with better readability.", DemoViewType = typeof(GettingStarted) });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "KANBAN BOARD", Description = "This sample demonstrates the kanban view customization using DataTemplates.", DemoViewType = typeof(Customization) });
            this.Demos.Add(new DemoInfo() { SampleName = "Swimlane", GroupName = "KANBAN BOARD", Description = "Swim lanes are horizontal categorizations that allow you to categorize your current workflow by different projects, teams, users, or whatever you need.", DemoViewType = typeof(Swimlane) });
        }
    }
}
