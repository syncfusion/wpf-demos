#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace syncfusion.expenseanalysis.wpf
{
    public static class SampleDataGenerator
    {
        public const string HOUSING = "Housing";
        public const string TRANSPORT = "Transportation";
        public const string FOOD = "Food";
        public const string UTILITY = "Utilities";
        public const string HEALTH = "Health Care";
        public const string INSURANCE = "Insurance";
        public const string ENTERTAINMENT = "Entertainment";
        public const string PERSONAL_CARE = "Personal Care";
        public const string DEBT = "Debt";
        public const string INCOME = "Income";
        public const string GOAL = "Goal";
        public const string BUDGET = "Budget";

        public const string SALARY = "Salary";

        private static readonly string[] Categories =
        {
            HOUSING,
            TRANSPORT,
            FOOD,
            UTILITY,
            HEALTH,
            INSURANCE,
            ENTERTAINMENT,
            PERSONAL_CARE,
            DEBT,
            INCOME,
            GOAL,
        };

        private static readonly string[][] SubCategories =
        {
            new[] {"Rent", "Mortgage", "Property Taxes", "Maintenance"},
            new[] {"Car Payment", "Gas", "Public Transportation", "Parking Fees"},
            new[] {"Groceries", "Eating Out", "Alcohol", "Coffee"},
            new[] {"Electricity", "Water", "Gas", "Internet", "Phone"},
            new[] {"Doctor Visits", "Prescriptions", "Dental", "Eyecare"},
            new[] {"Health", "Life", "Car", "Homeowners"},
            new[] {"Movies", "Concerts", "Sport Events", "Vacation"},
            new[] {"Salon", "Spa", "Gym"},
            new[] {"Student Loans", "Personal Loans"},
            new[] {"Dividends", "Interest"},
        };

        private static readonly Dictionary<string, Tuple<int, int>> SubCategoryRanges = new Dictionary<string, Tuple<int, int>>
        {
            { "Rent", Tuple.Create(-2000, -1000) },
            { "Mortgage", Tuple.Create(-3000, -2000) },
            { "Property Taxes", Tuple.Create(-300, -200) },
            { "Maintenance", Tuple.Create(-300, -200) },
            { "Car Payment", Tuple.Create(-400, -300) },
            { "Gas", Tuple.Create(-200, -100) },
            { "Public Transportation", Tuple.Create(-100, -50) },
            { "Parking Fees", Tuple.Create(-100, -50) },
            { "Groceries", Tuple.Create(-400, -300) },
            { "Eating Out", Tuple.Create(-200, -100) },
            { "Alcohol", Tuple.Create(-100, -50) },
            { "Coffee", Tuple.Create(-50, -25) },
            { "Electricity", Tuple.Create(-200, -100) },
            { "Water", Tuple.Create(-100, -50) },
            { "Internet", Tuple.Create(-100, -50) },
            { "Phone", Tuple.Create(-100, -50) },
            { "Doctor Visits", Tuple.Create(-200, -100) },
            { "Prescriptions", Tuple.Create(-100, -50) },
            { "Dental", Tuple.Create(-200, -100) },
            { "Eyecare", Tuple.Create(-100, -50) },
            { "Life", Tuple.Create(-100, -50) },
            { "Health", Tuple.Create(-500, -200) },
            { "Car", Tuple.Create(-200, -100) },
            { "Homeowners", Tuple.Create(-300, -200) },
            { "Movies", Tuple.Create(-50, -25) },
            { "Concerts", Tuple.Create(-100, -50) },
            { "Sport Events", Tuple.Create(-100, -50) },
            { "Vacation", Tuple.Create(-1000, -500) },
            { "Salon", Tuple.Create(-50, -25) },
            { "Spa", Tuple.Create(-100, -50) },
            { "Gym", Tuple.Create(-50, -25) },
            { "Hobbies", Tuple.Create(-100, -50) },
            { "Gym Membership", Tuple.Create(-50, -25) },
            { "Personal Care", Tuple.Create(-50, -25) },
            { "Clothing", Tuple.Create(-200, -100) },
            { "Gifts", Tuple.Create(-100, -50) },
            { "Debt", Tuple.Create(-500, -100) },
            { "Credit Card", Tuple.Create(-200, -100) },
            { "Student Loans", Tuple.Create(-500, -200) },
            { "Personal Loans", Tuple.Create(-1000, -500) },
            { "Credit Card Payment", Tuple.Create(-200, -100) },
            { "Other Debt", Tuple.Create(-500, -100) },
            { "Salary", Tuple.Create(8000, 8000) },
            { "Dividends", Tuple.Create(1000, 5000) },
            { "Interest", Tuple.Create(500, 1000) },

        };

        private static readonly string[] Goals =
        {
            "Vacation",
            "Car",
            "House",
            "Retirement",
            "Wedding",
            "Other"
        };

        private static readonly string[] Budgets =
        {
            "Food",
            "Transport",
            "Housing",
            "Utilities",
            "Entertainment",
            "Personal Care",
            "Debt",
            "Other"
        };

        private static readonly Random Random = new Random();

        public static IEnumerable<Transaction> GenerateTransactions(DateTime start, DateTime end)
        {
            Calendar calendar = new GregorianCalendar();
            var current = start;

            yield return GetTransaction(start, INCOME, "Other Income", 1000);
            // Loop every month
            while (current < end)
            {
                var firstDay = new DateTime(current.Year, current.Month, 1);
                var lastDay = firstDay.AddDays(calendar.GetDaysInMonth(current.Year, current.Month) - 1);
                var firstMonday = firstDay.AddDays(7 - (int)calendar.GetDayOfWeek(firstDay));
                var currentWeek = firstMonday;
                
                // Salary is credited in first working day of the month.
                yield return GetTransaction(firstMonday, INCOME, SALARY);

                // Bills are paid in first 10 days of the month.
                foreach (var category in new string[] { HOUSING, UTILITY, INSURANCE, DEBT })
                {
                    foreach (var subCategory in SubCategories[Categories.IndexOf(category)])
                    {
                        yield return GetTransaction(
                            firstDay.AddDays(Random.Next(10)),
                            category,
                            subCategory);
                    }
                }

                // Some random expenses every week.
                while(currentWeek.Month == firstDay.Month)
                {
                    var lastDayOfWeek = currentWeek.AddDays(6);
                    //if(DateTime.Now > lastDayOfWeek)
                    //{
                    //    break;
                    //}
                    var randomExpenses = new string[] { TRANSPORT, FOOD, HEALTH, ENTERTAINMENT, PERSONAL_CARE, INCOME };
                    for (int i = 0; i < 3; i++)
                    {
                        var expense = randomExpenses[Random.Next(randomExpenses.Length)];

                        yield return GetTransaction(
                            currentWeek.AddDays(Random.Next(6)),
                            expense);
                    }

                    currentWeek = lastDayOfWeek.AddDays(1);
                }

                current = lastDay.AddDays(1);
                if(current.Month == lastDay.Month)
                {
                    throw new InvalidOperationException("Error");
                }
            }
        }

        private static Transaction GetTransaction(
            DateTime? date = null, 
            string category = null, 
            string subCategory = null, 
            double? amt = null)
        {
            category = category ?? GetRandomCategory();
            subCategory = subCategory ?? GetRandomSubCategory(category);
            return new Transaction
            {
                Category = category,
                SubCategory = subCategory,
                Amount = amt ?? GetRandomAmount(category, subCategory),
                Date = date ?? GetRandomDate()
            };
        }

        private static string GetRandomCategory()
        {
            return Categories[Random.Next(Categories.Length)];
        }

        private static string GetRandomSubCategory(string category)
        {
            return SubCategories[Array.IndexOf(Categories, category)][Random.Next(SubCategories[Array.IndexOf(Categories, category)].Length)];
        }

        private static double GetRandomAmount(string category, string subCategory)
        {
            return Random.Next(SubCategoryRanges[subCategory].Item1, SubCategoryRanges[subCategory].Item2);
        }

        private static DateTime GetRandomDate()
        {
            var start = new DateTime(2020, 1, 1);
            var range = (DateTime.Today - start).Days;
            return start.AddDays(Random.Next(range));
        }

        internal static IEnumerable<Budget> GetBudgets(IEnumerable<string> preference)
        {
            var pref = preference.ToList();
            var expenses = new List<string> { TRANSPORT, FOOD, HEALTH, ENTERTAINMENT, PERSONAL_CARE };
            foreach (var item in expenses)
            {
                if(!pref.Contains(item))
                {
                    pref.Add(item);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                var expense = pref[i];

                yield return GetRandomBudget(
                    expense,
                    i < 3 ? BudgetType.Monthly : BudgetType.Yearly,
                    expense,
                    null);
            }
        }

        internal static Budget GetRandomBudget(
            string name,
            BudgetType? type,
            string category,
            string subCategory)
        {
            category = category ?? GetRandomCategory();
            type = type ?? GetRandomBudgetType();
            var average = 1000;// Math.Abs((SubCategoryRanges[subCategory].Item2 - SubCategoryRanges[subCategory].Item2)/2);
            if (type == BudgetType.Yearly)
            {
                average = average * 12;
            }

            return new Budget
            {
                Name = name,
                Type = type ?? GetRandomBudgetType(),
                Category = category,
                SubCategory = subCategory,
                Limit = average
            };
        }

        private static BudgetType GetRandomBudgetType()
        {
            if(Random.Next() % 2 == 0)
            {
                return BudgetType.Monthly;
            }
            return BudgetType.Yearly;
        }

        public static IEnumerable<Goal> GetGoals()
        {
            DateTime now = DateTime.Now;
            var names = new List<string>    {   "New Car", "New Laptop",   "Vacation", "New TV" };
            var targets = new List<double>  {   18000,       1300,           2500,           1000 };
            var start = new List<int>       {   365 / 2,    365 / 4,        365/12,         365 };
            var duration = new List<int>    {   365 * 2,    365 / 2,        365,        365 / 3  };

            for (int i = 0; i < names.Count; i++)
            {
                Goal g = new Goal();
                g.Name = names[i];
                g.Target = targets[i];

                var s = now - TimeSpan.FromDays(start[i]);
                g.StartDate = new DateTime(s.Year, s.Month, 1);

                var e = g.StartDate + TimeSpan.FromDays(duration[i]);
                g.EndDate = new DateTime(
                    e.Month == 12 ? e.Year + 1 : e.Year,
                    e.Month == 12 ? 1 : e.Month + 1, 1) - TimeSpan.FromDays(1);

                yield return g;
            }
        }
    }
}