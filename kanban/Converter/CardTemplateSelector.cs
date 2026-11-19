namespace syncfusion.kanbandemos.wpf
{
    using System.Windows.Controls;
    using System.Windows;

    /// <summary>
    /// A custom DataTemplateSelector that selects a DataTemplate based on the Category of a card item.
    /// </summary>
    public class CardTemplateSelector : DataTemplateSelector
    {
        #region Customization sample properties

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

        #endregion

        #region Sorting sample properties

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Open" category.
        /// </summary>
        public DataTemplate ToDoTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "In Progress" category.
        /// </summary>
        public DataTemplate InProgressTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Code Review" category.
        /// </summary>
        public DataTemplate ReviewTemplate { get; set; }

        /// <summary>
        /// Gets or sets the DataTemplate used for items with the "Done" category.
        /// </summary>
        public DataTemplate DoneTemplate { get; set; }

        #endregion

        #region Override methods

        /// <summary>
        /// Selects a DataTemplate based on the Category property of the MenuItem.
        /// Returns the appropriate template or falls back to the base implementation if no match is found.
        /// </summary>
        /// <param name="item">The data object to evaluate for template selection.</param>
        /// <param name="container">The container in which the template will be applied.</param>
        /// <returns>A DataTemplate corresponding to the item's category.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // Return data template for kanban sorting demo.
            if (item is CardDetails cardDetails)
            {
                if (cardDetails == null || cardDetails.Category == null)
                {
                    return base.SelectTemplate(item, container);
                }

                var category = cardDetails.Category as string;
                return category == "Open" ? ToDoTemplate :
                       category == "In Progress" ? InProgressTemplate :
                       category == "Code Review" ? ReviewTemplate :
                       (category == "Done" ? DoneTemplate :
                      base.SelectTemplate(item, container));
            }

            // Return data template for kanban customization demo.
            if (item is MenuItem menuItem)
            {
                if (menuItem == null || menuItem.Category == null)
                {
                    return base.SelectTemplate(item, container);
                }

                var category = menuItem.Category as string;
                return category == "Menu" ? MenuCardTemplate :
                       category == "Ready to Delivery" ? DeliveryCardTemplate :
                       category == "Ready to Serve" ? ReadyToServeCardTemplate :
                       (category == "Dining" || category == "Delivery") ? OrderCardTemplate :
                       base.SelectTemplate(item, container);
            }

            return null;
        }

        #endregion
    }
}