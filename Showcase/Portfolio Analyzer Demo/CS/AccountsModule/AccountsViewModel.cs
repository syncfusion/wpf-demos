#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using PortfolioAnalyzer.Model;

using Microsoft.Practices.Composite;
using PortfolioAnalyzer.Infrastructure;
using Microsoft.Practices.Composite.Events;
using System.Data;
using System.Windows.Media.Imaging;
using PortfolioAnalyzer.Data.Model;

namespace PortfolioAnalyzer.AccountsModule
{
    public class AccountsViewModel : INotifyPropertyChanged
    {

        #region Class Members

        IEventAggregator eventAggregator;
        List<Account> accounts;
        Account selectedAccount;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public AccountsViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            LoadAccountList();
        }

        /// <summary>
        /// Loads the images in the Image property of Accounts class.
        /// </summary>
        void LoadAccountList()
        {
            this.Accounts = GetAccountList();
            this.SelectedAccount = this.Accounts[0];
        }

        /// <summary>
        /// Gets or sets the accounts.
        /// </summary>
        /// <value>The accounts.</value>
        public List<Account> Accounts
        {
            get
            {
                return accounts;
            }
            set
            {
                if (this.accounts != value)
                {
                    this.accounts = value;

                    OnPropertyChanged("Accounts");
                }
            }
        }

        /// <summary>
        /// Gets the account list from the database.
        /// </summary>
        /// <returns>The list of Accounts</returns>
        public static List<Account> GetAccountList()
        {
            PortfolioManagerDB dataContext = new PortfolioManagerDB(DataUtils.connString);

            var accountNames = from accounts in dataContext.Accounts
                               orderby accounts.AccountName ascending
                               select new Account
                               {
                                   AccountName = accounts.AccountName,
                                   OpenBalance = accounts.OpenBalance,
                                   Image = accounts.ImageKey
                               };

            return accountNames.ToList();
        }

        /// <summary>
        /// Gets or sets the selected account.
        /// </summary>
        /// <value>The selected account.</value>
        public Account SelectedAccount
        {
            get
            {
                return selectedAccount;
            }
            set
            {
                if (this.selectedAccount != value)
                {
                    this.selectedAccount = value;
                    this.OnPropertyChanged("SelectedAccount");
                    this.eventAggregator.GetEvent<Events>().Publish(this.selectedAccount.AccountName);
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }

    /// <summary>
    /// Represents the Account class.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the open balance.
        /// </summary>
        /// <value>The open balance.</value>
        public decimal? OpenBalance { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public string Image { get; set; }
    }
}
