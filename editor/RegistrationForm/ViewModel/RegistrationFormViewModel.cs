#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows;
using Syncfusion.Windows.Shared;
using Microsoft.Xaml.Behaviors;

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

    public class KeyEvent : Behavior<UIElement>
    {
       protected override void OnAttached()
       {
           AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
       }

       private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
       {
           if ((int) e.Key >= 44 && (int) e.Key <= 69 || e.Key == Key.Space || e.Key == Key.Tab)
               e.Handled = false;
           else
               e.Handled = true;
       }
    }
}


