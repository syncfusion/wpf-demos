#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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

namespace syncfusion.layoutdemos.wpf
{
    public class DataBindingViewModel
    {
        private ObservableCollection<ApplicationTile> apps;

        public ObservableCollection<ApplicationTile> Applications
        {
            get { return apps; }
            set { apps = value; }
        }

        public DataBindingViewModel()
        {
            Applications = new ObservableCollection<ApplicationTile>();
            Applications.Add(new ApplicationTile() { Name = "News", Color = "#FF4DAEB5", Header = "RSS Feeds", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/RSS feeds2.png" });
            Applications.Add(new ApplicationTile() { Name = "Weather", Color = "#FF36377C", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Cloud Sun.png", Header = "71 Sunny"});
            Applications.Add(new ApplicationTile() { Name = "Stock", Color = "#FFD68513", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Stock Index Up.png", Header = "Dow Chemical." });
            Applications.Add(new ApplicationTile() { Name = "Twitter", Color = "#FF555BBE", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Twitter.png", Header = "metro studio"});
            Applications.Add(new ApplicationTile() { Name = "Pictures", Color = "green", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/photo.jpg", Header = "michael angela", SlideImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Interview4.jpg", CanSlide = true });
            Applications.Add(new ApplicationTile() { Name = "Internet Explorer", Color = "#FF02478A", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/IE.png"});
            Applications.Add(new ApplicationTile() { Name = "My Computer", Color = "#FF9AB534", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Monitor.png"});
            Applications.Add(new ApplicationTile() { Name = "Store", Color = "#FF7D35B2", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Market.png", Header = "market place"});
            Applications.Add(new ApplicationTile() { Name = "Videos", Color = "#FF781768", SlideImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Chad.png", CanSlide = true, Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Film.png", Header = "metro studio" });
        }
       
    }
}
