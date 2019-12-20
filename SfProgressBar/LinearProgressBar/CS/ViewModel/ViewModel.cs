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
using System.Windows.Threading;

namespace ProgressBar_Demo
{
    public class ViewModel : INotifyPropertyChanged
    {
        private int progressvalue = 10;

        private int secondaryProgressvalue = 10;

        #region Construtor

        /// <summary>
        /// Initializes a new instance of the time class.
        /// </summary>
        public ViewModel()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            timer.Start();
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
                return progressvalue;
            }
            set
            {
                if (progressvalue != value)
                {
                    progressvalue = value;
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
                return secondaryProgressvalue;
            }
            set
            {
                if (secondaryProgressvalue != value)
                {
                    secondaryProgressvalue = value;
                    RaisePropertyChanged("SecondaryProgressValue");
                }
            }
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


        /// <summary>
        /// Method represents the name of the property that changed.
        /// </summary>
        /// <param name="name">Defines value passed.</param

        private void RaisePropertyChanged(string name)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region Fields
        /// <summary>
        /// Represents the event trigger while change the property.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
