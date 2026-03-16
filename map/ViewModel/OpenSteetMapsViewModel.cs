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

namespace syncfusion.mapdemos.wpf
{
    public class OpenStreetMapsViewModel
    {
        public ObservableCollection<OpenStreetMapsModel> Models { get; set; }
        public OpenStreetMapsViewModel()
        {
            this.Models = new ObservableCollection<OpenStreetMapsModel>();
            this.Models.Add(new OpenStreetMapsModel() { Name = "USA ", Latitude = "37.0902N", Longitude = "95.7129W" });
            this.Models.Add(new OpenStreetMapsModel() { Name = "Brazil ", Latitude = "14.2350S", Longitude = "51.9253W" });
            this.Models.Add(new OpenStreetMapsModel() { Name = "India ", Latitude = "20.5937N", Longitude = "78.9629E" });
            this.Models.Add(new OpenStreetMapsModel() { Name = "China ", Latitude = "35.8617N", Longitude = "104.1954E" });
            this.Models.Add(new OpenStreetMapsModel() { Name = "Indonesia ", Latitude = "0.7893S", Longitude = "113.9213E" });
        }
    }
}
