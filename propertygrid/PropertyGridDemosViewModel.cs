#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
            this.Tag = Tag.Updated;
            this.Demos = new List<DemoInfo>();
            this.Demos.Add(new DemoInfo() { SampleName = "Getting Started", Description= "This sample showcases the basic functionalities of PropertyGrid control such as filtering and searching, nested properties, customization, sorting and grouping support etc.,", GroupName = "Property Grid", DemoViewType = typeof(GettingStarted), ShowBusyIndicator = false, Tag = Tag.Updated });
            this.Demos.Add(new DemoInfo() { SampleName = "Category Editor", Description= "This sample showcases the CategoryEditor support of PropertyGrid control. CategoryEditor support enables us to set the related properties (one or more properties) under single or multiple category based on the need.", GroupName = "Property Grid", ShowBusyIndicator= false, DemoViewType = typeof(CategoryEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Custom Editor", Description= "This sample showcases the CustomEditor support of PropertyGrid control. Using CustomEditor support we can assign own value editor(control) for the properties instead of default value editor.", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(CustomEditorDemo) });
            this.Demos.Add(new DemoInfo() { SampleName = "Attribute Support", Description= "This sample showcases the supported attributes of PropertyGrid control such as editor, bindable, editable, order, display etc.,", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(AttributeSupport) });
            this.Demos.Add(new DemoInfo() { SampleName = "Build-in Editor", Description= "This sample showcases all the built-in editors available in PropertyGrid control.", GroupName = "Property Grid", DemoViewType = typeof(BuildInEditorDemo), ShowBusyIndicator = false});
            this.Demos.Add(new DemoInfo() { SampleName = "Collection Editor", Description= "This sample showcases the collection and mask editor support of PropertyGrid control. Using CollectionEditor support we can add, remove and edit the collection type properties in PropertyGrid.", GroupName = "Property Grid", ShowBusyIndicator = false, DemoViewType = typeof(CollectionEditorDemo) });
            this.Demos.Add(new DemoInfo()
            {
                SampleName = "Property Definitions",
                GroupName = "Property Grid",
                DemoViewType = typeof(PropertyDefinitionDemo),
                Tag = Tag.New,
                ShowBusyIndicator = false,
                Description = "This sample showcases the Property Definitions support of PropertyGrid control. Using Property Definitions support we can generate customized property item for the defined business model in PropertyGrid."
            });

        }
    }
}
