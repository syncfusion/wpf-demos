#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System.Windows.Controls;
    using System.Windows;

    /// <summary>
    /// A custom DataTemplateSelector that selects a DataTemplate based on the Category of a MenuItem.
    /// </summary>
    public class CardTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Ready to Delivery" category.
        /// </summary>
        public DataTemplate DeliveryCardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Menu" category.
        /// </summary>
        public DataTemplate MenuCardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Ready to Serve" category.
        /// </summary>
        public DataTemplate ReadyToServeCardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Order" category.
        /// </summary>
        public DataTemplate OrderCardTemplate { get; set; }

        /// <summary>
        /// Selects a DataTemplate based on the Category property of the MenuItem.
        /// Returns the appropriate template or falls back to the base implementation if no match is found.
        /// </summary>
        /// <param name="item">The data object to evaluate for template selection.</param>
        /// <param name="container">The container in which the template will be applied.</param>
        /// <returns>A DataTemplate corresponding to the item's category.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var model = item as MenuItem;

            if (model == null || model.Category == null)
            {
                return base.SelectTemplate(item, container);
            }
            
            var category = model.Category as string;

            return category == "Menu" ? MenuCardTemplate :
                   category == "Ready to Delivery" ? DeliveryCardTemplate :
                   category == "Ready to Serve" ? ReadyToServeCardTemplate :
                   (category == "Dining" || category == "Delivery") ? OrderCardTemplate :
                   base.SelectTemplate(item, container);
        }
    }
}