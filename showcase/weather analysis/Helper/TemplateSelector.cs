#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Markup;

namespace syncfusion.weatheranalysis.wpf
{
    public class ComboBoxTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SelectedItemTemplate { get; set; }
        public DataTemplateSelector SelectedItemTemplateSelector { get; set; }
        public DataTemplate DropdownItemsTemplate { get; set; }
        public DataTemplateSelector DropdownItemsTemplateSelector { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            var itemToCheck = container;

            // Search up the visual tree, stopping at either a ComboBox or
            // a ComboBoxItem (or null). This will determine which template to use
            while (itemToCheck!=null
            && !(itemToCheck is ComboBox)
            && !(itemToCheck is ComboBoxItem))
                itemToCheck = VisualTreeHelper.GetParent(itemToCheck);

            // If you stopped at a ComboBoxItem, you're in the dropdown
            var inDropDown = itemToCheck is ComboBoxItem;

            return inDropDown
                ? DropdownItemsTemplate ?? DropdownItemsTemplateSelector?.SelectTemplate(item, container)
                : SelectedItemTemplate ?? SelectedItemTemplateSelector?.SelectTemplate(item, container);
        }

    }

    public class ComboBoxTemplateSelectorExtension : MarkupExtension
    {
        public DataTemplate SelectedItemTemplate { get; set; }
        public DataTemplateSelector SelectedItemTemplateSelector { get; set; }
        public DataTemplate DropdownItemsTemplate { get; set; }
        public DataTemplateSelector DropdownItemsTemplateSelector { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
            => new ComboBoxTemplateSelector()
            {
                SelectedItemTemplate = SelectedItemTemplate,
                SelectedItemTemplateSelector = SelectedItemTemplateSelector,
                DropdownItemsTemplate = DropdownItemsTemplate,
                DropdownItemsTemplateSelector = DropdownItemsTemplateSelector
            };
    }
}
