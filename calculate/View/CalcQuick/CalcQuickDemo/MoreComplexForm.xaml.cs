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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.Calculate;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;

namespace syncfusion.calculatedemos.wpf
{
    /// <summary>
    /// Interaction logic for MoreComplexForm.xaml
    /// </summary>
    public partial class MoreComplexForm : ChromelessWindow
    {
        #region Constructor

        public MoreComplexForm()
        {
            InitializeComponent();

            CalcQuickDemoDataViewModel dat = new CalcQuickDemoDataViewModel();
            this.cboDiscount.ItemsSource = dat.BindDiscount();
            this.cboItem.ItemsSource = dat.BindItem();
            this.txtPrice.MouseLeave += new MouseEventHandler(txtPrice_MouseLeave);
            this.txtQty.MouseLeave += new MouseEventHandler(txtPrice_MouseLeave);
            this.txtShipping.MouseLeave += new MouseEventHandler(txtPrice_MouseLeave);
            this.txtTax.MouseLeave += new MouseEventHandler(txtPrice_MouseLeave);
            this.txtTotal.MouseLeave += new MouseEventHandler(txtPrice_MouseLeave);
        }

        #endregion
        protected override void OnClosed(EventArgs e)
        {
            this.txtPrice.MouseLeave -= new MouseEventHandler(txtPrice_MouseLeave);
            this.txtQty.MouseLeave -= new MouseEventHandler(txtPrice_MouseLeave);
            this.txtShipping.MouseLeave -= new MouseEventHandler(txtPrice_MouseLeave);
            this.txtTax.MouseLeave -= new MouseEventHandler(txtPrice_MouseLeave);
            this.txtTotal.MouseLeave -= new MouseEventHandler(txtPrice_MouseLeave);
            base.OnClosed(e);
        }
        #region Event Handler
        /// <summary>
        /// Set Calculator properties on MouseLeave
        /// </summary>
        void txtPrice_MouseLeave(object sender, MouseEventArgs e)
        {
            calculator["Quantity"] = this.txtQty.Text;
            calculator["Price"] = this.txtPrice.Text;
            calculator["Discount"] = this.cboDiscount.Text;
            calculator["Shipping"] = this.txtShipping.Text;
            calculator["Tax"] = this.txtTax.Text;
            calculator["Total"] = this.txtTotal.Text;

            calculator.SetDirty();

            this.txtQty.Text = calculator["Quantity"];
            this.txtPrice.Text = calculator["Price"];
            this.cboDiscount.Text = calculator["Discount"];
            this.txtShipping.Text = calculator["Shipping"];
            this.txtTax.Text = calculator["Tax"];
            this.txtTotal.Text = calculator["Total"];
        }

        CalcQuick calculator = new CalcQuick();
        /// <summary>
        /// Instantiate a CalcQuick object
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtPrice.Text = "0";
            //Instantiate a CalcQuick object:
            calculator["Quantity"] = this.txtQty.Text;
            calculator["Price"] = this.txtPrice.Text;
            calculator["Discount"] = this.cboDiscount.Text;
            calculator["Shipping"] = this.txtShipping.Text;
            calculator["Tax"] = this.txtTax.Text;
            calculator["Total"] = this.txtTotal.Text;

            calculator.SetDirty();

            this.txtQty.Text = calculator["Quantity"];
            this.txtPrice.Text = calculator["Price"];
            this.cboDiscount.Text = calculator["Discount"];
            this.txtShipping.Text = calculator["Shipping"];
            this.txtTax.Text = calculator["Tax"];
            this.txtTotal.Text = calculator["Total"];
        }
    #endregion

}
}
