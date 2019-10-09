#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DomainUpDownDemo
{
    class ViewModel : NotificationObject
    {
        private ObservableCollection<string> country = new ObservableCollection<string>();
        
        public ObservableCollection<string> Countries
        {
            get { return country; }
            set { country = value; RaisePropertyChanged("Countries"); }
        }

        public ViewModel()
        {
            Countries.Add("Asia");
            Countries.Add("Europe");
            Countries.Add("Australia");
            Countries.Add("Africa");
            Countries.Add("America");
            Countries.Add("Antarctica");    
        }

    }
    public class Country
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
