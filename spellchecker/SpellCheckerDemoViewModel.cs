#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace syncfusion.spellcheckerdemo.wpf
{
    public class SpellCheckerDemoViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new SpellCheckerProductDemos());
            return productdemos;
        }
    }

    public class SpellCheckerProductDemos : ProductDemo
    {
        public SpellCheckerProductDemos()
        {
            this.Product = "Spell Checker";
            this.ProductCategory = "MISCELLANEOUS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M12 1H2C1.44772 1 1 1.44772 1 2V4H13V2C13 1.44772 12.5523 1 12 1ZM0 4V5V12C0 13.1046 0.89543 14 2 14H12C13.1046 14 14 13.1046 14 12V2C14 0.895431 13.1046 0 12 0H2C0.895431 0 0 0.89543 0 2V4ZM13 5H1V12C1 12.5523 1.44772 13 2 13H12C12.5523 13 13 12.5523 13 12V5ZM3 7C2.72386 7 2.5 7.22386 2.5 7.5C2.5 7.77614 2.72386 8 3 8H5C5.27614 8 5.5 7.77614 5.5 7.5C5.5 7.22386 5.27614 7 5 7H3ZM2.5 10.5C2.5 10.2239 2.72386 10 3 10H11C11.2761 10 11.5 10.2239 11.5 10.5C11.5 10.7761 11.2761 11 11 11H3C2.72386 11 2.5 10.7761 2.5 10.5ZM7 7.5C7 6.67157 7.67157 6 8.5 6H10.5C11.3284 6 12 6.67157 12 7.5C12 8.32843 11.3284 9 10.5 9H8.5C7.67157 9 7 8.32843 7 7.5ZM8 7.5C8 7.22386 8.22386 7 8.5 7H10.5C10.7761 7 11 7.22386 11 7.5C11 7.77614 10.7761 8 10.5 8H8.5C8.22386 8 8 7.77614 8 7.5Z"),
                Width = 14,
                Height = 14,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Miscellaneous.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "The SpellChecker control provides spell checking functionality. Error words are underlined and corrected through suggestions in the context menu. ";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Spell Checker.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic features of the SfSpellChecker which checks the spellings of any text such as Provide built-in spell check options, Provide suggestions through dialogue and context menu", GroupName = "SPELL CHECKER", DemoViewType = typeof(SpellCheckerDemo) });
           


        }
    }
}
