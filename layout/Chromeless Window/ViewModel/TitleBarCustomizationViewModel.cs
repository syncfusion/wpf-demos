#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Represents the business logic or behaviour for MainWindow.xaml.
    /// </summary>
    public class TitleBarCustomizationViewModel :NotificationObject
    {
        /// <summary>
        /// Maintains the commnd for buttons.
        /// </summary>
        private ICommand helpCommand;

        /// <summary>
        /// Maintains the textbox text.
        /// </summary>
        private string textProperty;

        /// <summary>
        /// Maintains the textChangedCommand for buttons.
        /// </summary>
        private ICommand textChangedCommand;

        /// <summary>
        /// Maintains the findNextCommand for buttons.
        /// </summary>
        private ICommand findNextCommand;

        /// <summary>
        /// Maintains the findPreviousCommand for buttons.
        /// </summary>
        private ICommand findPreviousCommand;

        /// <summary>
        /// Holds the order details.
        /// </summary>
        private List<OrderInfo> orderDetails;

        /// <summary>
        /// Maintains the sf data grid.
        /// </summary>
        private static SfDataGrid dataGrid = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        public TitleBarCustomizationViewModel()
        {
            helpCommand = new DelegateCommand<object>(Execute);
            findNextCommand = new DelegateCommand<object>(ExecuteFindNext);
            findPreviousCommand = new DelegateCommand<object>(ExecuteFindPrevious);
            textChangedCommand = new DelegateCommand<object>(ExecuteTextChanged);
            OrderInfoRepository order = new OrderInfoRepository();
            OrdersDetails = order.GetOrdersDetails(100);
        }

        /// <summary>
        /// Gets the data grid.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns>Returns window property.</returns>
        public static string GetSfDataGrid(DependencyObject obj)
        {
            return (string)obj.GetValue(SfDataGridProperty);
        }

        /// <summary>
        /// Sets the data grid.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="value">Specifies the window.</param>
        public static void SetSfDataGrid(DependencyObject obj, SfDataGrid value)
        {
            obj.SetValue(SfDataGridProperty, value);
        }

        // Using a DependencyProperty as the backing store for SfDataGrid. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SfDataGridProperty =
            DependencyProperty.RegisterAttached("SfDataGrid", typeof(string), typeof(TitleBarCustomizationViewModel), new FrameworkPropertyMetadata(OnSfDataGridChanged));

        /// <summary>
        /// Method executes when dependency property changes
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="args">Specifies the event.</param>        
        public static void OnSfDataGridChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            dataGrid = obj as SfDataGrid;
        }

        /// <summary>
        /// Gets or sets the helpCommand <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the textChangedCommand <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        public ICommand TextChangedCommand
        {
            get
            {
                return textChangedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the findNextCommand <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        public ICommand FindNextCommand
        {
            get
            {
                return findNextCommand;
            }
        }

        /// <summary>
        /// Gets or sets the findPreviousCommand <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        public ICommand FindPreviousCommand
        {
            get
            {
                return findPreviousCommand;
            }
        }

        /// <summary>
        /// Gets or sets the text <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        public string TextProperty
        {
            get
            {
                return textProperty;
            }
            set
            {
                textProperty = value;
                RaisePropertyChanged("TextProperty");
            }
        }

        /// <summary>
        /// Gets or sets the orders details <see cref="TitleBarCustomizationViewModel"/> class.
        /// </summary>
        /// <value>The orders details.</value>
        public List<OrderInfo> OrdersDetails
        {
            get
            {
                return orderDetails;
            }
            set
            {
                orderDetails = value;
                RaisePropertyChanged("OrdersDetails");
            }
        }

        /// <summary>
        /// Method which is used to execute the HelpCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void Execute(object parameter)
        {
            System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/chromlesswindow/getting-started");
        }

        /// <summary>
        /// Method which is used to execute the FindNextCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteFindNext(object parameter)
        {
            dataGrid.SearchHelper.FindNext(TextProperty);
        }

        /// <summary>
        /// Method which is used to execute the TextChangedCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteTextChanged(object parameter)
        {
            dataGrid.SearchHelper.Search(TextProperty);
        }

        /// <summary>
        /// Method which is used to execute the FindPreviousCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteFindPrevious(object parameter)
        {
            dataGrid.SearchHelper.FindPrevious(TextProperty);           
        }
    }
}
