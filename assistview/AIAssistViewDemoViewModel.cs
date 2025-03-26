#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
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
using System.Windows.Media.Imaging;
using System.Windows.Media;
using syncfusion.assistviewdemo.wpf.Views;

namespace syncfusion.assistviewdemo.wpf
{
    public class AIAssistViewDemoViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new AIAssistViewProductDemos());
            return productdemos;
        }
    }

    public class AIAssistViewProductDemos : ProductDemo
    {
        public AIAssistViewProductDemos()
        {
            this.Product = "AIAssistView";
            this.ProductCategory = "CONVERSATIONAL UI";
            this.IsPreview = false;
            this.Tag = Tag.Updated;
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12.643 0.396994C12.6908 0.170187 12.8881 0.00592932 13.1198 0.00015676C13.3515 -0.00561577 13.5568 0.14861 13.6158 0.372759L13.7576 0.911495C13.9289 1.56259 14.4374 2.07108 15.0885 2.24241L15.6272 2.38418C15.8383 2.43973 15.989 2.62579 15.9994 2.84381C16.0099 3.06183 15.8777 3.26143 15.6729 3.33689L14.9155 3.61593C14.3611 3.82018 13.936 4.27469 13.7693 4.84149L13.612 5.37652C13.5479 5.5942 13.3454 5.74148 13.1185 5.73525C12.8917 5.72902 12.6975 5.57083 12.6456 5.34996L12.5483 4.93646C12.4022 4.31554 11.9493 3.81213 11.3472 3.6014L10.5994 3.33965C10.3909 3.26667 10.255 3.06549 10.2651 2.8448C10.2752 2.62411 10.429 2.43623 10.6433 2.38265L11.1789 2.24874C11.8726 2.07534 12.4063 1.52119 12.5536 0.821562L12.643 0.396994ZM13.147 3.82058C13.3876 3.44543 13.7133 3.13011 14.0989 2.90157C13.7128 2.67212 13.386 2.35504 13.1451 1.97693C12.9054 2.35331 12.5803 2.66972 12.1958 2.89928C12.5818 3.12875 12.9071 3.44505 13.147 3.82058ZM9.11891 4.29743C9.16666 4.07062 9.36402 3.90636 9.59573 3.90059C9.82744 3.89482 10.0327 4.04905 10.0917 4.27319L10.198 4.67725C10.3151 5.12199 10.6624 5.46933 11.1072 5.58636L11.5112 5.69269C11.7223 5.74823 11.873 5.93429 11.8834 6.15231C11.8938 6.37034 11.7616 6.56994 11.5568 6.6454L10.9888 6.85468C10.6101 6.9942 10.3198 7.30466 10.2059 7.69183L10.0879 8.0931C10.0238 8.31078 9.82126 8.45806 9.59445 8.45183C9.36763 8.44559 9.17344 8.28741 9.12147 8.06654L9.0485 7.75641C8.9487 7.33228 8.63935 6.98841 8.22809 6.84447L7.66721 6.64815C7.45869 6.57517 7.32279 6.37399 7.33292 6.15331C7.34304 5.93262 7.4968 5.74473 7.71113 5.69115L8.11286 5.59072C8.58666 5.47227 8.95126 5.09375 9.05187 4.61586L9.11891 4.29743ZM9.61781 5.72685C9.481 5.90747 9.31778 6.06696 9.13358 6.19969C9.31864 6.33252 9.48233 6.49216 9.61944 6.67278C9.75662 6.49271 9.92018 6.33373 10.1048 6.20148C9.91961 6.0685 9.7554 5.90843 9.61781 5.72685ZM2 2.5C2 2.22386 2.22386 2 2.5 2H8.5C8.77614 2 9 1.77614 9 1.5C9 1.22386 8.77614 1 8.5 1H2.5C1.67157 1 1 1.67158 1 2.5V15.1182C1 15.7357 1.82026 15.9505 2.12295 15.4124L3.82728 12.3823C3.96011 12.1462 4.21 12 4.48097 12H13.5C14.3284 12 15 11.3284 15 10.5V7.5C15 7.22386 14.7761 7 14.5 7C14.2239 7 14 7.22386 14 7.5V10.5C14 10.7761 13.7761 11 13.5 11H4.48097C3.84872 11 3.26564 11.341 2.95569 11.8921L2 13.5912V2.5Z"),
                Width = 15,
                Height = 15,
            };
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/AIAssistView.png", UriKind.RelativeOrAbsolute));
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Conversational UI.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "This sample demonstrates the default functionality of the AIAssistView component, offering a simple chat interface for communicating with an AI device.";
            this.Demos.Add(new DemoInfo() { SampleName = "AIAssistView", Tag = Tag.Updated, IsAISample = true, Description = "This sample demonstrates the default functionality of the AIAssistView component, offering a simple chat interface for communicating with an AI device.", GroupName = "AssistView", DemoViewType = typeof(AssistViewDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Reservation", Description = "This sample demonstrates a reservation chatbot that provides a user-friendly interface for booking appointments and managing reservations. ", GroupName = "AssistView", DemoViewType = typeof(ComposeView) });
            this.Demos.Add(new DemoInfo() { SampleName = "Flyout", Description = "This sample showcases how to host the AIAssistView in a flyout seamlessly integrating it into an application while minimizing space usage.", GroupName = "AssistView", DemoViewType = typeof(Overview) });


        }
    }
}
