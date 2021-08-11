#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Class represents the demo viewmodel which maintains all the samples.
    /// </summary>
    public class NotificationDemosViewModel : DemoBrowserViewModel
    {
        /// <summary>
        /// Maintains the list of products.
        /// </summary>
        /// <returns>Returns product demos.</returns>
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new BusyIndicatorProductDemos());
            productdemos.Add(new ProgressbarProductDemos());
            productdemos.Add(new BadgeProductDemos());
            productdemos.Add(new HubTileProductDemos());
            return productdemos;
        }
    }

    /// <summary>
    /// Class represents the notification product demos
    /// </summary>
    public class ProgressbarProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="ProgressbarProductDemos"/> class.
        /// </summary>
        public ProgressbarProductDemos()
        {
            this.Product = "Progressbar";
            this.ProductCategory = "NOTIFICATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Linear ProgressBar", Description = "This sample showcases the features supported by Linear ProgressBar." , DemoViewType = typeof(LinearProgressBar) });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Circular ProgressBar", Description = "This sample showcases the features supported by Circular ProgressBar." , DemoViewType = typeof(CircularProgressBar) });
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "Step ProgressBar", Description = "This sample demonstrates how to create a shipment tracking process using the Syncfusion StepProgressBar control.", DemoViewType = typeof(ShipmentTracking) });
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", ThemeMode = ThemeMode.Default, Description = "This sample demonstrates how to customize the MarkerTemplate, SecondaryContent and Content in StepProgressBar control.", GroupName = "Step ProgressBar", DemoViewType = typeof(StepProgressBarCustomization) });
        }
    }

    /// <summary>
    /// Class represents the notification product demos
    /// </summary>
    public class BusyIndicatorProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="BusyIndicatorProductDemos"/> class.
        /// </summary>
        public BusyIndicatorProductDemos()
        {
            this.Product = "Busy Indicator";
            this.ProductCategory = "NOTIFICATION";
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Tag = Tag.Updated, GroupName = "BUSY INDICATOR", Description = "This sample showcases the Animation types and Busy status of SfBusyIndicator.", DemoViewType = typeof(GettingStarted) });
            this.Demos.Add(new DemoInfo() { SampleName = "Busy Indicator", GroupName = "BUSY INDICATOR", Description = "This sample showcase the real time busy indicator usage in SfDataGrid.", DemoViewType = typeof(BusyIndicator) });
        }
    }



    /// <summary>
    /// Class represents the notification product demos
    /// </summary>
    public class HubTileProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="HubTileProductDemos"/> class.
        /// </summary>
        public HubTileProductDemos()
        {
            this.Product = "Hub Tile";
            this.ProductCategory = "NOTIFICATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Hub Tile", Title = "Hub Tile", GroupName = "TILE CONTROLS", DemoViewType = typeof(HubTileView), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates the basic features along with the customizations of title, header and transition effects in HubTile control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Pulsing Tile", Title = "Pulsing Tile", GroupName = "TILE CONTROLS", DemoViewType = typeof(PulsingTileView), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates the basic features along with the customizations of title, header, pulsing scale and duration in TileView control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Windows 10 Tiles", Title = "Windows 10 Tiles", GroupName = "TILE CONTROLS", DemoViewType = typeof(WindowsTile), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates the WPF tiles which can be arranged under various container and panel controls to look like the Windows 10 start screen or in any other format based on the requirement." });
        }
    }
    
    /// <summary>
    /// Class represents the notification product demos
    /// </summary>
    public class BadgeProductDemos : ProductDemo
    {
        /// <summary>
        /// Initializes the new instance of <see cref="BadgeProductDemos"/> class.
        /// </summary>
        public BadgeProductDemos()
        {
            this.Product = "Badge";
            this.ProductCategory = "NOTIFICATION";
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Shapes", GroupName = "Badge", DemoViewType = typeof(GettingStartedDemo), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates the default and custom shapes, fill colors, anchor and alignment support available in Badge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Embed with Other Controls", Title = "Embed with Other Controls", GroupName = "Badge", DemoViewType = typeof(IntegrateWithOtherControlsDemo), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates how the Badge control embed with ListView and RibbonButton controls." });
        }
    }
}
