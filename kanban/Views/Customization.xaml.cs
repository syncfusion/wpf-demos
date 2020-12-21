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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using syncfusion.demoscommon.wpf;

namespace syncfusion.kanbandemos.wpf
{
    /// <summary>
    /// Interaction logic for Customization.xaml
    /// </summary>
    public partial class Customization : DemoControl
    {
        public Customization()
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

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    } 
}
