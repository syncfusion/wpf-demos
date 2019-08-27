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
using System.Collections.ObjectModel;
using System.Windows.Input;
using Syncfusion.Windows.Chart;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Serialization
{
    public class SerializationVewModel
    {
        public SerializationVewModel()
        {
            TemperatureDetails = new ObservableCollection<Temperature>();

            TemperatureDetails.Add(new Temperature() { Month = "Jan", GISS = 20, HadCRUT = 20, Rss_Msu = 30, UAH_MSU = 70 });
            TemperatureDetails.Add(new Temperature() { Month = "Feb", GISS = 30, HadCRUT = 50, Rss_Msu = 50, UAH_MSU = 25 });
            TemperatureDetails.Add(new Temperature() { Month = "Mar", GISS = 40, HadCRUT = 55, Rss_Msu = 63, UAH_MSU = 35 });
            TemperatureDetails.Add(new Temperature() { Month = "Apr", GISS = 50, HadCRUT = 58, Rss_Msu = 84, UAH_MSU = 46 });
            TemperatureDetails.Add(new Temperature() { Month = "May", GISS = 25, HadCRUT = 26, Rss_Msu = 48, UAH_MSU = 56 });
            TemperatureDetails.Add(new Temperature() { Month = "Jun", GISS = 26, HadCRUT = 48, Rss_Msu = 56, UAH_MSU = 54 });
            TemperatureDetails.Add(new Temperature() { Month = "Jul", GISS = 56, HadCRUT = 59, Rss_Msu = 65, UAH_MSU = 43 });
            TemperatureDetails.Add(new Temperature() { Month = "Aug", GISS = 38, HadCRUT = 29, Rss_Msu = 76, UAH_MSU = 65 });
            TemperatureDetails.Add(new Temperature() { Month = "Sep", GISS = 22, HadCRUT = 59, Rss_Msu = 67, UAH_MSU = 67 });
            TemperatureDetails.Add(new Temperature() { Month = "Oct", GISS = 33, HadCRUT = 70, Rss_Msu = 67, UAH_MSU = 78 });
            TemperatureDetails.Add(new Temperature() { Month = "Nov", GISS = 48, HadCRUT = 60, Rss_Msu = 78, UAH_MSU = 87 });
            TemperatureDetails.Add(new Temperature() { Month = "Dec", GISS = 69, HadCRUT = 20, Rss_Msu = 87, UAH_MSU = 33 });
        }

        public ObservableCollection<Temperature> TemperatureDetails
        {
            get;
            set;
        }

    }
}
