using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PropertyGridConfigurationDemo
{    
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
        UnitedStates,

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
