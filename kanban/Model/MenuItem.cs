#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a menu item with details such as name, description, category, image, ingredients, and order state.
    /// </summary>
    public class MenuItem
    {
        #region Fields

        /// <summary>
        /// The name of the menu item displayed on the kanban card.
        /// </summary>
        private string itemName;

        /// <summary>
        /// A brief description of the menu item represented by the kanban card.
        /// </summary>
        private string description;

        /// <summary>
        /// The category or type to which the menu item belongs.
        /// </summary>
        private object category;

        /// <summary>
        /// A list of ingredients or tags associated with the menu item.
        /// </summary>
        private Uri image;

        /// <summary>
        /// The list of tags associated with the kanban card.
        /// </summary>
        private List<string> ingredients;

        /// <summary>
        /// The current order state of the menu item.
        /// </summary>
        private object orderState;

        /// <summary>
        /// The rating of the menu item.
        /// </summary>
        private double rating;

        /// <summary>
        /// The unique identifier assigned to the order.
        /// </summary>
        private double orderID;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the menu item.
        /// </summary>
        public string ItemName
        {
            get { return this.itemName; }
            set { this.itemName = value; }
        }

        /// <summary>
        /// Gets or sets the description of the menu item.
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the category of the menu item.
        /// </summary>
        public object Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        /// <summary>
        /// Gets or sets the image source representing the menu item, which can be a file path, URI, or embedded resource.
        /// </summary>
        public Uri Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        /// <summary>
        /// Gets or sets the list of ingredients used in the menu item.
        /// </summary>
        public List<string> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }

        /// <summary>
        /// Gets or sets the current order state of the menu item (e.g., Dining, Delivery).
        /// </summary>
        public object OrderState
        {
            get { return this.orderState; }
            set { this.orderState = value; }
        }

        /// <summary>
        /// Gets or sets the rating of the menu item.
        /// </summary>
        public double Rating
        {
            get { return this.rating; }
            set { this.rating = value; }
        }

        /// <summary>
        /// Gets or sets the unique identifier associated with the order.
        /// </summary>
        public double OrderID
        {
            get { return orderID; }
            set { this.orderID = value; }
        }

        #endregion
    }
}