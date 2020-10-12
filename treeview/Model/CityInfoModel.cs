#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.treeviewdemos.wpf
{
    public class Country : INotifyPropertyChanged
    {
        #region Feilds

        private bool isSelected;
        private string name;
        private ObservableCollection<State> states;

        #endregion

        #region Constructor
        public Country()
        {
        }
        #endregion

        #region Properties
        public ObservableCollection<State> States

        {
            get { return states; }
            set
            {
                states = value;
                RaisedOnPropertyChanged("States");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisedOnPropertyChanged("Name");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisedOnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }

    public class State : INotifyPropertyChanged
    {
        #region Feilds

        private bool isSelected;
        private string name;
        private ObservableCollection<City> cities;

        #endregion

        #region Constructor
        public State()
        {
        }
        #endregion

        #region Properties
        public ObservableCollection<City> Cities
        {
            get { return cities; }
            set
            {
                cities = value;
                RaisedOnPropertyChanged("States");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisedOnPropertyChanged("Name");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisedOnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }
    

    public class City : INotifyPropertyChanged
    {
        #region Feilds

        private bool isSelected;
        private string name;

        #endregion

        #region Constructor
        public City()
        {
        }
        #endregion

        #region Properties

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisedOnPropertyChanged("Name");
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                RaisedOnPropertyChanged("IsSelected");
            }
        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }

}
