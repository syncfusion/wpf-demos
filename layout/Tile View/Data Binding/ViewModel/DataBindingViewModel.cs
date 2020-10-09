#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
            Applications.Add(new ApplicationTile() { Name = "News", Color = "#FF4DAEB5", View = new NewsView(), Header = "RSS Feeds", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/RSS feeds2.png" });
            Applications.Add(new ApplicationTile() { Name = "Weather", Color = "#FF36377C", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Cloud Sun.png", Header = "71 Sunny", Description = "Wednesday, 60 Cloudy Thursday, 55 Sunny Friday, 75 Cloudy", View = new WeatherView() });
            Applications.Add(new ApplicationTile() { Name = "Stock", Color = "#FFD68513", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Stock Index Up.png", View = new StockView(), Description = "3 Dow stocks that never discovered.", Header = "Dow Chemical."});
            Applications.Add(new ApplicationTile() { Name = "Twitter", Color = "#FF555BBE", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Twitter.png", Header="metro studio", Description = "Response to Metro Studio is more than imagined", View = new TwitterView() });
            Applications.Add(new ApplicationTile() { Name = "Pictures", Color = "green", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/photo.jpg", View = new GalleryView(), Header = "michael angela", Description = "April 15, 2012 Boston, London", SlideImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Interview4.jpg", CanSlide = true });
            Applications.Add(new ApplicationTile() { Name = "Internet Explorer", Color = "#FF02478A", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/IE.png", View = new BrowserView() });
            Applications.Add(new ApplicationTile() { Name = "My Computer", Color = "#FF9AB534", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Monitor.png", View = new ComputerView() });
            Applications.Add(new ApplicationTile() { Name = "Store", Color = "#FF7D35B2", Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Market.png", Header = "market place", View = new StoreView() });
            Applications.Add(new ApplicationTile() { Name = "Videos", Color = "#FF781768", View = new VideosView(), SlideImage = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Chad.png", CanSlide = true, Icon = "/syncfusion.layoutdemos.wpf;component/Assets/TileView/Film.png", Description = "Syncfusion employees discuss the success of Metro Studio.", Header = "metro studio" });
        }
       
    }
}
