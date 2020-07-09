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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Syncfusion.UI.Xaml.Maps;

namespace DataMarkers
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int markerWidth;      

        private Color color = Colors.Red;       

        public ObservableCollection<Model> DataMarkers { get; set; }
        public ViewModel()
        {
            MarkerWidth = 16;
            IconColor = Colors.Red;

            this.DataMarkers = new ObservableCollection<Model>();
            this.DataMarkers.Add(new Model() { Label = "USA ", Latitude = "38.8833N", Longitude = "77.0167W" });
            this.DataMarkers.Add(new Model() { Label = "Brazil ", Latitude = "15.7833S", Longitude = "47.8667W" });
            this.DataMarkers.Add(new Model() { Label = "India ", Latitude = "21.0000N", Longitude = "78.0000E" });
            this.DataMarkers.Add(new Model() { Label = "China ", Latitude = "35.0000N", Longitude = "103.0000E" });
            this.DataMarkers.Add(new Model() { Label = "Australia ", Latitude = "25.2744S", Longitude = "133.7751E" });
            this.DataMarkers.Add(new Model() { Label = "DRC ", Latitude = "4.0383S", Longitude = "21.7587E" });

        }

        public Array MarkerTypes
        {
            get { return Enum.GetValues(typeof(MarkerIcon)); }
        }

        public Array Alignment
        {
            get { return Enum.GetValues(typeof(MarkerAlignment)); }
        }

      
        public int MarkerWidth
        {
            get { return markerWidth; }
            set
            {
                markerWidth = value;
                MarkerSize = new Size(markerWidth, markerWidth);
                OnPropertyChanged("MarkerSize");
                OnPropertyChanged("MarkerWidth");
            }
        }

        public Size MarkerSize { get; set; }   
        public Brush IconBrush { get; set; }

        public Color IconColor
        {
            get { return color; }
            set
            {
                color = value;
                IconBrush = new SolidColorBrush(color);
                OnPropertyChanged("IconBrush");
                OnPropertyChanged("IconColor");
            }
        }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
