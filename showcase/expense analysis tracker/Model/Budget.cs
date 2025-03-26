#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.expenseanalysis.wpf
{
    public class Budget : BaseViewModel, IDataErrorInfo
    {
        private string name;
        private string category;
        private string subCategory;
        private double limit;
        private BudgetType type;
        private double expense;
        private double estimate;
        private double balance;
        private string statusMessage;
        private Brush expenseColor;
        private Brush estimateColor;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        private string ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "Name cannot be empty";
            }
            return null;
        }

        public IEnumerable<string> Categories
        {
            get { return GetCategories(); }
        }

        public Func<IEnumerable<string>> GetCategories { get; set; }

        public IEnumerable<string> SubCategories
        {
            get { return GetSubCategories(Category); }
        }

        public Func<string, IEnumerable<string>> GetSubCategories;

        public string Category
        {
            get { return category; }
            set 
            { 
                category = value;
                RaisePropertyChanged(nameof(Category));
                RaisePropertyChanged(nameof(SubCategories));
            }
        }

        private string ValidateCategory()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "Category cannot be empty";
            }
            return null;
        }

        public string SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; RaisePropertyChanged(nameof(subCategory)); }
        }

        public BudgetType Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged(nameof(Type)); }
        }

        public double Limit
        {
            get { return limit; }
            set { limit = value; RaisePropertyChanged(nameof(Limit)); }
        }

        private string ValidateLimit()
        {
            if (Limit < 1)
            {
                return "Limit cannot be less than 1";
            }
            return null;
        }

        public double Expense
        {
            get { return expense; }
            private set { expense = value; RaisePropertyChanged(nameof(Expense)); }
        }

        public double Estimate
        {
            get { return estimate; }
            private set { estimate = value; RaisePropertyChanged(nameof(Estimate)); }
        }

        public double Balance
        {
            get { return balance; }
            private set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }

        public string StatusMessage
        {
            get { return statusMessage; }
            private set { statusMessage = value; RaisePropertyChanged(nameof(StatusMessage)); }
        }

        public Budget Clone()
        {
            return new Budget
            {
                Name = this.Name,
                Category = this.Category,
                SubCategory = this.SubCategory,
                Limit = this.Limit,
                Balance = this.Balance,
                Expense = this.Expense,
                Estimate = this.Estimate,
                StatusMessage = this.StatusMessage,
                Type = this.Type,
            };
        }

        public void Apply(Budget apply)
        {
            Name = apply.Name;
            Category = apply.Category;
            SubCategory = apply.SubCategory;
            Limit = apply.Limit;
            Balance = apply.Balance;
            Expense = apply.Expense;
            Estimate = apply.Estimate;
            StatusMessage = apply.StatusMessage;
            Type = apply.Type;
        }

        GregorianCalendar calendar = new GregorianCalendar();
        public void Update(ObservableCollection<Transaction> transactions, DateTime date)
        {
            Expense = 0;
            foreach (var trans in transactions.Where(
                t =>
                    (Category == null ? true : t.Category == Category &&
                    SubCategory == null ? true : t.SubCategory == SubCategory)
            ))
            {
                if (Type == BudgetType.Yearly && trans.Date.Year == date.Year)
                {
                    Expense += trans.Amount;
                }
                else if (Type == BudgetType.Monthly && trans.Date.Year == date.Year && trans.Date.Month == date.Month)
                {
                    Expense += trans.Amount;
                }
            }
            Expense = -Expense;
            Balance = Math.Max(0, (Limit - Expense));
            if (Type == BudgetType.Monthly)
            {
                var numberOfDays = date.Day;
                var maxNumberOfDays = calendar.GetDaysInMonth(date.Year, date.Month);
                var averageExpense = Expense / numberOfDays;
                Estimate = averageExpense * maxNumberOfDays;
            }
            else
            {
                var numberOfDays = calendar.GetDayOfYear(date);
                var maxNumberOfDays = calendar.GetDaysInYear(date.Year);
                var averageExpense = Expense / numberOfDays;
                Estimate = averageExpense * maxNumberOfDays;
            }

            if (Estimate < Limit)
            {
                StatusMessage = "Expense on control";
                ExpenseColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#189E4A"));
                EstimateColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DCFCE7"));
            }
            else if (Estimate > Limit)
            {
                if (Expense < Limit)
                {
                    StatusMessage = "Risk of overspending";
                    ExpenseColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF821C"));
                    EstimateColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEDD5"));
                }
                else
                {
                    StatusMessage = "Overspent";
                    ExpenseColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B4F"));
                    EstimateColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FEE2E2"));
                }
            }
        }

        public Brush ExpenseColor
        {
            get { return expenseColor; }
            private set { expenseColor = value; RaisePropertyChanged(nameof(ExpenseColor)); }
        }

        public Brush EstimateColor
        {
            get { return estimateColor; }
            private set { estimateColor = value; RaisePropertyChanged(nameof(EstimateColor)); }
        }

        public string Error
        {
            get
            {
                return ValidateName() ?? ValidateCategory() ?? ValidateLimit() ?? null;
            }
        }

        public string this[string columnName]
        {
            get
            {
                RaisePropertyChanged(nameof(Error));
                switch (columnName)
                {
                    case nameof(Name):
                        return ValidateName();
                    case nameof(Category):
                        return ValidateCategory();
                    case nameof(Limit):
                        return ValidateLimit();
                    default:
                        return null;
                }
            }
        }
    }

    public class AddBudget : Budget { }

}