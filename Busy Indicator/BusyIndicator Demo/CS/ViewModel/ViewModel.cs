#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Threading;

namespace BusyIndicatorDemo
{
    class ViewModel : NotificationObject
    {
        public ViewModel()
        {
            Random rndm = new Random();
            items = new ObservableCollection<Model>()
            {
             
             new Model { ProductId = 1, ProductName = "Rice", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 2, ProductName = "Wheat", Price2000 = rndm.Next(5, 80), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 1, ProductName = "Oil", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 4, ProductName = "Corn", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 5, ProductName = "Gram", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 6, ProductName = "Milk", Price2000 = rndm.Next(5, 90), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 7, ProductName = "Butter", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 8, ProductName = "Ghee", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 9, ProductName = "Oats", Price2000 = rndm.Next(5, 80), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 10, ProductName = "Cheese", Price2000 = rndm.Next(5, 60), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 11, ProductName = "Ragi", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 12, ProductName = "Chocalate", Price2000 = rndm.Next(5, 40), Price2010 = rndm.Next(10, 60) },
             new Model { ProductId = 13, ProductName = "Olive", Price2000 = rndm.Next(5, 90), Price2010 = rndm.Next(10, 60) },

            };
            eventLogs = new ObservableCollection<string>();
            IsBusyChangedCommand = new DelegateCommand<object>(BusyChanged,CanChange);
            StartTimer();
        }

        
        private ObservableCollection<Model> items;

        public ObservableCollection<Model> Items
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
        void timer_Tick(object sender, EventArgs e)
        {
            if (IsIndeterminate)
                return;
            ProgressValue += 1;
            if (ProgressValue == 100)
            {
                IsBusy = false;
                timer.Stop();
                ProgressValue = 0;
            }
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
