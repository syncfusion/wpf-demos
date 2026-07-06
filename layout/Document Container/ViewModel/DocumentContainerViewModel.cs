using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.layoutdemos.wpf
{
    public class DocumentContainerViewModel : NotificationObject
    {
        private bool TabItem = true;
        public bool TabItemContextMenu
        {
            get
            {
                return TabItem;
            }
            set
            {
                TabItem = value;
                this.RaisePropertyChanged("TabItemContextMenu");
            }
        }

        private bool Tablist = true;
        public bool TablistContextMenu
        {
            get
            {
                return Tablist;
            }
            set
            {
                Tablist = value;
                this.RaisePropertyChanged("TablistContextMenu");
            }
        }
    }
}
