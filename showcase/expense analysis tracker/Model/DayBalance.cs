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
