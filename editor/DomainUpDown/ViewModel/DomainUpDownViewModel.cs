#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace syncfusion.editordemos.wpf
{
    class DomainUpDownViewModel : NotificationObject
    {
        private ObservableCollection<string> country = new ObservableCollection<string>();
        
        public DomainUpDownViewModel()
        {
            Countries.Add("Asia");
            Countries.Add("Europe");
            Countries.Add("Australia");
            Countries.Add("Africa");
            Countries.Add("America");
            Countries.Add("Antarctica");    
        }

        public ObservableCollection<string> Countries
        {
            get { return country; }
            set { country = value; RaisePropertyChanged("Countries"); }
        }
    }
}
