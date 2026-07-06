using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace syncfusion.treegriddemos.wpf
{
    [TemplatePart(Name = "PART_FindNext", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FindPrevious", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Close", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ClearButton", Type = typeof(Button))]
    //[TemplatePart(Name = "PART_ApplyFiltering", Type = typeof(CheckBox))]
    [TemplatePart(Name = "PART_SearchScopeCombo", Type = typeof(ComboBox))]
    [TemplatePart(Name = "PART_AdornerLayer", Type = typeof(AdornerDecorator))]
    [TemplatePart(Name = "PART_CaseSensitiveSearch", Type = typeof(CheckBox))]
    /// <summary>
    /// A control that provides a small search panel for the tree grid and manages user interactions.
    /// </summary>
    public class TreeGridSearchControl : Control, IDisposable
    {
        #region Fields
        internal Button FindNextButton;
        internal Button FindPreviousButton;
        internal Button CloseButton;
        internal Button ClearFilterButton;
        internal TextBox SearchTextBox;
        //internal CheckBox ApplyFilterCheckBox;
        internal CheckBox CaseSensitiveSearchCheckBox;
        internal AdornerDecorator AdornerLayer;
        internal ComboBox SearchScopeComboBox;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the TreeGrid for the corresponding search operation.
        /// </summary>
        public SfTreeGrid TreeGrid
        {
            get { return (SfTreeGrid)GetValue(TreeGridProperty); }
            set { SetValue(TreeGridProperty, value); }
        }
        public static readonly DependencyProperty TreeGridProperty =
            DependencyProperty.Register("TreeGrid", typeof(SfTreeGrid), typeof(TreeGridSearchControl), new PropertyMetadata(null));

        #endregion

        #region Ctor

        /// <summary>
        /// Runs once when the class is loaded and sets the default style key.
        /// </summary>
        static TreeGridSearchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeGridSearchControl), new FrameworkPropertyMetadata(typeof(TreeGridSearchControl)));
        }

        /// <summary>
        /// Initializes a new instance of the control without assigning a tree grid.
        /// </summary>
        public TreeGridSearchControl()
        {
        }

        /// <summary>
        /// Initializes a new instance of the control and assigns the provided tree grid for searching.
        /// </summary>
        public TreeGridSearchControl(SfTreeGrid treeGrid)
        {
            TreeGrid = treeGrid;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Shows or hides the search panel and updates focus accordingly.
        /// </summary>
        internal void UpdateSearchControlVisibility(bool visible)
        {
            if (visible)
            {
                this.SearchScopeComboBox.SelectedIndex = 0;
                this.Visibility = Visibility.Visible;
                this.SearchTextBox.Focus();
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
                this.SearchTextBox.Clear();
                this.TreeGrid.SearchController.Clear();
                this.TreeGrid.Focus();
            }
        }

        /// <summary>
        /// Called when the control template is applied and links template parts to fields.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FindNextButton = this.GetTemplateChild("PART_FindNext") as Button;
            ClearFilterButton = this.GetTemplateChild("PART_ClearButton") as Button;
            FindPreviousButton = this.GetTemplateChild("PART_FindPrevious") as Button;
            CloseButton = this.GetTemplateChild("PART_Close") as Button;
            //ApplyFilterCheckBox = this.GetTemplateChild("PART_ApplyFiltering") as CheckBox;
            SearchScopeComboBox = this.GetTemplateChild("PART_SearchScopeCombo") as ComboBox;
            SearchTextBox = this.GetTemplateChild("PART_TextBox") as TextBox;
            CaseSensitiveSearchCheckBox = this.GetTemplateChild("PART_CaseSensitiveSearch") as CheckBox;
            AdornerLayer = this.GetTemplateChild("PART_AdornerLayer") as AdornerDecorator;
            this.SearchTextBox.Focus();
            this.WireEvents();
        }

        #endregion

        #region Events

        /// <summary>
        /// Attaches event handlers for the control parts so the control reacts to user actions.
        /// </summary>
        private void WireEvents()
        {
            FindNextButton.Click += OnFindNextButtonClick;
            ClearFilterButton.Click += OnClearFilterButtonClick;
            FindPreviousButton.Click += OnFindPreviousButtonClick;
            CloseButton.Click += OnCloseButtonClick;
            SearchTextBox.TextChanged += OnTextChanged;
            //ApplyFilterCheckBox.Click += OnApplyFilterCheckBoxClick;
            CaseSensitiveSearchCheckBox.Click += OnCaseSensitiveSearchCheckBoxClick;
            SearchScopeComboBox.SelectionChanged += OnSearchScopeComboBoxSelectionChanged;
            AdornerLayer.KeyDown += OnAdornerLayerKeyDown;
        }

        /// <summary>
        /// Clears the search text when the clear button is clicked.
        /// </summary>
        private void OnClearFilterButtonClick(object sender, RoutedEventArgs e)
        {
            this.SearchTextBox.Clear();
        }

        /// <summary>
        /// Handles keyboard shortcuts for opening and closing the search panel.
        /// </summary>
        void OnAdornerLayerKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.F) && (e.KeyboardDevice.Modifiers & ModifierKeys.Control) != ModifierKeys.None)
                this.UpdateSearchControlVisibility(true);
            else if (e.Key == Key.Escape)
                this.UpdateSearchControlVisibility(false);
        }

        /// <summary>
        /// Event handler to handle CaseSensitive search check box click.
        /// </summary>
        private void OnCaseSensitiveSearchCheckBoxClick(object sender, RoutedEventArgs e)
        {
            if (this.TreeGrid?.SearchController == null)
                return;
            this.TreeGrid.SearchController.AllowCaseSensitiveSearch = (bool)this.CaseSensitiveSearchCheckBox.IsChecked;
        }

        /// <summary>
        /// Event handler to handle when text value is changed in SearchTextBox.
        /// </summary>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.TreeGrid?.SearchController == null)
                return;

            if (!string.IsNullOrEmpty(SearchTextBox.Text))
                this.ClearFilterButton.IsEnabled = true;
            else
                this.ClearFilterButton.IsEnabled = false;

            this.TreeGrid.SearchController.Search(SearchTextBox.Text);
            UpdateSearchNavigationButtons();
        }

        /// <summary>
        /// Enables or disables the FindNext and FindPrevious buttons based on search results.
        /// </summary>
        internal void UpdateSearchNavigationButtons()
        {
            if (this.TreeGrid?.SearchController == null)
            {
                this.FindNextButton.IsEnabled = false;
                this.FindPreviousButton.IsEnabled = false;
                return;
            }

            var searchRecords = this.TreeGrid.SearchController.GetRecords();
            bool hasResults = searchRecords != null && searchRecords.Count > 0;
            this.FindNextButton.IsEnabled = hasResults;
            this.FindPreviousButton.IsEnabled = hasResults;
        }

        /// <summary>
        /// Event handler to handle when clicking on FindNext button.
        /// </summary>
        private void OnFindNextButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.TreeGrid?.SearchController == null)
                return;
            this.TreeGrid.SearchController.FindNext(SearchTextBox.Text);
        }

        /// <summary>
        /// Event handler to handle when clicking on FindPrevious button.
        /// </summary>
        private void OnFindPreviousButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.TreeGrid?.SearchController == null)
                return;
            this.TreeGrid.SearchController.FindPrevious(SearchTextBox.Text);
        }

        /// <summary>
        /// Event handler to handle when clicking on Close button.
        /// </summary>
        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.SearchTextBox.Clear();
            if (this.TreeGrid?.SearchController != null)
                this.TreeGrid.SearchController.Clear();
            this.Visibility = Visibility.Collapsed;
            this.TreeGrid.Focus();
        }

        /// <summary>
        /// Event handler to handle ApplyFilter check box click.
        /// </summary>
        //private void OnApplyFilterCheckBoxClick(object sender, RoutedEventArgs e)
        //{
        //    if (this.TreeGrid?.SearchController == null)
        //        return;
        //    this.TreeGrid.SearchController.AllowFiltering = (bool)this.ApplyFilterCheckBox.IsChecked;
        //}

        /// <summary>
        /// Event handler to handle selection changes in SearchScope combo box.
        /// </summary>
        private void OnSearchScopeComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.TreeGrid?.SearchController == null)
                return;

            // Update the search scope based on selected item
            var selectedItem = this.SearchScopeComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                var scopeContent = selectedItem.Content.ToString();
                SearchScope scope = SearchScope.Both;

                if (scopeContent == "Root Nodes")
                    scope = SearchScope.RootNodes;
                else if (scopeContent == "Child Nodes")
                    scope = SearchScope.ChildNodes;

                this.TreeGrid.SearchController.SearchScope = scope;

                // Re-search with the new scope
                if (!string.IsNullOrEmpty(SearchTextBox.Text))
                {
                    this.TreeGrid.SearchController.Search(SearchTextBox.Text);
                    UpdateSearchNavigationButtons();
                }
            }
        }

        #endregion

        /// <summary>
        /// Detaches all event handlers previously attached to control parts to avoid memory leaks.
        /// </summary>
        private void UnWireEvents()
        {
            if (FindNextButton == null)
                return;
            FindNextButton.Click -= OnFindNextButtonClick;
            FindPreviousButton.Click -= OnFindPreviousButtonClick;
            CloseButton.Click -= OnCloseButtonClick;
            SearchTextBox.TextChanged -= OnTextChanged;
            //ApplyFilterCheckBox.Click -= OnApplyFilterCheckBoxClick;
            CaseSensitiveSearchCheckBox.Click -= OnCaseSensitiveSearchCheckBoxClick;
            SearchScopeComboBox.SelectionChanged -= OnSearchScopeComboBoxSelectionChanged;
        }

        /// <summary>
        /// Releases resources used by the control and detaches event handlers.
        /// </summary>
        public void Dispose()
        {
            this.UnWireEvents();
            this.TreeGrid = null;
        }
    }
}
