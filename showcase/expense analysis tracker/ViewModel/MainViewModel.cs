#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.expenseanalysis.wpf;
using Syncfusion.Data.Extensions;
//using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.expenseanalysis.wpf
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Transaction> transactions;
        private ListViewModel modules;
        private ItemViewModel selectedModule;
        private double balance;
        private ObservableCollection<DayBalance> dailyBalances;
        private ObservableCollection<DayBalance> monthlyBalance;
        //private ObservableCollection<DayBalance> yearBalance;
        private ObservableCollection<Budget> budgets;
        private ObservableCollection<Budget> montlyBudgetReport;
        private ObservableCollection<Budget> yearlyBudgetReport;
        private double totalIncome;
        private double totalExpense;
        private int totalTransactions;
        private ObservableCollection<CategoryExpense> categoryExpenses;
        private ICommand queryRowHeightCommand;
        private ObservableCollection<Goal> goals;
        private ObservableCollection<Goal> currentGoals;
        private ObservableCollection<Goal> completedGoals;
        private Visibility isCompact = Visibility.Visible;

        public ObservableCollection<Transaction> Transactions
        {
            get { return transactions; }
            set { transactions = value; RaisePropertyChanged(nameof(Transactions)); }
        }

        public ListViewModel Modules
        {
            get { return modules; }
            set { modules = value; RaisePropertyChanged(nameof(Modules)); }
        }

        public ItemViewModel SelectedModule
        {
            get { return selectedModule; }
            set { selectedModule = value; RaisePropertyChanged(nameof(SelectedModule)); }
        }

        public double Balance
        {
            get { return balance; }
            set { balance = value; RaisePropertyChanged(nameof(Balance)); }
        }

        public ObservableCollection<DayBalance> DailyBalance
        {
            get { return dailyBalances; }
            set { dailyBalances = value; RaisePropertyChanged(nameof(DailyBalance)); }
        }

        public ObservableCollection<DayBalance> MonthlyBalance
        {
            get { return monthlyBalance; }
            set { monthlyBalance = value; RaisePropertyChanged(nameof(MonthlyBalance)); }
        }

        //public ObservableCollection<DayBalance> YearlyBalance
        //{
        //    get { return yearBalance; }
        //    set { yearBalance = value; RaisePropertyChanged(nameof(YearlyBalance)); }
        //}

        public ObservableCollection<Budget> Budgets
        {
            get { return budgets; }
            set { budgets = value; RaisePropertyChanged(nameof(Budgets)); }
        }

        public ObservableCollection<Budget> MonthlyBudgetReport
        {
            get { return montlyBudgetReport; }
            set { montlyBudgetReport = value; RaisePropertyChanged(nameof(MonthlyBudgetReport)); }
        }

        public ObservableCollection<Budget> YearlyBudgetReport
        {
            get { return yearlyBudgetReport; }
            set { yearlyBudgetReport = value; RaisePropertyChanged(nameof(YearlyBudgetReport)); }
        }

        public ObservableCollection<Goal> Goals
        {
            get { return goals; }
            set { goals = value; RaisePropertyChanged(nameof(Goals)); }
        }

        public ObservableCollection<Goal> CurrentGoals
        {
            get { return currentGoals; }
            set { currentGoals = value; RaisePropertyChanged(nameof(CurrentGoals)); }
        }

        public ObservableCollection<Goal> CompletedGoals
        {
            get { return completedGoals; }
            set { completedGoals = value; RaisePropertyChanged(nameof(CompletedGoals)); }
        }

        public double TotalIncome
        {
            get { return totalIncome; }
            set { totalIncome = value; RaisePropertyChanged(nameof(TotalIncome)); }
        }

        public double TotalExpense
        {
            get { return totalExpense; }
            set { totalExpense = value; RaisePropertyChanged(nameof(TotalExpense)); }
        }

        public int TotalTransactions
        {
            get { return totalTransactions; }
            set { totalTransactions = value; RaisePropertyChanged(nameof(TotalTransactions)); }
        }

        public ObservableCollection<CategoryExpense> CategoryExpenses
        {
            get { return categoryExpenses; }
            set { categoryExpenses = value; RaisePropertyChanged(nameof(CategoryExpenses)); }
        }

        public Visibility TransEditButtonVisibility
        {
            get
            {
                return transEditButtonVisibility;
            }
            set
            {
                transEditButtonVisibility = value;
                RaisePropertyChanged(nameof(TransEditButtonVisibility));
            }
        }

        public Visibility TransDeleteButtonVisibility
        {
            get
            {
                return transDeleteButtonVisibility;
            }
            set
            {
                transDeleteButtonVisibility = value;
                RaisePropertyChanged(nameof(TransDeleteButtonVisibility));
            }
        }

        public ICommand QueryRowHeightCommand
        {
            get { return queryRowHeightCommand; }
            set { queryRowHeightCommand = value; }
        }

        public ICommand AddBudgetCommand
        { get; private set; }

        public ICommand AddGoalCommand
        { get; private set; }

        public ICommand AddTransactionCommand 
        { get; private set; }

        public ICommand EditBudgetCommand
        { get; private set; }

        public ICommand EditGoalCommand
        { get; private set; }

        public ICommand EditTransactionCommand 
        { get; private set; }

        public ICommand DeleteBudgetCommand
        { get; private set; }

        public ICommand DeleteGoalCommand
        { get; private set; }

        public ICommand DeleteTransactionsCommand
        { get; private set; }

        public ICommand SelectionChangedCommand
        { get; private set; }

        public ICommand GridLoadedCommand
        { get; private set; }

        public ICommand SizeChangedCommand
        { get; private set; }

        public Visibility IsCompact
        {
            get { return isCompact; }
            set { isCompact = value; RaisePropertyChanged(nameof(IsCompact)); }
        }

        public IEnumerable<string> BudgetCategories()
        {
            return Categories()
                .Where(t =>
                    t != SampleDataGenerator.INCOME &&
                    t != SampleDataGenerator.GOAL);
        }

        public IEnumerable<string> Categories()
        {
            return Transactions
                .GroupBy(t => t.Category)
                .Select(t => t.Key);
        }

        public IEnumerable<string> SubCategories(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return null;
            }
            else
            {
                if (category != SampleDataGenerator.GOAL)
                {
                    return Transactions
                        .Where(t => t.Category == category)
                        .GroupBy(t => t.SubCategory)
                        .Select(t => t.Key);
                }
                else
                {
                    return GetGoals();
                }
            }
        }

        private IEnumerable<string> GetGoals()
        {
            return Goals
                .Where(
                    g => g.EndDate > DateTime.Now && g.Target > g.Saving)
                .GroupBy(t => t.Name)
                .Select(t => t.Key);
        }

        private const string LAST_30_DAYS = "Last 30 days";
        private const string LAST_60_DAYS = "Last 60 days";
        private const string LAST_90_DAYS = "Last 90 days";

        public IEnumerable<string> ExpenseFilter
        {
            get
            {
                yield return LAST_30_DAYS;
                yield return LAST_60_DAYS;
                yield return LAST_90_DAYS;
            }
        }

        private string selectedExpenseFilter = LAST_90_DAYS;
        public string SelectedExpenseFilter
        {
            get
            { 
                return selectedExpenseFilter; 
            }
            set 
            { 
                if (selectedExpenseFilter != value)
                {
                    selectedExpenseFilter = value;
                    RaisePropertyChanged(nameof(SelectedExpenseFilter));
                    RefreshCategoryExpenses();
                }
            }
        }

        private Visibility transEditButtonVisibility = Visibility.Collapsed;
        private Visibility transDeleteButtonVisibility = Visibility.Collapsed;

        public MainViewModel()
        {
            LoadRandomData();
            OnTransactionsChanged();

            Modules = new ListViewModel();
            QueryRowHeightCommand = new DelegateCommand<QueryRowHeightEventArgs>(QueryRowHeightExecute);
            AddBudgetCommand = new DelegateCommand<AddBudget>(AddBudget);
            AddGoalCommand = new DelegateCommand<AddGoal>(AddGoal);
            AddTransactionCommand = new DelegateCommand<Transaction>(AddTransaction);

            EditBudgetCommand = new DelegateCommand<Budget>(EditBudget);
            EditGoalCommand = new DelegateCommand<Goal>(EditGoal);
            EditTransactionCommand = new DelegateCommand<Transaction>(EditTransaction);

            DeleteBudgetCommand = new DelegateCommand<Budget>(DeleteBudget);
            DeleteGoalCommand = new DelegateCommand<Goal>(DeleteGoal);
            DeleteTransactionsCommand = new DelegateCommand<object>(DeleteTransactions);

            SelectionChangedCommand = new DelegateCommand<object>(SelectionChanged);
            GridLoadedCommand = new DelegateCommand<object>(GridLoaded);
            SizeChangedCommand = new DelegateCommand<object>(SizeChanged);
        }

        private void SizeChanged(object obj)
        {
            if (obj is SizeChangedEventArgs)
            {
                var size = obj as SizeChangedEventArgs;
                if(size.NewSize.Width < 1300 || size.NewSize.Height < 700)
                {
                    IsCompact = Visibility.Collapsed;
                }
                else
                {
                    IsCompact = Visibility.Visible;
                }
            }   
        }

        private void OnTransactionsChanged()
        {
            RefreshBalanceData();
            RefreshDashboardData();
            RefreshTransactionsData();
            RefreshGoalsData();
            RefreshBudgetData();
        }

        private void QueryRowHeightExecute(QueryRowHeightEventArgs e)
        {
        }

        private void AddBudget(Budget budget)
        {
            var selecteeBudget = BudgetDiaog(budget, true);
            if (selecteeBudget != null)
            {
                Budgets.Add(selecteeBudget);
                RefreshBudgetData();
            }
        }

        private void EditBudget(Budget budget)
        {
            var selecteeBudget = BudgetDiaog(budget, false);
            if (selecteeBudget != null)
            {
                budget.Apply(selecteeBudget);
                RefreshBudgetData();
            }
        }

        private Budget BudgetDiaog(Budget budget, bool add)
        {
            var selectedBudget = budget.Clone();
            selectedBudget.GetCategories = BudgetCategories;
            selectedBudget.GetSubCategories = SubCategories;
            var budgetEditor = new DialogWindow 
            {
                DataContext = selectedBudget,
                Width = 300,
                Height = 400,
            };
            if(add)
            {
                budgetEditor.Title = "Create Budget";
                budgetEditor.AcceptText = "Create";
            }
            else
            {
                budgetEditor.Title = "Edit Budget";
                budgetEditor.AcceptText = "Save";
            }
            budgetEditor.Content = new EditBudgetView();
            budgetEditor.Owner = Application.Current.MainWindow;
            budgetEditor.ShowDialog();
            selectedBudget.GetCategories = null;
            selectedBudget.GetSubCategories = null;
            if( budgetEditor.Result == MessageBoxResult.OK)
            {
                return selectedBudget;
            }
            return null;
        }

        private void AddGoal(AddGoal goal)
        {
            var selectedGoal = GoalDiaog(goal, true);
            if (selectedGoal != null)
            {
                Goals.Add(selectedGoal);
                RefreshGoalsData();
            }
        }

        private void EditGoal(Goal goal)
        {
            var selectedGoal = GoalDiaog(goal, false);
            if (selectedGoal != null)
            {
                goal.Apply(selectedGoal);
                RefreshGoalsData();
            }
        }

        private Goal GoalDiaog(Goal goal, bool add)
        {
            var selectedGoal = goal.Clone();

            var goalEditor = new DialogWindow
            {
                DataContext = selectedGoal,
                Width = 300,
                Height = 400,
            };
            if (add)
            {
                goalEditor.Title = "Create Goal";
                goalEditor.AcceptText = "Create";
            }
            else
            {
                goalEditor.Title = "Edit Goal";
                goalEditor.AcceptText = "Save";
            }
            goalEditor.Content = new EditGoalView();
            goalEditor.Owner = Application.Current.MainWindow;
            goalEditor.ShowDialog();
            if(goalEditor.Result == MessageBoxResult.OK)
            {
                return selectedGoal;
            }
            return null;
        }

        private void AddTransaction(Transaction t)
        {
            var selectedTransaction = new Transaction() { Date = DateTime.Now.Date };
            selectedTransaction = TransactionDiaog(selectedTransaction, true);
            if (selectedTransaction != null)
            {
                Transactions.Add(selectedTransaction);
                OnTransactionsChanged();
            }
        }

        private void EditTransaction(Transaction t)
        {
            var selectedTransaction = TransactionDiaog(t, false);
            if (selectedTransaction != null)
            {
                t.Apply(selectedTransaction);
                OnTransactionsChanged();
            }
        }

        private Transaction TransactionDiaog(Transaction t, bool add)
        {
            var selectedTransaction = t.Clone();
            selectedTransaction.GetCategories = Categories;
            selectedTransaction.GetSubCategories = SubCategories;
            var transactionEditor = new DialogWindow 
            {
                DataContext = selectedTransaction,
                Width = 300,
                Height = 400,
            };
            if (add)
            {
                transactionEditor.Title = "Create Transaction";
                transactionEditor.AcceptText = "Create";
            }
            else
            {
                transactionEditor.Title = "Edit Transaction";
                transactionEditor.AcceptText = "Save";
            }
            transactionEditor.Content = new EditTransactionView();
            transactionEditor.Owner = Application.Current.MainWindow;
            transactionEditor.ShowDialog();
            selectedTransaction.GetCategories = null;
            selectedTransaction.GetSubCategories = null;
            if(transactionEditor.Result == MessageBoxResult.OK)
            {
                if(selectedTransaction.Category == SampleDataGenerator.INCOME)
                {
                    selectedTransaction.Amount = Math.Abs(selectedTransaction.Amount);
                }
                else
                {
                    selectedTransaction.Amount = -Math.Abs(selectedTransaction.Amount);
                }
                return selectedTransaction;
            }
            return null;
        }

        private void DeleteBudget(Budget budget)
        {
            if (Delete(budget) == MessageBoxResult.OK)
            {
                Budgets.Remove(budget);
                RefreshBudgetData();
            }
        }

        private void DeleteGoal(Goal goal)
        {
            if(Delete(goal) == MessageBoxResult.OK)
            {
                Goals.Remove(goal);
                RefreshGoalsData();
            }
        }

        private void DeleteTransactions(object transactions)
        {
            if (Delete(transactions) == MessageBoxResult.OK)
            {
                if (transactions is IEnumerable)
                {
                    var selectedItems = (transactions as IEnumerable).ToList<Transaction>().ToList();
                    foreach (var item in selectedItems)
                    {
                        Transactions.Remove(item);
                    }
                }
                else if(transactions is Transaction)
                {
                    Transactions.Remove(transactions as Transaction);
                }
                OnTransactionsChanged();
            }
        }

        private MessageBoxResult Delete(object obj)
        {
            var dialog = new DialogWindow 
            {
                DataContext = this,
                Width = 250,
                Height = 175,
            };
            dialog.Content = new DeleteDialog();
            dialog.Title = "Delete";
            dialog.AcceptText = "Delete";
            string msg = "Are you sure to delete the ";

            if(obj is Budget)
            {
                dialog.DataContext = msg + "budget?";
            }
            else if(obj is Goal)
            {
                dialog.DataContext = msg + "goal?";
            }
            else if(obj is Transaction)
            {
                dialog.DataContext = msg + "transaction?";
            }
            else if(obj is IEnumerable)
            {
                dialog.DataContext = msg + "transactions?";
            }
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();
            return dialog.Result;
        }

        private void SelectionChanged(object args)
        {
            var selectionChangeArgs = args as GridSelectionChangedEventArgs;
            if(selectionChangeArgs != null)
            {
                var grid = selectionChangeArgs.OriginalSender as SfDataGrid;
                OnTransactionSelectionChange(grid);
            }
        }

        private void GridLoaded(object args)
        {
            TransEditButtonVisibility = Visibility.Collapsed;
            TransDeleteButtonVisibility = Visibility.Collapsed;
        }

        private void OnTransactionSelectionChange(SfDataGrid grid)
        {
            if (grid != null)
            {
                if (grid.SelectedItems != null)
                {
                    if (grid.SelectedItems.Count == 0)
                    {
                        TransEditButtonVisibility = Visibility.Collapsed;
                        TransDeleteButtonVisibility = Visibility.Collapsed;
                    }
                    else if (grid.SelectedItems.Count == 1)
                    {
                        TransEditButtonVisibility = Visibility.Visible;
                        TransDeleteButtonVisibility = Visibility.Visible;
                    }
                    else if (grid.SelectedItems.Count > 1)
                    {
                        TransEditButtonVisibility = Visibility.Collapsed;
                        TransDeleteButtonVisibility = Visibility.Visible;
                    }
                }
            }
        }

        /// <summary>
        /// Get the balance in the specified frequency.
        /// </summary>
        /// <param name="start">start of the frequency</param>
        /// <param name="frequency">1 - daily, 2 - monthly, 3 - yearly</param>
        /// <returns></returns>
        public IEnumerable<DayBalance> GetBalance(DateTime start, int frequency)
        {
            DateTime run = start;
            DateTime? dateTime = null;
            //double balance = 0;
            foreach (var tran in Transactions
                .Where(t => t.Date > start)
                .OrderBy(t => t.Date))
            {
                if (dateTime == null)
                {
                    dateTime = tran.Date; 
                }
                if (
                    ((frequency == 1 && tran.Date.Date.Date != dateTime.Value.Date.Date) ||
                    (frequency == 2 && tran.Date.Date.Month != dateTime.Value.Date.Month) ||
                    (frequency == 3 && tran.Date.Date.Month != dateTime.Value.Date.Month)) &&
                    (tran.Date > start)
                    )
                {
                    while(tran.Date.Date >= run.Date)
                    {
                        if(frequency == 2 || frequency == 3)
                        {
                            run = tran.Date.Date;
                        }
                        DayBalance bal = new DayBalance();
                        bal.Date = run.Date;
                        bal.Balance = tran.Balance;
                        yield return bal;
                        run = run.AddDays(1);
                    }
                }
                else
                {
                    //balance += tran.Amount;
                }
                dateTime = tran.Date;
                //yield return new DayBalance { Date = tran.Date, Balance = tran.Balance };
            }
        }

        private void LoadRandomData()
        {
            Goals = new ObservableCollection<Goal>(SampleDataGenerator.GetGoals());
            Transactions = new ObservableCollection<Transaction>(
                SampleDataGenerator.GenerateTransactions(DateTime.Now.AddDays(-900), DateTime.Now).Where(
                    t => t.Date < DateTime.Now.Date
                ));
            var categoris = Transactions
                .Where(t => t.Date.Year == DateTime.Now.Year && t.Date.Month == DateTime.Now.Month)
                .Where(t => 
                    t.Category != SampleDataGenerator.INCOME &&
                    t.Category != SampleDataGenerator.DEBT &&
                    t.Category != SampleDataGenerator.INSURANCE &&
                    t.Category != SampleDataGenerator.HOUSING)
                .GroupBy(t => t.Category)
                .Select(t => t.Key);
            Budgets = new ObservableCollection<Budget>(SampleDataGenerator.GetBudgets(categoris));

            foreach (var goal in Goals)
            {
                var i = goal.StartDate.AddDays(1);
                while (i < DateTime.Now && goal.Saving < goal.Target)
                {
                    Transactions.Add(
                        new Transaction
                        {
                            Amount = -goal.MonthlyTarget,
                            Category = SampleDataGenerator.GOAL,
                            Date = i,
                            SubCategory = goal.Name
                        }
                    );
                    i = i.AddMonths(1);
                    goal.Saving += goal.MonthlyTarget;
                }
            }
        }

        private void RefreshBalanceData()
        {
            double bal = 0;
            foreach (var trans in Transactions.OrderBy(t => t.Date))
            {
                bal += trans.Amount;
                trans.Balance = bal;
            }
        }

        private void RefreshDashboardData()
        {
            DailyBalance = new ObservableCollection<DayBalance>(GetBalance(DateTime.Now.Date.AddDays(-30), 1));
            MonthlyBalance = new ObservableCollection<DayBalance>(GetBalance(DateTime.Now.Date.AddYears(-1), 2));
            //YearlyBalance = new ObservableCollection<DayBalance>(GetBalance(default(DateTime), 3));
            RefreshCategoryExpenses();
        }

        private void RefreshCategoryExpenses()
        {
            var date = DateTime.Now.AddDays(-30);
            if (SelectedExpenseFilter == LAST_30_DAYS)
            {
                date = DateTime.Now.AddDays(-30);
            }
            else if(SelectedExpenseFilter == LAST_60_DAYS)
            {
                date = DateTime.Now.AddDays(-60);
            }
            else if(SelectedExpenseFilter == LAST_90_DAYS)
            {
                date = DateTime.Now.AddDays(-90);
            }

            var temp = new ObservableCollection<CategoryExpense>(Transactions
                .Where(t => t.Date > date)
                .Where(t => t.Category != SampleDataGenerator.INCOME)
                .GroupBy(t => t.Category)
                .Select(g => {
                    return new CategoryExpense
                    {
                        Category = g.Key,
                        Amount = Math.Abs(g.Sum(t => t.Amount))
                    };
                })
                .OrderByDescending(cat => cat.Amount));
            var total = temp.Sum(exp => exp.Amount);
            foreach (var categoryExpense in temp)
            {
                categoryExpense.Percentage = categoryExpense.Amount / total;
            }

            CategoryExpenses = temp;
        }

        private void RefreshTransactionsData()
        {
            Balance = Transactions.Sum(t => t.Amount);
            TotalExpense = Math.Abs(Transactions.Where(t => t.Category != SampleDataGenerator.INCOME).Sum(t => t.Amount));
            TotalIncome = Transactions.Where(t => t.Category == SampleDataGenerator.INCOME).Sum(t => t.Amount);
            TotalTransactions = Transactions.Count;
        }

        private void RefreshGoalsData()
        {
            foreach (var g in Goals)
            {
                g.Saving = 0;
            }
            foreach (var trans in Transactions)
            {
                if(trans.Category == SampleDataGenerator.GOAL)
                {
                    var goal = Goals.FirstOrDefault(g => g.Name == trans.SubCategory);
                    if (goal != null)
                    {
                        goal.Saving += -trans.Amount;
                    }
                }
            }

            CompletedGoals = new ObservableCollection<Goal>(Goals.Where(g => g.Saving >= g.Target || DateTime.Now > g.EndDate));
            CurrentGoals = new ObservableCollection<Goal>(Goals.Where(g => !(g.Saving >= g.Target || DateTime.Now > g.EndDate)));

            CurrentGoals.Add(new AddGoal
            {
                StartDate = DateTime.Now.Date,
                EndDate = DateTime.Now.AddMonths(3).Date,
                Target = 1000,
            });
        }

        private void RefreshBudgetData()
        {
            MonthlyBudgetReport = new ObservableCollection<Budget>();
            YearlyBudgetReport = new ObservableCollection<Budget>();


            foreach (var budget in Budgets)
            {
                budget.Update(Transactions, DateTime.Now);
                if (budget.Type == BudgetType.Monthly)
                {
                    MonthlyBudgetReport.Add(budget);
                }
                else if (budget.Type == BudgetType.Yearly)
                {
                    YearlyBudgetReport.Add(budget);
                }
            }

            MonthlyBudgetReport.Add(new AddBudget() { Type = BudgetType.Monthly });
            YearlyBudgetReport.Add(new AddBudget() { Type = BudgetType.Yearly });
        }
    }
}
