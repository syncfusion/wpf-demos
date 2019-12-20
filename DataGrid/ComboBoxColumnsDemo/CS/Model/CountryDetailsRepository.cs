#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxColumnsDemo
{
    public static class CountryDetailsRepository
    {
        public static Dictionary<string, ObservableCollection<ShipCityDetails>> GetShipCities()
        {
            ObservableCollection<ShipCityDetails> argentina = new ObservableCollection<ShipCityDetails>();
            argentina.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 101 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 102 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 103 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 104 });
            argentina.Add(new ShipCityDetails() { ShipCityName = "Buenos Aires", ShipCityID = 105 });

            ObservableCollection<ShipCityDetails> austria = new ObservableCollection<ShipCityDetails>();
            austria.Add(new ShipCityDetails() { ShipCityName = "austriaAachen", ShipCityID = 106 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 107 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Århus", ShipCityID = 108 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 109 });
            austria.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 110 });

            ObservableCollection<ShipCityDetails> belgium = new ObservableCollection<ShipCityDetails>();
            belgium.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 111 });
            belgium.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 112 });
            belgium.Add(new ShipCityDetails() { ShipCityName = "Lille", ShipCityID = 113 });
            belgium.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 114 });

            ObservableCollection<ShipCityDetails> brazil = new ObservableCollection<ShipCityDetails>();
            brazil.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 115 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Aachen", ShipCityID = 116 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 117 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 118 });
            brazil.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 119 });

            ObservableCollection<ShipCityDetails> canada = new ObservableCollection<ShipCityDetails>();
            canada.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 120 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Århus", ShipCityID = 121 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 122 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Lille", ShipCityID = 123 });
            canada.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 124 });

            ObservableCollection<ShipCityDetails> denmark = new ObservableCollection<ShipCityDetails>();
            denmark.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 125 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 126 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 127 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 128 });
            denmark.Add(new ShipCityDetails() { ShipCityName = "Århus", ShipCityID = 129 });

            ObservableCollection<ShipCityDetails> finland = new ObservableCollection<ShipCityDetails>();
            finland.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 130 });
            finland.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 131 });
            finland.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 132 });
            finland.Add(new ShipCityDetails() { ShipCityName = "Helsinki", ShipCityID = 133 });

            ObservableCollection<ShipCityDetails> italy = new ObservableCollection<ShipCityDetails>();
            italy.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 134 });
            italy.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 135 });
            italy.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 136 });
            italy.Add(new ShipCityDetails() { ShipCityName = "Helsinki", ShipCityID = 137 });

            ObservableCollection<ShipCityDetails> us = new ObservableCollection<ShipCityDetails>();
            us.Add(new ShipCityDetails() { ShipCityName = "Campinas", ShipCityID = 138 });
            us.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 139 });
            us.Add(new ShipCityDetails() { ShipCityName = "Bergamo", ShipCityID = 140 });
            us.Add(new ShipCityDetails() { ShipCityName = "Graz", ShipCityID = 141 });
            us.Add(new ShipCityDetails() { ShipCityName = "Århus", ShipCityID = 142 });

            ObservableCollection<ShipCityDetails> uk = new ObservableCollection<ShipCityDetails>();
            uk.Add(new ShipCityDetails() { ShipCityName = "Bruxelles", ShipCityID = 143 });
            uk.Add(new ShipCityDetails() { ShipCityName = "Montréal", ShipCityID = 145 });
            uk.Add(new ShipCityDetails() { ShipCityName = "Cork", ShipCityID = 146 });
            uk.Add(new ShipCityDetails() { ShipCityName = "Helsinki", ShipCityID = 147 });


            Dictionary<string, ObservableCollection<ShipCityDetails>> shipDictionary =
                new Dictionary<string, ObservableCollection<ShipCityDetails>>();
            shipDictionary.Add("Argentina", argentina);
            shipDictionary.Add("Austria", austria);
            shipDictionary.Add("Belgium", belgium);
            shipDictionary.Add("Brazil", brazil);
            shipDictionary.Add("Canada", canada);
            shipDictionary.Add("Denmark", denmark);
            shipDictionary.Add("Finland", finland);
            shipDictionary.Add("Italy", italy);
            shipDictionary.Add("US", us);
            shipDictionary.Add("UK", uk);
            return shipDictionary;
        }
    }
}
