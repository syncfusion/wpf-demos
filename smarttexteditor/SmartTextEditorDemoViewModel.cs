#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.smarttexteditordemos.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Syncfusion.UI.Xaml.SmartComponents;

namespace syncfusion.smarttexteditordemos.wpf
{
    public class SmartTextEditorViewDemoViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SmartTextEditorViewProductDemos());
            return productdemos;
        }
    }

    public class SmartTextEditorViewProductDemos : ProductDemo
    {
        public SmartTextEditorViewProductDemos()
        {
            this.Product = "Smart TextEditor";
            this.ProductCategory = "SMART COMPONENTS";
            this.IsPreview = true;
            this.Tag = Tag.New;
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M4.5 4C4.77614 4 5 4.22386 5 4.5C5 4.77614 4.77614 5 4.5 5H2C1.44772 5 1 5.44772 1 6V12C1 12.5523 1.44772 13 2 13H14C14.5523 13 15 12.5523 15 12V10.5C15 10.2239 15.2239 10 15.5 10C15.7761 10 16 10.2239 16 10.5V12C16 13.1046 15.1046 14 14 14H2C0.895431 14 0 13.1046 0 12V6C1.28853e-07 4.89543 0.895431 4 2 4H4.5ZM13.6592 5.87988C14.1916 5.34778 15.0545 5.34778 15.5869 5.87988C16.1193 6.4123 16.1201 7.27605 15.5879 7.80859L12.0459 11.3506C11.973 11.4235 11.878 11.4727 11.7764 11.4902L10.3311 11.7393C10.1728 11.7665 10.0112 11.716 9.89648 11.6035C9.7819 11.4911 9.72799 11.3306 9.75195 11.1719L9.97656 9.7002C9.99268 9.59507 10.042 9.49711 10.1172 9.42188L13.6592 5.87988ZM6.5166 11H5.5791L5.2832 10.1006H3.75L3.45508 11H2.52051L4.10547 6.73438H4.92285L6.5166 11ZM10.9404 10.0127L10.8447 10.6348L11.4512 10.5303L13.916 8.06641L13.4014 7.55176L10.9404 10.0127ZM3.97559 9.41211H5.05664L4.51562 7.7666L3.97559 9.41211ZM8.03711 5.96289L9.5 6.5L8.03711 7.03711L7.5 8.5L6.96289 7.03711L5.5 6.5L6.96289 5.96289L7.5 4.5L8.03711 5.96289ZM14.8799 6.58691C14.738 6.44533 14.5081 6.44533 14.3662 6.58691L14.1084 6.84473L14.623 7.35938L14.8809 7.10156C15.0225 6.95954 15.0218 6.72881 14.8799 6.58691ZM10.9824 1.68066L11.5146 2.98535L12.8193 3.51855L13.5 3.7959L12.8193 4.07422L11.5146 4.60645L10.9824 5.91113L10.7041 6.59277L10.4258 5.91113L9.89355 4.60645L8.58887 4.07422L7.9082 3.7959L8.58887 3.51855L9.89355 2.98535L10.4258 1.68066L10.7041 1L10.9824 1.68066Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Smart TextEditor.png", UriKind.RelativeOrAbsolute));
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Smart Components.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "This sample demonstrates the default functionality of the SfSmartTextEditor control, offering inline or popup AI-assisted text suggestions while typing that can be accepted with Tab or the Right arrow.";
            this.Demos.Add(new DemoInfo() { SampleName = "Smart TextEditor", Tag = Tag.New, IsAISample = true, Description = "This sample demonstrates the default functionality of the SfSmartTextEditor control, offering inline or popup AI-assisted text suggestions while typing that can be accepted with Tab or the Right arrow.", GroupName = "Smart TextEditor", DemoViewType = typeof(SmartTextEditorDemo) });
        }
    }
}
