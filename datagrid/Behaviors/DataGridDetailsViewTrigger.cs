using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System.Windows;

namespace syncfusion.datagriddemos.wpf
{
    public class DataGridDetailsViewTrigger : TargetedTriggerAction<SfDataGrid>
    {
        protected override void Invoke(object parameter)
        {
            this.Target.ExpandAllDetailsView();
        }
    }
}
