#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.layoutdemos.wpf.ViewModel
{
    public class TextInputLayoutGettingStartedViewModel : NotificationObject, INotifyDataErrorInfo
    {
        #region Fields

        private readonly string mailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                    [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        private string name = string.Empty;

        private string gender = string.Empty;

        private string phoneNumber = string.Empty;

        private string mail = string.Empty;

        private string alternativeMail = string.Empty;

        private string country = string.Empty;

        private string address = string.Empty;

        private string notes = string.Empty;

        private string alternativePhoneNumber;

        private bool isHintAlwaysFloated;

        /// <summary>
        /// flag suspends validation till submit button clicked. 
        /// </summary>
        private bool canValidateForErrors;

        #endregion

        #region Properties

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                RaisePropertyChanged("PhoneNumber");
            }
        }

        public string AlternativePhoneNumber
        {
            get { return alternativePhoneNumber; }
            set
            {
                alternativePhoneNumber = value;
                RaisePropertyChanged("AlternativePhoneNumber");
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                RaisePropertyChanged("Mail");
            }
        }

        public string AlternativeMail
        {
            get { return alternativeMail; }
            set
            {
                alternativeMail = value;
                RaisePropertyChanged("AlternativeMail");
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                RaisePropertyChanged("Country");
            }
        }

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                RaisePropertyChanged("Gender");
            }
        }


        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        public bool IsHintAlwaysFloated
        {
            get { return isHintAlwaysFloated; }
            set
            {
                isHintAlwaysFloated = value;
                RaisePropertyChanged("EnableHintAlwaysFloated");
            }
        }

        public ICommand ResetCommand { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        #endregion

        #region Constructor

        public TextInputLayoutGettingStartedViewModel()
        {
            canValidateForErrors = false;
            SubmitCommand = new SubmitResetCommand(new Action(OnSubmitButtonClicked));
            ResetCommand = new SubmitResetCommand(new Action(OnResetButtonClicked));

        }

        #endregion

        #region  INotifyDataErrorInfo

        public bool HasErrors
        {
            get
            {
                return OnValidate(string.Empty).Count > 0;
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            return OnValidate(propertyName);
        }

        private List<string> OnValidate(string columnName)
        {
            List<string> result = new List<string>();

            if (!canValidateForErrors)
                return result;

            if (string.IsNullOrEmpty(columnName) || columnName == "Name")
            {
                if (string.IsNullOrEmpty(Name))
                    result.Add("Enter your name");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "Gender")
            {
                if (string.IsNullOrEmpty(Name))
                    result.Add("Enter your gender");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "PhoneNumber")
            {
                if (string.IsNullOrEmpty(PhoneNumber))
                    result.Add("Enter your phone number");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "AlternativePhoneNumber")
            {
                if (string.IsNullOrEmpty(AlternativePhoneNumber))
                    result.Add("Enter your alternate phone number");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "Mail")
            {
                if (!Regex.IsMatch(Mail, mailPattern))
                    result.Add("Enter a valid email address");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "AlternativeMail")
            {
                if (!Regex.IsMatch(AlternativeMail, mailPattern))
                    result.Add("Enter a valid alternate email address");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "Country")
            {
                if (string.IsNullOrEmpty(Country))
                    result.Add("Enter your country");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "Address")
            {
                if (string.IsNullOrEmpty(Address))
                    result.Add("Enter your  address");
            }

            return result;
        }

        private void RaiseErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
            {
                ErrorsChanged.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// This method will be called whenever reset button is clicked.
        /// </summary>
        private void OnResetButtonClicked()
        {
            canValidateForErrors = false;
            Name = string.Empty;
            Gender = string.Empty;
            PhoneNumber = string.Empty;
            AlternativePhoneNumber = string.Empty;
            Country = string.Empty;
            Address = string.Empty;
            Mail = string.Empty;
            AlternativeMail = string.Empty;
            Notes = string.Empty;
        }

        /// <summary>
        /// This method will be called whenever submit button is clicked
        /// </summary>
        private void OnSubmitButtonClicked()
        {
            canValidateForErrors = true;
            if (this.ErrorsChanged != null)
            {
                this.RaiseErrorsChanged("Name");
                this.RaiseErrorsChanged("Gender");

                this.RaiseErrorsChanged("PhoneNumber");
                this.RaiseErrorsChanged("AlternativePhoneNumber");

                this.RaiseErrorsChanged("Mail");
                this.RaiseErrorsChanged("AlternativeMail");

                this.RaiseErrorsChanged("Country");
                this.RaiseErrorsChanged("Address");
            }

            if (!this.HasErrors)
                MessageBox.Show("Your details has been registered successfully", "Success", MessageBoxButton.OK);
        }

        #endregion
    }

    internal class SubmitResetCommand : ICommand
    {
        private Action itemAction;

        public SubmitResetCommand(Action action)
        {
            itemAction = action;
        }
#pragma warning disable 67
        public event EventHandler CanExecuteChanged;
#pragma warning restore 67
        public bool CanExecute(object parameter)
        {
            return true;
        }


        public void Execute(object parameter)
        {
            itemAction();
        }
    }
}
