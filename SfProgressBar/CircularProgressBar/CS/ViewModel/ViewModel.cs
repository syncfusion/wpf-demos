#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace CircularProgressBar_2017
{
    public class ViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer SfCircularBarPlayPauseTimer;

        #region Cons

        /// <summary>
        /// Initializes a new instance of the time class.
        /// </summary>
        public ViewModel()
        {
            DispatcherTimer SfCircularBarTimer = new DispatcherTimer();
            SfCircularBarTimer.Tick += SfCircularBarTimer_Tick;
            SfCircularBarTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            SfCircularBarTimer.Start();
            SfCircularBarPlayPauseTimer = new DispatcherTimer();
            SfCircularBarPlayPauseTimer.Tick += SfCircularBarPlayPauseTimer_Tick;
            SfCircularBarPlayPauseTimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            SfCircularBarPlayPauseTimer.Start();
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

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        private int progressValue;

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

        /// <summary>
        /// Represents the event trigger while change the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Method represents the name of the property that changed.
        /// </summary>
        /// <param name="name"></param>
        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }

    public class DoubleToPctConverter : IValueConverter
    {
        /// <summary>
        /// Convert the progress value to percentage.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string result = "";
            double d = ((IConvertible)value).ToDouble(null);
            result = string.Format("{0}%", d);

            return result;
        }

        /// <summary>
        /// Represent the call back.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
