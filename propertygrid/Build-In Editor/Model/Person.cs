#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace syncfusion.propertygriddemos.wpf
{
    [Editor(typeof(string), typeof(TextBoxEditor))]
    [Editor(typeof(DateTime), typeof(DateTimeEditor))]
    [Editor(typeof(Gender), typeof(EnumComboEditor))]
    [Editor(typeof(Brush), typeof(BrushSelectorEditor))]
    [Editor(typeof(IEnumerable), typeof(ITypeItemsSourceControl))]
    [Editor(typeof(bool), typeof(CheckBoxEditor))]
    [Editor(typeof(long), typeof(IntegerTextBoxEditor))]
    [MaskAttribute(MaskAttribute.EmailId, "Email")]
    [Editor(typeof(double), typeof(DoubleTextBoxEditor))]
    [Editor(typeof(TimeSpan), typeof(TimeSpanEditor))]
    public class BuildInPerson
    {
        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Employee Name")]
        [DescriptionAttribute("Name of the employee.")]
        public string EmployeeName { get; set; }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Date of Birth")]
        [DescriptionAttribute("Birth date of the employee.")]
        public DateTime DOB { get; set; }

        [CategoryAttribute("Identity")]
        [DisplayNameAttribute("Gender")]
        [DescriptionAttribute("Gender information of the employee.")]
        public Gender Gender { get; set; }

        [CategoryAttribute("Favorites")]
        [DisplayNameAttribute("Favorite Color")]
        [DescriptionAttribute("Favorite color of the employee.")]
        public Brush FavoriteColor { get; set; }

        [CategoryAttribute("Customer Details")]
        [DisplayNameAttribute("Customers")]
        [DescriptionAttribute("List of Customers that was handled by employee.")]
        public ObservableCollection<CustomerDetails> Customers { get; set; }

        [CategoryAttribute("License Details")]
        [DisplayNameAttribute("IsActive")]
        [DescriptionAttribute("Determines whether the employee has been logged-in or not.")]
        public bool IsActive { get; set; }

        [CategoryAttribute("Contact Details")]
        [DisplayNameAttribute("Mobile Number")]
        [DescriptionAttribute("Contact Number of the employee.")]
        public long Mobile { get; set; }

        [CategoryAttribute("Contact Details")]
        [DisplayNameAttribute("Email ID")]
        [DescriptionAttribute("Email address of the employee.")]
        public string Email { get; set; }

        [CategoryAttribute("Performance Details")]
        [DisplayNameAttribute("Rating")]
        [DescriptionAttribute("Rating of the employee.")]
        public double Rating { get; set; }

        [CategoryAttribute("Attendance Details")]
        [DisplayNameAttribute("Worked hours")]
        [DescriptionAttribute("Total number of hours worked per day")]
        public TimeSpan WorkedHours { get; set; }
    }
}
