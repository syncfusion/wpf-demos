#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Kanban;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.kanbandemos.wpf
{
    public class MenuDetails
    {
        public ObservableCollection<KanbanModel> PizzaShop
        {
            get;
            set;
        }

        public void Dispose()
        {
            if (PizzaShop != null)
                PizzaShop.Clear();
        }

        public MenuDetails()
        {
            PizzaShop = new ObservableCollection<KanbanModel>();

            KanbanModel item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Double Cheese Margherita";
            item.Description = "The minimalist classic with a double helping of cheese";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/DoubleCheeseMargherita.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Bucolic Pie";
            item.Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Bucolicpie.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Bumper Crop";
            item.Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Bumpercrop.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Spice of Life";
            item.Description = "Thrill-seeking, heat-seeking pizza people only.  It's hot. Trust us";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Spiceoflife.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Order";
            item.Title = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Verynicoise.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Margherita.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Verynicoise.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Ready to Serve";
            item.Title = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Margherita.png", UriKind.RelativeOrAbsolute);
            item.ColorKey = "Ready";
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Ready to Delivery";
            item.Title = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Saladdaze.png", UriKind.RelativeOrAbsolute);
            item.ColorKey = "Delivery";
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"syncfusion.kanbandemos.wpf;component/Assets/Kanban/Saladdaze.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);
        }
    }
}
