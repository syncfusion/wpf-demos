#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Printing
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// A command class that initiates action over the respective object.
    /// </summary>
    public class PrintCommand:ICommand
    {
        private readonly Action<object> executeEvent;
        private readonly Predicate<object> canExecuteEvent;

        /// <summary>
        /// Default constructor to execute an action.
        /// </summary>
        /// <param name="execute">action to execute.</param>
        public PrintCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Constructor to execute an action only on approval.
        /// </summary>
        /// <param name="execute">action to execute.</param>
        /// <param name="canExecute">whether to execute or not</param>
        public PrintCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            this.executeEvent = execute;
            this.canExecuteEvent = canExecute;
        }


        /// <summary>
        /// An event that determines whether the proposed execution can be changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Gets whether to execute the action or not.
        /// </summary>
        /// <param name="parameter">element that undergoes action.</param>
        /// <returns>a boolean value</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecuteEvent == null || this.canExecuteEvent(parameter);
        }

        /// <summary>
        /// A method to execute action.
        /// </summary>
        /// <param name="parameter">object to incur action.</param>
        public void Execute(object parameter)
        {
            this.executeEvent(parameter);
        }
    }
}