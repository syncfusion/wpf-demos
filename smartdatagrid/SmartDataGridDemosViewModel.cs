#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.smartdatagriddemos.wpf
{
    public class SmartDataGridDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SmartDataGridProductDemos());
            return productdemos;
        }
    }

    public class SmartDataGridProductDemos : ProductDemo
    {
        public SmartDataGridProductDemos()
        {
            this.Product = "Smart DataGrid";
            this.ProductCategory = "SMART COMPONENTS";
            this.IsPreview = true;
            this.Tag = Tag.New;
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M13 1C14.1046 1 15 1.89543 15 3V8.34473L14.3994 8.09961L14.0342 7.20508L14.0332 7.20312C14.0228 7.17783 14.0112 7.15336 14 7.12891V6H10.5V7.51465L10.2607 8.09961L9.5 8.41016V6H6.5V9H8.63574C8.39813 9.28939 8.26272 9.64011 8.23047 10H6.5V11.6211C5.11093 12.298 5.17451 14.3684 6.68066 14.9229H6.68164L6.89355 15H3L2.7959 14.9893C1.85435 14.8938 1.1062 14.1457 1.01074 13.2041L1 13V3C1 1.89543 1.89543 1 3 1H13ZM14.5 12C14.7761 12 15 12.2239 15 12.5V13C15 14.1046 14.1046 15 13 15H12.5C12.2239 15 12 14.7761 12 14.5C12 14.2239 12.2239 14 12.5 14H13C13.5523 14 14 13.5523 14 13V12.5C14 12.2239 14.2239 12 14.5 12ZM8.41699 11.7334C8.51328 11.4714 8.88419 11.4714 8.98047 11.7334L9.25977 12.4941C9.29015 12.5764 9.35519 12.6415 9.4375 12.6719L10.1982 12.9512C10.4603 13.0475 10.4603 13.4184 10.1982 13.5146L9.4375 13.7939C9.35504 13.8244 9.29008 13.8901 9.25977 13.9727L8.98047 14.7334C8.88403 14.9951 8.51332 14.9952 8.41699 14.7334L8.1377 13.9727C8.10733 13.89 8.04162 13.8243 7.95898 13.7939L7.19824 13.5146C6.93643 13.4183 6.93654 13.0476 7.19824 12.9512L7.95898 12.6719C8.0415 12.6416 8.10727 12.5766 8.1377 12.4941L8.41699 11.7334ZM2 13C2 13.5523 2.44772 14 3 14H5.5V10H2V13ZM12.0156 7.77246C12.1308 7.49025 12.5303 7.49025 12.6455 7.77246L13.1699 9.05566C13.2207 9.17993 13.3191 9.27928 13.4434 9.33008L14.7275 9.85449C15.0096 9.9698 15.0096 10.3691 14.7275 10.4844L13.4434 11.0088C13.3193 11.0596 13.2207 11.1582 13.1699 11.2822L12.6455 12.5664C12.5302 12.8483 12.1309 12.8484 12.0156 12.5664L11.4912 11.2822C11.4404 11.158 11.3411 11.0595 11.2168 11.0088L9.93359 10.4844C9.65159 10.3691 9.65171 9.96987 9.93359 9.85449L11.2168 9.33008C11.3411 9.27932 11.4404 9.17992 11.4912 9.05566L12.0156 7.77246ZM2 9H5.5V6H2V9ZM3 2C2.44772 2 2 2.44772 2 3V5H14V3C14 2.44772 13.5523 2 13 2H3Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>(); 
            this.ControlDescription = "The SmartDatgrid is an intelligent, AI-powered data grid control that lets users retrieve detailed information from the grid and perform actions on the data interactively using natural-language prompts, providing a seamless and efficient data-management experience.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Smart DataGrid.png", UriKind.RelativeOrAbsolute));
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Smart Components.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Smart DataGrid", Tag = Tag.New, IsAISample = true, GroupName = "Smart DataGrid", Description = "The SmartDatgrid is an intelligent, AI-powered data grid control that lets users retrieve detailed information from the grid and perform actions on the data interactively using natural-language prompts, providing a seamless and efficient data-management experience.", DemoViewType = typeof(SmartDataGridDemo) });          
        }
    }
}
