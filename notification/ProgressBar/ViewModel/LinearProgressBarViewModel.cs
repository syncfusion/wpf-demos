#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows.Threading;

namespace syncfusion.notificationdemos.wpf
{
    public class LinearProgressBarViewModel : NotificationObject , IDisposable
    {
        /// <summary>
        /// Represents the progress value.
        /// </summary>
        private int progressValue = 10;

        /// <summary>
        /// Represents the progress value.
        /// </summary>
        private int secondaryProgressValue = 10;

        /// <summary>
        /// Represents the timer for progress value.
        /// </summary>
        private DispatcherTimer playTimer;

        #region Construtor

        /// <summary>
        /// Initializes a new instance of the time class.
        /// </summary>
        public LinearProgressBarViewModel()
        {
            playTimer = new DispatcherTimer();
            playTimer.Tick += Timer_Tick;
            playTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            playTimer.Start();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the LinearProgressBar progress value.
        /// </summary
        public int ProgressValue
        {
            get
            {
                return progressValue;
            }
            set
            {
                if (progressValue != value)
                {
                    progressValue = value;
                    RaisePropertyChanged("ProgressValue");
                }
            }
        }

        /// <summary>
        /// Gets or sets the LinearProgressBar secondary value.
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
        /// Dispose the timer.
        /// </summary>
        public void Dispose()
        {
            playTimer.Stop();
        }
        #endregion


        #region Events
        /// <summary>
        /// Represents to increase the progress value based time interval.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (ProgressValue < 100)
            {
                ProgressValue += 1;
            }
            else
            {
                ProgressValue = 0;
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
        }

        #endregion

    }
}
