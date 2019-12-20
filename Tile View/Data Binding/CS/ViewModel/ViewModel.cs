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

namespace DataBindingDemo
{
    public class ViewModel
    {
        private ObservableCollection<ApplicationTile> apps;

        public ObservableCollection<ApplicationTile> Applications
        {
            get { return apps; }
            set { apps = value; }
        }

        public ViewModel()
        {
            Applications = new ObservableCollection<ApplicationTile>();
            Applications.Add(new ApplicationTile() { Name = "news", Color = "#FF4DAEB5", View = new NewsView(), Header = "RSS Feeds", Icon = "/Images/RSS feeds2.png" });
            Applications.Add(new ApplicationTile() { Name = "weather", Color = "#FF36377C", Icon = "/Images/Cloud Sun.png", Header = "71 Sunny", Description = "Wednesday, 60 Cloudy Thursday, 55 Sunny Friday, 75 Cloudy", View = new WeatherView() });
            Applications.Add(new ApplicationTile() { Name = "stock", Color = "#FFD68513", Icon = "/Images/Stock Index Up.png", View = new StockView(), Description = "3 Dow stocks that never discovered.", Header = "Dow Chemical."});
            Applications.Add(new ApplicationTile() { Name = "twitter", Color = "#FF555BBE", Icon = "/Images/Twitter.png", Header="metro studio", Description = "Response to Metro Studio is more than imagined", View = new TwitterView() });
            Applications.Add(new ApplicationTile() { Name = "pictures", Color = "green", Icon = "/Images/photo.jpg", View = new GalleryView(), Header = "michael angela", Description = "April 15, 2012 Boston, London", SlideImage = "/Images/Interview4.jpg", CanSlide = true });
            Applications.Add(new ApplicationTile() { Name = "internet explorer", Color = "#FF02478A", Icon = "/Images/IE.png", View = new BrowserView() });
            Applications.Add(new ApplicationTile() { Name = "my computer", Color = "#FF9AB534", Icon = "/Images/Monitor.png", View = new ComputerView() });
            Applications.Add(new ApplicationTile() { Name = "store", Color = "#FF7D35B2", Icon = "/Images/Market.png", Header = "market place", View = new StoreView() });
            Applications.Add(new ApplicationTile() { Name = "videos", Color = "#FF781768", View = new VideosView(), SlideImage = "/Images/Chad.png", CanSlide = true, Icon = "/Images/Film.png", Description = "Syncfusion employees discuss the success of Metro Studio.", Header = "metro studio" });
        }
       
    }
}
