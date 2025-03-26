#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.invoice.wpf
{
    /// <summary>
    /// Interaction logic for AddressDialog.xaml
    /// </summary>
    public partial class AddressDialog : Window
    {
        public event EventHandler CloseRequested;
        public event EventHandler UpdateRequested;
        BillingInformation info;
        /// <summary>
        /// 
        /// </summary>
        public AddressDialog()
            : this(new BillingInformation())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="billInfo"></param>
        public AddressDialog(BillingInformation billInfo)
        {
            this.InitializeComponent();
            //var bounds = Window.Current.Bounds;
            //this.Height = bounds.Height;
            info = billInfo;
            this.DataContext = info;
        }
        ///// <summary>
        ///// Invoked when this page is about to be displayed in a Frame.
        ///// </summary>
        ///// <param name="e">Event data that describes how this page was reached.  The Parameter
        ///// property is typically used to configure the page.</param>
        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (CloseRequested != null)
                CloseRequested(this, EventArgs.Empty);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            BillingInfoEventArgs args = new BillingInfoEventArgs();
            args.BillingInformation = info;
            if (UpdateRequested != null)
                UpdateRequested(this, args);
        }

        private void invoiceNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            int value = 0;
            if (int.TryParse(invoiceNo.Text, out value))
            {
                invoiceNo.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 64, 81));
            }
            else
            {

                invoiceNo.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 37, 37));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class BillingInfoEventArgs : EventArgs
    {
        BillingInformation m_billInfo;
        public BillingInformation BillingInformation
        {
            get { return m_billInfo; }
            set { m_billInfo = value; }
        }
    }
}
