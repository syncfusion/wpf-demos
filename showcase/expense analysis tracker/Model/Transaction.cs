using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Represents the single financial transaction, such as an income or an expense.
    /// </summary>
    public class Transaction : BaseViewModel, IDataErrorInfo
    {
        private string category;
        private string subCategory;
        private DateTime date;
        private double amount;
        private string description;

        /// <summary>
        /// Gets or sets the primary category of the transaction.
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
        /// Validates the Category property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.</returns>
        private string ValidateCategory()
        {
            if (string.IsNullOrEmpty(Category))
            {
                return "Category cannot be empty";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the sub-category of the transaction.
        /// </summary>
        public string SubCategory
        {
            get { return subCategory; }
            set { subCategory = value; RaisePropertyChanged(nameof(SubCategory)); }
        }


        /// <summary>
        /// Validates the SubCategory property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.</returns>
        private string ValidateSubCategory()
        {
            if (string.IsNullOrEmpty(SubCategory))
            {
                return "SubCategory cannot be empty";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the date on which the transaction occured.
        /// </summary>
        public DateTime Date
        {
            get { return date; }
            set { date = value; RaisePropertyChanged(nameof(Date)); }
        }

        /// <summary>
        /// Validates the Date property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.An error message if validation fails, otherwise, null.</returns>
        private string ValidateDate()
        {
            if(Date > DateTime.Now.Date)
            {
                return "Date cannot be greater than today";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets the monetary value of the transaction. Positive valuess can represent income, while negative values can represent expenses.
        /// </summary>
        public double Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(nameof(Amount)); }
        }

        /// <summary>
        /// Validates the Amount property.
        /// </summary>
        /// <returns>An error message if validation fails, otherwise, null.</returns>
        private string ValidateAmount()
        {
            if (Amount == 0)
            {
                return "Amount cannot be zero";
            }
            return null;
        }

        /// <summary>
        /// Gets or sets a descriptive note for the transaction.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(nameof(Description)); }
        }

        private double balance;

        /// <summary>
        /// Gets or sets the account balance after this transaction was processed
        /// </summary>
        public double Balance
        {
            get { return balance; }
            set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }

        /// <summary>
        /// Gets the collection of available spending categories.
        /// </summary>
        public IEnumerable<string> Categories
        {
            get { return GetCategories != null ? GetCategories() : null; }
        }

        /// <summary>
        /// Gets or sets the function that retrieves all aavailable categories.
        /// </summary>
        public Func<IEnumerable<string>> GetCategories { get; set; }

        /// <summary>
        /// Gets the collection of available sub-categories for the currently selected category.
        /// </summary>
        public IEnumerable<string> SubCategories
        {
            get { return GetSubCategories != null ? GetSubCategories(Category) : null; }
        }

        /// <summary>
        /// Gets or sets the function that retrieves sub-categories based on a parent category
        /// </summary>
        public Func<string, IEnumerable<string>> GetSubCategories;

        /// <summary>
        /// Gets an error message indicating what is wrong with this object. It aggregates validation errors from multiple properties.
        /// </summary>
        public string Error
        {
            get
            {
                return ValidateCategory() ?? ValidateSubCategory() ?? ValidateDate() ?? ValidateAmount();
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name. This is part of the <see cref="IDataErrorInfo"/> interface.
        /// </summary>
        /// <param name="columnName">The name of the proeprty to validate.</param>
        /// <returns>An error message if validation fails, otherwise, null if there is no error.</returns>
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

        /// <summary>
        /// Creates a deep copy of the current Transaction object.
        /// </summary>
        /// <returns>A new <see cref="Transaction"/> instance with the same values as the current one.</returns>
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

        /// <summary>
        /// Applies the properties of another <see cref="Transaction"/> object to this interface.
        /// </summary>
        /// <param name="transaction">The Transaction object whose values will be applied.</param>
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

    /// <summary>
    /// Represents a summary of expenses for a specific category. It hold the total amount spent in a category and the percentage it represents of overall expenses.
    /// </summary>
    public class CategoryExpense : BaseViewModel
    {
        private string category;

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Category
        {
            get { return category; }
            set { category = value; RaisePropertyChanged(nameof(Category));}
        }
        private double amount;

        /// <summary>
        /// Gets or sets the Total expense amouunt of the category.
        /// </summary>
        public double Amount
        {
            get { return amount; }
            set { amount = value; RaisePropertyChanged(nameof(Amount)); }
        }

        private double percentage;

        /// <summary>
        /// Gets or sets the percentage of total expenses that this category.
        /// </summary>
        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

    }
}
