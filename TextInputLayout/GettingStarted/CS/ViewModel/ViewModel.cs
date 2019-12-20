using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace GettingStarted
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        #region event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region fields

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


        #endregion

        #region properties

        public ObservableCollection<string> ComboBoxContent { get; set; }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                IsFirstNameEmpty = false;
                NotifyPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                IsLastNameEmpty = false;
                NotifyPropertyChanged("LastName");
            }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                IsMobileNumberEmpty = false;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        public string AlternativePhoneNumber
        {
            get { return alternativePhoneNumber; }
            set
            {
                alternativePhoneNumber = value;
                IsAlternativeMobileNumberEmpty = false;
                NotifyPropertyChanged("AlternativePhoneNumber");
            }
        }

        public string Mail
        {
            get { return mail; }
            set
            {
                mail = value;
                IsMailIdEmpty = false;
                NotifyPropertyChanged("Mail");
            }
        }

        public string AlternativeMail
        {
            get { return alternativeMail; }
            set
            {
                alternativeMail = value;
                IsAlternativeMailIdEmpty = false;
                NotifyPropertyChanged("AlternativeMail");
            }
        }

        public string CurrentAddress
        {
            get { return currentAddress; }
            set
            {
                currentAddress = value;
                IsAddressEmpty = false;
                NotifyPropertyChanged("CurrentAddress");
            }
        }

        public string PermanentAddress
        {
            get { return permanentAddress; }
            set
            {
                permanentAddress = value;
                IsAlternativeAddressEmpty = false;
                NotifyPropertyChanged("PermanentAddress");
            }
        }

        public string Notes
        {
            get { return notes; }
            set
            {
                notes = value;
                NotifyPropertyChanged("Notes");
            }
        }

        private bool isFirstNameEmpty;

        public bool IsFirstNameEmpty
        {
            get { return isFirstNameEmpty; }
            set
            {
                isFirstNameEmpty = value;
                NotifyPropertyChanged("IsFirstNameEmpty");
            }
        }

        private bool isLastNameEmpty;

        public bool IsLastNameEmpty
        {
            get { return isLastNameEmpty; }
            set
            {
                isLastNameEmpty = value;
                NotifyPropertyChanged("IsLastNameEmpty");
            }
        }

        private bool isAddressEmpty;

        public bool IsAddressEmpty
        {
            get { return isAddressEmpty; }
            set
            {
                isAddressEmpty = value;
                NotifyPropertyChanged("IsAddressEmpty");
            }
        }

        private bool isAlternativeAddressEmpty;

        public bool IsAlternativeAddressEmpty
        {
            get { return isAlternativeAddressEmpty; }
            set
            {
                isAlternativeAddressEmpty = value;
                NotifyPropertyChanged("IsAlternativeAddressEmpty");
            }
        }

        private bool isMobileNumberEmpty;

        public bool IsMobileNumberEmpty
        {
            get { return isMobileNumberEmpty; }
            set
            {
                isMobileNumberEmpty = value;
                NotifyPropertyChanged("IsMobileNumberEmpty");
            }
        }

        private bool isAlternativeMobileNumberEmpty;

        public bool IsAlternativeMobileNumberEmpty
        {
            get { return isAlternativeMobileNumberEmpty; }
            set
            {
                isAlternativeMobileNumberEmpty = value;
                NotifyPropertyChanged("IsAlternativeMobileNumberEmpty");
            }
        }

        private bool isMailIdEmpty;

        public bool IsMailIdEmpty
        {
            get { return isMailIdEmpty; }
            set
            {
                isMailIdEmpty = value;
                NotifyPropertyChanged("IsMailIdEmpty");
            }
        }

        private bool isAlternativeMailIdEmpty;

        public bool IsAlternativeMailIdEmpty
        {
            get { return isAlternativeMailIdEmpty; }
            set
            {
                isAlternativeMailIdEmpty = value;
                NotifyPropertyChanged("IsAlternativeMailIdEmpty");
            }
        }

        public bool IsHintAlwaysFloated
        {
            get { return isHintAlwaysFloated; }
            set
            {
                isHintAlwaysFloated = value;
                NotifyPropertyChanged("EnableHintAlwaysFloated");
            }
        }

        public ICommand ResetCommand { get; private set; }

        public ICommand SubmitCommand { get; private set; }

        #endregion

        #region ctor

        public SignUpViewModel()
        {
            SubmitCommand = new SubmitResetCommand(new Action(OnSubmitButtonClicked));
            ResetCommand = new SubmitResetCommand(new Action(OnResetButtonClicked));
            ComboBoxContent = new ObservableCollection<string>
        {
            "AlwaysFloat",
            "Float"
        };
        }

        #endregion

        #region event

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// This method will be called whenever reset button is clicked.
        /// </summary>
        private void OnResetButtonClicked()
        {
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
            IsFirstNameEmpty = string.IsNullOrEmpty(FirstName);
            IsLastNameEmpty = string.IsNullOrEmpty(LastName);
            IsMobileNumberEmpty = string.IsNullOrEmpty(PhoneNumber);
            IsAlternativeMobileNumberEmpty = string.IsNullOrEmpty(AlternativePhoneNumber);
            IsAddressEmpty = string.IsNullOrEmpty(CurrentAddress);
            IsAlternativeAddressEmpty = string.IsNullOrEmpty(PermanentAddress);
            IsMailIdEmpty = string.IsNullOrEmpty(Mail);
            IsAlternativeMailIdEmpty = string.IsNullOrEmpty(AlternativeMail);

            if (!IsFirstNameEmpty && !IsLastNameEmpty && !IsAddressEmpty && !IsAlternativeAddressEmpty 
                && !IsMailIdEmpty && !IsAlternativeMailIdEmpty && !IsMobileNumberEmpty && !IsAlternativeMobileNumberEmpty)
            {
                MessageBox.Show("Your details has been registered successfully", "Success", MessageBoxButton.OK);
            }
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

        public event EventHandler CanExecuteChanged;

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
