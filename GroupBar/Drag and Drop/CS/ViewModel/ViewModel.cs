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

namespace GroupBarDemo
{
    public class ViewModel : NotificationObject
    {
        #region Properties
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

        #region ICommandMembers

        private ICommand dragstart;
        public ICommand DragStart
        {
            get { return dragstart; }
            set
            {
                dragstart = value;
                this.RaisePropertyChanged(() => this.DragStart);
            }
        }

        private ICommand dragend;
        public ICommand DragEnd
        {
            get { return dragend; }
            set
            {
                dragend = value;
                this.RaisePropertyChanged(() => this.DragEnd);
            }
        }
        #endregion

        #region Constructors
        public ViewModel()
        {
            DragStart = new DelegateCommand<object>(GroupViewItemDragStart);
            DragEnd = new DelegateCommand<object>(GroupViewItemDragEnd);
        }
        #endregion

        #region Helpermethods
        private void GroupViewItemDragStart(object param)
        {
            if (param != null)
            {
                coll.Add("DragStarted  (" + param.ToString() + " )");
                EventLogsCollection = coll;
            }
        }

        private void GroupViewItemDragEnd(object param)
        {
            if (param != null)
            {
                coll.Add("DragEnded  (" + param.ToString() + " )");
                EventLogsCollection = coll;
            }
        }
        #endregion
    }
}
