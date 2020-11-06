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
    /// Represents the sorted mail collection.
    /// </summary>
    public class SortedMailCollectionModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the header.
        /// </summary>
        private string header;

        /// <summary>
        ///  Maintains the collection of sorted mails.
        /// </summary>
        private ObservableCollection<MailModel> sortedMailCollection = new ObservableCollection<MailModel>();

        /// <summary>
        /// Gets or sets the header <see cref="SortedMailCollectionModel"/> class.
        /// </summary>
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                RaisePropertyChanged("Header");
            }
        }

        /// <summary>
        /// Gets or sets the mails to the collection  <see cref="SortedMailCollectionModel"/> class.
        /// </summary>
        public ObservableCollection<MailModel> MailCollection
        {
            get
            {
                return sortedMailCollection;
            }
            set
            {
                sortedMailCollection = value;
                RaisePropertyChanged("MailCollection");
            }
        }
    }
}
