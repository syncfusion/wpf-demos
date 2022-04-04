#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    public class CheckBoxSelectorColumnTrigger : TargetedTriggerAction<SfDataGrid>
    {
        protected override void Invoke(object parameter)
        {
            var items = this.Target.ItemsSource as List<ProductInfo>;
            this.Target.SelectedItems.Add(items[4]);
            this.Target.SelectedItems.Add(items[6]);
            this.Target.SelectedItems.Add(items[10]);
            this.Target.SelectedItems.Add(items[15]);
            this.Target.SelectedItems.Add(items[16]);
        }
    }
}
