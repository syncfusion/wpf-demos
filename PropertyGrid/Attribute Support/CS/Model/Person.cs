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
using System.Windows.Media.Imaging;
using System.Reflection;

namespace PropertyGridAttributeDemo
{
    [Editor(typeof(ImageSource), typeof(ImageViewer))]
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
            DOB = new DateTime(1987, 10, 16);
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Image = new BitmapImage(new Uri(path + @"\carl.png", UriKind.RelativeOrAbsolute));
            Bank = new Bank() { Name = "Centura Banks", AccountNumber = 00987453721, CustomerID = "carljohnson", Password = "nuttertools" };
            Designation = "Team Lead";
        }
        
        [Display(Description = "Gender information of the Employee", Order = 3, Name = "Gender", GroupName = "Identity")]
        public Gender Gender
        {
            get;

            set;
        }

        [Display(Description = "Country where the employee locating", Order = 7, Name = "Country", GroupName = "Location")]
        public Country Country
        {
            get;

            set;
        }

        [Bindable(false)]
        public string MaritalStatus
        {
            get;

            set;
        }

        [Display(Description = "NetSalary of the employee", GroupName = "Identity", AutoGenerateField = false)]
        public double NetSalary
        {
            get;

            set;
        }

        [Display(Description = "Email address of the employee", Order = 6, Name = "Email ID", GroupName = "Contact Details")]
        public string Email
        {
            get;

            set;
        }

        [Display(Description = "First Name of the employee", Order = 0, Name = "First Name", GroupName = "Identity")]
        public string FirstName
        {
            get;

            set;
        }

        [Editable(false)]
        [Display(Description = "Position of the employee in the organisation", Name = "Designation", GroupName = "Identity")]
        public string Designation
        {
            get;

            set;
        }


        [Display(Description = "Last Name of the employee", Order = 1, Name = "Last Name", GroupName = "Identity")]
        public string LastName
        {
            get;

            set;
        }


        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Employee ID")]
        [DescriptionAttribute("ID of the employee")]
        public string ID
        {
            get;

            set;
        }


        [Display(Description = "Birth date of the employee", Order = 4, Name = "Date of Birth", GroupName = "Identity")]
        public DateTime DOB
        {
            get;

            set;
        }


        [Display(Description = "Contact Number of the employee", Order = 5, Name = "Mobile Number", GroupName = "Contact Details")]
        public long Mobile
        {
            get;

            set;
        }

        [Display(Description = "Age of the employee", Order = 2, Name = "Age", GroupName = "Identity")]
        public int Age
        {
            get;

            set;
        }

        [Display(Description = "Photo shot of the employee", Name = "Image", GroupName = "Identity")]
        public ImageSource Image
        {
            get;

            set;
        }

        [Display(Description = "Bank in which the employee has account", Order = 8, Name = "Bank")]
        public Bank Bank
        {
            get;

            set;
        }

    }
}
