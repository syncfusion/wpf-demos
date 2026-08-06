using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.TreeGrid;
using System.Windows;

namespace syncfusion.treegriddemos.wpf
{ 
    public class SfTreeGridSelectionBehavior : Behavior<SfTreeGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.ReadLocalValue(SfTreeGrid.SelectionBackgroundProperty) != DependencyProperty.UnsetValue)
                AssociatedObject.ClearValue(SfTreeGrid.SelectionBackgroundProperty);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
    }
}