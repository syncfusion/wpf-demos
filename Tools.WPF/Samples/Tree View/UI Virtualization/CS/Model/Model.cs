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
