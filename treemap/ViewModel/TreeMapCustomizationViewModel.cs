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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.treemapdemos.wpf
{
    public class TreeMapCustomizationViewModel
    {
        public ObservableCollection<OlympicMedals> OlympicMedalsDetails { get; set; }

        public TreeMapCustomizationViewModel()
        {
            this.OlympicMedalsDetails = new ObservableCollection<OlympicMedals>();
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Swimming", GoldMedals = 16, SilverMedals = 9, BronzeMedals = 6, TotalMedals = 31, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Swimming.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Track and Field", GoldMedals = 9, SilverMedals = 13, BronzeMedals = 7, TotalMedals = 29, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/TrackAndField.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Gymnastics", GoldMedals = 3, SilverMedals = 1, BronzeMedals = 2, TotalMedals = 6, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Gymnastics.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Boxing", GoldMedals = 1, SilverMedals = 0, BronzeMedals = 1, TotalMedals = 2, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Boxing.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Cycling", GoldMedals = 1, SilverMedals = 2, BronzeMedals = 1, TotalMedals = 4, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Cycling.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Shooting", GoldMedals = 3, SilverMedals = 0, BronzeMedals = 1, TotalMedals = 4, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Shooting.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Wrestling", GoldMedals = 2, SilverMedals = 0, BronzeMedals = 2, TotalMedals = 4, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Wrestling.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Archery", GoldMedals = 0, SilverMedals = 1, BronzeMedals = 0, TotalMedals = 1, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Archery.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Soccer", GoldMedals = 1, SilverMedals = 0, BronzeMedals = 0, TotalMedals = 1, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Soccer.png")) });
            this.OlympicMedalsDetails.Add(new OlympicMedals { Country = "US", GameName = "Diving", GoldMedals = 1, SilverMedals = 1, BronzeMedals = 2, TotalMedals = 4, GameImgSource = new BitmapImage(new Uri("pack://application:,,,/syncfusion.treemapdemos.wpf;Component/Assets/Treemap/Diving.png")) });
        }
    }
}
