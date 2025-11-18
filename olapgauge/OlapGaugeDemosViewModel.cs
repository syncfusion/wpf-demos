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
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M6.94008 1.0003C7.80041 0.991707 8.65252 1.16824 9.43863 1.51793C9.81275 1.68435 10.1677 1.88814 10.4985 2.12553L11.0816 1.31311C10.6957 1.03616 10.2815 0.798409 9.84507 0.604252C8.92795 0.196282 7.93381 -0.00967508 6.93009 0.000349109C5.92638 0.0103733 4.93655 0.236145 4.02776 0.662349C3.11898 1.08855 2.31248 1.70522 1.66297 2.47053C1.01347 3.23583 0.536147 4.13187 0.263391 5.09787C-0.00936553 6.06387 -0.0711795 7.07723 0.0821417 8.06922C0.124321 8.34212 0.379745 8.52916 0.652647 8.48698C0.925549 8.4448 1.11259 8.18938 1.07041 7.91647C0.938989 7.0662 0.991973 6.1976 1.22576 5.3696C1.45955 4.54161 1.86869 3.77357 2.4254 3.1176C2.98212 2.46162 3.67341 1.93305 4.45237 1.56773C5.23133 1.20241 6.07975 1.00889 6.94008 1.0003ZM11.8598 3.48111C12.2488 4.01833 12.5468 4.61746 12.7405 5.25461C12.9908 6.07777 13.0611 6.94513 12.9467 7.79786C12.91 8.07156 13.1021 8.32319 13.3758 8.35991C13.6495 8.39663 13.9011 8.20453 13.9378 7.93084C14.0713 6.93599 13.9893 5.92406 13.6973 4.96371C13.4557 4.16923 13.0751 3.42542 12.5746 2.76631L13.4873 1.85355C13.6826 1.65829 13.6826 1.34171 13.4873 1.14645C13.2921 0.951184 12.9755 0.951184 12.7802 1.14645L7.37841 6.54826C7.25731 6.51675 7.13044 6.5 7 6.5C6.17157 6.5 5.5 7.17157 5.5 8C5.5 8.82843 6.17157 9.5 7 9.5C7.82843 9.5 8.5 8.82843 8.5 8C8.5 7.67258 8.39501 7.36989 8.21734 7.12355L11.8598 3.48111ZM6.5 8C6.5 7.72386 6.72386 7.5 7 7.5C7.0919 7.5 7.1766 7.52434 7.24964 7.56659C7.40039 7.65379 7.5 7.81556 7.5 8C7.5 8.27614 7.27614 8.5 7 8.5C6.72386 8.5 6.5 8.27614 6.5 8Z"),
                Width = 14,
                Height = 10,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/BusinessIntilegence.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "OlapGauge is a powerful data visualization control for displaying OLAP data in gauges, with customizable features for creating interactive dashboards and reports.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Olap Gauge.png", UriKind.RelativeOrAbsolute));
            this.Demos = new List<DemoInfo>();

            DemoInfo OLAPGaugeDemo = new DemoInfo()
            {
                SampleName = "KPI",

                GroupName = "PRODUCT SHOWCASE",

                Description = "OlapGauge for WPF helps in choosing scenarios dynamically, by which KPI information is highlighted via Value ToolTip and Goal ToolTip.",

                DemoViewType = typeof(KPI),

                ThemeMode = ThemeMode.None,

            };

            List<Documentation> OLAPGaugeHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "OLAP gauge - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/olap-gauge/getting-started")}
            };

            OLAPGaugeDemo.Documentations = OLAPGaugeHelpDocuments;
            this.Demos.Add(OLAPGaugeDemo);
            this.Demos.Add(new DemoInfo() { SampleName = "XAML Configuration", GroupName = "PRODUCT SHOWCASE", DemoViewType = typeof(XAMLConfiguration), Description = "This sample enables you to add an OlapReport created in XAML and bind the data through XAML configuration.", ThemeMode = ThemeMode.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "APPEARANCE", DemoViewType = typeof(Customization), Description = "This sample allows you to customize the appearance of OlapGauge control. This sample demonstrates how the Key Performance Indicators(KPIs) in OLAP cube are displayed through OlapGauge contro", ThemeMode = ThemeMode.None });
        }
    }
}
