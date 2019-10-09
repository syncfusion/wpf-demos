#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Kanban;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;

namespace Customization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var workflow = new WorkflowCollection();
            workflow.Add(new KanbanWorkflow() { Category = "Menu", AllowedTransitions = { "Dining", "Delivery" } });
            workflow.Add(new KanbanWorkflow() { Category = "Dining", AllowedTransitions = { "Ready to Serve" } });
            workflow.Add(new KanbanWorkflow() { Category = "Delivery", AllowedTransitions = { "Ready to Delivery" } });
            kanban.Workflows = workflow;
        }

        private void kanban_DragStart(object sender, KanbanDragStartEventArgs e)
        {
            if (e.SelectedColumn.Title.ToString() == "Menu")
            {
                e.KeepCard = true;
            }
        }

        private void kanban_DragEnd(object sender, KanbanDragEndEventArgs e)
        {
            if (e.SelectedColumn.Title.ToString() == "Menu" && e.SelectedColumn != e.TargetColumn &&
                e.TargetColumn.Title.ToString() == "Order")
            {
                e.IsCancel = true;

                KanbanModel selectedCard = e.SelectedCard.Content as KanbanModel;

                KanbanModel model = new KanbanModel();
                model.Category = e.TargetKey;
                model.Description = selectedCard.Description;
                model.ImageURL = selectedCard.ImageURL;
                model.ColorKey = selectedCard.ColorKey;
                model.Tags = selectedCard.Tags;
                model.ID = selectedCard.ID;
                model.Title = selectedCard.Title;

                (kanban.ItemsSource as ObservableCollection<KanbanModel>).Add(model);
            }
        }
    }

    public class CardCountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var columnTag = value as ColumnTag;
            if (columnTag == null) return "";
            if (columnTag.Header.ToString() == "Menu")
                return "Total Items : ";
            else if (columnTag.Header.ToString() == "Order")
                return "Pizza Count : ";
            else if (columnTag.Header.ToString() == "To be cooked")
                return "Pizza Count : ";
            else if (columnTag.Header.ToString() == "Ready to Serve")
                return "Pizza Count : ";
            else if (columnTag.Header.ToString() == "Ready to Delivery")
                return "Pizza Count : ";
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }

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
            item.ImageURL = new Uri(@"Images/DoubleCheeseMargherita.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Bucolic Pie";
            item.Description = "The pizza you daydream about to escape city life. Onions, peppers, and tomatoes";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Bucolicpie.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Bumper Crop";
            item.Description = "Can't get enough veggies? Eat this. Carrots, mushrooms, potatoes, and way more";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Bumpercrop.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Spice of Life";
            item.Description = "Thrill-seeking, heat-seeking pizza people only.  It's hot. Trust us";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Spiceoflife.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Order";
            item.Title = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Verynicoise.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Margherita.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Very Nicoise";
            item.Description = "Anchovies, Dijon vinaigrette, shallots, red peppers, and potatoes";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Verynicoise.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Ready to Serve";
            item.Title = "Margherita";
            item.Description = "The classic. Fresh tomatoes, garlic, olive oil, and basil. For pizza purists and minimalists only";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Margherita.png", UriKind.RelativeOrAbsolute);
            item.ColorKey = "Ready";
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Ready to Delivery";
            item.Title = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Saladdaze.png", UriKind.RelativeOrAbsolute);
            item.ColorKey = "Delivery";
            PizzaShop.Add(item);

            item = new KanbanModel();
            item.Category = "Menu";
            item.Title = "Salad Daze";
            item.Description = "Pretty much salad on a pizza. Broccoli, olives, cherry tomatoes, red onion";
            item.Tags = new string[] { "Onions", "Bell Pepper", "Pork", "Cheese" };
            item.ImageURL = new Uri(@"Images/Saladdaze.png", UriKind.RelativeOrAbsolute);
            PizzaShop.Add(item);
        }
    }
}
