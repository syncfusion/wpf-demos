#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace syncfusion.layoutdemos.wpf
{
    public enum Gender
    {
        Female,

        Male
    }

    public class CardViewModel : NotificationObject , IDataErrorInfo
    {

        private string firstName;

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                this.RaisePropertyChanged("FirstName");
            }
        }

        [Required]

        private string lastname;

        public string LastName
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
                this.RaisePropertyChanged("LastName");
            }
        }

        [Range(1, 100)]

        private int? age;
        public int? Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
                this.RaisePropertyChanged("Age");
            }
        }

        private DateTime dob;
        public DateTime DOB
        {
            get
            {
                return dob;
            }

            set
            {
                dob = value;
                this.RaisePropertyChanged("DOB");
            }
        }

        [Required]

        private Gender gender;
        public Gender Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                this.RaisePropertyChanged("Gender");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                this.RaisePropertyChanged("Email");
            }
        }

        private bool _validationSuccess = true;

        internal bool ValidationSuccess
        {
            get { return _validationSuccess; }
            set { _validationSuccess = value; }
        }


        #region IDataErrorInfo Members

        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                string result = String.Empty;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(this.FirstName))
                    {
                        result = "First name is mandatory";
                    }
                }
                if (columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(this.LastName))
                    {
                        result = "Last name is mandatory";
                    }
                }
                if (columnName == "Age")
                {
                    if ((this.Age < 1 || this.Age > 100 )|| this.Age == null)
                    {
                        result = "Age should greater than 1 and less than 100";
                    }
                }
                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(this.Email))
                    {
                        result = " Email Required";
                    }
                    else
                    {
                        string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

                        if (!Regex.IsMatch(this.Email, MatchEmailPattern))
                            result = "Invalid Email ID";
                    }
                }
                if (columnName == "Gender")
                {


                    if (!this.Gender.ToString().ToLower().Equals("male") && !this.Gender.ToString().ToLower().Equals("female"))
                    {
                        result = "Gender should be Male of Female";
                    }

                }
                ValidationSuccess = string.IsNullOrEmpty(result) ? true : false;
                return result;
            }
        }

        #endregion

    }
    /// <summary>
    /// Rule for gender
    /// </summary>
    public class GenderValidationRule : ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = new System.Windows.Controls.ValidationResult(true, null);
            if (!value.ToString().ToLower().Equals("male") && !value.ToString().ToLower().Equals("female"))
            {
                result = new System.Windows.Controls.ValidationResult(false, "Gender should be Male of Female");
            }
            return result;
        }
    }
}
