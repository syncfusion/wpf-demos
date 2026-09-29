#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using Syncfusion.UI.Xaml.Kanban;
    using System.Collections.ObjectModel;
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for Customization.xaml
    /// </summary>
    public partial class Customization : DemoControl
    {

        /// <summary>
        /// Stores the next available unique identifier to be assigned to a newly created order item.
        /// </summary>
        private double orderID = 1602;

        /// <summary>
        /// Initializes a new instance of the <see cref="Customization"/> class.
        /// </summary>
        public Customization(string themename) : base(themename)
        {
            InitializeComponent();

            var workflow = new WorkflowCollection();
            workflow.Add(new KanbanWorkflow() { Category = "Menu", AllowedTransitions = { "Dining", "Delivery" } });
            workflow.Add(new KanbanWorkflow() { Category = "Dining", AllowedTransitions = { "Ready to Serve" } });
            workflow.Add(new KanbanWorkflow() { Category = "Delivery", AllowedTransitions = { "Ready to Delivery" } });
            kanban.Workflows = workflow;
        }

        private void OnKanbanDragStart(object sender, KanbanDragStartEventArgs e)
        {
            if (e.SelectedColumn.Title.ToString() == "Menu")
            {
                e.KeepCard = true;
            }
        }

        private void OnKanbanDragEnd(object sender, KanbanDragEndEventArgs e)
        {
            if (e.SelectedColumn.Title.ToString() == "Menu" && e.SelectedColumn != e.TargetColumn &&
                e.TargetColumn.Title.ToString() == "Order")
            {
                e.IsCancel = true;

                MenuItem selectedCard = e.SelectedCard.Content as MenuItem;

                MenuItem item = new MenuItem();
                item.Category = e.TargetKey;
                item.Description = selectedCard.Description;
                item.OrderID = this.orderID;
                item.Image = selectedCard.Image;
                item.OrderState = selectedCard.OrderState;
                item.Ingredients = selectedCard.Ingredients;
                item.ItemName = selectedCard.ItemName;

                (kanban.ItemsSource as ObservableCollection<MenuItem>).Add(item);

                this.orderID += 1;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (kanban != null)
            {
                kanban.Dispose();
                kanban = null;
            }
            
            base.Dispose(disposing);
        }
    }
}