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
    ///  Represents the note model.
    /// </summary>
    public class NoteModel
    {
        #region Field
        /// <summary>
        ///  Maintains the message.
        /// </summary>
        private string message;
        #endregion

        #region Properties
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
        #endregion
    }
}
