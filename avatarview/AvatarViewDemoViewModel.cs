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
using syncfusion.avatarviewdemo.wpf.Views;
using static System.Net.Mime.MediaTypeNames;
using Syncfusion.Windows.Shared;


namespace syncfusion.avatarviewdemo.wpf
{
    public class AvatarViewDemoViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new AvatarViewProductDemos());
            return productdemos;
        }
    }
    public class AvatarViewProductDemos : ProductDemo
    {
        public AvatarViewProductDemos()
        {
            this.Product = "AvatarView";
            this.ProductCategory = "MISCELLANEOUS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12.3383 12.1448C13.3677 11.0676 14 9.60763 14 8C14 4.68629 11.3137 2 8 2C4.68629 2 2 4.68629 2 8C2 9.6076 2.63224 11.0675 3.66163 12.1447C4.36204 10.5929 6.0406 9.5 7.99996 9.5C9.95934 9.5 11.6379 10.5929 12.3383 12.1448ZM8 15C11.866 15 15 11.866 15 8C15 4.13401 11.866 1 8 1C4.13401 1 1 4.13401 1 8C1 11.866 4.13401 15 8 15ZM10 6.5C10 7.60457 9.10457 8.5 8 8.5C6.89543 8.5 6 7.60457 6 6.5C6 5.39543 6.89543 4.5 8 4.5C9.10457 4.5 10 5.39543 10 6.5Z"),
                Width = 15,
                Height = 15,

            };
            this.Demos = new List<DemoInfo>();
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/AvatarView.png", UriKind.RelativeOrAbsolute));
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Miscellaneous.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "SfAvatarView is a graphical representation of the user image that allows you to customize the view by adding an image, background color, icon, text, etc.";
            this.Demos.Add(new DemoInfo() { SampleName = "Initials", IsAISample = false, Description = "This sample demonstrates the initials content type for AvatarView and its customization.", GroupName = "AvatarView", DemoViewType = typeof(InitialsDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Avatar Character", IsAISample = false, Description = "This sample demonstrates the predefined avatar characters available in AvatarView and their customization.", GroupName = "AvatarView", DemoViewType = typeof(AvatarCharacterDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Image", IsAISample = false, Description = "This sample demonstrates how to add custom images as avatars, replacing initials with user-defined images in AvatarView and customizing them.", GroupName = "AvatarView", DemoViewType = typeof(CustomImageDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "GroupView", Description = "This sample showcases the various group view representations of avatar view control. ", GroupName = "AvatarView", DemoViewType = typeof(GroupViewDemo) });
        }
    }
}
