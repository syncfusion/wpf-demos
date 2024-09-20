#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.mapdemos.wpf
{
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a view model that manages and provides offline data options.
    /// </summary>
    public class LocationIndicatorViewModel
    {
        /// <summary>
        /// Gets or sets a collection of offline data options such as names of datasets.
        /// </summary>
        public ObservableCollection<string> DataOptions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationIndicatorViewModel"/> class.
        /// </summary>
        public LocationIndicatorViewModel()
        {
            this.DataOptions = new ObservableCollection<string>();
            this.DataOptions.Add("Hospitals in New York");
            this.DataOptions.Add("Hotels in Denver");
        }
    }
}