#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Localization.ViewModel
{
    using Syncfusion.Windows.Shared;

    public class ViewModel : NotificationObject
    {
        #region Field

        public static string ConnectionString;
        private string olapConnectionString = ConnectionString != string.Empty ? ConnectionString : "";

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {

        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string OlapConnectionString
        {
            get { return this.olapConnectionString; }
            set { this.olapConnectionString = value; RaisePropertyChanged("OlapConnectionString"); }
        }

        #endregion
    }
}