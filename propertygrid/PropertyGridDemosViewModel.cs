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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.propertygriddemos.wpf 
{
    public class PropertyGridDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new PropertyGridProductDemos());
            return productdemos;
        }
    }

    public class PropertyGridProductDemos : ProductDemo
    {
        public PropertyGridProductDemos()
        {
            this.Product = "Property Grid";
            this.ProductCategory = "GRIDS";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M10 1H2C1.44772 1 1 1.44772 1 2V12C1 12.5523 1.44772 13 2 13H10C10.5523 13 11 12.5523 11 12V2C11 1.44772 10.5523 1 10 1ZM2 0C0.895431 0 0 0.89543 0 2V12C0 13.1046 0.895431 14 2 14H10C11.1046 14 12 13.1046 12 12V2C12 0.895431 11.1046 0 10 0H2ZM4 4C4 4.55228 3.55228 5 3 5C2.44772 5 2 4.55228 2 4C2 3.44772 2.44772 3 3 3C3.55228 3 4 3.44772 4 4ZM3 10C3.55228 10 4 9.55228 4 9C4 8.44771 3.55228 8 3 8C2.44772 8 2 8.44771 2 9C2 9.55228 2.44772 10 3 10ZM5.5 3.5C5.5 3.22386 5.72386 3 6 3H9.5C9.77614 3 10 3.22386 10 3.5C10 3.77614 9.77614 4 9.5 4H6C5.72386 4 5.5 3.77614 5.5 3.5ZM6 8C5.72386 8 5.5 8.22386 5.5 8.5C5.5 8.77614 5.72386 9 6 9H9.5C9.77614 9 10 8.77614 10 8.5C10 8.22386 9.77614 8 9.5 8H6ZM5.5 5.5C5.5 5.22386 5.72386 5 6 5H8C8.27614 5 8.5 5.22386 8.5 5.5C8.5 5.77614 8.27614 6 8 6H6C5.72386 6 5.5 5.77614 5.5 5.5ZM6 10C5.72386 10 5.5 10.2239 5.5 10.5C5.5 10.7761 5.72386 11 6 11H8C8.27614 11 8.5 10.7761 8.5 10.5C8.5 10.2239 8.27614 10 8 10H6Z"),
                Width = 12,
                Height = 14,
            };
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/Grids.png", UriKind.RelativeOrAbsolute));
            this.Tag = Tag.None;
            this.Demos = new List<DemoInfo>();
            this.ControlDescription = "The PropertyGrid control, provides an intuitive way to display and edit properties, with the ability to sort, group, etc. ";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/PropertyGrid.png", UriKind.RelativeOrAbsolute));
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description = "This sample showcases the basic functionalities of PropertyGrid control such as filtering and searching, nested properties, customization, sorting and grouping support etc.,", GroupName = "Getting Started", ShowBusyIndicator=true, DemoViewType = typeof(GettingStarted), Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Property Definitions", GroupName = "Getting Started", DemoViewType = typeof(PropertyDefinitionDemo), Tag = Tag.None, Description = "This sample showcases the Property Definitions support of PropertyGrid control. Using Property Definitions support we can generate customized property item for the defined business model in PropertyGrid." });
            this.Demos.Add(new DemoInfo() { SampleName = "Nested and ReadOnly Support", Description = "This sample showcases the nested property exploring and readonly support of PropertyGrid control. Using nested property support, we can explore or hide the nested properties from the parent properties.", GroupName = "Getting Started", DemoViewType = typeof(NestedAndReadOnlySupportDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Built-in Editor", Description= "This sample showcases all the built-in editors available in PropertyGrid control.", GroupName = "Build-in Editors", ShowBusyIndicator= true, DemoViewType = typeof(BuiltInEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Build-in Mask Editor", Description = "This sample showcases all the built-in mask editors available in PropertyGrid control. Using built-in mask, we can restrict the user to enter irrelevant inputs ", GroupName = "Build-in Editors", ShowBusyIndicator=true, DemoViewType = typeof(BuildInMaskEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Collection Editor", Description = "This sample showcases the collection editor and property hide support in PropertyGrid control. Using CollectionEditor support we can add, remove and edit the collection type properties in PropertyGrid.", GroupName = "Build-in Editors", DemoViewType = typeof(CollectionEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Configuring at CompileTime", Description = "This sample showcases the compile time property definition support in PropertyGrid control such as editor, category, editable, order, display etc.,", GroupName = "Property Customization", DemoViewType = typeof(ConfigureAtCompiletimeDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Configuring at RunTime", Description = "This sample showcases the runtime property definition in PropertyGrid control such as editor, category, editable, order, display etc.,", GroupName = "Property Customization", DemoViewType = typeof(ConfigureAtRuntimeDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Editor", Description= "This sample showcases the CustomEditor support of PropertyGrid control. Using CustomEditor support we can assign own value editor(control) for the properties instead of default value editor.", GroupName = "Editor Customization", DemoViewType = typeof(CustomEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Category Editor", Description = "This sample showcases the CategoryEditor support of PropertyGrid control. CategoryEditor support enables us to set the related properties (one or more properties) under single or multiple category based on the need.", GroupName = "Editor Customization", DemoViewType = typeof(CategoryEditorDemo) });
        }
    }
}
