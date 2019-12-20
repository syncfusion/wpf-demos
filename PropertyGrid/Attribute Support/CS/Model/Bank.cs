#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PropertyGridAttributeDemo
{
    [Editor(typeof(Object), typeof(PasswordEditor))]
    public class Bank
    {       
        [Display(Description = "Name of the bank", Name = "Name")]
        public string Name
        {
            get;

            set;
        }
  
        [Display(Description = "Customer ID used for Net Banking.", Name = "Customer ID")]
        public string CustomerID
        {
            get;

            set;
        }

        [Display(Description = "Password used for Net Banking.")]
        [Editable(false)]
        public object Password
        {
            get;

            set;
        }
     
        [Display(Description = "Bank Account Number.", Name = "Account Number")]
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
