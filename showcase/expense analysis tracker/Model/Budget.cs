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
    /// <summary>
    /// Represents a budget item in the in the expense analysis application
    /// </summary>
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

        /// <summary>
        /// Gets or sets the name of the budget.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(nameof(Name)); }
        }

        /// <summary>
        /// Validates the Name property.
        /// </summary>
        /// <returns>An Error message if validation fails; otherwise, null.</returns>
        private string ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "Name cannot be empty";
            }
            return null;
        }

        /// <summary>
        /// Gets the collection of available spending categories.
        /// </summary>
        public IEnumerable<string> Categories
        {
            get { return GetCategories(); }
        }

        /// <summary>
        /// Gets or sets the function of retrieves all available categories.
        /// </summary>
        public Func<IEnumerable<string>> GetCategories { get; set; }

        /// <summary>
        /// Gets the collection of available sub-categories for the currently selected category.
        /// </summary>
        public IEnumerable<string> SubCategories
        {
            get { return GetSubCategories(Category); }
        }

        /// <summary>
        /// Gets or sets the function that retrieves sub-categories based on a parent category.
        /// </summary>
        public Func<string, IEnumerable<string>> GetSubCategories;

        /// <summary>
        /// Gets or sets the category to which this budget applies.
        /// </summary>
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

        /// <summary>
        /// validated the Category property.
        /// </summary>
        /// <returns>An error message if validation fails; otherwise, null.</returns>
        private string ValidateCategory()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return "Category cannot be empty";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the sub-category to which this budget applies.
        /// </summary>
        public string SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; RaisePropertyChanged(nameof(subCategory)); }
        }

        /// <summary>
        /// Gets or sets the type of the budget.
        /// </summary>
        public BudgetType Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged(nameof(Type)); }
        }

        /// <summary>
        /// Gets or sets the spending limit for this budget.
        /// </summary>
        public double Limit
        {
            get { return limit; }
            set { limit = value; RaisePropertyChanged(nameof(Limit)); }
        }

        /// <summary>
        /// Validates the Limit property.
        /// </summary>
        /// <returns>An error message if validation fails; otherwise, null.</returns>
        private string ValidateLimit()
        {
            if (Limit < 1)
            {
                return "Limit cannot be less than 1";
            }
            return null;
        }

        /// <summary>
        /// Gets the total expense recorded for this budget period.
        /// </summary>
        public double Expense
        {
            get { return expense; }
            private set { expense = value; RaisePropertyChanged(nameof(Expense)); }
        }

        /// <summary>
        /// Gets the estimated total expense for the full period, based on the current spending.
        /// </summary>
        public double Estimate
        {
            get { return estimate; }
            private set { estimate = value; RaisePropertyChanged(nameof(Estimate)); }
        }

        /// <summary>
        /// Gets the remaining balance of the budget.
        /// </summary>
        public double Balance
        {
            get { return balance; }
            private set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }

        /// <summary>
        /// Gets the status message indicating the health of the budget.
        /// </summary>
        public string StatusMessage
        {
            get { return statusMessage; }
            private set { statusMessage = value; RaisePropertyChanged(nameof(StatusMessage)); }
        }

        /// <summary>
        /// Create a deep copy of the budget object.
        /// </summary>
        /// <returns>A new <see cref="Budget"/> instance with the same value as the current one.</returns>
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

        /// <summary>
        /// Applies the properties of another <see cref="Budget"/> object to this reference.
        /// </summary>
        /// <param name="apply">The budget object whose values will be applied.</param>
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

        /// <summary>
        /// Updates the budget's expense, balance, and estimate based on collection of transactions and a given date.
        /// </summary>
        /// <param name="transactions">The collection of all transactions to evaluate.</param>
        /// <param name="date">The current date, used to determine the relevant time period.</param>
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

        /// <summary>
        /// Gets the color representing the expense status, which changes based on how close the expense is to the limit.
        /// </summary>
        public Brush ExpenseColor
        {
            get { return expenseColor; }
            private set { expenseColor = value; RaisePropertyChanged(nameof(ExpenseColor)); }
        }

        /// <summary>
        /// Gets the color the estimate visualization, which corresponds to the expense status.
        /// </summary>
        public Brush EstimateColor
        {
            get { return estimateColor; }
            private set { estimateColor = value; RaisePropertyChanged(nameof(EstimateColor)); }
        }

        /// <summary>
        /// Gets an error message indicating what is wrong with this object. It aggregates validation errors from the multiple properties.
        /// </summary>
        public string Error
        {
            get
            {
                return ValidateName() ?? ValidateCategory() ?? ValidateLimit() ?? null;
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name. This is part of the <see cref="IDataErrorInfo"/> interface.
        /// </summary>
        /// <param name="columnName">The name of the property to validate.</param>
        /// <returns>The error message for the property, or null if there is no error.</returns>
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

    /// <summary>
    /// Represents a temporary or new budget being created. This class can be used in "ADD" or "EDIT" dialogs.
    /// </summary>
    public class AddBudget : Budget { }

}