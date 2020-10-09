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

namespace PerformanceDemo
{
    internal class Commands : ICommand
    {
        private Action<object> executeOnDemandLoading;
        private Func<object, bool> canExecuteOnDemandLoading;

        public Commands(Action<object> executeOnDemandLoading, Func<object, bool> canExecuteOnDemandLoading)
        {
            this.executeOnDemandLoading = executeOnDemandLoading;
            this.canExecuteOnDemandLoading = canExecuteOnDemandLoading;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this.canExecuteOnDemandLoading(parameter);
        }

        public void Execute(object parameter)
        {
            this.executeOnDemandLoading(parameter);
        }
    }
}
