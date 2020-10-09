#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Windows.Media;
using Syncfusion.Windows.PropertyGrid;

namespace syncfusion.propertygriddemos.wpf
{  
   [TypeConverter(typeof(ExpandableObjects))]
    public class Person
    {
        public Person()
        {
            FirstName = "Carl";
            LastName = "Johnson";
            Age = 30;
            Mobile = 91983467382;
            Email = "carljohnson@gta.com";
            ID = "0005A";
            FavoriteColor = Brushes.Gray;
            IsLicensed = true;
            DOB = new DateTime(1987, 10, 16);
            Key = "dasd798@79hiujodsa';psdoiu9*(Uj0JK)(";
            Bank = new Bank() { Name = "Centura Banks", AccountNumber = 00987453721, CustomerID = "carljohnson", Password = "nuttertools" };
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("First Name")]
        [DescriptionAttribute("First Name of the actual person.")]
        public string FirstName
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Last Name")]
        [DescriptionAttribute("Last Name of the actual person.")]
        public string LastName
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Age")]
        [DescriptionAttribute("Age of the actual person.")]
        public int Age
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Date of Birth")]
        [DescriptionAttribute("Birth date of the actual person.")]
        public DateTime DOB
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Gender")]
        [DescriptionAttribute("Gender information of the actual person.")]
        public Gender Gender
        {
            get;

            set;
        }

        [CategoryAttribute("Favorites")]
        [DisplayNameAttribute("Favorite Color")]
        [DescriptionAttribute("Favorite color of the actual person.")]
        public Brush FavoriteColor
        {
            get;

            set;
        }

        [Browsable(false)]
        public string MaritalStatus
        {
            get;

            set;
        }

        [CategoryAttribute("Account Details")]
        [DisplayNameAttribute("Bank")]
        [DescriptionAttribute("Bank in which the person has account.")]
        [ReadOnly(true)]
        public Bank Bank
        {
            get;

            set;
        }

        [CategoryAttribute("License Details")]
        [DisplayNameAttribute("IsLicensed")]
        [DescriptionAttribute("Determines whether the person has license or not.")]
        public bool IsLicensed
        {
            get;

            set;
        }

        [CategoryAttribute("License Details")]
        [DisplayNameAttribute("Key")]
        [DescriptionAttribute("License key for the person.")]
        [ReadOnly(true)]
        public string Key
        {
            get;

            set;
        }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("ID")]
        [DescriptionAttribute("ID of the actual person.")]
        public string ID
        {
            get;

            set;
        }

        [CategoryAttribute("Location")]
        [DisplayNameAttribute("Country")]
        [DescriptionAttribute("Country where the actual person is located.")]
        public Country Country
        {
            get;

            set;
        }

        [CategoryAttribute("Contact Details")]
        [DisplayNameAttribute("Mobile Number")]
        [DescriptionAttribute("Contact Number of the actual person.")]
        public long Mobile
        {
            get;

            set;
        }

        [CategoryAttribute("Contact Details")]
        [DisplayNameAttribute("Email ID")]
        [DescriptionAttribute("Email address of the actual person.")]
        public string Email
        {
            get;

            set;
        }
    }  
}
