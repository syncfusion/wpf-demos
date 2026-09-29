using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System.Windows;

namespace syncfusion.datagriddemos.wpf
{
    public class DataGridRowSelectionBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.ReadLocalValue(SfDataGrid.RowSelectionBrushProperty) != DependencyProperty.UnsetValue)
                AssociatedObject.ClearValue(SfDataGrid.RowSelectionBrushProperty);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}