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
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ColorPickerDemo
{
    public class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            colorChangedLogCommand = new DelegateCommand<object>(PropertyChangedHandler);
        }

        private ICommand colorChangedLogCommand;

        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand ColorChanged
        {
            get
            {
                return colorChangedLogCommand;
            }
        }
        public void PropertyChangedHandler(object param)
        {
            EventLog.Add("Color Changed:" + param.ToString());
        }

    }
}
