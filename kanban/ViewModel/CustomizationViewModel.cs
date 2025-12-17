namespace syncfusion.kanbandemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents a view model for managing a customizable menu of pizza items, including their details, categories, and order states.
    /// </summary>
    public class CustomizationViewModel
    {
        /// <summary>
        /// Gets or sets the collection of pizza menu items.
        /// </summary>
        public ObservableCollection<MenuItem> PizzaShop { get; set; }


        /// <summary>
        /// Clears the <see cref="PizzaShop"/> collection to release resources.
        /// </summary>
        public void Dispose()
        {
            if (PizzaShop != null)
                PizzaShop.Clear();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomizationViewModel"/> class.
        /// Populates the <see cref="PizzaShop"/> collection with predefined menu items.
        /// </summary>
        public CustomizationViewModel()
        {
            PizzaShop = new ObservableCollection<MenuItem>();

            MenuItem item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Double Cheese Margherita";
            item.Description = "The minimalist classic with a double helping of cheese";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri("syncfusion.kanbandemos.wpf;component/Assets/Kanban/DoubleCheeseMargherita.png", UriKind.RelativeOrAbsolute);
            item.Rating = 5;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Bucolic Pie";
            item.Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Bucolicpie.png", UriKind.RelativeOrAbsolute);
            item.Rating = 3;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Bumper Crop";
            item.Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Bumpercrop.png", UriKind.RelativeOrAbsolute);
            item.Rating = 3;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Spice of Life";
            item.Description = "Thrill-seeking, heat-seeking pizza people only.  It's hot. Trust us";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Spiceoflife.png", UriKind.RelativeOrAbsolute);
            item.Rating = 4;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Order";
            item.ItemName = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Verynicoise.png", UriKind.RelativeOrAbsolute);
            item.Rating = 4;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Margherita.png", UriKind.RelativeOrAbsolute);
            item.Rating = 4.5;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Verynicoise.png", UriKind.RelativeOrAbsolute);
            item.Rating = 3.8;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Ready to Serve";
            item.ItemName = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Margherita.png", UriKind.RelativeOrAbsolute);
            item.OrderState = "Ready";
            item.OrderID = 1601;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Ready to Delivery";
            item.ItemName = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri("syncfusion.kanbandemos.wpf;component/Assets/Kanban/Saladdaze.png", UriKind.RelativeOrAbsolute);
            item.OrderState = "Delivery";
            item.OrderID = 1600;
            PizzaShop.Add(item);

            item = new MenuItem();
            item.Category = "Menu";
            item.ItemName = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            item.Ingredients = new List<string> { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.Image = new Uri("syncfusion.kanbandemos.wpf;component/Assets/Kanban/Saladdaze.png", UriKind.RelativeOrAbsolute);
            item.Rating = 3.5;
            PizzaShop.Add(item);
        }
    }
}
