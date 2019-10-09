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
using System.Windows.Input;
#if NETCORE
using System.Diagnostics;
#endif
namespace WizardSample
{
    public class ViewModel : NotificationObject
    {
        #region Properties

        private string name = string.Empty;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                this.RaisePropertyChanged(() => this.Name);
                ValidatePage3();
            }
        }

        private string organisation = string.Empty;
        public string Organisation
        {
            get { return organisation; }
            set
            {
                organisation = value;
                this.RaisePropertyChanged(() => this.Organisation);
                ValidatePage3();
            }
        }

        private string key = string.Empty;
        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                this.RaisePropertyChanged(() => this.Key);
            }
        }

        private bool isenable;
        public bool IsEnable
        {
            get { return isenable; }
            set
            {
                isenable = value;
                this.RaisePropertyChanged(() => this.IsEnable);
            }
        }
        
        private float progressval=2;
        public float ProgressValue
        {
            get { return progressval; }
            set
            {
                progressval = value;
                this.RaisePropertyChanged(() => this.ProgressValue);
            }
        }

        public List<string> SkinCollection { get; set; }
#endregion

        #region ICommandMembers
        private ICommand textvalidate;
        public ICommand TextValidate
        {
            get { return textvalidate; }
            set
            {
                textvalidate = value;
                this.RaisePropertyChanged(() => this.TextValidate);
            }
        }

        private ICommand textchanged;
        public ICommand TextChanged
        {
            get { return textchanged; }
            set
            {
                textchanged = value;
                this.RaisePropertyChanged(() => this.TextChanged);
            }
        }

        private ICommand help;
        public ICommand Help
        {
            get { return help; }
            set
            {
                help = value;
                this.RaisePropertyChanged(() => this.Help);
            }
        }

        private ICommand progress;
        public ICommand Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                this.RaisePropertyChanged(() => this.Progress);
            }
        }

        private string  selectedTheme="Metro";
        public string SelectedTheme
        {
            get { return selectedTheme; }
            set
            {
                selectedTheme = value;
                this.RaisePropertyChanged(() => this.SelectedTheme);
            }
        }

       

        #endregion

        #region Constructor
        public ViewModel()
        {
            Help = new DelegateCommand<object>(WizardHelp);
            TextChanged = new DelegateCommand<object>(Masktextchanged);
            TextValidate = new DelegateCommand<object>(MaskValidated);
            Progress = new DelegateCommand<object>(InitateProgress);
            
        }
        
        #endregion

        #region Helpermethods
        private void ValidatePage3()
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

        private void Masktextchanged(object param)
        {
            ValidatePage3();
        }

        private void MaskValidated(object param)
        {
            ValidatePage3();
        }

        private void WizardHelp(object param)
        {
#if NETCORE
            ProcessStartInfo psi = new ProcessStartInfo { FileName = "http://help.syncfusion.com/UG/User%20Interface/WPF/Tools/documents/350wizard.htm", UseShellExecute = true }; 
            Process.Start (psi);
#else
            System.Diagnostics.Process.Start("http://help.syncfusion.com/UG/User%20Interface/WPF/Tools/documents/350wizard.htm");
#endif    
        }

        private void InitateProgress(object param)
        {
            for (float i = 0; i < 1000; i++)
                ProgressValue=ProgressValue+i;
        }

#endregion
    }
}
