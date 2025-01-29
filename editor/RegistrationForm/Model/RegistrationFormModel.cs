#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.ComponentModel;
using System.Windows;
using System.Text.RegularExpressions;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    public class Person : NotificationObject, IDataErrorInfo
    { 
        #region RegisterCommandValidation
        public void Fo()
        {
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);                
            }
            else if (string.IsNullOrEmpty(age.ToString()) || age == 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);                
            }
            else if (string.IsNullOrEmpty(dob.ToString()) || (dob.Date <= DateTime.Parse("1/1/0001") || dob.Date >= DateTime.Today))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);                
            }
            else if (!this.IsValidField(mobileno, @"^\(\d{3}\)\d{3}-\d{4}$"))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (!this.IsValidField(email, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9]+.[A-Za-z]{2,3}$"))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(marks.ToString()) || marks.ToString() == "0")
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(exp.ToString()) || exp.ToString() == "0")
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (string.IsNullOrEmpty(currentCTC.ToString()) || currentCTC <= 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }

            else if (string.IsNullOrEmpty(expectedCTC.ToString()) || expectedCTC <= 0)
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                MessageBox.Show("Successfully Registered", "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
            }
        }      
        #endregion

        #region properties       

        private string name="Carl Johnson";
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                this.RaisePropertyChanged(() => this.Name);
            }
        }

        private int age = 25;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                this.RaisePropertyChanged(() => this.Age);
            }
        }

        private DateTime dob = DateTime.Parse("10/10/1985", new System.Globalization.CultureInfo("en-US", true));
        public DateTime DOB
        {
            get
            {
                return dob;
            }
            set
            {
                dob = value;
                this.RaisePropertyChanged(() => this.DOB);
            }
        }

        private String mobileno="(993)278-2456";
        public String MobileNo
        {
            get
            {
                return mobileno;
            }
            set
            {
                mobileno = value;
                this.RaisePropertyChanged(() => this.MobileNo);
            }
        }

        private string email="cj@gmail.com";
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                this.RaisePropertyChanged(() => this.Email);
            }
        }

        private double marks=double.Parse("75");
        public double Marks
        {
            get
            {
                return marks;
            }
            set
            {
                marks = value;
                this.RaisePropertyChanged(() => this.Marks);
            }
        }

        private double exp=2;
        public double Exp
        {
            get
            {
                return exp;
            }
            set
            {
                exp = value;
                this.RaisePropertyChanged(() => this.Exp);
            }
        }

        private decimal currentCTC = decimal.Parse("20000.00");
        public decimal CurrentCTC
        {
            get
            {
                return currentCTC;
            }
            set
            {
                currentCTC = value;
                this.RaisePropertyChanged(() => this.CurrentCTC);
            }
        }

        private double expectedCTC=double.Parse("25000.00");
        public double ExpectedCTC
        {
            get
            {
                return expectedCTC;
            }
            set
            {
                expectedCTC = value;
                this.RaisePropertyChanged(() => this.ExpectedCTC);
            }
        }


        #endregion

        #region error
        public string Error
        {
            get { return null; }
        }
       
        public string this[string columnName]
        {
         
            get
            {
                string error = null;
                switch (columnName)
                {

                    case "Name":
                        {
                            if (string.IsNullOrEmpty(name))
                            {
                                error = "Name field required.";
                            }

                        }
                        break;
                    case "Age":
                        {
                            if (age <= 0 || age > 100)
                            {
                                error = "Age must be in the range [0,100]";
                            }
                        }
                        break;
                    case "DOB":
                        {
                            if (dob.Date <= DateTime.Parse("1/1/0001") || dob.Date >= DateTime.Today)
                            {
                                error = "Valid Date of Birth required.";
                            }
                        }
                        break;
                    case "MobileNo":
                        {
                            if (!this.IsValidField(mobileno, @"^\(\d{3}\)\d{3}-\d{4}$"))
                            {
                                error = "Valid Phone No. required.";
                            }
                        }
                        break;
                    case "Email":
                        {
                            if (!this.IsValidField(email, @"^[A-Za-z0-9._%-]+@[A-Za-z0-9]+.[A-Za-z]{2,3}$"))
                            {
                                error = "Valid E-mail address required.";
                            }
                        }
                        break;
                    case "Marks":
                        {
                            if (marks <= 0)
                            {
                                error = "Valid Score required.";
                            }
                        }
                        break;
                    case "Exp":
                        {
                            if(exp.ToString() == "0")
                                error = "Need Experienced Candidates.";
                        }
                        break;
                    case "CurrentCTC":
                        {
                            if (currentCTC <= 0)
                            {
                                error = "Valid data required.";
                            }
                        }
                        break;
                    case "ExpectedCTC":
                        {
                            if (expectedCTC <= 0)
                            {
                                error = "Valid data required.";
                            }
                        }
                        break;                       
                }
                return error;
            }
        }

        private bool IsValidField(string field, string pattern)
        {
            if(string.IsNullOrEmpty(field) || !Regex.IsMatch(field, pattern))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}

