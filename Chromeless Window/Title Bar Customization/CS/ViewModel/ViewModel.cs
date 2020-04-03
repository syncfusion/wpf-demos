#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.Generic;
using System.Windows.Input;

namespace TitleBarCustomization
{
    /// <summary>
    /// Represents the business logic or behaviour for MainWindow.xaml.
    /// </summary>
    public class ViewModel :NotificationObject
    {
        /// <summary>
        /// Maintains the commnd for buttons.
        /// </summary>
        private ICommand command;

        /// <summary>
        /// Holds the order details.
        /// </summary>
        private List<OrderInfo> _ordersDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            command = new DelegateCommand(Execute, CanExecute);
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersDetails = order.GetOrdersDetails(100);
        }

        /// <summary>
        /// Gets or sets the command <see cref="ViewModel"/>
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
        }

        /// <summary>
        /// Gets or sets the orders details <see cref="ViewModel"/> class.
        /// </summary>
        /// <value>The orders details.</value>
        public List<OrderInfo> OrdersDetails
        {
            get { return _ordersDetails; }
            set { _ordersDetails = value; RaisePropertyChanged("OrdersDetails"); }
        }

        /// <summary>
        /// Indicates whether the command can execute.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Returns true.</returns>
        private bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Method which is used to execute the action.
        /// </summary>
        /// <param name="parameter"></param>
        private void Execute(object parameter)
        {
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/chromlesswindow/getting-started");
        }
    }
}
