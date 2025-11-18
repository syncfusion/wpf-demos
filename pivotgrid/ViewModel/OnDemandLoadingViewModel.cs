#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using Syncfusion.Windows.Shared;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;    

    public class OnDemandLoadingViewModel : NotificationObject
    {
        #region Private Variable
        private ObservableCollection<ItemObject> itemObjectCollection;

        #endregion

        #region Method

        /// <summary>
        /// Initializes the ViewModel class
        /// </summary>
        public OnDemandLoadingViewModel()
        {
            itemObjectCollection = ItemObjects.GetList();
        }

        #endregion

        #region Public Properties
        public ObservableCollection<ItemObject> ItemObjectCollection
        {
            get { return itemObjectCollection; }
            set
            {
                itemObjectCollection = value;
                RaisePropertyChanged(() => ItemObjectCollection);
            }
        }

        #endregion
    }
}