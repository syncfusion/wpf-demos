#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace syncfusion.editordemos.wpf
{
    public class RegistrationFormViewModel : NotificationObject
    {
        public RegistrationFormViewModel()
        {
            ModelPerson = new Person();
        }

        private Person _modelPerson;
        public Person ModelPerson
        {
            get { return _modelPerson; }
            set
            {
                _modelPerson = value;
                this.RaisePropertyChanged(() => this.ModelPerson);
            }
        }

        private ICommand registerCommand;
        public ICommand RegisterCommand
        {
            get
            {
                if (registerCommand == null)
                {
                    registerCommand = new DelegateCommand<object>(SaveAll);
                }
                return registerCommand;
            }

        }
        public void SaveAll(object param)
        {
            ModelPerson.Fo();
        }
    }
}


