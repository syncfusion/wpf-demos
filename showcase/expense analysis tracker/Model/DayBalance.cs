#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Represents the financial balance for a single day. This class is used to track the negt changes in the funds for a specific date.
    /// </summary>
    public class DayBalance : BaseViewModel
    {
        private DateTime date;
        private double balance;

        /// <summary>
        /// Gets or sets the date for which the balance is recorded.
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; RaisePropertyChanged(nameof(Date)); }
        }

        /// <summary>
        /// Gets or sets the net balance for the day. This could be the sum of all transactions on that day.
        /// </summary>
        public double Balance
        {
            get { return balance; }
            set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }
    }
}
