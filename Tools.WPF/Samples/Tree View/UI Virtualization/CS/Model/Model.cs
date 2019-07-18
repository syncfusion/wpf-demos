#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;

namespace Virtualization
{
    public class MyTreeView : NotificationObject, IVirtualTree
    {

        public MyTreeView()
        {
            items = new ObservableCollection<MyTreeView>();
        }

        private string header;

        public string Header
        {
            get 
            { 
                return header; 
            }
            set 
            { 
                header = value;                
              this.RaisePropertyChanged(() => this.Header);
            }
        }

        private ObservableCollection<MyTreeView> items;

        public ObservableCollection<MyTreeView> Items
        {
            get 
            { 
                return items; 
            }
            set 
            { 
                items = value;
                this.RaisePropertyChanged(() => this.Items);
            }
        }        

        public double ExtentHeight
        {
            get;
            set;
        }

        public bool IsExpanded
        {
            get;
            set;
        }

        public int ItemsCount
        {
            get;
            set;
        }

        public IVirtualTree Parent
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }
    }
}
