using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseAnalysisDemo
{
    class ExpenseData
    {
        public DateTime DateTime { get; set; }
        public string CategoryName { get; set; }
        public string SubCategory { get; set; }
        public double Amount { get; set; }
        public AccountType AccountType { get; set; }
        public string Description { get; set; }



        public List<ExpenseData> GenerateExpenseData(DateTime start, DateTime end, int recordCount)
        {
            var expenses = new List<ExpenseData>();
            var categories = new Category().GetCategories();
            var totCategory = categories.Count;
            var catCount = 0;
            int IncomeMonth = 0;
            while (start < end)
            {
                var count = 0;
                while (count < recordCount)
                {
                    if (catCount > totCategory - 1)
                        catCount = 0;
                    var category = categories[catCount];
                    var expense = new ExpenseData
                    {
                        DateTime = start,
                        AccountType = category.AccountType,
                        Amount = (new Random(catCount + start.Month).Next(category.Start, category.End)),
                        CategoryName = category.Name,
                        SubCategory = category.SubCategory,
                        Description = category.Description
                    };
                    if (expense.AccountType == AccountType.Positve && CheckIncome(expenses, expense.CategoryName))
                    {
                        IncomeMonth = expense.DateTime.Month;
                    }
                    if (expense.AccountType == AccountType.Positve &&
                        CheckDataExists(expenses, expense.CategoryName, expense.SubCategory, expense.AccountType,IncomeMonth))
                    {
                        catCount++;
                        continue;
                    }

                    if (expense.AccountType == AccountType.Negative &&
                        expense.SubCategory == "Mortgage/rent" && CheckNegativeDataExists(expenses, "Home", "Mortgage/rent", expense.AccountType))
                    {

                        catCount++;
                        continue;
                    }

                    expenses.Add(expense);
                    count++;
                    catCount++;



                }
                start = start.AddDays(1);

            }

            return expenses;
        }

        public bool CheckDataExists(List<ExpenseData> expenses, string category, string subCategory, AccountType type,int incomeMonth)
        {

            return expenses.Any(expense => expense.CategoryName == category && expense.SubCategory == subCategory && incomeMonth==expense.DateTime.Month);
        }
        public bool CheckNegativeDataExists(List<ExpenseData> expenses, string category, string subCategory, AccountType type)
        {

            return expenses.Any(expense => expense.CategoryName == category && expense.SubCategory == subCategory);
        }
        public bool CheckIncome(List<ExpenseData> expenses, string category)
        {
            return expenses.Any(expense => expense.CategoryName == category);
        }
    }


    enum AccountType
    {
        Positve,
        Negative
    }
    class Category
    {
        public string Name { get; set; }
        public string SubCategory { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public AccountType AccountType { get; set; }
        public string Description { get; set; }
        public List<Category> GetCategories()
        {
            var categories = new List<Category>
                {
                    new Category
                        {
                            Name = "Home",
                            SubCategory = "Mortgage/rent",
                            Start = 350,
                            End = 700,
                            AccountType = AccountType.Negative,
                            Description = "Bank of America"
                        },
                         new Category
                        {
                            Name = "Home",
                            SubCategory = "Home repairs",
                            Start = 50,
                            End = 300,
                            AccountType = AccountType.Negative,
                            Description = "Lowes"
                        },
                         new Category
                        {
                            Name = "Home",
                            SubCategory = "Mobile telephone",
                            Start = 400,
                            End = 600,
                            AccountType = AccountType.Negative,
                            Description = "Verizon Wireless"
                        },
                         new Category
                        {
                            Name = "Home",
                            SubCategory = "Utilities",
                            Start = 100,
                            End = 200,
                            AccountType = AccountType.Negative,
                              Description = "Duke energy"
                        },
                         new Category
                        {
                            Name = "Home",
                            SubCategory = "Home improvement",
                            Start = 1000,
                            End = 2000,
                            AccountType = AccountType.Negative,
                          Description = "Home depot"
                        },
                         new Category
                        {
                            Name = "Home",
                            SubCategory = "Home security",
                            Start = 220,
                            End = 300,
                            AccountType = AccountType.Negative,
                            Description = "ADT"
                        },
                         new Category
                        {
                            Name = "Daily Living",
                            SubCategory = "Dry cleaning",
                            Start = 200,
                            End = 300,
                            AccountType = AccountType.Negative,
                            Description = "ABC Cleaners"
                        },
                         new Category
                        {
                            Name = "Daily Living",
                            SubCategory = "Dining out",
                            Start = 50,
                            End = 100,
                            AccountType = AccountType.Negative,
                            Description = "Olive Garden"
                        },
                         new Category
                        {
                            Name = "Daily Living",
                            SubCategory = "Groceries",
                            Start = 120,
                            End = 200,
                            AccountType = AccountType.Negative,
                            Description = "Kroger"
                        },
                         new Category
                        {
                            Name = "Dues/subscriptions",
                            SubCategory = "Internet connection",
                            Start = 300,
                            End = 500,
                            AccountType = AccountType.Negative,
                            Description = "Time warner cable"
                        },
                         new Category
                        {
                            Name = "Dues/subscriptions",
                            SubCategory = "Newspapers",
                            Start = 12,
                            End = 20,
                            AccountType = AccountType.Negative,
                            Description = "Wall Street Journal"
                        },
                         new Category
                        {
                            Name = "Entertainment",
                            SubCategory = "Movies/plays",
                            Start = 5,
                            End = 10,
                            AccountType = AccountType.Negative,
                            Description = "Weekend Movies"
                        },
                         new Category
                        {
                            Name = "Entertainment",
                            SubCategory = "Concerts/clubs",
                            Start = 1000,
                            End = 2000,
                            AccountType = AccountType.Negative,
                            Description = "Comedy drama show"
                        },
                         new Category
                        {
                            Name = "Financial obligations",
                            SubCategory = "Retirement (401k, Roth IRA)",
                            Start = 200,
                            End = 400,
                            AccountType = AccountType.Negative,
                            Description = "Retirement"
                        },
                         new Category
                        {
                              Name = "Financial obligations",
                            SubCategory = "Income tax (additional)",
                            Start = 200,
                            End = 300,
                            AccountType = AccountType.Negative,
                            Description = "Income tax"
                        },
                         new Category
                        {
                            Name = "Health",
                            SubCategory = "Insurance (H)",
                            Start = 300,
                            End = 500,
                            AccountType = AccountType.Negative,
                            Description = "United Healthcare"
                        },
                         new Category
                        {
                            Name = "Health",
                            SubCategory = "Prescriptions",
                            Start = 300,
                            End = 500,
                            AccountType = AccountType.Negative,
                            Description = "Rite Aid"
                        },
                         new Category
                        {
                            Name = "Personal",
                            SubCategory = "Clothing",
                            Start = 300,
                            End = 500,
                            AccountType = AccountType.Negative,
                            Description = "Kohls"
                        },
                         new Category
                        {
                            Name = "Personal",
                            SubCategory = "Gifts",
                            Start = 100,
                            End = 500,
                            AccountType = AccountType.Negative,
                            Description = "Amazon.com"
                        },
                         new Category
                        {
                            Name = "Personal",
                            SubCategory = "Books",
                            Start = 100,
                            End = 500,
                            AccountType = AccountType.Negative,
                            Description = "Purchased novels and technology books"
                        },
                         new Category
                        {
                            Name = "Transportation",
                            SubCategory = "Gas/fuel",
                            Start = 200,
                            End = 400,
                            AccountType = AccountType.Negative
                        },
                         new Category
                        {
                            Name = "Transportation",
                            SubCategory = "Repairs",
                            Start = 50,
                            End = 100,
                            AccountType = AccountType.Negative,
                            Description = "AAA"
                        },
                         new Category
                        {
                            Name = "Transportation",
                            SubCategory = "Parking",
                            Start = 10,
                            End = 50,
                            AccountType = AccountType.Negative,
                            Description = "1 hr parking charge"
                        },
                         new Category
                        {
                            Name = "Income",
                            SubCategory = "Salary",
                            Start = 15000,
                            End = 20000,
                            AccountType = AccountType.Positve,
                            Description = "Salary credited"
                        },
                         new Category
                        {
                            Name = "Income",
                            SubCategory = "Interest/dividends",
                            Start = 500,
                            End = 700,
                            AccountType = AccountType.Positve
                        },
                         new Category
                        {
                            Name = "Income",
                            SubCategory = "Miscellaneous",
                            Start = 4000,
                            End = 6000,
                            AccountType = AccountType.Positve
                        }
                };

            return categories;
        }
    }
}
