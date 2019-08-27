#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Visual_Styles.ViewModel
{
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class ViewModel : Syncfusion.Windows.Shared.NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.olapDataManager = new OlapDataManager(ViewModel.ConnectionString);
        }
        #endregion

        /// <summary>
        /// Gets the olap grid visual styles.
        /// </summary>
        /// <value>The olap grid visual styles.</value>
        public IEnumerable<String> OlapClientVisualStyles
        {
            get
            {
                return new List<string>() { "Blend", "Metro", "Office2010Black", "Office2010Blue", "Office2010Silver", "Office2013LightGray", "Office2013DarkGray", "Office2013White", "VisualStudio2013" }; ;
            }
        }

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }
        #endregion
    }
}
