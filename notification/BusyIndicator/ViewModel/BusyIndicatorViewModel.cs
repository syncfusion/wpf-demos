#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using Syncfusion.Windows.Controls.Notification;
using System.Windows.Threading;
using AnimationTypes = Syncfusion.Windows.Controls.Notification.AnimationTypes;

namespace syncfusion.notificationdemos.wpf
{
    class BusyIndicatorViewModel : NotificationObject, IDisposable
    {
        public BusyIndicatorViewModel()
        {
            Random rndm = new Random();
            items = new ObservableCollection<BusyIndicatorModel>()
            {
             
             new BusyIndicatorModel { ProductId = 1, ProductName = "Rice", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 2, ProductName = "Wheat", Price2000 = rndm.Next(5, 80), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 3, ProductName = "Oil", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 4, ProductName = "Corn", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 5, ProductName = "Gram", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 6, ProductName = "Milk", Price2000 = rndm.Next(5, 90), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 7, ProductName = "Butter", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 8, ProductName = "Ghee", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 9, ProductName = "Oats", Price2000 = rndm.Next(5, 80), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 10, ProductName = "Cheese", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 11, ProductName = "Ragi", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 12, ProductName = "Chocalate", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new BusyIndicatorModel { ProductId = 13, ProductName = "Olive", Price2000 = rndm.Next(5, 90), Price2010 = rndm.Next(10, 60) },

            };
            eventLogs = new ObservableCollection<string>();
            IsBusyChangedCommand = new DelegateCommand<object>(BusyChanged,CanChange);
            StartTimer();
            
            BusyIndicatorItems = new ObservableCollection<BusyIndicatorModel>();
            foreach (var item in Enum.GetValues(typeof(AnimationTypes)).Cast<AnimationTypes>())
            {
                if (item != AnimationTypes.Globe && item != AnimationTypes.Print && item != AnimationTypes.Rectangle && item != AnimationTypes.Flight && item != AnimationTypes.Snow && item != AnimationTypes.Sunny)
                    BusyIndicatorItems.Add(new BusyIndicatorModel() { Animation = item });
            }
        }

        public ObservableCollection<BusyIndicatorModel> BusyIndicatorItems { get; set; }

        private ObservableCollection<BusyIndicatorModel> items;

        public ObservableCollection<BusyIndicatorModel> Items
        {
            get { return items; }
            set { items = value; }
        }
        private bool isBusy=true;
        public bool IsBusy
        {
            get { return isBusy; }
            set { 
                isBusy = value;
                IsBusyChanged();
                RaisePropertyChanged("IsBusy");
            }
        }

        public bool isIndeterminate;
        public bool IsIndeterminate
        {
            get { return isIndeterminate;}
            set 
            { 
                isIndeterminate=value;
                RaisePropertyChanged("IsIndeterminate");
            }
        }
        public double progressValue;
        public double ProgressValue
        {
            get { return progressValue; }
            set {
                progressValue = value;
                RaisePropertyChanged("ProgressValue");
            }
        }
        public bool CanChange(object param)
        {
            return true;
        }
        private ICommand isBusyChangedCommand;
        public ICommand
          IsBusyChangedCommand
        {
            get
            {
                return isBusyChangedCommand;
            }
            set
            {
                isBusyChangedCommand = value;
            }

        }

        DispatcherTimer timer;
        public void BusyChanged(object param)
        {
            EventLogs.Add("IsBusy Changed :  " + IsBusy);
            StartTimer();
        }

        public void IsBusyChanged()
        {
            EventLogs.Add("IsBusy Changed :  " + IsBusy);
            StartTimer();
        }

        private void StartTimer()
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
            }
            if (IsBusy && !IsIndeterminate && timer != null)
            {
                timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                timer.Start();
                timer.Tick += new EventHandler(timer_Tick);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (IsIndeterminate)
                return;
            ProgressValue += 1;
            if (ProgressValue == 10)
            {
                IsBusy = false;
                timer.Stop();
                ProgressValue = 0;
            }
        }

        /// <summary>
        /// Dispose the timer objects.
        /// </summary>
        public void Dispose()
        {
            timer.Stop();
            BusyIndicatorItems.Clear();
            EventLogs.Clear();
        }

        private ObservableCollection<string> eventLogs;

        public ObservableCollection<string> EventLogs
        {
            get { return eventLogs; }
            set
            {
                eventLogs = value;
                this.RaisePropertyChanged(() => this.EventLogs);
            }
        }

    }
}
