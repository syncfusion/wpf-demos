#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
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

namespace syncfusion.kanbandemos.wpf
{
    /// <summary>
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : DemoControl
    {
        public Selection(string themename) : base(themename)
        {
            InitializeComponent();
            var workflow = new WorkflowCollection();
            workflow.Add(new KanbanWorkflow() { Category = "Open", AllowedTransitions = { "InProgress", "Closed", "Closed NoChanges", "Won't Fix" } });
            workflow.Add(new KanbanWorkflow() { Category = "Postponed", AllowedTransitions = { "Open", "InProgress", "Closed", "Closed NoChanges", "Won't Fix" } });
            workflow.Add(new KanbanWorkflow() { Category = "Review", AllowedTransitions = { "InProgress", "Closed", "Postponed" } });
            workflow.Add(new KanbanWorkflow() { Category = "InProgress", AllowedTransitions = { "Review", "Postponed" } });
            this.Kanban.Workflows = workflow;
        }

        protected override void Dispose(bool disposing)
        {
            if (Kanban != null)
            {
                this.Kanban.Dispose();
                this.Kanban = null;
            }
            
            base.Dispose(disposing);
        }

        /// <summary>
        /// Occurs when the selection mode is changed.
        /// </summary>
        /// <param name="sender">The source object (ComboBox).</param>
        /// <param name="e">The event arguments.</param>
        private void OnSelectionModeChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = this.sortBySelection.SelectedItem.ToString();
            switch (selectedItem)
            {
                case "None":
                    this.Kanban.CardSelectionType = KanbanCardSelectionType.None;
                    break;

                case "Single":
                    this.Kanban.CardSelectionType = KanbanCardSelectionType.Single;
                    break;

                case "Multiple":
                    this.Kanban.CardSelectionType = KanbanCardSelectionType.Multiple;
                    break;

                default:
                    // Optional: handle unexpected values gracefully
                    this.Kanban.CardSelectionType = KanbanCardSelectionType.None;
                    break;
            }
        }
    }    
}
