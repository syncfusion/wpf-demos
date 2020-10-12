#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;
    using System;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class CustomizationViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> showAllMember;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationViewModel"/> class.
        /// </summary>
        public CustomizationViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = CustomizationModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = CustomizationModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            this.olapDataManager = new OlapDataManager(ConnectionString);
        }
        #endregion

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public DelegateCommand<object> ShowAllMemberCommand
        {
            get
            {
                this.showAllMember = this.showAllMember ?? new DelegateCommand<object>(this.ShowAllMemberChanged);
                return this.showAllMember;
            }
            set { this.showAllMember = value; }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (isDisposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }


        #endregion

        #region Methods

        private void ShowAllMemberChanged(object parm)
        {
            this.ClientDataManager.ShowLevelTypeAll = !this.ClientDataManager.ShowLevelTypeAll;
            this.ClientDataManager.NotifyElementModified();
        }

        #endregion
    }
}
