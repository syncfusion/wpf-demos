#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.expenseanalysis.wpf
{
    public class Transaction : BaseViewModel, IDataErrorInfo
    {
        private string category;
        private string subCategory;
        private DateTime date;
        private double amount;
        private string description;

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
            if (string.IsNullOrEmpty(Category))
            {
                return "Category cannot be empty";
            }
            return null;
        }

        public string SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; RaisePropertyChanged(nameof(SubCategory)); }
        }

        private string ValidateSubCategory()
        {
            if (string.IsNullOrEmpty(SubCategory))
            {
                return "SubCategory cannot be empty";
            }
            return null;
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; RaisePropertyChanged(nameof(Date)); }
        }

        private string ValidateDate()
        {
            if (Date == null)
            {
                return "Date cannot be empty";
            }
            else if(Date > DateTime.Now.Date)
            {
                return "Date cannot be greater than today";
            }
            return null;
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(nameof(Amount)); }
        }

        private string ValidateAmount()
        {
            if (Amount == 0)
            {
                return "Amount cannot be zero";
            }
            return null;
        }

        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(nameof(Description)); }
        }

        private double balance;

        public double Balance
        {
            get { return balance; }
            set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }

        public IEnumerable<string> Categories
        {
            get { return GetCategories != null ? GetCategories() : null; }
        }

        public Func<IEnumerable<string>> GetCategories { get; set; }

        public IEnumerable<string> SubCategories
        {
            get { return GetSubCategories != null ? GetSubCategories(Category) : null; }
        }

        public Func<string, IEnumerable<string>> GetSubCategories;

        public string Error
        {
            get
            {
                return ValidateCategory() ?? ValidateSubCategory() ?? ValidateDate() ?? ValidateAmount();
            }
        }

        public string this[string columnName]
        {
            get
            {
                RaisePropertyChanged(nameof(Error));
                switch (columnName)
                {
                    case nameof(Category):
                        return ValidateCategory();
                    case nameof(SubCategory):
                        return ValidateSubCategory();
                    case nameof(Date):
                        return ValidateDate();
                    case nameof(Amount):
                        return ValidateAmount();
                }
                return null;
            }
        }

        internal Transaction Clone()
        {
            return new Transaction()
            {
                Category = this.Category,
                SubCategory = this.SubCategory,
                Date = this.Date,
                Amount = this.Amount,
                Description = this.Description,
                Balance = this.Balance
            };
        }

        internal void Apply(Transaction transaction)
        {
            this.Category = transaction.Category;
            this.SubCategory = transaction.SubCategory;
            this.Date = transaction.Date;
            this.Amount = transaction.Amount;
            this.Description = transaction.Description;
            this.Balance = transaction.Balance;
        }
    }

    public class CategoryExpense : BaseViewModel
    {
        private string category;

        public string Category
        {
            get { return category; }
            set { category = value; RaisePropertyChanged(nameof(Category));}
        }
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(nameof(Amount)); }
        }

        private double percentage;

        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

    }
}
