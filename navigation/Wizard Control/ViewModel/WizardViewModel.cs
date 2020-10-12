#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Windows.Input;
namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the behaviour or business logic for Window1.xaml.
    /// </summary>
    public class WizardViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the name in wizard.
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        /// Maintains the organisation in wizard.
        /// </summary>
        private string organisation = string.Empty;

        /// <summary>
        /// Maintains the 16 digit key in wizard.
        /// </summary>
        private string key = string.Empty;

        /// <summary>
        /// Maintains the isEnable for wizard.
        /// </summary>
        private bool isEnable;

        /// <summary>
        /// Maintains the command for helpCommand.
        /// </summary>
        private ICommand helpCommand;

        /// <summary>
        ///  Maintains the command for textValidateCommand.
        /// </summary>
        private ICommand textValidateCommand;

        /// <summary>
        ///  Maintains the command for textChangedCommand.
        /// </summary>
        private ICommand textChangedCommand;

        /// <summary>
        ///  Maintains the command for progressCommand.
        /// </summary>
        private ICommand progressCommand;

        /// <summary>
        /// Maintains the progress bar value.
        /// </summary>
        private int progressBarValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="WizardViewModel"/> class.
        /// </summary>
        public WizardViewModel()
        {
            helpCommand = new DelegateCommand<object>(WizardHelp);
            textChangedCommand = new DelegateCommand<object>(Masktextchanged);
            textValidateCommand = new DelegateCommand<object>(MaskValidated);
            progressCommand = new DelegateCommand<object>(InitateProgress);
        }

        /// <summary>
        /// Gets or sets the name in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
                UnlockKey();
            }
        }

        /// <summary>
        /// Gets or sets the organisation in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public string Organisation
        {
            get
            {
                return organisation;
            }
            set
            {
                organisation = value;
                RaisePropertyChanged("Organisation");
                UnlockKey();
            }
        }

        /// <summary>
        /// Gets or sets the key in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
                RaisePropertyChanged("Key");
                UnlockKey();
            }
        }

        /// <summary>
        /// Indicates whether isEnable in wizard is true or not <see cref="WizardViewModel"/> class.
        /// </summary>
        public bool IsEnable
        {
            get
            {
                return isEnable;
            }
            set
            {
                isEnable = value;
                RaisePropertyChanged("IsEnable");
            }
        }     

        /// <summary>
        /// Gets or sets the command for textValidateCommand in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public ICommand TextValidateCommand
        {
            get
            {
                return textValidateCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for textChange in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public ICommand TextChangedCommand
        {
            get
            {
               return textChangedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for helpCommand in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for progressCommand in wizard <see cref="WizardViewModel"/> class.
        /// </summary>
        public ICommand ProgressCommand
        {
            get
            {
                return progressCommand;
            }
        }

        /// <summary>
        /// Gets or sets the progress bar value <see cref="WizardViewModel"/> class.
        /// </summary>
        public int ProgressBarValue
        {
            get
            {
                return progressBarValue;
            }
            set
            {
                progressBarValue = value;
                RaisePropertyChanged("ProgressBarValue");
            }
        }

        /// <summary>
        /// Methods used to validate page 3 in wizard.
        /// </summary>
        private void UnlockKey()
        {
            if (Name != string.Empty && Organisation != string.Empty && Key != string.Empty && Key != "____-____-____-____")
            {
                IsEnable = true;
            }
            else
            {
                IsEnable = false;
            }
        }

        /// <summary>
        ///  Methods used to validate page 3 in wizard when masktext changed.
        /// </summary>
        /// <param name="param">Specifies the parameter.</param>
        private void Masktextchanged(object param)
        {
            UnlockKey();
        }

        /// <summary>
        /// Methods used to validate page 3 in wizard when masktext validated.
        /// </summary>
        /// <param name="param">Specifies the parameter.</param>
        private void MaskValidated(object param)
        {
            UnlockKey();
        }

        /// <summary>
        /// Methods used for wizard helpCommand.
        /// </summary>
        /// <param name="param">Specifies the parameter.</param>
        private void WizardHelp(object param)
        {
            System.Diagnostics.Process.Start("http://help.syncfusion.com/UG/User%20Interface/WPF/Tools/documents/350wizard.htm");
        }

        /// <summary>
        /// Method used to initate the progressCommand in wizard.
        /// </summary>
        /// <param name="param">Specifies the parameter.</param>     
        private void InitateProgress(object param)
        {
            ProgressBarValue=100;
        }
    }
}
