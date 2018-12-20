#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ObservableCollectionBindingDemo
{
    public class SportDataModel : INotifyPropertyChanged
    {
        public SportDataModel()
        {

        }
        int _sportID;
        string _sportName;
        double preferredNumberOfCandidates;

        public int SportID
        {
            get { return this._sportID; }
            set { this._sportID = value; this.OnPropertyChanged(new PropertyChangedEventArgs("SportID")); }
        }

        public string SportName
        {
            get { return this._sportName; }
            set { this._sportName = value; this.OnPropertyChanged(new PropertyChangedEventArgs("SportName")); }
        }

        public double CandidatesCount
        {
            get { return this.preferredNumberOfCandidates; }
            set { this.preferredNumberOfCandidates = value; this.OnPropertyChanged(new PropertyChangedEventArgs("CandidatesCount")); }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, args);
        }
        #endregion

        
    }
}
