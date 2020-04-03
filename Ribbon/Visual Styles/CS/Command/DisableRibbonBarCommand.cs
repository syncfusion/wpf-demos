#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RibbonSample
{
    /// <summary>
    /// Represents the control when command executes the action occurs.
    /// </summary>
    class DisableRibbonBarCommand : ICommand
    {
        #region Command Delegates
        /// <summary>
        /// The command uses action delegate as first argument.
        /// </summary>
        Action<object> executeAction;

        /// <summary>
        /// The command uses func delegate as second argument
        /// </summary>
        Func<object, bool> canExecute;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DisableRibbonBarCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The <see cref="System.Action"/>instance containing the delegates.</param>
        /// <param name="canExecute">The <see cref="System.Func{T, TResult}"/>instance containing the delegates.</param>
        public DisableRibbonBarCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.executeAction = executeAction;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Indicates whether the command can execute on the current command target.
        /// </summary>
        /// <param name="parameter">Specifies the object of canexecute method.</param>
        /// <returns>
        /// The canexecute method returns boolean.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Performs the actions that are associated with the command.
        /// </summary>
        /// <param name="parameter">Specifies the object of execute method.</param>
        public void Execute(object parameter)
        {
            executeAction(parameter);
        }
        #endregion

        #region Events
        /// <summary>
        /// Event handler of the icommand interface. 
        /// </summary>
        public event EventHandler CanExecuteChanged;
        #endregion
    }


    class RightToLeftCommand : ICommand
    {
        #region Command Delegates
        /// <summary>
        /// The command uses action and func delegates.    
        /// </summary>
        Action<object> executeActionRTL;
        Func<object, bool> canExecuteRTL;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RightToLeftCommand"/> class.
        /// </summary>
        /// <param name="executeActionRTL">The <see cref="System.Action"/>instance containing the delegates.</param>
        /// <param name="canExecuteRTL">The <see cref="System.Func{T, TResult}"/>instance containing the delegates.</param>
        public RightToLeftCommand(Action<object> executeActionRTL, Func<object, bool> canExecuteRTL)
        {
            this.canExecuteRTL = canExecuteRTL;
            this.executeActionRTL = executeActionRTL;
        }
        #endregion

        #region Events
        /// <summary>
        /// Event handler of the icommand interface.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Indicates whether the command can execute on the current command target.
        /// </summary>
        /// <param name="parameter">Specifies the object of canexecute method.</param>
        /// <returns>The canexecute method returns boolean.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Performs the actions that are associated with the command.
        /// </summary>
        /// <param name="parameter">Specifies the object of execute method.</param>
        public void Execute(object parameter)
        {
            executeActionRTL(parameter);
        }
        #endregion
    }
}
