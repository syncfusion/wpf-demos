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
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Tools.Controls;

namespace GroupBarDemo
{
    public class ViewModel : NotificationObject
    {
        #region Properties

        private ICommand selectedobjchanged;
        public ICommand SelectedObjectChanged
        {
            get { return selectedobjchanged; }
            set
            {
                selectedobjchanged = value;
                this.RaisePropertyChanged(() => this.SelectedObjectChanged);
            }
        }

        private object selobj;
        public object GroupBarSelectedObject
        {
            get { return selobj; }
            set
            {
                selobj = value;
                this.RaisePropertyChanged(() => this.GroupBarSelectedObject);
            }
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
        #endregion

        #region Constructor
        public ViewModel()
        {
            SelectedObjectChanged = new DelegateCommand<object>(GroupbarSelectedObjectChanged);
        }
        #endregion

        #region Helpermethods
        private void GroupbarSelectedObjectChanged(object param)
        {
            if (GroupBarSelectedObject != null)
            {
                if (GroupBarSelectedObject is GroupBarItem)
                    coll.Add("Selected Object changed : " + ((GroupBarItem)GroupBarSelectedObject).HeaderText + " (GroupBarItem)");
                if (GroupBarSelectedObject is GroupViewItem)
                    coll.Add("Selected Object changed : " + ((GroupViewItem)GroupBarSelectedObject).Text + " (GroupViewItem)");

                EventLogsCollection = coll;
            }
        }
        #endregion

    }
}
