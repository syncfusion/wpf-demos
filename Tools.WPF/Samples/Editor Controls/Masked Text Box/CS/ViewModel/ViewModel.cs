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
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace MaskedTextBoxDemo
{
    class ViewModel : NotificationObject
    {

        private ObservableCollection<string> eventLogsCollection;

        public ObservableCollection<string> EventLogsCollection
        {
            get { return eventLogsCollection; }
            set
            {
                eventLogsCollection = value;
                this.RaisePropertyChanged(() => this.EventLogsCollection);
            }
        }
        ObservableCollection<string> coll = new ObservableCollection<string>();

        private string emailValidationString = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})";
        public string EmailValidationString
        {
            get
            {
                return emailValidationString;
            }
            set
            {
                emailValidationString = value;
                RaisePropertyChanged(() => this.EmailValidationString);
            }
        }

        private Brush validationBorderBrush;
        public Brush ValidationBorderBrush
        {
            get
            {
                return validationBorderBrush;
            }
            set
            {
                validationBorderBrush = value;
                RaisePropertyChanged(() => this.ValidationBorderBrush);
            }
        }

        private string dateValue = "";
        public string DateValue
        {
            get
            {
                return dateValue;
            }
            set
            {
                dateValue = value;
                RaisePropertyChanged(() => this.DateValue);
            }
        }

        private string emailValue = "";
        public string EmailValue
        {
            get
            {
                return emailValue;
            }
            set
            {
                emailValue = value;
                RaisePropertyChanged(() => this.EmailValue);
            }
        }
        private string phoneValue = "";
        public string PhoneValue
        {
            get
            {
                return phoneValue;
            }
            set
            {
                phoneValue = value;
                RaisePropertyChanged(() => this.PhoneValue);
            }
        }

        private ICommand dateValueChangedCommand;
        public ICommand DateValueChangedCommand
        {
            get
            {
                if (dateValueChangedCommand == null)
                {
                    dateValueChangedCommand = new DelegateCommand<object>(DateValueChanged);
                }
                return dateValueChangedCommand;
            }

        }
        private ICommand phoneValueChangedCommand;
        public ICommand PhoneValueChangedCommand
        {
            get
            {
                if (phoneValueChangedCommand == null)
                {
                    phoneValueChangedCommand = new DelegateCommand<object>(PhoneValueChanged);
                }
                return phoneValueChangedCommand;
            }


        }
        private ICommand emailValueChangedCommand;
        public ICommand EmailValueChangedCommand
        {
            get
            {
                if (emailValueChangedCommand == null)
                {
                    emailValueChangedCommand = new DelegateCommand<object>(EmailValueChanged);
                }
                return emailValueChangedCommand;
            }


        }

        private ICommand stringValidationCompletedCommand;
        public ICommand StringValidationCompletedCommand
        {
            get
            {
                if (stringValidationCompletedCommand == null)
                {
                    stringValidationCompletedCommand = new DelegateCommand<object>(StringValidationCompleted);
                }
                return stringValidationCompletedCommand;
            }
        }


        public void DateValueChanged(object param)
        {

            if (DateValue != null)
            {
                AddLog("Date of Birth - Value Changed: " + (DateValue).ToString());
            }
            else
            {
                AddLog("Date of Birth -Value Changed: NULL");
            }

        }
        public void PhoneValueChanged(object param)
        {
            if (PhoneValue != null)
            {
                AddLog("Phone Number - Value Changed: " + (PhoneValue).ToString());
            }
            else
            {
                AddLog("Phone Number - Value Changed: NULL");
            }

        }
        public void EmailValueChanged(object param)
        {
            if (EmailValue != null)
            {
                AddLog("Email Address - Value Changed: " + (EmailValue).ToString());
            }
            else
            {
                AddLog("Email Address - Value Changed: NULL");
            }

        }
        public void StringValidationCompleted(object param)
        {
            if (Regex.IsMatch(EmailValue.ToString(), EmailValidationString))
            {
                ValidationBorderBrush = Brushes.Transparent;
                AddLog("Validated : " + EmailValue.ToString() + " (Valid Input)");
            }
            else
            {
                ValidationBorderBrush = Brushes.Red;
                AddLog("Validated : " + EmailValue.ToString() + " (InValid Input)");
            }
        }
        private void AddLog(string eventlog)
        {
            coll.Add(eventlog);
            EventLogsCollection = coll;
        }

    }
}

