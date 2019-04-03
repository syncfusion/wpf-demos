#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GroupbarOutlookDemo
{
    public class SortedMailCollection
    {
        private string header;

        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        private ObservableCollection<MailModel> mailCollection = new ObservableCollection<MailModel>();
        public ObservableCollection<MailModel> MailCollection
        {
            get { return mailCollection; }
            set { mailCollection = value; }
        }

    }
}
