using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Globalization;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace ExpenseAnalysisDemo
{
    internal class ViewModel : NotificationObject
    {
        private double _homeAmount;
        private double _securityAmount;
        private double _entertainmentAmount;
        private double _healthAmount;
        private double _transportAmount;
        private double _personalAmount;
        private double _mortgage;
        private double _homerepair;
        private double _utilities;
        private double _homeImprovement;
        private double _mobileTelephone;
        private double _drycleaing;
        private double _dininout;
        private double _groceries;
        private double _movies;
        private double _clubs;
        private double _insurance;
        private double _prescriptions;
        private double _gas;
        private double _repairs;
        private double _parking;
        private double _clothing;
        private double _gifts;
        private double _books;

        public ViewModel()
        {
            TotalExpenses = (new ExpenseData()).GenerateExpenseData(new DateTime(2013, 1, 1), new DateTime(2013, 12, 31),
                                                                    2);
            this.Update();
        }

        private void Update()
        {            
            var month = ComboBoxSelectedItem == null ? "All" : (ComboBoxSelectedItem as ComboBoxItemAdv).Content.ToString();
            if (month.Equals("All"))
            {
                Expenses = TotalExpenses;

                var max = TotalExpenses.Where(x => x.AccountType == AccountType.Negative).Max(x => x.Amount);
                var maxExpense = TotalExpenses.First(x => x.Amount.Equals(max));
                MostSpent = max.ToString("c") + " in " +
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(maxExpense.DateTime.Month) + " " +
                            maxExpense.DateTime.Year;

                var min = TotalExpenses.Where(x => x.AccountType == AccountType.Negative).Min(x => x.Amount);
                var minExpense = TotalExpenses.First(x => x.Amount.Equals(min));
                LeastSpent = min.ToString("c") + " in " +
                             CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(minExpense.DateTime.Month) + " " +
                             minExpense.DateTime.Year;

                var avg = TotalExpenses.Where(x => x.AccountType == AccountType.Negative).Average(x => x.Amount);
                AverageSpent = avg.ToString("c") + "/month";

            }
            else
            {
                Expenses = TotalExpenses.Where(ed =>
                    {
                        var m = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(ed.DateTime.Month);
                        if (m.ToLower().Equals(month.ToString().ToLower()))
                            return true;
                        return false;
                    }).ToList();

                var max = Expenses.Where(x => x.AccountType == AccountType.Negative).Max(x => x.Amount);
                var maxExpense = Expenses.First(x => x.Amount.Equals(max));
                MostSpent = max.ToString("c") + " on " +
                            CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(maxExpense.DateTime.Month) + " " +
                            maxExpense.DateTime.Day;

                var min = Expenses.Where(x => x.AccountType == AccountType.Negative).Min(x => x.Amount);
                var minExpense = Expenses.First(x => x.Amount.Equals(min));
                LeastSpent = min.ToString("c") + " on " +
                             CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(minExpense.DateTime.Month) + " " +
                             minExpense.DateTime.Day;

                var avg = Expenses.Where(x => x.AccountType == AccountType.Negative).Average(x => x.Amount);
                AverageSpent = avg.ToString("c") + "/month";
            }

            PositiveAmount = Expenses.Where(x => x.AccountType == AccountType.Positve).Sum(x => x.Amount);
            NegativeAmount = Expenses.Where(x => x.AccountType == AccountType.Negative).Sum(x => x.Amount);
            BalanceAmount = PositiveAmount - NegativeAmount;

            NoPositiveTransactions = Expenses.Count(x => x.AccountType == AccountType.Positve);
            NoNegativeTransactions = Expenses.Count(x => x.AccountType == AccountType.Negative);
            NoTotalTransactions = NoPositiveTransactions + NoNegativeTransactions;

            #region PieData

            _homeAmount = Expenses.Where(x => x.CategoryName == "Home").Sum(x => x.Amount);
            _securityAmount = Expenses.Where(x => x.CategoryName == "Daily Living").Sum(x => x.Amount);
            _entertainmentAmount = Expenses.Where(x => x.CategoryName == "Entertainment").Sum(x => x.Amount);
            _healthAmount = Expenses.Where(x => x.CategoryName == "Health").Sum(x => x.Amount);
            _transportAmount = Expenses.Where(x => x.CategoryName == "Transportation").Sum(x => x.Amount);
            _personalAmount = Expenses.Where(x => x.CategoryName == "Personal").Sum(x => x.Amount);
            _mortgage = Expenses.Where(x => x.SubCategory == "Mortgage/rent").Sum(x => x.Amount);
            _homerepair = Expenses.Where(x => x.SubCategory == "Home repairs").Sum(x => x.Amount);
            _utilities = Expenses.Where(x => x.SubCategory == "Utilities").Sum(x => x.Amount);
            _homeImprovement = Expenses.Where(x => x.SubCategory == "Home improvement").Sum(x => x.Amount);
            _mobileTelephone = Expenses.Where(x => x.SubCategory == "Mobile telephone").Sum(x => x.Amount);
            _drycleaing = Expenses.Where(x => x.SubCategory == "Dry cleaning").Sum(x => x.Amount);
            _dininout = Expenses.Where(x => x.SubCategory == "Dining out").Sum(x => x.Amount);
            _groceries = Expenses.Where(x => x.SubCategory == "Groceries").Sum(x => x.Amount);
            _movies = Expenses.Where(x => x.SubCategory == "Movies/plays").Sum(x => x.Amount);
            _clubs = Expenses.Where(x => x.SubCategory == "Concerts/clubs").Sum(x => x.Amount);
            _insurance = Expenses.Where(x => x.SubCategory == "Insurance (H)").Sum(x => x.Amount);
            _prescriptions = Expenses.Where(x => x.SubCategory == "Prescriptions").Sum(x => x.Amount);
            _gas = Expenses.Where(x => x.SubCategory == "Gas/fuel").Sum(x => x.Amount);
            _repairs = Expenses.Where(x => x.SubCategory == "Repairs").Sum(x => x.Amount);
            _parking = Expenses.Where(x => x.SubCategory == "Parking").Sum(x => x.Amount);
            _clothing = Expenses.Where(x => x.SubCategory == "Clothing").Sum(x => x.Amount);
            _gifts = Expenses.Where(x => x.SubCategory == "Gifts").Sum(x => x.Amount);
            _books = Expenses.Where(x => x.SubCategory == "Books").Sum(x => x.Amount);

            PieExpense = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Home", Amount = _homeAmount},
                    new CompanyExpense {Category = "Daily Living", Amount = _securityAmount},
                    new CompanyExpense {Category = "Entertainment", Amount = _entertainmentAmount},
                    new CompanyExpense {Category = "Health", Amount = _healthAmount},
                    new CompanyExpense {Category = "Transportation", Amount = _transportAmount},
                    new CompanyExpense {Category = "Personal", Amount = _transportAmount}
                };

            Home = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Mortgage/rent", Amount = _mortgage},
                    new CompanyExpense {Category = "Home repairs", Amount = _homerepair},
                    new CompanyExpense {Category = "Utilities", Amount = _utilities},
                    new CompanyExpense {Category = "Home improvement", Amount = _homeImprovement},
                    new CompanyExpense {Category = "Mobile telephone", Amount = _mobileTelephone}
                };

            DailyLiving = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Dry cleaning", Amount = _drycleaing},
                    new CompanyExpense {Category = "Dining out", Amount = _dininout},
                    new CompanyExpense {Category = "Groceries", Amount = _groceries}
                };

            Entertainment = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Movies/plays", Amount = _movies},
                    new CompanyExpense {Category = "Concerts/clubs", Amount = _clubs}
                };

            Health = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Insurance (H)", Amount = _insurance},
                    new CompanyExpense {Category = "Prescriptions", Amount = _prescriptions}
                };

            Transportation = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Gas/fuel", Amount = _gas},
                    new CompanyExpense {Category = "Repairs", Amount = _repairs},
                    new CompanyExpense {Category = "Parking", Amount = _parking}
                };

            Personal = new List<CompanyExpense>
                {
                    new CompanyExpense {Category = "Clothing", Amount = _clothing},
                    new CompanyExpense {Category = "Gifts", Amount = _gifts},
                    new CompanyExpense {Category = "Books", Amount = _books}
                };

            PieConverter = new List<CompanyExpense>();
            PieConverter = PieExpense;

            #endregion
        }

        public string MostSpent
        {
            get { return _mostSpent; }
            set { _mostSpent = value;
            RaisePropertyChanged("MostSpent");
            }
        }

        public string LeastSpent
        {
            get { return _leastSpent; }
            set { _leastSpent = value;
            RaisePropertyChanged("LeastSpent");
            }
        }

        public string AverageSpent
        {
            get { return _averageSpent; }
            set { _averageSpent = value;
            RaisePropertyChanged("AverageSpent");
            }
        }        

        private List<CompanyExpense> _personal;

        public List<CompanyExpense> Personal
        {
            get { return _personal; }
            set
            {
                _personal = value;
                RaisePropertyChanged("Personal");
            }
        }

        private List<CompanyExpense> _transportation;

        public List<CompanyExpense> Transportation
        {
            get { return _transportation; }
            set
            {
                _transportation = value;
                RaisePropertyChanged("Transportation");
            }
        }

        private List<CompanyExpense> _health;

        public List<CompanyExpense> Health
        {
            get { return _health; }
            set
            {
                _health = value;
                RaisePropertyChanged("Health");
            }
        }

        private List<CompanyExpense> _entertainment;

        public List<CompanyExpense> Entertainment
        {
            get { return _entertainment; }
            set
            {
                _entertainment = value;
                RaisePropertyChanged("Entertainment");
            }
        }

        private List<CompanyExpense> _dailyLiving;

        public List<CompanyExpense> DailyLiving
        {
            get { return _dailyLiving; }
            set
            {
                _dailyLiving = value;
                RaisePropertyChanged("DailyLiving");
            }
        }

        private List<CompanyExpense> _home;

        public List<CompanyExpense> Home
        {
            get { return _home; }
            set
            {
                _home = value;
                RaisePropertyChanged("Home");
            }
        }

        private List<CompanyExpense> _pieExpense;

        public List<CompanyExpense> PieExpense
        {
            get { return _pieExpense; }
            set
            {
                _pieExpense = value;
                RaisePropertyChanged("PieExpense");
            }
        }

        private List<CompanyExpense> _pieConverter;

        public List<CompanyExpense> PieConverter
        {
            get { return _pieConverter; }
            set
            {
                _pieConverter = value;
                RaisePropertyChanged("PieConverter");
            }
        }

        private List<ExpenseData> _totalexpenses;

        public List<ExpenseData> TotalExpenses
        {
            get { return _totalexpenses; }
            set
            {
                _totalexpenses = value;
                RaisePropertyChanged("TotalExpenses");
            }
        }

        private List<ExpenseData> _expenses;

        public List<ExpenseData> Expenses
        {
            get { return _expenses; }
            set
            {
                _expenses = value;
                RaisePropertyChanged("Expenses");
            }
        }

        private double _positiveAmount;

        public double PositiveAmount
        {
            get { return _positiveAmount; }
            set
            {
                _positiveAmount = value;
                RaisePropertyChanged("PositiveAmount");
            }
        }

        private double _negativeAmount;

        public double NegativeAmount
        {
            get { return _negativeAmount; }
            set
            {
                _negativeAmount = value;
                RaisePropertyChanged("NegativeAmount");
            }
        }

        private double _balanceAmount;

        public double BalanceAmount
        {
            get { return _balanceAmount; }
            set
            {
                _balanceAmount = value;
                RaisePropertyChanged("BalanceAmount");
            }
        }

        private int _noPositiveTransactions;

        public int NoPositiveTransactions
        {
            get { return _noPositiveTransactions; }
            set
            {
                _noPositiveTransactions = value;
                RaisePropertyChanged("NoPositiveTransactions");
            }
        }

        private int _noNegativeTransactions;

        public int NoNegativeTransactions
        {
            get { return _noNegativeTransactions; }
            set
            {
                _noNegativeTransactions = value;
                RaisePropertyChanged("NoNegativeTransactions");
            }
        }

        private int _noTotalTransactions;

        public int NoTotalTransactions
        {
            get { return _noTotalTransactions; }
            set
            {
                _noTotalTransactions = value;
                RaisePropertyChanged("NoTotalTransactions");
            }
        }

        private object comboBoxSelectedItem;
        private string _mostSpent;
        private string _leastSpent;
        private string _averageSpent;

        public object ComboBoxSelectedItem
        {
            get { return comboBoxSelectedItem; }
            set
            {
                comboBoxSelectedItem = value;
                RaisePropertyChanged("ComboBoxSelectedItem");
                this.Update();
            }
        }
    }

    public class CompanyExpense
    {
        public string Category { get; set; }
        public double Amount { get; set; }
    }

    public class PieChartViewModel
    {
        public PieChartViewModel()
        {
           // this.Expenditure = new List<CompanyExpense>();
            //Expenditure.Add(new CompanyExpense() { Expense = "Home", Amount = 20d });
            //Expenditure.Add(new CompanyExpense() { Expense = "Entertainment", Amount = 23d });
            //Expenditure.Add(new CompanyExpense() { Expense = "Insurance", Amount = 12d });
            //Expenditure.Add(new CompanyExpense() { Expense = "Labor", Amount = 28d });
            //Expenditure.Add(new CompanyExpense() { Expense = "Warehousing", Amount = 10d });
            //Expenditure.Add(new CompanyExpense() { Expense = "Taxes", Amount = 10d });
            //Expenditure.Add(new CompanyExpense() { Expense = "Truck", Amount = 10d });

        }

        public IList<CompanyExpense> Expenditure
        {
            get;
            set;
        }
    }

    public class LabelConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    
}
