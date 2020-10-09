// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="">
//   
// </copyright>
// <summary>
//   Represents the command class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#if WINRT_USING
using System.Threading.Tasks;
#endif

namespace DiagramBuilder.Utility
{
    using System;
    using System.Windows.Input;

    /// <summary>
    ///     Represents the command class.
    /// </summary>
    internal class Command : ICommand
    {
        /// <summary>
        ///     Reprsents the can execute.
        /// </summary>
        private Func<object, bool> canExecute;

        /// <summary>
        ///     Reprsents the can execute cache.
        /// </summary>
        private bool canExecuteCache;

        /// <summary>
        ///     Reprsents the execute action.
        /// </summary>
        private Action<object> executeAction;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="executeAction">
        /// The execute action.
        /// </param>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        public Command(Action<object> executeAction, Func<object, bool> canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        /// <summary>
        ///     Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command
        ///     can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.
        ///     If the command does not require data to be passed,
        ///     this object can be set to null.
        /// </param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (parameter == null || this.canExecute == null)
            {
                return true;
            }

            bool tempCanExecute = this.canExecute(parameter);

            if (this.canExecuteCache != tempCanExecute)
            {
                this.canExecuteCache = tempCanExecute;
                if (this.CanExecuteChanged != null)
                {
                    this.CanExecuteChanged(this, new EventArgs());
                }
            }

            return this.canExecuteCache;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command.
        ///     If the command does not require data to be passed,
        ///     this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            this.executeAction(parameter);
        }
    }
}