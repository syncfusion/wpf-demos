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
using System.Windows.Threading;

namespace syncfusion.mapdemos.wpf
{
    /// <summary>
    /// Represents the view model for the map, containing a collection of geographical models and logic for updating their local times.
    /// </summary>
    public class MapViewModel
    {
        /// <summary>
        /// Gets or sets Collection of map data models.
        /// </summary>
        public ObservableCollection<Model> Models { get; set; }

        /// <summary>
        /// The timer that updates the local time for each model every second.
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// Initializes a new instance of the MapViewModel class and populates the collection of geographical models with predefined data.
        /// </summary>
        public MapViewModel()
        {
            this.Models = new ObservableCollection<Model>();
            this.Models.Add(new Model() { Name = "USA", Latitude = "38.8833N", Longitude = "77.0167W", TimeZone = "Eastern Standard Time" });
            this.Models.Add(new Model() { Name = "Brazil", Latitude = "15.7833S", Longitude = "47.8667W", TimeZone = "E. South America Standard Time" });
            this.Models.Add(new Model() { Name = "India", Latitude = "21.0000N", Longitude = "78.0000E", TimeZone = "India Standard Time" });
            this.Models.Add(new Model() { Name = "China", Latitude = "35.0000N", Longitude = "103.0000E", TimeZone = "China Standard Time" });
            this.Models.Add(new Model() { Name = "Indonesia", Latitude = "6.1750S", Longitude = "106.8283E", TimeZone = "W. Australia Standard Time" });

            // Start the timer to update every minute
            this.StartTimer();
        }

        /// <summary>
        /// Initializes and starts the timer that updates the local time for each model every second.
        /// </summary>
        private void StartTimer()
        {
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            this.timer.Tick += (s, e) => this.UpdateTime();
            this.timer.Start();
        }

        /// <summary>
        /// Stops the timer that updates the local time for each model.
        /// </summary>
        internal void StopTimer()
        {
            if (this.timer == null)
            {
                return;
            }

            this.timer.Stop();
            this.timer = null;
        }

        /// <summary>
        /// Updates the local time for each geographical model in the collection based on their respective time zones.
        /// </summary>
        private void UpdateTime()
        {
            foreach (var model in this.Models)
            {
                model.LocalTime = this.GetLocalTime(model.TimeZone);
            }
        }

        /// <summary>
        /// Retrieves the current local time in the specified time zone and formats it to display hours, minutes, seconds, and AM/PM.
        /// </summary>
        /// <param name="timeZoneId">The ID of the time zone.</param>
        /// <returns>The local time as a formatted string.</returns>
        private string GetLocalTime(string timeZoneId)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            DateTime utcNow = DateTime.UtcNow;
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZone);

            // Format to show hours, minutes, seconds, and AM/PM
            return localTime.ToString("hh:mm:ss tt");
        }
    }
}