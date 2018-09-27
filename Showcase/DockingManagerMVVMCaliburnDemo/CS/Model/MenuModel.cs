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
