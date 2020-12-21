#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
