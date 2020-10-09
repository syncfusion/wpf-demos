#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the mail category.
    /// </summary>
    public class MailCategoriesModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the collection of mails.
        /// </summary>
        private ObservableCollection<MailModel> mailCollection;

        /// <summary>
        ///  Maintains the header.
        /// </summary>
        private string header;

        /// <summary>
        /// Gets or sets the mail details <see cref="MailCategoriesModel"/> class.
        /// </summary>
        public ObservableCollection<MailModel> MailCollection
        {
            get { return mailCollection; }
            set { mailCollection = value; RaisePropertyChanged("MailCollection"); }
        }

        /// <summary>
        /// Gets or sets the header <see cref="MailCategoriesModel"/> class.
        /// </summary>
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                if (header != value)
                {
                    header = value;
                    RaisePropertyChanged("Header");
                }
            }
        }
    }
}
