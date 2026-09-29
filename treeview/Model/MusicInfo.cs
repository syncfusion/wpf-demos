using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace syncfusion.treeviewdemos.wpf
{
    public class MusicInfo : NotificationObject
    {
        #region Fields

        public string itemName;
        public int id;
        public bool hasChildNodes;

        #endregion

        #region Properties

        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                RaisePropertyChanged("ItemName");
            }
        }

        public int ID
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("ID");
            }
        }

        public bool HasChildNodes
        {
            get { return hasChildNodes; }
            set
            {
                hasChildNodes = value;
                RaisePropertyChanged("HasChildNodes");
            }
        }

        #endregion        
    }
}
