#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.ObjectModel;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Class represents the behaviour or business logic for MainWindow.xaml
    /// </summary>
    public class PulsingTileViewModel :NotificationObject
    {
        /// <summary>
        /// Maintains a collection for pulse scale
        /// </summary>
        private ObservableCollection<double> pulseScale;

        /// <summary>
        /// Maintains a collection for pulse duration
        /// </summary>
        private ObservableCollection<TimeSpan> pulseDuration;

        /// <summary>
        /// Initalize the instance of <see cref="PulsingTileViewModel"/> class
        /// </summary>
        public PulsingTileViewModel()
        {
            PulseScale = new ObservableCollection<double>();
            PulseDuration = new ObservableCollection<TimeSpan>();
            Additems();
        }

        /// <summary>
        /// Gets or sets the collection for pulse scale<see cref="PulsingTileViewModel"/>class.
        /// </summary>
        public ObservableCollection<double> PulseScale
        {
            get { return pulseScale; }
            set
            {
                pulseScale = value;
                RaisePropertyChanged("PulseScale");
            }
        }

        /// <summary>
        /// Gets or sets the collection for pulse duration<see cref="PulsingTileViewModel"/>class.
        /// </summary>
        public ObservableCollection<TimeSpan> PulseDuration
        {
            get { return pulseDuration; }
            set
            {
                pulseDuration = value;
                RaisePropertyChanged("PulseDuration");
            }
        }

        /// <summary>
        /// Method to populate elements of pulsing tile
        /// </summary>
        private void Additems()
        {
            for (double i = 1; i <= 5; i++)
            {
                PulseScale.Add(i);
            }
            for (double i = 1; i <= 8; i++)
            {
                PulseDuration.Add(TimeSpan.FromSeconds(i));
            }
        }
    }
}
