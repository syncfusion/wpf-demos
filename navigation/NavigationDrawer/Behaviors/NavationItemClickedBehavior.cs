#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    public class NavationItemClickedAction : TargetedTriggerAction<Grid>
    {
        UserControl userControl=null;
        protected override void Invoke(object parameter)
        {
            var args = parameter as NavigationItemClickedEventArgs;
            if (args == null)
                return;

            if (args.Item.ItemType != ItemType.Tab)
                return;

            var pagename = args.Item.Header.ToString();

            if (pagename == "Sample Page 1" || pagename == "Category 1" || pagename == "Home" || pagename == "Browse" || pagename == "Inbox" || pagename == "Personal")
            {
                userControl = new SamplePage1();
            }
            else if (pagename == "Sample Page 2" || pagename == "Category 2" || pagename == "Account" || pagename == "Track an Order" || pagename == "Primary" || pagename == "Drafts")
            {
                userControl = new SamplePage2();
            }
            else if (pagename == "Sample Page 3" || pagename == "Category 3" || pagename == "Mail" || pagename == "Order History" || pagename == "Social" || pagename == "Starred")
            {
                userControl = new SamplePage3();
            }
            else if (pagename == "Sample Page 4" || pagename == "Category 4" || pagename == "Calendar" || pagename == "Promotions" || pagename == "All mail")
            {
                userControl = new SamplePage4();
            }
            else if (pagename == "Your Cart" || pagename == "Document options" || pagename == "Sent mail" || pagename == "Trash")
            {
                userControl = new SamplePage5();
            }
            else if (pagename == "Help" || pagename == "Create new" || pagename == "Important" || pagename == "Spam")
            {
                userControl = new SamplePage6();
            }
            else if (pagename == "Work" || pagename == "Upload file")
            {
                userControl = new SamplePage7();
            }
            else if (pagename == "Settings")
            {
                userControl = new SampleSettingsPage();
            }
            if (pagename != "Settings")
            {
                (((this.Target as Grid).Children[0] as UserControl).Content as TextBlock).Text = pagename;
            }
            else
            {
                (((this.Target as Grid).Children[0] as UserControl).Content as TextBlock).Text = string.Empty;
            }
           ((this.Target as Grid).Children[1] as UserControl).Content = userControl;
        }
    }
}


