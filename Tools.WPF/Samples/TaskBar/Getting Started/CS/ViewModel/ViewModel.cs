#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace TaskBarDemo
{
    public class ViewModel : NotificationObject
    {
        private ICommand EventLogCommand;
      
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand  SelectionChanged
        {
            get
            {
                return EventLogCommand;
            }
        }
      

        private object selectedValue;
        public object SelectedValue 
        { 
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                RaisePropertyChanged("SelectedValue");

            }
        }


        public void PropertyChangedHandler(object param)
        {
            if (SelectedValue != null)
            {
                EventLog.Add("Selection Changed : "+(SelectedValue as TaskBarItem).Name  );
            }
        }

      

        public ViewModel()
        {
            EventLogCommand = new DelegateCommand<object>(PropertyChangedHandler);           
        }
    }
}
