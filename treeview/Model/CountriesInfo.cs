#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class CountriesInfo : NotificationObject
    {
        public CountriesInfo()
        {
            Models = new ObservableCollection<CountriesInfo>();
        }

        private ObservableCollection<CountriesInfo> models;
        public ObservableCollection<CountriesInfo> Models
        {
            get
            {
                return models;
            }

            set
            {
                models = value;
                this.RaisePropertyChanged("Models");
            }
        }
        

        private string state;
        /// <summary>
        /// Gets or sets a value indicating the state of the TreeViewItem.
        /// </summary>
        public string State
        {
            get
            {
                return state;
            }

            set
            {
                state = value;
                this.RaisePropertyChanged("State");
            }
        }
    }
}
