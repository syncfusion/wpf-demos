#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace RadarChart
{
    public class CompanyExpenseDetails : ObservableCollection<ExpenseData>
    {
        public CompanyExpenseDetails()
        {
            this.Add(new ExpenseData() { ExpenseID = 101, ExpenseName = "Sales", ExpenseAlloted = 40d, AmountSpent = 55d });
            this.Add(new ExpenseData() { ExpenseID = 102, ExpenseName = "Marketing", ExpenseAlloted = 33d, AmountSpent = 45d });
            this.Add(new ExpenseData() { ExpenseID = 103, ExpenseName = "Administration", ExpenseAlloted = 40d, AmountSpent = 70d });
            this.Add(new ExpenseData() { ExpenseID = 104, ExpenseName = "Customer Support", ExpenseAlloted = 32d, AmountSpent = 47d });
            this.Add(new ExpenseData() { ExpenseID = 105, ExpenseName = "IT Service", ExpenseAlloted = 33d, AmountSpent = 50d });
            this.Add(new ExpenseData() { ExpenseID = 106, ExpenseName = "Transportation", ExpenseAlloted = 25d, AmountSpent = 55d });
        }

    }

    public class CircularChartModel
    {
        public CircularChartModel()
        {
            this.ExpenseDetails = new CompanyExpenseDetails();
        }
        public CompanyExpenseDetails ExpenseDetails
        {
            get;
            set;
        }
    }
}
