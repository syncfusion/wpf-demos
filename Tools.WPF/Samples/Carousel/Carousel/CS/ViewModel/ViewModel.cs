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
using System.Windows.Controls;

namespace CarouselDemo
{
    class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            selectionChangedLogCommand = new DelegateCommand<object>(PropertyChangedHandler);
        }

        private ICommand selectionChangedLogCommand;

        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }
        public ICommand SelectionChanged
        {
            get
            {
                return selectionChangedLogCommand;
            }
        }
        public void PropertyChangedHandler(object param)
        {
            if (param != null)
            {
                Border border = param as Border;
                TextBlock txt = VisualUtils.FindDescendant(border, typeof(TextBlock)) as TextBlock;
                EventLog.Add("Selection Changed : " + txt.Text);
            }
        }
    }
}
