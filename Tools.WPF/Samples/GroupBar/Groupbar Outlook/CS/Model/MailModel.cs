#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GroupbarOutlookDemo
{
    public class MailModel : INotifyPropertyChanged
    {
        public string Sender { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string[] CC { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
        private bool isUnRead;

        public bool IsUnRead
        {
            get { return isUnRead; }
            set { isUnRead = value; Notify("IsUnRead"); }
        }

        public string Category { get; set; }
        public DateTime Date { get; set; }
        public bool IsFlagged { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void Notify(string Name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
    }
}
