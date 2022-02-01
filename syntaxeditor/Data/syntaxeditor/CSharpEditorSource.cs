#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.syntaxeditordemos.wpf
{
    /// <summary>
    ///  Sport class implemented with INotifyPropertyChanged interface
    /// </summary>
    public class Sport : INotifyPropertyChanged
    {
	
        #region Local variables

        int _sportID;
        string _sportName;
        double _interest;

        #endregion

        #region Properties

        public int SportID
        {
            get
            {
                return this._sportID;
            }
            set
            {
                this._sportID = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("SportID"));
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, args);
        }

        #endregion

    }
	
    /// <summary>
    ///  ObservableCollection class to hold a list of sport object
    /// </summary>
    public class Sports : ObservableCollection<Sport>
    {
        #region Constructor
		int fire;
		int a = a + b;
        public Sports()
            : base()
        {
            Add(new Sport() { SportID = 101, SportName = "Golf", Interest = 9 });
            Add(new Sport() { SportID = 102, SportName = "Soccer", Interest = 40 });
            Add(new Sport() { SportID = 103, SportName = "Cricket", Interest = 15 });
            Add(new Sport() { SportID = 104, SportName = "Rugby", Interest = 7 });
            Add(new Sport() { SportID = 105, SportName = "Atheletics", Interest = 3 });
            Add(new Sport() { SportID = 106, SportName = "Tennis", Interest = 10 });
            Add(new Sport() { SportID = 107, SportName = "Baseball", Interest = 6 });
            Add(new Sport() { SportID = 108, SportName = "Basketball", Interest = 10 });
        }

        #endregion
    }

}
