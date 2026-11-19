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
