#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotUpdating.ViewModel
{
    using Model;
    using Syncfusion.Windows.Shared;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using System;

    public class ViewModel : NotificationObject
    {
        DispatcherTimer timer;
        int updateRate = 200; //msecs
        int updateCount = 20; //updates per tick event
        private Random rand = new Random(123123);
        private DelegateCommand<object> timerActivationCommand;
        private DelegateCommand<object> updateSourceCommand;

        #region Properties
        private ProductSales.ProductSalesCollection productSalesData;

        /// <summary>
        /// Gets or sets the product sales data.
        /// </summary>
        /// <value>The product sales data.</value>
        public ProductSales.ProductSalesCollection ProductSalesData
        {
            get
            {
                this.productSalesData = this.productSalesData ?? ProductSales.GetSalesData();
                return this.productSalesData;
            }
            set
            {
                this.productSalesData = value;
                RaisePropertyChanged("ProductSalesData");
            }
        }

        public DelegateCommand<object> TimerActivationCommand
        {
            get
            {
                this.timerActivationCommand = this.timerActivationCommand ?? new DelegateCommand<object>(DoTimerActivate);
                return this.timerActivationCommand;
            }
            set { this.timerActivationCommand = value; }
        }

        public List<int> ThrottleUpdateRates
        {
            get
            {
                return new List<int> { 0, 300, 500, 1000, 2000 };
            }
        }


        public DelegateCommand<object> UpdateSourceCommand
        {
            get
            {
                this.updateSourceCommand = this.updateSourceCommand ?? new DelegateCommand<object>(UpdateItemsSource);
                return this.updateSourceCommand;
            }
            set { this.updateSourceCommand = value; }
        }

        #endregion

        #region Helper Methods

        private void DoTimerActivate(object parm)
        {
            if (parm is bool)
            {
                if (timer == null)
                {
                    timer = new DispatcherTimer();
                    timer.Tick += timer_Tick;
                    timer.Interval = TimeSpan.FromMilliseconds(updateRate);
                }

                if ((bool)parm)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        private void UpdateItemsSource(object parm)
        {
            ProductSales dr = null;
            switch (parm.ToString())
            {
                case "Add at Top":
                    dr = new ProductSales()
                    {
                        Country = "Canada",
                        State = "Brunswick",
                        Product = "Bike",
                        Date = "FY 2003",
                        Quantity = 1,
                        Amount = 100d
                    };
                    break;
                case "Add at Middle":
                    dr = new ProductSales()
                    {
                        Country = "Canada",
                        State = "Brunswick",
                        Product = "Bike",
                        Date = "FY 2007",
                        Quantity = 1,
                        Amount = 200d
                    };
                    break;
                case "Add at Bottom":
                    dr = new ProductSales()
                    {
                        Country = "Canada",
                        State = "Brunswick",
                        Product = "Bike",
                        Date = "FY 2010",
                        Quantity = 1,
                        Amount = 300d
                    };
                    break;
            }
            productSalesData.Add(dr);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < updateCount; ++i)
            {
                ChangeOneValue(1);
            }
        }
        private void ChangeOneValue(int loc)
        {
            productSalesData[loc].Amount = rand.Next(1000);
        }
        #endregion
    }
}