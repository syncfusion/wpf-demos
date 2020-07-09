#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MonthCellCustomization
{
    /// <summary>   
    /// Represents custom data properties.   
    /// </summary> 
    public class Events : NotificationObject
    {
        #region Private Properties

        private string eventName;
        private DateTime from;
        private DateTime to;
        private Brush background;
        private bool isAllDay;

        #endregion

        #region Public Properties

        public string EventName
        {
            get { return eventName; }
            set
            {
                eventName = value;
                this.RaisePropertyChanged("EventName");
            }
        }

        public DateTime From
        {
            get { return from; }
            set
            {
                from = value;
                this.RaisePropertyChanged("From");
            }
        }

        public DateTime To
        {
            get { return to; }
            set
            {
                to = value;
                this.RaisePropertyChanged("To");
            }
        }

        public Brush Background
        {
            get { return background; }
            set
            {
                background = value;
                this.RaisePropertyChanged("Background");
            }
        }

        public bool IsAllDay
        {
            get { return isAllDay; }
            set
            {
                isAllDay = value;
                this.RaisePropertyChanged("IsAllDay");
            }
        }

        #endregion
    }
}
