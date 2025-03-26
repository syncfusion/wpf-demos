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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.kanbandemos.wpf
{
    public class KanbanDemosViewModel : DemoBrowserViewModel
    {
        public override List<ProductDemo> GetDemosDetails()
        {
            var productdemos = new List<ProductDemo>();
            productdemos.Add(new KanbanProductDemos());
            return productdemos;
        }
    }

    public class KanbanProductDemos : ProductDemo
    {
        public KanbanProductDemos()
        {
            this.Product = "Kanban";
            this.ProductCategory = "DATA VISUALIZATION";
            this.ListViewImagePathData = new System.Windows.Shapes.Path()
            {
                Data = Geometry.Parse("M3 2H13C13.5523 2 14 2.44772 14 3V13C14 13.5523 13.5523 14 13 14H3C2.44772 14 2 13.5523 2 13V3C2 2.44772 2.44772 2 3 2ZM1 3C1 1.89543 1.89543 1 3 1H13C14.1046 1 15 1.89543 15 3V13C15 14.1046 14.1046 15 13 15H3C1.89543 15 1 14.1046 1 13V3ZM4 3C3.44772 3 3 3.44772 3 4V9C3 9.55228 3.44772 10 4 10C4.55228 10 5 9.55228 5 9V4C5 3.44772 4.55228 3 4 3ZM7 4C7 3.44772 7.44772 3 8 3C8.55228 3 9 3.44772 9 4V6C9 6.55228 8.55228 7 8 7C7.44772 7 7 6.55228 7 6V4ZM12 3C11.4477 3 11 3.44772 11 4V12C11 12.5523 11.4477 13 12 13C12.5523 13 13 12.5523 13 12V4C13 3.44772 12.5523 3 12 3Z"),
                Width = 16,
                Height = 16,
            };
            this.Demos = new List<DemoInfo>();
            this.HeaderImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/ProductCategoryImages/DataVisualization.png", UriKind.RelativeOrAbsolute));
            this.ControlDescription = "Kanban is an intuitive project management control with a customizable board view for tracking progress.";
            this.GalleryViewImageSource = new BitmapImage(new Uri(@"/syncfusion.demoscommon.wpf;component/Assets/GalleryViewImages/Kanban.png", UriKind.RelativeOrAbsolute));
            this.Tag = Tag.Updated;

            DemoInfo GettingStartedDemo = new DemoInfo()
            {
                SampleName = "Getting Started",

                GroupName = "KANBAN BOARD",

                Description = "This sample demonstrates the kanban with columns. By default, the columns are sized smartly to arrange the default elements of the cards with better readability.",

                DemoViewType = typeof(GettingStarted),

            };

            List<Documentation> GettingStartedHelpDocuments = new List<Documentation>()
            {
                new Documentation(){ Content = "Kanban - Getting Started", Uri = new Uri("https://help.syncfusion.com/wpf/kanban-board/getting-started")}
            };

            GettingStartedDemo.Documentations = GettingStartedHelpDocuments;
            this.Demos.Add(GettingStartedDemo);
            this.Demos.Add(new DemoInfo() { SampleName = "Customization", GroupName = "KANBAN BOARD", Description = "This sample demonstrates the kanban view customization using DataTemplates.", DemoViewType = typeof(Customization) });
            this.Demos.Add(new DemoInfo() { SampleName = "Swimlane", GroupName = "KANBAN BOARD", Description = "Swim lanes are horizontal categorizations that allow you to categorize your current workflow by different projects, teams, users, or whatever you need.", DemoViewType = typeof(Swimlane) });
            this.Demos.Add(new DemoInfo() { SampleName = "Dialog Editing", GroupName = "KANBAN BOARD", Description = "This sample showcases how to perform create, and update operations with the Kanban control. You can add a new card using the button in the properties panel, and update a card by tapping on it to open the details in a dialog.", DemoViewType = typeof(DialogEditing), Tag = Tag.New });
        }
    }
}
