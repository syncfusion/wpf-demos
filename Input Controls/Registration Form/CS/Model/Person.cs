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
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Syncfusion.Windows.Shared;

namespace EditorControlsDemo
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
            else if ((mobileno.ToString().Length < 15))
            {
                MessageBox.Show("Form has invalid data", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);

            }
            else if (string.IsNullOrEmpty(email.ToString()))
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

        private String mobileno="19932782456";
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
                           if (string.IsNullOrEmpty(mobileno.ToString()) || (mobileno.ToString()).Length < 15 )
                           {
                               if((mobileno.ToString().Contains('+') || mobileno.ToString().Contains('-')))
                               {
                                   if(mobileno.ToString().Length < 15)
                                   error = "Valid Mobile No. required. " +(mobileno.Length - 4) +" numbers are not enough.";
                               }                              
                            }
                        }
                        break;
                    case "Email":
                        {
                            if (string.IsNullOrEmpty(email.ToString()))
                            {
                                error = "Valid E-mail address required.";
                            }
                            else
                            {
                                string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                                Regex re = new Regex(strRegex);
                                if (!(re.IsMatch(email.ToString())))
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
        #endregion

    }



}

