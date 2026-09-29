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
