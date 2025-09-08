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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FieldDialog : Window
    {
        #region Fields
        public event EventHandler CloseRequested;
        public event EventHandler UpdateRequested;
        readonly InvoiceItem invoiceItem;
        readonly ProductList m_productlist;
        const double DefaultTaxInPercent = 7;
        bool onInit;
        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public FieldDialog()
            : this(null, "Add Items", new ProductList())
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public FieldDialog(ProductList productList)
            : this(null, "Add Items", productList)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="title"></param>
        /// <param name="productList"></param>
        public FieldDialog(InvoiceItem newItem, string title, ProductList productList)
            : this(newItem, title, productList, 0)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="title"></param>
        public FieldDialog(InvoiceItem newItem, string title, ProductList productList, int productIndex)
        {
            this.InitializeComponent();

            //this.Height 

            if (newItem == null)
            {
                newItem = new InvoiceItem();
                newItem.ItemName = productList[0].Name;
                newItem.Rate = productList[0].Rate;
            }
            invoiceItem = newItem;
            onInit = true;
            this.DataContext = invoiceItem;
            this.Title = title;
            double currentRate = invoiceItem.Rate;

            m_productlist = productList;
            this.item.ItemsSource = m_productlist;
            this.item.DisplayMemberPath = "Name";
            this.item.SelectedItem = m_productlist[productIndex];
            if (currentRate != 0)
                this.rate.Content = currentRate;
            if (!newItem.Taxes.Equals("0"))
            {
                this.taxesTextBlock.Content = newItem.Taxes.ToString();
            }
            if (newItem.Rate != 0)
            {
                this.rate.Content = newItem.Rate;

                UpdateTotalAmount();
            }

            if (newItem.Quantity == 0)
            {
                newItem.Quantity = 1;
                this.quantity.Value = 1;
                CalculateTax();
                UpdateTotalAmount();
            }
            onInit = false;
        }
        #endregion
        #region Implementation

        #region Events
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
        private void updtButton_Click(object sender, RoutedEventArgs e)
        {
            FieldsUpdateEventArgs args = new FieldsUpdateEventArgs();
            args.UpdatedFields = invoiceItem;

            if (UpdateRequested != null)
            {
                UpdateRequested(this, args);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)e.OriginalSource;
            textBox.SelectAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (onInit)
                return;
            int value = 0;
            if (int.TryParse(quantity.Value.ToString(), out value))
            {
                CalculateTax();
                UpdateTotalAmount();
                quantity.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 64, 81));
            }
            else
            {
                quantity.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 37, 37));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (onInit)
                return;
            Product product = item.SelectedItem as Product;
            invoiceItem.ItemName = product.Name;
            if (!invoiceItem.Rate.Equals(product.Rate.ToString()))
            {
                invoiceItem.Rate = product.Rate;
                rate.Content = invoiceItem.Rate;
                CalculateTax();
                UpdateTotalAmount();
            }
        }

        #endregion
        #region Helper Method
        /// <summary>
        /// 
        /// </summary>
        public void InitializeFocus()
        {
            this.item.Focus();
        }
        /// <summary>
        /// 
        /// </summary>
        public Product SelectedProduct
        {
            set
            {
                if (value != null)
                {
                    item.SelectedItem = value;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void UpdateTotalAmount()
        {

            int quantityValue = GetQuantityAsInt();
            double rateValue = (double)rate.Content;
            double calculatedTax = invoiceItem.Taxes;
            double taxedAmount = (quantityValue * rateValue) + calculatedTax;
            this.totalAmount.Content = taxedAmount.ToString() + "$";
        }
        public int GetQuantityAsInt()
        {
            return (int)quantity.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CalculateTax()
        {
            double currentRate = (double)rate.Content;
            int currentQuantity = GetQuantityAsInt();

            {
                double calculatedTax = 0.0;
                calculatedTax = (currentRate * currentQuantity) * (DefaultTaxInPercent / 100);
                invoiceItem.Taxes = calculatedTax;
                taxesTextBlock.Content = "$" + calculatedTax.ToString();
            }
        }
        #endregion

        private void quantity_ValueChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (onInit)
                return;
            if (rate != null)
            {
                double value = (double)rate.Content;
                {
                    //rate.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 64, 81));
                    CalculateTax();
                    UpdateTotalAmount();
                }
            }
        }
        #endregion
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }



    /// <summary>
    /// 
    /// </summary>
    public class FieldsUpdateEventArgs : EventArgs
    {
        private InvoiceItem m_invoiceItem;
        public InvoiceItem UpdatedFields
        {
            get
            {
                return m_invoiceItem;
            }
            set
            {
                m_invoiceItem = value;
            }
        }
    }

}
