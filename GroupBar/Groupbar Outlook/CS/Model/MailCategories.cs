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
    /// Represents the mail category.
    /// </summary>
    public class MailCategory
    {
        #region Field
        /// <summary>
        ///  Maintains the collection of mails.
        /// </summary>
        private ObservableCollection<MailModel> _mailCollection;

        /// <summary>
        ///  Maintains the header.
        /// </summary>
        private string header;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the mail details.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<MailModel> MailCollection
        {
            get { return _mailCollection; }
            set { _mailCollection = value; }
        }

        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        [Category("Summary")]
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                if (header != value)
                    header = value;
            }
        }
        #endregion
    }
}
