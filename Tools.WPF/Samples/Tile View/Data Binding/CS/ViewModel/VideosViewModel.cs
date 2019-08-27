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
using Syncfusion.Windows.Shared;

namespace DataBindingDemo
{
    public class VideosViewModel
    {
        public ObservableCollection<VideoModel> Videos { get; set; }

        public VideosViewModel()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            Videos = new ObservableCollection<VideoModel>();
            Videos.Add(new VideoModel() { Name = "Response to Metro Studio is more than imagined", Uri = "/Images/Chad.png" });
            Videos.Add(new VideoModel() { Name = "Forest", Uri = "/Images/Forest.jpg" });
            Videos.Add(new VideoModel() { Name = "Sample Video", Uri = "/Images/Ferry.jpg" });
            Videos.Add(new VideoModel() { Name = "Moving Sky", Uri = "/Images/sky.jpg" });
        }
    }

    public class VideoModel
    {
        public string Name { get; set; }

        public string Uri { get; set; }
    }
}
