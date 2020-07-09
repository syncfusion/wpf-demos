#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace DragAndDropDemo
{
    public class ViewModel : NotificationObject
    {
        BitmapImage folder = new BitmapImage(new Uri("Images/folder.png", UriKind.RelativeOrAbsolute));
        BitmapImage file = new BitmapImage(new Uri("Images/file.png", UriKind.RelativeOrAbsolute));
        BitmapImage image = new BitmapImage(new Uri("Images/Image.png", UriKind.RelativeOrAbsolute));
        public ViewModel()
        {
            Nodes1 = new ObservableCollection<Model>();
            Nodes2 = new ObservableCollection<Model>();

            // Generate source for SfTreeView1
            PopulateData1();
            // Generate source for SfTreeView2
            PopulateData2();
        }

        private void PopulateData1()
        {
            var RootNode1 = new Model { Header = "Work Documents", Image = folder, IsExpanded = true };
            var RootNode2 = new Model { Header = "Personal Folder", Image = folder, IsExpanded = true };
             
            var ChildNode1 = new Model { Header = "Functional Specifications", Image = folder, IsExpanded = true };
            var ChildNode2 = new Model { Header = "TreeView spec", Image = file, IsExpanded = true };
            var ChildNode3 = new Model { Header = "Feature Schedule", Image = file, IsExpanded = false };
            var ChildNode4 = new Model { Header = "Overall Project Plan", Image = file, IsExpanded = false };
            var ChildNode5 = new Model { Header = "Feature Resource Allocation", Image = file, IsExpanded = false };
            var ChildNode6 = new Model { Header = "Home Remodel Folder", Image = folder, IsExpanded = true };
            var ChildNode7 = new Model { Header = "Contractor Contact Info", Image = file, IsExpanded = false };
            var ChildNode8 = new Model { Header = "Paint Color Scheme", Image = file, IsExpanded = false };
            var ChildNode9 = new Model { Header = "Flooring Woodgrain type", Image = file, IsExpanded = false };
            var ChildNode10 = new Model { Header = "Kitchen Cabinet Style", Image = file, IsExpanded = false };            

            var ChildNode11 = new Model { Header = "My Network Places", Image = folder, IsExpanded = true };
            var ChildNode12 = new Model { Header = "Server", Image = folder, IsExpanded = false };
            var ChildNode13 = new Model { Header = "My Folders", Image = folder, IsExpanded = false };           

            var ChildNode14 = new Model { Header = "My Computer", Image = folder, IsExpanded = true };
            var ChildNode15 = new Model { Header = "Music", Image = folder, IsExpanded = false };
            var ChildNode16 = new Model { Header = "Videos", Image = folder, IsExpanded = false };
            var ChildNode17 = new Model { Header = "Wallpaper.png", Image = image, IsExpanded = false };
            var ChildNode18 = new Model { Header = "My Banner.png", Image = image, IsExpanded = false };

            var ChildNode19 = new Model { Header = "Favourites", Image = folder, IsExpanded = true };
            var ChildNode20 = new Model { Header = "Image1.png", Image = image, IsExpanded = false };
            var ChildNode21 = new Model { Header = "Image2.png", Image = image, IsExpanded = false };
            var ChildNode22 = new Model { Header = "Image3.png", Image = image, IsExpanded = false };

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
            var RootNode1 = new Model { Header = "Work Documents", Image = folder, IsExpanded = true };
            var RootNode2 = new Model { Header = "Personal Folder", Image = folder, IsExpanded = true };

            var ChildNode1 = new Model { Header = "Functional Specifications", Image = folder, IsExpanded = true };
            var ChildNode2 = new Model { Header = "TreeView spec", Image = file, IsExpanded = true };
            var ChildNode3 = new Model { Header = "Feature Schedule", Image = file, IsExpanded = false };
            var ChildNode4 = new Model { Header = "Overall Project Plan", Image = file, IsExpanded = false };
            var ChildNode5 = new Model { Header = "Feature Resource Allocation", Image = file, IsExpanded = false };
            var ChildNode6 = new Model { Header = "Home Remodel Folder", Image = folder, IsExpanded = true };
            var ChildNode7 = new Model { Header = "Contractor Contact Info", Image = file, IsExpanded = false };
            var ChildNode8 = new Model { Header = "Paint Color Scheme", Image = file, IsExpanded = false };
            var ChildNode9 = new Model { Header = "Flooring Woodgrain type", Image = file, IsExpanded = false };
            var ChildNode10 = new Model { Header = "Kitchen Cabinet Style", Image = file, IsExpanded = false };

            var ChildNode11 = new Model { Header = "My Network Places", Image = folder, IsExpanded = true };
            var ChildNode12 = new Model { Header = "Server", Image = folder, IsExpanded = false };
            var ChildNode13 = new Model { Header = "My Folders", Image = folder, IsExpanded = false };

            var ChildNode14 = new Model { Header = "My Computer", Image = folder, IsExpanded = true };
            var ChildNode15 = new Model { Header = "Music", Image = folder, IsExpanded = false };
            var ChildNode16 = new Model { Header = "Videos", Image = folder, IsExpanded = false };
            var ChildNode17 = new Model { Header = "Wallpaper.png", Image = image, IsExpanded = false };
            var ChildNode18 = new Model { Header = "My Banner.png", Image = image, IsExpanded = false };

            

            var ChildNode19 = new Model { Header = "Favourites", Image = folder, IsExpanded = true };
            var ChildNode20 = new Model { Header = "Image3.png", Image = image, IsExpanded = false };
            var ChildNode21 = new Model { Header = "Image4.png", Image = image, IsExpanded = false };
            var ChildNode22 = new Model { Header = "Image5.png", Image = image, IsExpanded = false };

            var ChildNode23 = new Model { Header = "Image1.png", Image = image, IsExpanded = false };
            var ChildNode24 = new Model { Header = "Image2.png", Image = image, IsExpanded = false };

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

        public ObservableCollection<Model> Nodes1 { get; set; }

        public ObservableCollection<Model> Nodes2 { get; set; }
    }
}
