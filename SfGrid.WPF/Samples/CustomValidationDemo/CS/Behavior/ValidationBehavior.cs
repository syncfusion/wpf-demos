#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;

namespace CustomValidationDemo
{
    public class ValidationBehavior : Behavior<SfDataGrid>
    {

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.CurrentCellValidating += AssociatedObject_CurrentCellValidating;
            this.AssociatedObject.RowValidating += AssociatedObject_RowValidating;
        }

        void AssociatedObject_RowValidating(object sender, RowValidatingEventArgs args)
        {
            var data = args.RowData as OrderInfo;
            decimal columnData = 0;
            decimal compareData = 0;
            double total = data.Freight + data.Expense;            
            decimal.TryParse(total.ToString(), out columnData);
            decimal.TryParse("3000", out compareData);

            NumberFormatInfo numberFormatInfo = new NumberFormatInfo()
            {
                CurrencyDecimalDigits = NumberFormatInfo.CurrentInfo.CurrencyDecimalDigits,
                CurrencyDecimalSeparator = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator,
                CurrencyGroupSeparator = NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator,
                CurrencyNegativePattern = NumberFormatInfo.CurrentInfo.CurrencyNegativePattern,
                CurrencyPositivePattern = NumberFormatInfo.CurrentInfo.CurrencyPositivePattern,
                CurrencySymbol = NumberFormatInfo.CurrentInfo.CurrencySymbol,
            };
            string columninfo = columnData.ToString("C", numberFormatInfo);
            string compareinfo = compareData.ToString("C", numberFormatInfo);
            if (Convert.ToDouble(columninfo.Substring(1, columninfo.Length - 1)) < Convert.ToDouble(compareinfo.Substring(1, compareinfo.Length - 1)))
            {
                args.ErrorMessages.Add("Expense", "Sum of Expense and Freight should be a minimum of 3000 to be eligible for Discount.");
                args.IsValid = false;
            }         
        }

        void AssociatedObject_CurrentCellValidating(object sender, CurrentCellValidatingEventArgs args)
        {
            if (args.Column.MappingName == "Discount" && Convert.ToDouble(args.NewValue) > 40)
            {
                args.ErrorMessage = "Discount should not exceed 40 percent.";
                args.IsValid = false;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.CurrentCellValidating -= AssociatedObject_CurrentCellValidating;
            this.AssociatedObject.RowValidating -= AssociatedObject_RowValidating;
        }
    }
}
