#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace syncfusion.datagriddemos.wpf
{
    public class CountryInfoViewModel : NotificationObject
    {
        Random r = new Random();
        public CountryInfoViewModel()
        {
            CountryDetails = PopulateCountryDetails();

            var random = new Random();
            for (int i = 0; i < CountryDetails.Count; i++)
            {
                var item = CountryDetails[i];
                var economy = new ObservableCollection<EconomyGrowth>();
                for (int j = 0; j < 5; j++)
                {
                    economy.Add(new EconomyGrowth() { Year = DateTime.Now.Year - j, GrowthPercentage = random.Next(0, 5) });
                }
                item.EconomyRate = economy;
            }
        }

        private ObservableCollection<CountryInfo> PopulateCountryDetails()
        {
            countryDetails.Add(new CountryInfo("1", "Afghanistan", "Kabul", "Islamic Emirate of Afghanistan", "Asia", "Pushtu Dari", "Afghani", 34104128, 28.1));
            countryDetails.Add(new CountryInfo("7", "Argentina", "Buenos Aires", "Argentine Republic", "South America", "Spanish", "Peso", 413229912, 97.2));
            countryDetails.Add(new CountryInfo("9", "Australia", "Canberra", "Commonwealth of Australia", "Australia", "English", "Australian Dollar", 34104128, 99));
            countryDetails.Add(new CountryInfo("29", "Barbados", "Bridgetown", "Barbados", "North America", "English", "Barbados Dollar", 274913, 99.7));
            countryDetails.Add(new CountryInfo("30", "Belarus", "Minsk", "Republic of Belarus", "Europe", "Belorussian", "Ruble", 9513664, 99.6));
            countryDetails.Add(new CountryInfo("31", "Belgium", "Brussels", "Kingdom of Belgium", "Europe", "Flemish (Dutch), French, German", "Euro", 10793439, 99));
            countryDetails.Add(new CountryInfo("38", "Brazil", "Brazilia", "Federative Republic of Brazil", "South America", "Portuguese", "Real", 199303225, 88.6));
            countryDetails.Add(new CountryInfo("45", "Cameroon", "Yaounde", "Republic of Cameroon", "Africa", "French, English", "Franc CFA", 20744860, 75.9));
            countryDetails.Add(new CountryInfo("50", "Chile", "Santiago", "Republic of Chile", "South America", "Spanish", "Spanish Peso", 17509658, 95.7));
            countryDetails.Add(new CountryInfo("53", "Colombia", "Bogota", "Republic of Colombia", "South America", "Spanish", "Spanish Peso", 47899079, 90.4));
            countryDetails.Add(new CountryInfo("63", "Denmark", "Copenhagen", "Kingdom of Denmark", "Europe", "Danish", "Krone", 5601189, 99));
            countryDetails.Add(new CountryInfo("67", "Dominica", "Roseau", "Commonwealth of Dominica", "North America", "French patois, Eng.", "East Caribbean Dollar", 67771, 94));
            countryDetails.Add(new CountryInfo("70", "Egypt", "Cairo", "Arab Republic of Egypt", "Africa", "Arabic", "Egyptian Pound", 84790168, 72));
            countryDetails.Add(new CountryInfo("75", "Ethiopia", "Addis Ababa", "Federal Democratic Republic of Ethiopia", "Africa", "Amharic", "Birr", 87631686, 42.7));
            countryDetails.Add(new CountryInfo("76", "Fiji", "Suva", "Republic of Fiji", "South Europe", "English", "Fijian Dollar", 879222, 93.7));
            countryDetails.Add(new CountryInfo("78", "France", "Paris", "French Republic", "Europe", "French", "Euro", 63644129, 99));
            countryDetails.Add(new CountryInfo("91", "Gambia", "Banjul", "Republic of the Gambia", "Africa", "English", "Dalasi", 1855510, 50));
            countryDetails.Add(new CountryInfo("100", "Guyana", "Georgetown", "Co-operative Republic of Guyana", "South America", "English", "Guyana Dollar", 456674565, 91.8));
            countryDetails.Add(new CountryInfo("103", "Hungary", "Budapest", "Republic of Hungary", "Europe", "Hungarian", "Forint", 758869, 99));
            countryDetails.Add(new CountryInfo("106", "India", "New Delhi", "Republic of India - Bharat", "Asia", "Hindi", "Rupee", 1268260518, 74.04));
            countryDetails.Add(new CountryInfo("107", "Indonesia", "Jakarta", "Republic of Indonesia", "Asia", "Bahasa Indonesia", "Rupiah", 246166130, 90.4));
            countryDetails.Add(new CountryInfo("110", "Ireland", "Dublin", "Republic of Ireland", "Europe", "Irish Gaelic, English", "Irish-Pound", 4606950, 99));
            countryDetails.Add(new CountryInfo("113", "Jamaica", "Kingston", "Jamaica", "Caribbean Ocean", "English", "Jamaican Dollar", 2766771, 87.9));
            countryDetails.Add(new CountryInfo("115", "Jordan", "Amman", "The Hashemite Kingdom of Jorden", "Asia", "Arabic", "Jordanian Dinar", 6503345, 92.6));
            countryDetails.Add(new CountryInfo("117", "Kenya", "Nairobi", "Republic of Kenya", "Africa", "Kiswahili, English", "Kenyan Shilling", 43501390, 87.4));
            countryDetails.Add(new CountryInfo("121", "Kuwait", "Kuwait City", "State of Kuwait", "Asia", "Arabic", "Kuwait Dinar", 2917194, 93.3));
            countryDetails.Add(new CountryInfo("126", "Liberia", "Monrovia", "Republic of Liberia", "Africa", "English", "Liberian Dollar", 4284080, 60.8));
            countryDetails.Add(new CountryInfo("130", "Luxembourg", "Luxemburg", "Grand Duchy of Luxembourg", "Europe", "Luxemburgish, French, English", "Euro", 525983, 100));
            countryDetails.Add(new CountryInfo("133", "Malawi", "Lilongwe", "Republic of Malawi", "Africa", "English, Chichewa", "Kwacha", 16238217, 74.8));
            countryDetails.Add(new CountryInfo("134", "Malaysia", "Kuala Lumpur", "Malaysia", "Asia", "Malay", "Ringgit", 29604978, 92.1));
            countryDetails.Add(new CountryInfo("150", "Namibia", "Windhoek", "Republic of Namibia", "Africa", "English", "Rand", 2387159, 88.8));
            countryDetails.Add(new CountryInfo("153", "Netherlands", "Amsterdam", "Kingdom of The Netherlands", "Europe", "Dutch", "Euro", 16738135, 99));
            countryDetails.Add(new CountryInfo("157", "Nicaragua", "Managua", "Republic of Nicaragua", "South America", "Spanish", "Gold Cordoba", 6006990, 67.5));
            countryDetails.Add(new CountryInfo("159", "Nigeria", "Abuja", "Federal Republic of Nigeria", "Africa", "English", "Naira", 169416887, 61.3));
            countryDetails.Add(new CountryInfo("170", "Paraguay", "Asuncion", "Republic of Paraguay", "South America", "Spanish", "Guarani", 6753180, 94));
            countryDetails.Add(new CountryInfo("182", "Rwanda", "Kigali", "Republic of Rwanda", "Africa", "Kinyarwanda, French", "Rwanda Franc", 11479847, 71.1));
            countryDetails.Add(new CountryInfo("192", "San Marino", "San Marino", "Most Serene Republic of San Marino", "Europe", "Italian", "Euro", 32056, 96));
            countryDetails.Add(new CountryInfo("195", "Senegal", "Dakar", "Republic of Senegal", "Africa", "French", "CFA Franc", 133216648, 39.3));
            countryDetails.Add(new CountryInfo("198", "Singapore", "Singapore", "Republic of Singapore", "Asia", "Malay, Chinese, Tamil", "Singapore Dollar", 5237597, 92.5));

            return countryDetails;
        }

        private ObservableCollection<CountryInfo> countryDetails = new ObservableCollection<CountryInfo>();
        public ObservableCollection<CountryInfo> CountryDetails
        {
            get
            {
                return countryDetails;
            }
            set
            {
                countryDetails = value;
                RaisePropertyChanged("CountryDetails");
            }
        } 

        
    }
}
