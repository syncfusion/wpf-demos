#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.Generic;

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
            this.Tag = Tag.None;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic functionalities of PropertyGrid control such as filtering and searching, nested properties, customization, sorting and grouping support etc.,", GroupName = "Property Grid", DemoViewType = typeof(GettingStarted), ShowBusyIndicator = false, Tag = Tag.None });
            this.Demos.Add(new DemoInfo() { SampleName = "Built-in Editor", Description= "This sample showcases all the built-in editors available in PropertyGrid control.", GroupName = "Property Grid", ShowBusyIndicator= false, DemoViewType = typeof(BuiltInEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Build-in Mask Editor", Description = "This sample showcases all the built-in mask editors available in PropertyGrid control. Using built-in mask, we can restrict the user to enter irrelevant inputs ", GroupName = "Property Grid", DemoViewType = typeof(BuildInMaskEditorDemo), ShowBusyIndicator = false });
            this.Demos.Add(new DemoInfo() { SampleName = "Configuring at CompileTime", Description = "This sample showcases the compile time property definition support in PropertyGrid control such as editor, category, editable, order, display etc.,", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(ConfigureAtCompiletimeDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Configuring at RunTime", Description = "This sample showcases the runtime property definition in PropertyGrid control such as editor, category, editable, order, display etc.,", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(ConfigureAtRuntimeDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Property Definitions", GroupName = "Property Grid",DemoViewType = typeof(PropertyDefinitionDemo),Tag = Tag.None,ShowBusyIndicator = false,Description = "This sample showcases the Property Definitions support of PropertyGrid control. Using Property Definitions support we can generate customized property item for the defined business model in PropertyGrid."});
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Editor", Description= "This sample showcases the CustomEditor support of PropertyGrid control. Using CustomEditor support we can assign own value editor(control) for the properties instead of default value editor.", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(CustomEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Nested and ReadOnly Support", Description = "This sample showcases the nested property exploring and readonly support of PropertyGrid control. Using nested property support, we can explore or hide the nested properties from the parent properties.", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(NestedAndReadOnlySupportDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Collection Editor", Description= "This sample showcases the collection editor and property hide support in PropertyGrid control. Using CollectionEditor support we can add, remove and edit the collection type properties in PropertyGrid.", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(CollectionEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Category Editor", Description = "This sample showcases the CategoryEditor support of PropertyGrid control. CategoryEditor support enables us to set the related properties (one or more properties) under single or multiple category based on the need.", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(CategoryEditorDemo) });
        }
    }
}
