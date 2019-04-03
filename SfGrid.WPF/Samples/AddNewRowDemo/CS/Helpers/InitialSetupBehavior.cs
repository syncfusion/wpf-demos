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
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Interactivity;

namespace AddNewRowDemo
{
    public class InitialSetupBehaviour: Behavior<SfDataGrid>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.RowValidating += OnRowValidating;
        }

        void OnRowValidating(object sender, RowValidatingEventArgs args)
        {
            if (args.RowData != null && string.IsNullOrEmpty((args.RowData as OrderInfo).CustomerID))
            {
                args.ErrorMessages.Add("CustomerID", "Customer ID field should not be null or empty");
                args.IsValid = false;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.RowValidating -= OnRowValidating;
        }
    }
}
