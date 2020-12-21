#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using Syncfusion.Windows.Shared;
using System.Diagnostics;
using System.ComponentModel;
using Syncfusion.Data.Extensions;
using System.Reflection;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// This class represents the StocksViewModel 
    /// </summary>
    public class TradingGridViewModel : NotificationObject, IDisposable
    {
        #region Members

        ObservableCollection<StockDetails> data;
        Random r = new Random(123345345);
        Random p1 = new Random(123345345);
        internal DispatcherTimer timer;
        private bool enableTimer = false;
        private int noOfUpdates = 1000;
        List<string> StockSymbols = new List<string>();
      
        #endregion

        /// <summary>
        /// Gets the stocks.
        /// </summary>
        /// <value>The stocks.</value>
        public ObservableCollection<StockDetails> Stocks
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
                RaisePropertyChanged("Stocks");
            }
        }

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TradingGridViewModel"/> class.
        /// </summary>
        public TradingGridViewModel()
        {
            this.data = new ObservableCollection<StockDetails>();
            this.AddRows(200);
            this.timer = new DispatcherTimer();
            this.ResetRefreshFrequency(1000);
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += timer_Tick;
           
        }

        #endregion

        #region Timer and updating code

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void StartTimer()
        {
            if (!this.timer.IsEnabled)
            {
                this.timer.Start();
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void StopTimer()
        {
            this.timer.Stop();
        }

        /// <summary>
        /// Handles the Tick event of the timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void timer_Tick(object sender, object e)
        {
            int startTime = DateTime.Now.Millisecond;
            ChangeRows(noOfUpdates);
        }

        /// <summary>
        /// Adds the rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void AddRows(int count)
        {
            for (int i = 0; i < count; ++i)
            {
                var newRec = new StockDetails();
                newRec.Symbol = ChangeSymbol();
                newRec.Trade1 = Math.Round(r.NextDouble() * 30, 2);
                newRec.Trade2 = Math.Round(r.NextDouble() * 12, 2);
                newRec.Trade3 = Math.Round(r.NextDouble() * 34, 2);
                newRec.Trade4 = Math.Round(r.NextDouble() * 56, 2);
                newRec.Trade5 = Math.Round(r.NextDouble() * 76, 2);
                newRec.Trade6 = Math.Round(r.NextDouble() * 33, 2);
                newRec.Trade7 = Math.Round(r.NextDouble() * 76, 2);
                newRec.Trade8 = Math.Round(r.NextDouble() * 26, 2);
                newRec.Trade9 = Math.Round(r.NextDouble() * 25, 2);
                newRec.Trade10 = Math.Round(r.NextDouble() * 32, 2);
                newRec.Trade11 = Math.Round(r.NextDouble() * 46, 2);
                newRec.Trade12 = Math.Round(r.NextDouble() * 52, 2);
                newRec.Trade13 = Math.Round(r.NextDouble() * 76, 2);
                newRec.Trade14 = Math.Round(r.NextDouble() * 21, 2);
                newRec.Trade15 = Math.Round(r.NextDouble() * 32, 2);
                newRec.Trade16 = Math.Round(r.NextDouble() * 31, 2);
                newRec.Trade17 = Math.Round(r.NextDouble() * 23, 2);
                newRec.Trade18 = Math.Round(r.NextDouble() * 51, 2);
                newRec.Trade19 = Math.Round(r.NextDouble() * 20, 2);
                newRec.Trade20 = Math.Round(r.NextDouble() * 30, 2);
                newRec.Trade21 = Math.Round(r.NextDouble() * 26, 2);
                newRec.Trade22 = Math.Round(r.NextDouble() * 42, 2);
                newRec.Trade23 = Math.Round(r.NextDouble() * 43, 2);
                newRec.Trade24 = Math.Round(r.NextDouble() * 12, 2);
                newRec.Trade25 = Math.Round(r.NextDouble() * 16, 2);
                newRec.Trade26 = Math.Round(r.NextDouble() * 19, 2);
                newRec.Trade27 = Math.Round(r.NextDouble() * 49, 2);
                newRec.Trade28 = Math.Round(r.NextDouble() * 64, 2);
                newRec.Trade29 = Math.Round(r.NextDouble() * 13, 2);
                data.Add(newRec);
            }
        }

        /// <summary>
        /// Changes the symbol.
        /// </summary>
        /// <returns></returns>
        private String ChangeSymbol()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            do
            {
                builder = new StringBuilder();
                for (int i = 0; i < 4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

            } while (StockSymbols.Contains(builder.ToString()));

            StockSymbols.Add(builder.ToString());
            return builder.ToString();
        }


        /// <summary>
        /// Resets the refresh frequency.
        /// </summary>
        /// <param name="changesPerTick">The changes per tick.</param>
        public void ResetRefreshFrequency(int changesPerTick)
        {
            if (this.timer == null)
                return;

            if (!this.noOfUpdates.Equals(changesPerTick))
            {
                this.StopTimer();
                this.noOfUpdates = changesPerTick;
                if (enableTimer)
                    this.StartTimer();
            }
        }


        /// <summary>
        /// Change the values in different rows.
        /// </summary>
        /// <param name="count">The count.</param>
        private void ChangeRows(int count)
        {
            if (data.Count < count)
                count = data.Count;
            for (int i = 0; i < count; ++i)
            {
                int recNo = r.Next(data.Count);
                var properties = data[recNo].GetType().GetProperties();
                int propertycount = p1.Next(properties.Count());
                if (propertycount > 0 && propertycount < 30)
                {
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 33, 2), typeof(Double)), null);
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 43, 2), typeof(Double)),null);
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 3, 2), typeof(Double)), null);
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 12, 2), typeof(Double)), null);
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 64, 2), typeof(Double)), null);
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 66, 2), typeof(Double)), null);
                    properties[propertycount].SetValue((data[recNo] as StockDetails), Convert.ChangeType(Math.Round(r.NextDouble() * 44, 2), typeof(Double)), null);
                }
            }
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.timer != null)
            {
                this.timer.Tick -= timer_Tick;
                this.StopTimer();
            }
        }

        #endregion
    }
}
