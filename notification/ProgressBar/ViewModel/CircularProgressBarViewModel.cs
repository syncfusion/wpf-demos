#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace syncfusion.notificationdemos.wpf
{
    public class CircularProgressBarViewModel : NotificationObject , IDisposable
    {
        /// <summary>
        /// Represents the play or pause timer.
        /// </summary>
        public DispatcherTimer PlayPauseTimer;

        /// <summary>
        /// Represents the circular bar timer.
        /// </summary>
        private DispatcherTimer playTimer;

        #region Cons

        /// <summary>
        /// Initializes a new instance of the time class.
        /// </summary>
        public CircularProgressBarViewModel()
        {
            playTimer = new DispatcherTimer();
            playTimer.Tick += SfCircularBarTimer_Tick;
            playTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            playTimer.Start();
            PlayPauseTimer = new DispatcherTimer();
            PlayPauseTimer.Tick += SfCircularBarPlayPauseTimer_Tick;
            PlayPauseTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            PlayPauseTimer.Start();
        }

        #endregion

        #region Method

        /// <summary>
        /// Represents to increase the progress value based time interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfCircularBarTimer_Tick(object sender, EventArgs e)
        {
            if (ProgressValue < 100)
            {
                ProgressValue += 1;
            }
            else
            {
                ProgressValue = 0;
            }
            if (CircularProgressValue < 100)
            {
                CircularProgressValue += 2;
            }
            else
            {
                CircularProgressValue = 0;
            }
            if (SecondaryProgressValue < 100)
            {
                SecondaryProgressValue += 2;
            }
            else
            {
                if (ProgressValue == 0)
                    SecondaryProgressValue = 0;
            }
            if (CircularSecondaryProgressValue < 100)
            {
                CircularSecondaryProgressValue += 3;
            }
            else
            {
                if (ProgressValue == 0)
                    CircularSecondaryProgressValue = 0;
            }
        }      

        /// <summary>
        /// Represents to increase the <see cref="PlayPauseProgress"/> value based time interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SfCircularBarPlayPauseTimer_Tick(object sender, EventArgs e)
        {
            if (PlayPauseProgress < 100)
            {
                PlayPauseProgress += 1;
            }
            else
            {
                PlayPauseProgress = 0;
            }
        }

        /// <summary>
        /// Dispose the timer objects.
        /// </summary>
        public void Dispose()
        {
            PlayPauseTimer.Stop();
            playTimer.Stop();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents the progress value.
        /// </summary>
        private int progressValue, circularProgressValue;

        /// <summary>
        /// Represents the secondary progress value.
        /// </summary>
        private int secondaryProgressValue, circularSecondaryProgressValue;

        /// <summary>
        /// Gets or sets the CircularProgressBar progress value.
        /// </summary>
        public int ProgressValue
        {
            get
            {
                return progressValue;
            }
            set
            {
                progressValue = value;
                RaisePropertyChanged("ProgressValue");
            }
        } 

        /// <summary>
        /// Gets or sets the CircularProgressBar progress value.
        /// </summary>
        public int CircularProgressValue
        {
            get
            {
                return circularProgressValue;
            }
            set
            {
                circularProgressValue = value;
                RaisePropertyChanged("CircularProgressValue");
            }
        }

        /// <summary>
        /// Gets or sets the CircularProgressBar secondary progress value.
        /// </summary
        public int SecondaryProgressValue
        {
            get
            {
                return secondaryProgressValue;
            }
            set
            {
                if (secondaryProgressValue != value)
                {
                    secondaryProgressValue = value;
                    RaisePropertyChanged("SecondaryProgressValue");
                }
            }
        }

        /// <summary>
        /// Gets or sets the CircularProgressBar secondary progress value.
        /// </summary
        public int CircularSecondaryProgressValue
        {
            get
            {
                return circularSecondaryProgressValue;
            }
            set
            {
                if (circularSecondaryProgressValue != value)
                {
                    circularSecondaryProgressValue = value;
                    RaisePropertyChanged("CircularSecondaryProgressValue");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private int playPauseProgress;

        /// <summary>
        /// Gets or sets the CircularProgressBar <see cref="PlayPauseProgress"/> value.
        /// </summary>
        public int PlayPauseProgress
        {
            get
            {
                return playPauseProgress;
            }
            set
            {
                playPauseProgress = value;
                RaisePropertyChanged("PlayPauseProgress");
            }
        }
       
        
        #endregion
    }    
}
