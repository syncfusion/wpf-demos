#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Media;

namespace HubTile_Data_Binding
{
    /// <summary>
    /// Represents a standard  model
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Represents the header to be displayed in hub tile
        /// </summary>
        private string header;

        /// <summary>
        /// Represents the background to be displayed in hub tile
        /// </summary>
        private Brush background;

        /// <summary>
        /// Represents the image path for image in the hub tile
        /// </summary>
        private string imageSource;

        /// <summary>
        /// Represents the interval for the hub tile
        /// </summary>
        private TimeSpan interval;

        /// <summary>
        /// Represents the header to be displayed in hub tile
        /// </summary>
        private string secondraryContent;

        /// <summary>
        /// Gets or sets the header to be displayed in the Hub Tile<see cref="Model"/>calss
        /// </summary>
        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        /// <summary>
        /// Gets or sets the imageSource path for the image to be displayed in the Hub Tile<see cref="Model"/>class
        /// </summary>
        public string ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        /// <summary>
        /// Gets or sets the interval for the Hub Tile<see cref="Model"/>class
        /// </summary>
        public TimeSpan Interval
        {
            get { return interval; }
            set { interval = value; }
        }

        /// <summary>
        /// Gets or sets the background for the Hub Tile<see cref="Model"/>class
        /// </summary>
        public Brush Background
        {
            get { return background; }
            set { background = value; }
        }

        /// <summary>
        /// Gets or sets the secondraryContent to be displayed in the Hub Tile<see cref="Model"/>calss
        /// </summary>
        public string SecondraryContent
        {
            get { return secondraryContent; }
            set { secondraryContent = value; }
        }
    }
}

