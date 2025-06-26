#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

namespace syncfusion.expenseanalysis.wpf
{
    public class DayBalance : BaseViewModel
    {
        private DateTime date;
        private double balance;

        public DateTime Date
        {
            get { return date; }
            set { date = value; RaisePropertyChanged(nameof(Date)); }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }
    }
}
