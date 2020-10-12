#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace syncfusion.visualstudiodemo.wpf
{
    public class MenuModel : NotificationObject
    {
        public string Header { get; set; }

        public MenuModel()
        {
            MenuItemCollection = new ObservableCollection<MenuModel>();
            SubMenuItemCollection = new ObservableCollection<MenuModel>();
        }

        private ObservableCollection<MenuModel> menuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> MenuItemCollection
        {
            get
            {
                return menuitemcolletion;
            }
            set
            {
                menuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> submenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> SubMenuItemCollection
        {
            get
            {
                return submenuitemcolletion;
            }
            set
            {
                submenuitemcolletion = value;
            }
        }
    }
}
