
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Class represents the DataTemplateSelector for MenuMerging sample.
    /// </summary>
    public class ItemDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Method which is used to select the template.
        /// </summary>
        /// <param name="item">Template to be changed.</param>
        /// <param name="container">Specifies the control container.</param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if ((item is MenuMergingRibbonItem && (item as MenuMergingRibbonItem).IsSplitButton) || (item is ModelTabRibbonItem && (item as ModelTabRibbonItem).IsSplitButton))
                {
                    return element.FindResource("Splitbutton") as DataTemplate;
                }
                else if ((item is MenuMergingRibbonItem && (item as MenuMergingRibbonItem).IsCheckBox) || (item is ModelTabRibbonItem && (item as ModelTabRibbonItem).IsCheckBox))
                {
                    return element.FindResource("CheckBox") as DataTemplate;
                }
                else if ((item is MenuMergingRibbonItem && (item as MenuMergingRibbonItem).HasTablePicker) || (item is ModelTabRibbonItem && (item as ModelTabRibbonItem).HasTablePicker))
                {
                    return element.FindResource("DropDownButtonWithTablePickerUI") as DataTemplate;
                }
                else if ((item is MenuMergingRibbonItem && (item as MenuMergingRibbonItem).IsDropDownButton) || (item is ModelTabRibbonItem && (item as ModelTabRibbonItem).IsDropDownButton))
                {
                    return element.FindResource("DropDownButton") as DataTemplate;
                }
                else if (item is ModelTabRibbonItem && (item as ModelTabRibbonItem).IsSeparator)
                {
                    return element.FindResource("RibbonSeparator") as DataTemplate;
                }
                else
                {
                    return element.FindResource("Ribbonbutton") as DataTemplate;
                }
            }
            return null;
        }
    }
}
