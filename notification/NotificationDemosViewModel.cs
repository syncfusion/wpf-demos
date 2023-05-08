#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M4 5H12C13.6569 5 15 6.34315 15 8C15 9.65685 13.6569 11 12 11H4C2.34315 11 1 9.65685 1 8C1 6.34315 2.34315 5 4 5ZM0 8C0 5.79086 1.79086 4 4 4H12C14.2091 4 16 5.79086 16 8C16 10.2091 14.2091 12 12 12H4C1.79086 12 0 10.2091 0 8ZM4 6C2.89543 6 2 6.89543 2 8C2 9.10457 2.89543 10 4 10H7C8.10457 10 9 9.10457 9 8C9 6.89543 8.10457 6 7 6H4Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Notification.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF SfProgressBar is a user interface element that displays the progress of a task or operation in multiple steps or in linear or circular shape. It provides customization options, including determinate and indeterminate states, segments, and color ranges to display progress.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Progressbar.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M9.92972 0.736366C10.0182 0.474791 10.302 0.334491 10.5636 0.422998C11.8239 0.849424 12.9579 1.58344 13.863 2.55858C14.7681 3.53373 15.4157 4.71922 15.7472 6.00773C16.0787 7.29624 16.0836 8.64708 15.7615 9.93796C15.4393 11.2288 14.8003 12.419 13.9023 13.4007C13.0043 14.3824 11.8756 15.1246 10.6185 15.5601C9.36132 15.9957 8.01539 16.1108 6.70252 15.8951C5.38966 15.6794 4.15132 15.1397 3.09961 14.3248C2.04791 13.5099 1.21604 12.4456 0.679332 11.2282C0.567937 10.9755 0.682468 10.6803 0.935145 10.5689C1.18782 10.4576 1.48296 10.5721 1.59436 10.8248C2.06398 11.89 2.79186 12.8213 3.7121 13.5343C4.63234 14.2474 5.71589 14.7196 6.86465 14.9084C8.01341 15.0971 9.1911 14.9963 10.2911 14.6152C11.3911 14.2341 12.3787 13.5847 13.1645 12.7257C13.9502 11.8667 14.5094 10.8254 14.7912 9.69584C15.0731 8.56632 15.0688 7.38433 14.7788 6.25688C14.4887 5.12944 13.9221 4.09213 13.1301 3.23888C12.3381 2.38563 11.3458 1.74337 10.2431 1.37024C9.98151 1.28174 9.84121 0.997941 9.92972 0.736366Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Notification.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription ="The WPF Busy Indicator control enables users to know when the application is busy.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Busy Indicator.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", GroupName = "BUSY INDICATOR", Description = "This sample showcases the Animation types and Busy status of SfBusyIndicator.", DemoViewType = typeof(GettingStarted) });
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M1 0C0.447715 0 0 0.447716 0 1V9C0 9.55229 0.447716 10 1 10H9C9.55229 10 10 9.55228 10 9V1C10 0.447715 9.55228 0 9 0H1ZM12 3H11V10C11 10.5523 10.5523 11 10 11H3V12C3 12.5523 3.44772 13 4 13H12C12.5523 13 13 12.5523 13 12V4C13 3.44772 12.5523 3 12 3Z"),
                Width = 13,
                Height = 13,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Notification.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The WPF Hub Tile is used to create a UI similar to the tile feature in Windows Desktop and Mobile to provide updates and notifications with various transition effects.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Hub Tile.png", UriKind.RelativeOrAbsolute));
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
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M5 0H11C13.76 0 16 2.24 16 5C16 7.76 13.76 10 11 10H5C2.24 10 0 7.76 0 5C0 2.24 2.24 0 5 0ZM4.99 6.59C5.15 6.4 5.27 6.15 5.36 5.85L5.34 5.87C5.43 5.57 5.48 5.21 5.48 4.79C5.48 4.44 5.44 4.14 5.37 3.9C5.3 3.65 5.2 3.45 5.07 3.3C4.95 3.14 4.8 3.03 4.63 2.96C4.47 2.89 4.29 2.85 4.1 2.85C3.9 2.85 3.71 2.88 3.54 2.95C3.36 3.02 3.22 3.12 3.09 3.24C2.96 3.36 2.86 3.51 2.79 3.69C2.72 3.87 2.68 4.06 2.68 4.28C2.68 4.48 2.71 4.66 2.77 4.82C2.83 4.98 2.92 5.12 3.03 5.23C3.14 5.34 3.27 5.43 3.42 5.49C3.57 5.55 3.74 5.58 3.91 5.58C4.01 5.58 4.11 5.57 4.2 5.54C4.29 5.52 4.38 5.48 4.45 5.44C4.53 5.39 4.59 5.35 4.65 5.29C4.71 5.23 4.76 5.17 4.79 5.11H4.8C4.8 5.36 4.77 5.57 4.72 5.76C4.67 5.95 4.6 6.1 4.5 6.23C4.41 6.36 4.29 6.46 4.16 6.52C4.02 6.59 3.88 6.62 3.71 6.62C3.64787 6.62 3.58575 6.61212 3.51663 6.60336C3.50787 6.60225 3.499 6.60112 3.49 6.6C3.41 6.59 3.34001 6.57 3.27002 6.55L3.27 6.55L3.26997 6.54999C3.19998 6.52999 3.12999 6.51 3.07 6.48C3.01 6.45 2.92 6.4 2.92 6.4V7.01C2.94582 7.01646 2.97582 7.02708 3.00998 7.03919C3.02873 7.04583 3.04874 7.05291 3.07 7.06C3.10299 7.071 3.139 7.07897 3.17638 7.08725C3.20698 7.09402 3.23849 7.101 3.27 7.11C3.34 7.13 3.42 7.14 3.5 7.15C3.57998 7.16 3.65997 7.16 3.73995 7.16H3.74C3.99 7.16 4.22 7.11 4.43 7.02C4.65 6.93 4.83 6.78 4.99 6.59ZM8.32 6.59C8.48 6.4 8.6 6.15 8.69 5.85L8.67 5.87C8.76 5.57 8.81 5.21 8.81 4.79C8.81 4.44 8.77 4.14 8.7 3.9C8.63 3.65 8.53 3.45 8.4 3.3C8.28 3.14 8.13 3.03 7.96 2.96C7.8 2.89 7.62 2.85 7.43 2.85C7.23 2.85 7.04 2.88 6.87 2.95C6.69 3.02 6.55 3.12 6.42 3.24C6.29 3.36 6.19 3.51 6.12 3.69C6.05 3.87 6.01 4.06 6.01 4.28C6.01 4.48 6.04 4.66 6.1 4.82C6.16 4.98 6.25 5.12 6.36 5.23C6.47 5.34 6.6 5.43 6.75 5.49C6.9 5.55 7.07 5.58 7.24 5.58C7.34 5.58 7.44 5.57 7.53 5.54C7.62 5.52 7.71 5.48 7.78 5.44C7.86 5.39 7.92 5.35 7.98 5.29C8.04 5.23 8.09 5.17 8.12 5.11H8.13C8.13 5.36 8.1 5.57 8.05 5.76C8 5.95 7.93 6.1 7.83 6.23C7.74 6.36 7.63 6.45 7.49 6.52C7.35 6.59 7.21 6.62 7.04 6.62C6.97788 6.62 6.91575 6.61212 6.84664 6.60336C6.83787 6.60225 6.829 6.60112 6.82 6.6C6.74 6.59 6.67 6.57 6.6 6.55C6.53 6.53 6.46 6.51 6.4 6.48C6.34 6.45 6.25 6.4 6.25 6.4V7.01C6.27583 7.01646 6.30582 7.02708 6.33999 7.03919C6.35874 7.04583 6.37874 7.05291 6.4 7.06C6.43299 7.071 6.469 7.07897 6.50638 7.08725C6.53698 7.09402 6.56849 7.101 6.6 7.11C6.67 7.13 6.75 7.15 6.83 7.15C6.90999 7.16 6.98997 7.16 7.06995 7.16H7.07C7.32 7.16 7.55 7.11 7.76 7.02C7.98 6.93 8.16 6.78 8.32 6.59ZM12 5.33H13.33V4.66H12V3.33H11.33V4.66H10V5.33H11.33V6.66H12V5.33ZM4.58914 3.65063C4.52914 3.57063 4.44914 3.51062 4.35914 3.46062C4.26914 3.42062 4.17914 3.39062 4.06914 3.39062C3.97914 3.39062 3.88914 3.41063 3.79914 3.45063C3.71914 3.49063 3.63914 3.54063 3.57914 3.61063C3.51914 3.68063 3.46914 3.76063 3.42914 3.86063C3.38914 3.96063 3.36914 4.07062 3.36914 4.19062C3.36914 4.32062 3.38914 4.44063 3.41914 4.54063C3.45914 4.64063 3.50914 4.73063 3.56914 4.79063C3.62914 4.86063 3.70914 4.91063 3.79914 4.95063C3.88914 4.99063 3.98914 5.00063 4.09914 5.00063C4.19914 5.00063 4.28914 4.98063 4.36914 4.95063C4.44914 4.92063 4.51914 4.87063 4.58914 4.80062C4.64914 4.74062 4.69914 4.67063 4.72914 4.58063C4.75914 4.50063 4.77914 4.41063 4.77914 4.31063C4.77914 4.17063 4.75914 4.04063 4.72914 3.93063C4.68914 3.82063 4.63914 3.72062 4.57914 3.64062L4.58914 3.65063ZM7.91921 3.65063C7.85921 3.57063 7.77922 3.51062 7.68922 3.46062C7.59922 3.42062 7.50922 3.39062 7.39922 3.39062C7.30922 3.39062 7.21921 3.41063 7.12921 3.45063C7.03921 3.49063 6.96922 3.54063 6.90922 3.61063C6.84922 3.68063 6.79922 3.76063 6.75922 3.86063C6.71922 3.96063 6.69922 4.07062 6.69922 4.19062C6.69922 4.32062 6.71921 4.44063 6.74921 4.54063C6.78921 4.64063 6.83922 4.73063 6.89922 4.79063C6.95922 4.86063 7.03921 4.91063 7.12921 4.95063C7.21921 4.99063 7.31921 5.00063 7.42921 5.00063C7.52921 5.00063 7.61922 4.98063 7.69922 4.95063C7.77922 4.91063 7.84921 4.87063 7.91921 4.80062C7.98921 4.73062 8.02921 4.67063 8.05921 4.58063C8.08921 4.50063 8.10921 4.41063 8.10921 4.31063C8.10921 4.17063 8.08921 4.04063 8.05921 3.93063C8.01921 3.82063 7.96922 3.72062 7.90922 3.64062L7.91921 3.65063Z"),
                Width = 16,
                Height = 10,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Notification.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The Badge control is used to notify users of new or unread messages, notifications, status, and more.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Badge.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Title = "Shapes", GroupName = "Badge", DemoViewType = typeof(GettingStartedDemo), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates the default and custom shapes, fill colors, anchor and alignment support available in Badge control." });
            this.Demos.Add(new DemoInfo() { SampleName = "Embed with Other Controls", Title = "Embed with Other Controls", GroupName = "Badge", DemoViewType = typeof(IntegrateWithOtherControlsDemo), ThemeMode = ThemeMode.Inherit, Description = "This sample demonstrates how the Badge control embed with ListView and RibbonButton controls." });
        }
    }
}
