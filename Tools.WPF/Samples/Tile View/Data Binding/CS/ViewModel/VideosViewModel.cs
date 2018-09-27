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
