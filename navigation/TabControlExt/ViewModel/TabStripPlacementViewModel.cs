#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class TabStripPlacementViewModel : NotificationObject
    {
        private ObservableCollection<TabStripPlacementModel> tabStripPlacementModelItems;

        public ObservableCollection<TabStripPlacementModel> TabStripPlacemntModelItems
        {
            get
            {
                return tabStripPlacementModelItems;
            }
            set
            {
                tabStripPlacementModelItems = value;
            }
        }

        public TabStripPlacementViewModel()
        {
            tabStripPlacementModelItems = new ObservableCollection<TabStripPlacementModel>();
            PopulateItems();
        }

        private void PopulateItems()
        {
            TabStripPlacementModel item1 = new TabStripPlacementModel()
            {
                Header = "Tab1",
                Content = "This is the content of first tabitem."
            };
            TabStripPlacementModel item2 = new TabStripPlacementModel()
            {
                Header = "Tab2",
                Content = "This is the content of second tabitem."
            };
            TabStripPlacementModel item3 = new TabStripPlacementModel()
            {
                Header = "Tab3",
                Content = "This is the content of third tabitem."
            };
            TabStripPlacementModel item4 = new TabStripPlacementModel()
            {
                Header = "Tab4",
                Content = "This is the content of fourth tabitem."
            };
            TabStripPlacementModel item5 = new TabStripPlacementModel()
            {
                Header = "Tab5",
                Content = "This is the content of fifth tabitem."
            };
            TabStripPlacementModel item6 = new TabStripPlacementModel()
            {
                Header = "Tab6",
                Content = "This is the content of sixth tabitem."
            };
            TabStripPlacementModel item7 = new TabStripPlacementModel()
            {
                Header = "Tab7",
                Content = "This is the content of seventh tabitem."
            };
            TabStripPlacementModel item8 = new TabStripPlacementModel()
            {
                Header = "Tab8",
                Content = "This is the content of eighth tabitem."
            };
            TabStripPlacementModel item9 = new TabStripPlacementModel()
            {
                Header = "Tab9",
                Content = "This is the content of ninth tabitem."
            };
            TabStripPlacementModel item10 = new TabStripPlacementModel()
            {
                Header = "Tab10",
                Content = "This is the content of tenth tabitem."
            };
            TabStripPlacementModel item11 = new TabStripPlacementModel()
            {
                Header = "Tab10",
                Content = "This is the content of eleventh tabitem."
            };
            TabStripPlacementModel item12 = new TabStripPlacementModel()
            {
                Header = "Tab10",
                Content = "This is the content of twelfth tabitem."
            };
            TabStripPlacementModel item13 = new TabStripPlacementModel()
            {
                Header = "Tab10",
                Content = "This is the content of thirteenth tabitem."
            };
            TabStripPlacementModel item14 = new TabStripPlacementModel()
            {
                Header = "Tab10",
                Content = "This is the content of fourteenth tabitem."
            };
            TabStripPlacementModel item15 = new TabStripPlacementModel()
            {
                Header = "Tab10",
                Content = "This is the content of fifteenth tabitem."
            };

            tabStripPlacementModelItems.Add(item1);
            tabStripPlacementModelItems.Add(item2);
            tabStripPlacementModelItems.Add(item3);
            tabStripPlacementModelItems.Add(item4);
            tabStripPlacementModelItems.Add(item5);
            tabStripPlacementModelItems.Add(item6);
            tabStripPlacementModelItems.Add(item7);
            tabStripPlacementModelItems.Add(item8);
            tabStripPlacementModelItems.Add(item9);
            tabStripPlacementModelItems.Add(item10);
            tabStripPlacementModelItems.Add(item11);
            tabStripPlacementModelItems.Add(item12);
            tabStripPlacementModelItems.Add(item13);
            tabStripPlacementModelItems.Add(item14);
            tabStripPlacementModelItems.Add(item15);
        }
    }
}
