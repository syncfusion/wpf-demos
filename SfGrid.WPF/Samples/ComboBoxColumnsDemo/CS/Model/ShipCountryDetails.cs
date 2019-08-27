#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.ComponentModel;

namespace ComboBoxColumnsDemo
{
    public class ShipCityDetails :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        private int _shipCityID;
        /// <summary>
        /// Gets or sets the shipCityID.
        /// </summary>
        /// <value>The ship city ID.</value>
        public int ShipCityID
        {
            get
            {
                return _shipCityID;
            }
            set
            {
                _shipCityID = value;
                RaisePropertyChanged("ShipCityID");
            }
        }

        private string _shipCityName;
        /// <summary>
        /// Gets or sets the shipCityName.
        /// </summary>
        /// <value>The ship city name.</value>
        public string ShipCityName
        {
            get
            {
                return _shipCityName;
            }
            set
            {
                _shipCityName = value;
                RaisePropertyChanged("ShipCityName");
            }
        }

    }
}
