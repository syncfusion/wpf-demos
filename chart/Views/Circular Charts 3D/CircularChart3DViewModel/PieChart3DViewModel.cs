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
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class PieChart3DViewModel
    {
        public PieChart3DViewModel()
        {
            this.Expenditure = new List<PieChart3DModel>();

            Expenditure.Add(new PieChart3DModel() { Expense = "Email", Amount = 20d });
            Expenditure.Add(new PieChart3DModel() { Expense = "Skype", Amount = 23d });
            Expenditure.Add(new PieChart3DModel() { Expense = "Phone", Amount = 12d });
            Expenditure.Add(new PieChart3DModel() { Expense = "Sms", Amount = 19d });
            Expenditure.Add(new PieChart3DModel() { Expense = "Facebook", Amount = 10d });
            Expenditure.Add(new PieChart3DModel() { Expense = "Twitter", Amount = 10d });
            Expenditure.Add(new PieChart3DModel() { Expense = "LinkedIn", Amount = 9d });
        }

        public IList<PieChart3DModel> Expenditure
        {
            get;
            set;
        }
    }
}
