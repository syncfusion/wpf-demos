#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Represents the sorted mail collection.
    /// </summary>
    public class SortedMailCollection
    {
         #region Field
        /// <summary>
        ///  Maintains the header.
        /// </summary>
        private string header;

        /// <summary>
        ///  Maintains the collection of sorted mails.
        /// </summary>
        private ObservableCollection<MailModel> mailCollection = new ObservableCollection<MailModel>();
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        [Category("Summary")]
        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        /// <summary>
        /// Gets or sets the mails to the collection.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<MailModel> MailCollection
        {
            get { return mailCollection; }
            set { mailCollection = value; }
        }
        #endregion
    }
}
