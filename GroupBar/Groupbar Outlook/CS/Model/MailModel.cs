#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
    /// <summary>
    /// Represents mail model.
    /// </summary>
    public class MailModel : INotifyPropertyChanged
    {
        #region  Fields
        /// <summary>
        ///  Maintains the sender details.
        /// </summary>
        private string sender;

        /// <summary>
        ///  Maintains the from address.
        /// </summary>
        private string from;

        /// <summary>
        ///  Maintains the to address.
        /// </summary>
        private string to;

        /// <summary>
        ///  Maintains the cc address.
        /// </summary>
        private string cC;

        /// <summary>
        ///  Maintains the message.
        /// </summary>
        private string message;

        /// <summary>
        ///  Maintains the subject.
        /// </summary>
        private string subject;

        /// <summary>
        /// Indicates whether the message unread or not.
        /// </summary>
        private bool isUnRead;

        /// <summary>
        ///  Maintains the mail category.
        /// </summary>
        private string category;

        /// <summary>
        ///  Maintains the date.
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Indicates whether the item is flagged or not.
        /// </summary>
        private bool isFlagged;
        #endregion

        #region Events
        /// <summary>
        /// Initialize the event which notifies when the selected item changes. 
        /// </summary> 
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion     

        #region properties
        /// <summary>
        /// Gets or sets the sender details.
        /// </summary>
        [Category("Summary")]
        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                if (sender != value)
                    sender = value;
            }
        }

        /// <summary>
        /// Gets or sets the from address.
        /// </summary>
        [Category("Summary")]
        public string From
        {
            get
            {
                return from;
            }
            set
            {
                if (from != value)
                    from = value;
            }
        }

        /// <summary>
        /// Gets or sets the to address.
        /// </summary>
        [Category("Summary")]
        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (to != value)
                    to = value;
            }
        }

        /// <summary>
        /// Gets or sets the cc.
        /// </summary>
        [Category("Summary")]
        public string CC
        {
            get
            {
                return cC;
            }
            set
            {
                if (cC != value)
                    cC = value;
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        [Category("Summary")]
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                if (message != value)
                    message = value;
            }
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        [Category("Summary")]
        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                if (subject != value)
                    subject = value;
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the message readable or not.
        /// </summary>
        [Category("Summary")]
        public bool IsUnRead
        {
            get { return isUnRead; }
            set { isUnRead = value; Notify("IsUnRead"); }
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [Category("Summary")]
        public string Category
        {
            get
            {
                return category;
            }
            set
            {
                if (category != value)
                    category = value;
            }
        }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        [Category("Summary")]
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                    date = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the message flagged or not.
        /// </summary>
        [Category("Summary")]
        public bool IsFlagged
        {
            get
            {
                return isFlagged;
            }
            set
            {
                if (isFlagged != value)
                    isFlagged = value;
            }

        }
        #endregion

        #region Methods
        /// <summary>
        /// Event handling method for notified changes.
        /// </summary>
        /// <param name="Name">Notifies when the changes occured</param>
        private void Notify(string Name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(Name));
        }
        #endregion
    }
}
