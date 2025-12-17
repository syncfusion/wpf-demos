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
            //ES-973566 Prevent adding multiple items when SelectionMode is Single
            if (this.Target.SelectionMode == GridSelectionMode.Single)
                return;
            var items = this.Target.ItemsSource as List<ProductInfo>;
            this.Target.SelectedItems.Add(items[4]);
            this.Target.SelectedItems.Add(items[6]);
            this.Target.SelectedItems.Add(items[10]);
            this.Target.SelectedItems.Add(items[15]);
            this.Target.SelectedItems.Add(items[16]);
        }
    }
}
