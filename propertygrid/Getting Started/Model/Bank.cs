#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.PropertyGrid;
using System.ComponentModel;
using System.Windows.Data;

namespace syncfusion.propertygriddemos.wpf
{
    [Editor("Password", typeof(PasswordEditor))]
    [Editor("AccountNumber", typeof(AccountNo))]
    public class Bank
    {
        [DisplayNameAttribute("Name")]
        [DescriptionAttribute("Name of the bank.")]
        public string Name
        {
            get;
            set;
        }

        [DisplayNameAttribute("Customer ID")]
        [DescriptionAttribute("Customer ID used for Net Banking.")]
        public string CustomerID
        {
            get;

            set;
        }

        [DescriptionAttribute("Password used for Net Banking.")]
        [ReadOnly(true)]
        public string Password
        {
            get;

            set;
        }

        [DisplayNameAttribute("Account Number")]
        [DescriptionAttribute("Bank Account Number.")]
        public long AccountNumber
        {
            get;

            set;
        }

       
        [DescriptionAttribute("Address of Bank.")]
        [ReadOnly(true)]
        public Address Address
        {
            get;

            set;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public enum Gender
    {
        Male,

        Female
    }

    public enum Country
    {
        USA,

        Germany,

        Canada,

        Mexico,

        Alaska,

        Japan,

        China,

        Peru,

        Chile,

        Argentina,

        Brazil
    }
}
