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
using System.Windows.Input;

namespace Virtualization
{
    public class ViewModel: NotificationObject
    {
        private ICommand selectedItemChangedCommand;
        public ICommand
           SelectedItemChangedCommand
        {
            get
            {
                return selectedItemChangedCommand;
            }
            set
            {
                selectedItemChangedCommand = value;
            }
        }

        public ObservableCollection<MyTreeView> MyItems
        {
            get;
            set;
        }

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }

        ObservableCollection<string> coll = new ObservableCollection<string>();

        public void SelectedItemChanged(object param)
        {            
            if (param != null)
                coll.Add("SelectedItem Changed : " + (param as MyTreeView).Header);
            EventLogsCollection = coll;
        }

        public ViewModel()
        {
            selectedItemChangedCommand = new DelegateCommand<object>(SelectedItemChanged);
            MyItems = new ObservableCollection<MyTreeView>();
            for (int i = 0; i < 1000; i++)
            {
                MyTreeView myitem = new MyTreeView() { Header = "Module " + i.ToString() };
                for (int j = 0; j < 100; j++)
                {
                    MyTreeView _myitem = new MyTreeView() { Header = "Sub Module " + j.ToString() };
                    myitem.Items.Add(_myitem);
                }
                MyItems.Add(myitem);
            }           
        }       
    }
}
