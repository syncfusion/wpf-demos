#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;

    public sealed class DelegateCommand
        : ICommand
    {
        #region [ Members ]

        private Action executeEvent;
        private Func<bool> canExecuteEvent;
        private string commandParameter;

        #endregion

        #region [ Constructor ]

        public DelegateCommand(Action executeCommand)
            : this(executeCommand, null) { }

        public DelegateCommand(Action executeCommand, Func<bool> canExecuteCommand)
        {
            if (executeCommand != null)
            {
                this.executeEvent = executeCommand;
                this.canExecuteEvent = canExecuteCommand;
            }
            //else
            //{
            //    throw new ArgumentNullException("Could not execute the command");
            //}
        }

        #endregion
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #region [ Properties ]

        public string CommandParameter
        {
            get { return this.commandParameter; }
            set { this.commandParameter = value; }
        }

        #endregion

        #region [ ICommand Members ]

        public bool CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
                this.commandParameter = parameter.ToString();
            this.Execute();
        }

        #endregion
        
        public bool CanExecute()
        {
            if (this.canExecuteEvent != null)
                return this.canExecuteEvent();
            return this.canExecuteEvent();
        }

        public void Execute()
        {
            this.executeEvent();
        }
    }
}
