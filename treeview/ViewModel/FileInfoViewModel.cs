#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class FileInfoViewModel : NotificationObject
    {
        BitmapImage folder = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/folder.png", UriKind.Relative));
        BitmapImage file = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/file.png", UriKind.Relative));
        BitmapImage image = new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/treeview_image.png", UriKind.Relative));
        public FileInfoViewModel()
        {
            Nodes1 = new ObservableCollection<FileInfoModel>();
            Nodes2 = new ObservableCollection<FileInfoModel>();

            // Generate source for SfTreeView1
            PopulateData1();
            // Generate source for SfTreeView2
            PopulateData2();
        }

        private void PopulateData1()
        {
            var RootNode1 = new FileInfoModel("Work Documents") { Image = folder, IsExpanded = true };
            var RootNode2 = new FileInfoModel("Personal Folder") { Image = folder, IsExpanded = true };

            var ChildNode1 = new FileInfoModel("Functional Specifications") { Image = folder, IsExpanded = true };
            var ChildNode2 = new FileInfoModel("TreeView spec") { Image = file, IsExpanded = true };
            var ChildNode3 = new FileInfoModel("Feature Schedule") { Image = file, IsExpanded = false };
            var ChildNode4 = new FileInfoModel("Overall Project Plan") { Image = file, IsExpanded = false };
            var ChildNode5 = new FileInfoModel("Feature Resource Allocation") { Image = file, IsExpanded = false };
            var ChildNode6 = new FileInfoModel("Home Remodel Folder") { Image = folder, IsExpanded = true };
            var ChildNode7 = new FileInfoModel("Contractor Contact Info") { Image = file, IsExpanded = false };
            var ChildNode8 = new FileInfoModel("Paint Color Scheme") { Image = file, IsExpanded = false };
            var ChildNode9 = new FileInfoModel("Flooring Woodgrain type") { Image = file, IsExpanded = false };
            var ChildNode10 = new FileInfoModel("Kitchen Cabinet Style") { Image = file, IsExpanded = false };

            var ChildNode11 = new FileInfoModel("My Network Places") { Image = folder, IsExpanded = true };
            var ChildNode12 = new FileInfoModel("Server") { Image = folder, IsExpanded = false };
            var ChildNode13 = new FileInfoModel("My Folders") { Image = folder, IsExpanded = false };

            var ChildNode14 = new FileInfoModel("My Computer") { Image = folder, IsExpanded = true };
            var ChildNode15 = new FileInfoModel("Music") { Image = folder, IsExpanded = false };
            var ChildNode16 = new FileInfoModel("Videos") { Image = folder, IsExpanded = false };
            var ChildNode17 = new FileInfoModel("Wallpaper.png") { Image = image, IsExpanded = false };
            var ChildNode18 = new FileInfoModel("My Banner.png") { Image = image, IsExpanded = false };

            var ChildNode19 = new FileInfoModel("Favourites") { Image = folder, IsExpanded = true };
            var ChildNode20 = new FileInfoModel("Stone.png") { Image = image, IsExpanded = false };
            var ChildNode21 = new FileInfoModel("Wind.png") { Image = image, IsExpanded = false };
            var ChildNode22 = new FileInfoModel("Nature.png") { Image = image, IsExpanded = false };

            RootNode1.Childs.Add(ChildNode1);
            RootNode1.Childs.Add(ChildNode3);
            RootNode1.Childs.Add(ChildNode4);
            RootNode1.Childs.Add(ChildNode5);
            RootNode2.Childs.Add(ChildNode6);

            RootNode2.Childs.Add(ChildNode11);
            RootNode2.Childs.Add(ChildNode14);
            RootNode2.Childs.Add(ChildNode19);

            ChildNode1.Childs.Add(ChildNode2);
            ChildNode6.Childs.Add(ChildNode7);
            ChildNode6.Childs.Add(ChildNode8);
            ChildNode6.Childs.Add(ChildNode9);
            ChildNode6.Childs.Add(ChildNode10);
            ChildNode11.Childs.Add(ChildNode12);
            ChildNode11.Childs.Add(ChildNode13);
            ChildNode11.Childs.Add(ChildNode17);

            ChildNode14.Childs.Add(ChildNode15);
            ChildNode14.Childs.Add(ChildNode16);
            ChildNode14.Childs.Add(ChildNode18);

            ChildNode19.Childs.Add(ChildNode20);
            ChildNode19.Childs.Add(ChildNode21);
            ChildNode19.Childs.Add(ChildNode22);

            Nodes1.Add(RootNode1);
            Nodes1.Add(RootNode2);
        }

        void PopulateData2()
        {
            var RootNode1 = new FileInfoModel("Work Documents") { Image = folder, IsExpanded = true };
            var RootNode2 = new FileInfoModel("Personal Folder") { Image = folder, IsExpanded = true };

            var ChildNode1 = new FileInfoModel("Functional Specifications") { Image = folder, IsExpanded = true };
            var ChildNode2 = new FileInfoModel("TreeView spec") { Image = file, IsExpanded = true };
            var ChildNode3 = new FileInfoModel("Feature Schedule") { Image = file, IsExpanded = false };
            var ChildNode4 = new FileInfoModel("Overall Project Plan") { Image = file, IsExpanded = false };
            var ChildNode5 = new FileInfoModel("Feature Resource Allocation") { Image = file, IsExpanded = false };
            var ChildNode6 = new FileInfoModel("Home Remodel Folder") { Image = folder, IsExpanded = true };
            var ChildNode7 = new FileInfoModel("Contractor Contact Info") { Image = file, IsExpanded = false };
            var ChildNode8 = new FileInfoModel("Paint Color Scheme") { Image = file, IsExpanded = false };
            var ChildNode9 = new FileInfoModel("Flooring Woodgrain type") { Image = file, IsExpanded = false };
            var ChildNode10 = new FileInfoModel("Kitchen Cabinet Style") { Image = file, IsExpanded = false };

            var ChildNode11 = new FileInfoModel("My Network Places") { Image = folder, IsExpanded = true };
            var ChildNode12 = new FileInfoModel("Server") { Image = folder, IsExpanded = false };
            var ChildNode13 = new FileInfoModel("My Folders") { Image = folder, IsExpanded = false };

            var ChildNode14 = new FileInfoModel("My Computer") { Image = folder, IsExpanded = true };
            var ChildNode15 = new FileInfoModel("Music") { Image = folder, IsExpanded = false };
            var ChildNode16 = new FileInfoModel("Videos") { Image = folder, IsExpanded = false };
            var ChildNode17 = new FileInfoModel("Wallpaper.png") { Image = image, IsExpanded = false };
            var ChildNode18 = new FileInfoModel("My Banner.png") { Image = image, IsExpanded = false };



            var ChildNode19 = new FileInfoModel("Favourites") { Image = folder, IsExpanded = true };
            var ChildNode20 = new FileInfoModel("Image3.png") { Image = image, IsExpanded = false };
            var ChildNode21 = new FileInfoModel("Image4.png") { Image = image, IsExpanded = false };
            var ChildNode22 = new FileInfoModel("Image5.png") { Image = image, IsExpanded = false };

            var ChildNode23 = new FileInfoModel("Image1.png") { Image = image, IsExpanded = false };
            var ChildNode24 = new FileInfoModel("Image2.png") { Image = image, IsExpanded = false };

            RootNode1.Childs.Add(ChildNode1);
            RootNode1.Childs.Add(ChildNode3);
            RootNode1.Childs.Add(ChildNode4);
            RootNode1.Childs.Add(ChildNode5);
            RootNode2.Childs.Add(ChildNode6);

            RootNode2.Childs.Add(ChildNode11);
            RootNode2.Childs.Add(ChildNode14);
            RootNode2.Childs.Add(ChildNode19);

            ChildNode1.Childs.Add(ChildNode2);
            ChildNode6.Childs.Add(ChildNode7);
            ChildNode6.Childs.Add(ChildNode8);
            ChildNode6.Childs.Add(ChildNode9);
            ChildNode6.Childs.Add(ChildNode10);
            ChildNode11.Childs.Add(ChildNode12);
            ChildNode11.Childs.Add(ChildNode13);

            ChildNode11.Childs.Add(ChildNode23);
            ChildNode11.Childs.Add(ChildNode24);

            ChildNode14.Childs.Add(ChildNode15);
            ChildNode14.Childs.Add(ChildNode16);
            ChildNode14.Childs.Add(ChildNode17);
            ChildNode14.Childs.Add(ChildNode18);

            ChildNode19.Childs.Add(ChildNode20);
            ChildNode19.Childs.Add(ChildNode21);
            ChildNode19.Childs.Add(ChildNode22);

            Nodes2.Add(RootNode1);
            Nodes2.Add(RootNode2);
        }

        public ObservableCollection<FileInfoModel> Nodes1 { get; set; }

        public ObservableCollection<FileInfoModel> Nodes2 { get; set; }
    }
}
