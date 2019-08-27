#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace StylingDemo
{
    public class CountriesList : INotifyPropertyChanged
    {
        #region Properties

        private string serialNumber;
        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value;
                OnPropertyChanged("SerialNumber");
            }
        }

        private string countryName;
        public string Country
        {
            get
            {
                return countryName;
            }
            set
            {
                countryName = value;
                OnPropertyChanged("Country");
            }
        }

        private string countryCapital;
        public string Captial
        {
            get
            {
                return countryCapital;
            }
            set
            {
                countryCapital = value;
                OnPropertyChanged("Captial");
            }
        }

        private string officialName;
        public string OfficialName
        {
            get
            {
                return officialName;
            }
            set
            {
                officialName = value;
                OnPropertyChanged("OfficialName");
            }
        }

        private string location;
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }

        private string language;
        public string Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                OnPropertyChanged("Language");
            }
        }

        private string currency;
        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
                OnPropertyChanged("Currency");
            }
        }

        private long population;
        public long Population
        {
            get
            {
                return population;
            }
            set
            {
                population = value;
                OnPropertyChanged("Population");
            }
        }

        private double literacyRate;
        public double LiteracyRate
        {
            get
            {
                return literacyRate;
            }
            set
            {
                literacyRate = value;
                OnPropertyChanged("LiteracyRate");
            }
        }

        private ObservableCollection<EconomyGrowth> economyGrowth;
        public ObservableCollection<EconomyGrowth> EconomyRate
        {
            get
            {
                return economyGrowth;
            }
            set
            {
                economyGrowth = value;
                OnPropertyChanged("EconomyRate");
            }
        }

        #endregion

        #region Ctor

        public CountriesList()
        {

        }

        public CountriesList(string _serialNumber, string _countryName, string _countryCapital, string _officialName, string _location, string _language, string _currency, long _Population, double _LiteracyRate)
        {
            this.SerialNumber = _serialNumber;
            this.Country = _countryName;
            this.Captial = _countryCapital;
            this.OfficialName = _officialName;
            this.Location = _location;
            this.Language = _language;
            this.Currency = _currency;
            this.Population = _Population;
            this.LiteracyRate = _LiteracyRate;
        }

        #endregion

        #region INotifyEventChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }

    public class PopulationGrowth : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private long population;
        public long Population
        {
            get
            {
                return population;
            }
            set
            {
                population = value;
                OnPropertyChanged("Population");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }

    public class EconomyGrowth : INotifyPropertyChanged
    {
        private int year;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        private double growthPercentage;
        public double GrowthPercentage
        {
            get
            {
                return growthPercentage;
            }
            set
            {
                growthPercentage = value;
                OnPropertyChanged("GrowthPercentage");
            }
        }


        #region INotifyEventChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        #endregion
    }
}
