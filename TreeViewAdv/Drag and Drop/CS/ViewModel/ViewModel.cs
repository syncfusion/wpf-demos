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

namespace DragandDropDemo
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            TreeViewAdv1_Models = new ObservableCollection<Model>();
            TreeViewAdv2_Models = new ObservableCollection<Model>();

            TreeViewAdv1();
            TreeViewAdv2();
            
        }

        void TreeViewAdv1()
        {
            BitmapImage image = new BitmapImage(new Uri("images/root.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_RootNode = new Model { Header = "Mailbox", Image = image, IsExpanded = true };

            BitmapImage image1 = new BitmapImage(new Uri("images/calendar.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode = new Model { Header = "Calendar", Image = image1, IsExpanded = false };

            BitmapImage image2 = new BitmapImage(new Uri("images/contacts.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode1 = new Model { Header = "Contacts", Image = image2, IsExpanded = false };

            BitmapImage image3 = new BitmapImage(new Uri("images/deleted.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode2 = new Model { Header = "Deleted Items", Image = image3, IsExpanded = false };

            BitmapImage image4 = new BitmapImage(new Uri("images/drafts.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode3 = new Model { Header = "Drafts", Image = image4, IsExpanded = false };

            BitmapImage image5 = new BitmapImage(new Uri("images/inbox.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode4 = new Model { Header = "Inbox", Image = image5, IsExpanded = false };

            BitmapImage image6 = new BitmapImage(new Uri("images/outbox.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode5 = new Model { Header = "Outbox", Image = image6, IsExpanded = false };

            BitmapImage image7 = new BitmapImage(new Uri("images/sentitems.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode6 = new Model { Header = "Sent Items", Image = image7, IsExpanded = false };

            BitmapImage image8 = new BitmapImage(new Uri("images/folders.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode7 = new Model { Header = "Personal", Image = image8, IsExpanded = false };

            BitmapImage image9 = new BitmapImage(new Uri("images/junk.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode8 = new Model { Header = "Junk", Image = image9, IsExpanded = false };

            BitmapImage image10 = new BitmapImage(new Uri("images/junk.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode9 = new Model { Header = "Notes", Image = image10, IsExpanded = false };

            BitmapImage image11 = new BitmapImage(new Uri("images/notes.gif", UriKind.RelativeOrAbsolute));
            var TreeView1_ChildNode10 = new Model { Header = "Journal", Image = image11, IsExpanded = false };

            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode1);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode2);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode3);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode4);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode5);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode6);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode7);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode8);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode9);
            TreeView1_RootNode.TreeViewAdv1_Models.Add(TreeView1_ChildNode10);
            TreeViewAdv1_Models.Add(TreeView1_RootNode);
        }

        void TreeViewAdv2()
        {
            BitmapImage image = new BitmapImage(new Uri("images/root.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_RootNode = new Model { Header = "Mailbox", Image = image, IsExpanded = true };

            BitmapImage image1 = new BitmapImage(new Uri("images/calendar.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode = new Model { Header = "Calendar", Image = image1, IsExpanded = false };

            BitmapImage image2 = new BitmapImage(new Uri("images/contacts.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode1 = new Model { Header = "Contacts", Image = image2, IsExpanded = false };

            BitmapImage image3 = new BitmapImage(new Uri("images/deleted.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode2 = new Model { Header = "Deleted Items", Image = image3, IsExpanded = false };

            BitmapImage image4 = new BitmapImage(new Uri("images/drafts.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode3 = new Model { Header = "Drafts", Image = image4, IsExpanded = false };

            BitmapImage image5 = new BitmapImage(new Uri("images/inbox.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode4 = new Model { Header = "Inbox", Image = image5, IsExpanded = false };

            BitmapImage image6 = new BitmapImage(new Uri("images/outbox.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode5 = new Model { Header = "Outbox", Image = image6, IsExpanded = false };

            BitmapImage image7 = new BitmapImage(new Uri("images/sentitems.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode6 = new Model { Header = "Sent Items", Image = image7, IsExpanded = false };

            BitmapImage image8 = new BitmapImage(new Uri("images/folders.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode7 = new Model { Header = "Personal", Image = image8, IsExpanded = false };

            BitmapImage image9 = new BitmapImage(new Uri("images/junk.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode8 = new Model { Header = "Junk", Image = image9, IsExpanded = false };

            BitmapImage image10 = new BitmapImage(new Uri("images/junk.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode9 = new Model { Header = "Notes", Image = image10, IsExpanded = false };

            BitmapImage image11 = new BitmapImage(new Uri("images/notes.gif", UriKind.RelativeOrAbsolute));
            var TreeView2_ChildNode10 = new Model { Header = "Journal", Image = image11, IsExpanded = false };

            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode1);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode2);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode3);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode4);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode5);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode6);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode7);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode8);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode9);
            TreeView2_RootNode.TreeViewAdv2_Models.Add(TreeView2_ChildNode10);
            TreeViewAdv2_Models.Add(TreeView2_RootNode);
        }

        public ObservableCollection<Model> TreeViewAdv1_Models { get; set; }

        public ObservableCollection<Model> TreeViewAdv2_Models { get; set; }
    }
}
