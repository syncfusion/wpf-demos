#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        private string firstName = string.Empty;

        private string lastName = string.Empty;

        private string phoneNumber = string.Empty;

        private string alternativePhoneNumber = string.Empty;

        private string mail = string.Empty;

        private string alternativeMail = string.Empty;

        private string currentAddress = string.Empty;

        private string permanentAddress = string.Empty;

        private string notes = string.Empty;

        private bool isHintAlwaysFloated;

        /// <summary>
        /// flag suspends validation till submit button clicked. 
        /// </summary>
        private bool canValidateForErrors;

        #endregion

        #region Properties

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                RaisePropertyChanged("LastName");
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

        public string CurrentAddress
        {
            get { return currentAddress; }
            set
            {
                currentAddress = value;
                RaisePropertyChanged("CurrentAddress");
            }
        }

        public string PermanentAddress
        {
            get { return permanentAddress; }
            set
            {
                permanentAddress = value;
                RaisePropertyChanged("PermanentAddress");
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

            if (string.IsNullOrEmpty(columnName) || columnName == "FirstName")
            {
                if (string.IsNullOrEmpty(FirstName))
                    result.Add("Enter your name");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "LastName")
            {
                if (string.IsNullOrEmpty(LastName))
                    result.Add("Enter your last name");
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

            if (string.IsNullOrEmpty(columnName) || columnName == "CurrentAddress")
            {
                if (string.IsNullOrEmpty(CurrentAddress))
                    result.Add("Enter your address");
            }

            if (string.IsNullOrEmpty(columnName) || columnName == "PermanentAddress")
            {
                if (string.IsNullOrEmpty(PermanentAddress))
                    result.Add("Enter your permanent address");
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
            FirstName = string.Empty;
            LastName = string.Empty;
            PhoneNumber = string.Empty;
            AlternativePhoneNumber = string.Empty;
            CurrentAddress = string.Empty;
            PermanentAddress = string.Empty;
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
                this.RaiseErrorsChanged("FirstName");
                this.RaiseErrorsChanged("LastName");
                this.RaiseErrorsChanged("PhoneNumber");
                this.RaiseErrorsChanged("AlternativePhoneNumber");
                this.RaiseErrorsChanged("Mail");
                this.RaiseErrorsChanged("AlternativeMail");
                this.RaiseErrorsChanged("CurrentAddress");
                this.RaiseErrorsChanged("PermanentAddress");
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
