#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.mapdemos.wpf
{
    /// <summary>
    /// Represents a geographical model with properties for name, coordinates, time zone, and local time. Implements INotifyPropertyChanged to support property change notifications.
    /// </summary>
    public class Model : INotifyPropertyChanged
    {
        /// <summary>
        /// The name of the geographical location.
        /// </summary>
        private string name;

        /// <summary>
        /// The latitude coordinate of the geographical location.
        /// </summary>
        private string latitude;

        /// <summary>
        /// The longitude coordinate of the geographical location.
        /// </summary>
        private string longitude;

        /// <summary>
        /// The time zone of the geographical location.
        /// </summary>
        private string timeZone;

        /// <summary>
        /// The local time.
        /// </summary>
        private string localTime;

        /// <summary>
        /// Gets or sets the name of the geographical location.
        /// </summary>
        public string Name 
        {
            get => this.name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Gets or sets the latitude coordinate of the geographical location.
        /// </summary>
        public string Latitude 
        {
            get => this.latitude;
            set
            {
                if (this.latitude != value)
                {
                    this.latitude = value;
                    this.OnPropertyChanged(nameof(Latitude));
                }
            }
        }

        /// <summary>
        /// Gets or sets the longitude coordinate of the geographical location.
        /// </summary>
        public string Longitude
        {
            get => this.longitude;
            set
            {
                if (this.longitude != value)
                {
                    this.longitude = value;
                    this.OnPropertyChanged(nameof(Longitude));
                }
            }
        }

        /// <summary>
        /// Gets or sets the time zone of the geographical location.
        /// </summary>
        public string TimeZone
        {
            get => this.timeZone;
            set
            {
                if (this.timeZone != value)
                {
                    this.timeZone = value;
                    this.OnPropertyChanged(nameof(TimeZone));
                }
            }
        }

        /// <summary>
        /// Gets or sets the localTime.
        /// </summary>
        public string LocalTime
        {
            get => this.localTime;
            set
            {
                if (this.localTime != value)
                {
                    this.localTime = value;
                    OnPropertyChanged(nameof(LocalTime));
                }
            }
        }

        /// <summary>
        /// Event that is raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method to raise the PropertyChanged event
        /// </summary>
        /// <param name="propertyName">The property name.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}