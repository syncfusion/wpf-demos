#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgaugedemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Collections.Generic;

    public class OlapGaugeDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new OlapGaugeProductDemos());
            return productdemos;
        }
    }

    public class OlapGaugeProductDemos : ProductDemo
    {
        public OlapGaugeProductDemos()
        {
            this.Product = "Olap Gauge";
            this.ProductCategory = "BUSINESS INTELLIGENCE";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "KPI", GroupName = "", DemoViewType = typeof(KPI), Description = "OlapGauge for WPF helps in choosing scenarios dynamically, by which KPI information is highlighted via Value ToolTip and Goal ToolTip.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "XAML Configuration", GroupName = "", DemoViewType = typeof(XAMLConfiguration), Description = "This sample enables you to add an OlapReport created in XAML and bind the data through XAML configuration.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "", DemoViewType = typeof(Customization), Description = "This sample allows you to customize the appearance of OlapGauge control. This sample demonstrates how the Key Performance Indicators(KPIs) in OLAP cube are displayed through OlapGauge contro", ThemeMode = ThemeMode.None });
        }
    }
}
