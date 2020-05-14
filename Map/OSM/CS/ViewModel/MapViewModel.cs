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

namespace OSMMaps
{
    public class MapViewModel
    {
        public ObservableCollection<Model> Models { get; set; }
        public MapViewModel()
        {
            this.Models = new ObservableCollection<Model>();
            this.Models.Add(new Model() { Name = "USA ", Latitude = "37.0902N", Longitude = "95.7129W" });
            this.Models.Add(new Model() { Name = "Brazil ", Latitude = "14.2350S", Longitude = "51.9253W" });
            this.Models.Add(new Model() { Name = "India ", Latitude = "20.5937N", Longitude = "78.9629E" });
            this.Models.Add(new Model() { Name = "China ", Latitude = "35.8617N", Longitude = "104.1954E" });
            this.Models.Add(new Model() { Name = "Indonesia ", Latitude = "0.7893S", Longitude = "113.9213E" });
        }
    }
}
