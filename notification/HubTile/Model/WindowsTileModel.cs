#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Represents a standard  model
    /// </summary>
    public class WindowsTileModel : NotificationObject
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
        private BitmapImage imageSource;

        /// <summary>
        /// Represents the interval for the hub tile
        /// </summary>
        private TimeSpan interval;

        /// <summary>
        /// Represents the header to be displayed in hub tile
        /// </summary>
        private string secondaryContent;

        /// <summary>
        /// Gets or sets the header to be displayed in the Hub Tile<see cref="WindowsTileModel"/>calss
        /// </summary>
        public string Header
        {
            get { return header; }
            set { header = value; RaisePropertyChanged("Header"); }
        }

        /// <summary>
        /// Gets or sets the bitmap image to be displayed in the Hub Tile<see cref="WindowsTileModel"/>class
        /// </summary>
        public BitmapImage ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; RaisePropertyChanged("ImageSource"); }
        }

        /// <summary>
        /// Gets or sets the interval for the Hub Tile<see cref="WindowsTileModel"/>class
        /// </summary>
        public TimeSpan Interval
        {
            get { return interval; }
            set { interval = value; RaisePropertyChanged("Interval"); }
        }

        /// <summary>
        /// Gets or sets the secondraryContent to be displayed in the Hub Tile<see cref="Model"/>calss
        /// </summary>
        public string SecondaryContent
        {
            get { return secondaryContent; }
            set { secondaryContent = value; RaisePropertyChanged("SecondaryContent"); }
        }

        /// <summary>
        /// Gets or sets the background for the Hub Tile<see cref="Model"/>class
        /// </summary>
        public Brush Background
        {
            get { return background; }
            set { background = value; }
        }
    }
}

