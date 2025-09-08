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
    using System.Windows;
    using System.Linq;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Collections.ObjectModel;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.SfSkinManager;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Provides behavior logic for the <see cref="DialogEditing"/> sample.
    /// This behavior extends the functionality of the DialogEditing sample by enabling custom interactions, and its validations.
    /// </summary>
    public class DialogEditingBehavior : Behavior<DialogEditing>
    {
        /// <summary>
        /// Holds the addCardButton.
        /// </summary>
        private Button addCardButton;

        /// <summary>
        /// Holds a reference to the <see cref="SfKanban"/> control for managing Kanban interactions.
        /// </summary>
        private SfKanban kanban;

        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += this.OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.kanban = this.AssociatedObject.kanban;
            this.addCardButton = this.AssociatedObject.AddCardButton;
            this.UnWireEvents();
            this.WireEvents();
        }

        /// <summary>
        /// Handles the event when a card is tapped on the Kanban board, typically to display a card editor dialog with options to edit or delete the card.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The card tapped event args.</param>
        private void OnKanbanCardTapped(object sender, KanbanTappedEventArgs e)
        {
            if (e.SelectedCard == null || e.SelectedCard.Content == null)
            {
                return;
            }

            var selectedcard = e.SelectedCard.Content as KanbanModel;
            var contextMenu = new ContextMenu();
            var editMenuItem = new System.Windows.Controls.MenuItem { Header = "Edit" };

            var editIcon = new Path
            {
                Data = Geometry.Parse("M4.9375 12.6875L13.6875 3.9375C14.4124 3.21263 14.4124 2.03737 13.6875 1.3125V1.3125C12.9626 0.587626 11.7874 0.587626 11.0625 1.3125L2.3125 10.0625M4.9375 12.6875L1 14L2.3125 10.0625M4.9375 12.6875L2.3125 10.0625M9.75 2.1875L12.375 4.8125"),
                Stroke = new SolidColorBrush(Color.FromRgb(128, 128, 128)),
                Width = 14,
                Height = 14,
                Stretch = Stretch.Fill,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            editMenuItem.Icon = editIcon;
            contextMenu.Items.Add(editMenuItem);

            editMenuItem.Click += (s, args) =>
            {
                this.ShowCardEditDialog(selectedcard as KanbanModel);
            };

            if (e.SelectedCard is FrameworkElement cardElement)
            {
                contextMenu.Placement = PlacementMode.Mouse;
                contextMenu.PlacementTarget = this.kanban;
                contextMenu.IsOpen = true;
            }
        }

        /// <summary>
        /// Shows the edit dialog for the selected card.
        /// </summary>
        /// <param name="selectedcard">The selected card.</param>
        private void ShowCardEditDialog(KanbanModel selectedcard)
        {
            if (selectedcard == null)
            {
                return;
            }

            ObservableCollection<KanbanModel> taskDetails = this.AssociatedObject.ViewModel.TaskDetails;
            var editCardDialog = new KanbanCardEditor();
            SfSkinManager.SetTheme(editCardDialog, SfSkinManager.GetTheme(this.kanban));

            editCardDialog.TitleTextBox.Text = selectedcard.Title;
            editCardDialog.StatusComboBox.SelectedItem = editCardDialog.StatusComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == selectedcard.Category.ToString());
            editCardDialog.AssigneeComboBox.SelectedItem = editCardDialog.AssigneeComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == selectedcard.Assignee);
            editCardDialog.PriorityComboBox.SelectedItem = editCardDialog.PriorityComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == selectedcard.ColorKey.ToString());
            editCardDialog.SummaryTextBox.Text = selectedcard.Description;
            editCardDialog.ShowDialog();

            if (editCardDialog.DialogResult == true && editCardDialog.Action == DialogAction.Save)
            {
                var card = new KanbanModel()
                {
                    Title = editCardDialog.TitleTextBox.Text,
                    Category = (editCardDialog.StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Assignee = (editCardDialog.AssigneeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    ColorKey = (editCardDialog.PriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Description = editCardDialog.SummaryTextBox.Text,
                };

                string imagePath = this.GetImagePath(card.Assignee);
                card.ImageURL = new Uri(imagePath, UriKind.Relative);
                taskDetails.Remove(selectedcard);
                taskDetails.Add(card);
            }
            else if (editCardDialog.Action == DialogAction.Delete)
            {
                taskDetails.Remove(selectedcard);
            }
        }

        /// <summary>
        /// Handles the event when the add new card button is clicked, typically to create a new task on the Kanban board.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The routed event args.</param>
        private void OnAddNewCardButtonClicked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<KanbanModel> taskDetails = this.AssociatedObject.ViewModel.TaskDetails;
            var addCardDialog = new KanbanCardEditor()
            {
                Title = "Add New Card",
            };

            SfSkinManager.SetTheme(addCardDialog, SfSkinManager.GetTheme(this.kanban));
            addCardDialog.DeleteButton.Visibility = Visibility.Collapsed;
            addCardDialog.CancelButton.Margin = new Thickness(148, 0, 0, 0);

            addCardDialog.ShowDialog();
            if (addCardDialog.DialogResult == true)
            {
                var newTask = new KanbanModel()
                {
                    Title = addCardDialog.TitleTextBox.Text,
                    Category = (addCardDialog.StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Assignee = (addCardDialog.AssigneeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    ColorKey = (addCardDialog.PriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                    Description = addCardDialog.SummaryTextBox.Text,
                };

                string imagePath = this.GetImagePath(newTask.Assignee);
                newTask.ImageURL = new Uri(imagePath, UriKind.Relative);
                taskDetails.Add(newTask);
            }
        }

        /// <summary>
        /// Gets the image path for the given assignee.
        /// </summary>
        /// <param name="assignee">The name of the assignee.</param>
        /// <returns>The image path for the assignee, or an empty string if not found.</returns>
        private string GetImagePath(string assignee)
        {
            string imagePath = "";
            switch (assignee)
            {
                case "Michael Smith":
                    imagePath = @"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle35.png";
                    break;
                case "Margaret Hamilt":
                    imagePath = @"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle9.png";
                    break;
                case "Laura Callahan":
                    imagePath = @"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle13.png";
                    break;
                case "Janet Leverling":
                    imagePath = @"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png";
                    break;
                case "Andrew Fuller":
                    imagePath = @"syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png";
                    break;
            }

            return imagePath;
        }

        /// <summary>
        /// Method to wire the events.
        /// </summary>
        private void WireEvents()
        {
            this.kanban.CardTapped += this.OnKanbanCardTapped;
            this.addCardButton.Click += this.OnAddNewCardButtonClicked;
        }

        /// <summary>
        /// Method to unwire the events.
        /// </summary>
        private void UnWireEvents()
        {
            this.kanban.CardTapped -= this.OnKanbanCardTapped;
            this.addCardButton.Click -= this.OnAddNewCardButtonClicked;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= this.OnAssociatedObjectLoaded;
            this.UnWireEvents();
            this.AssociatedObject.ViewModel = null;
            this.kanban = null;
            this.addCardButton = null;
        }
    }
}