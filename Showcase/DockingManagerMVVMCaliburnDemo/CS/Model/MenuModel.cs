#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Controls;

namespace DockingManagerMVVMCaliburnMicro
{
    public class MenuModel : NotificationObject
    {
        public string Header { get; set; }

        public MenuModel()
        {
            MenuItemCollection = new ObservableCollection<MenuModel>();
            SubMenuItemCollection = new ObservableCollection<MenuModel>();
        }

        private bool m_ischecked = false;

        public bool IsChecked
        {
            get
            {
                return m_ischecked;
            }
            set
            {
                m_ischecked = value;
                RaisePropertyChanged("IsChecked");
            }
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
