#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// class which helps to Search the Text in the DataGrid.
    /// </summary>
    [TemplatePart(Name = "PART_FindNext", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FindPrevious", Type = typeof(Button))]
    [TemplatePart(Name = "PART_Close", Type = typeof(Button))]
    [TemplatePart(Name = "PART_ApplyFiltering", Type = typeof(CheckBox))]
    [TemplatePart(Name = "PART_ComboBox", Type = typeof(ComboBox))]
    [TemplatePart(Name = "PART_AdornerLayer", Type = typeof(AdornerDecorator))]
    [TemplatePart(Name = "PART_CaseSensitiveSearch", Type = typeof(CheckBox))]   
    public class SearchControl : Control,IDisposable
    {
        #region Fields
        internal Button FindNextButton;
        internal Button FindPreviousButton;
        internal Button CloseButton;
        internal TextBox SearchTextBox;
        internal CheckBox ApplyFilterCheckBox;
        internal CheckBox CaseSensitiveSearchCheckBox;
        internal AdornerDecorator AdornerLayer;
        internal ComboBox ComboBox;
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the DataGrid for the corresponding search operation.
        /// </summary>
        public SfDataGrid DataGrid
        {
            get { return (SfDataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, value); }
        }
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register("DataGrid", typeof(SfDataGrid), typeof(SearchControl), new PropertyMetadata(null));

        #endregion

        #region Ctor

        static SearchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchControl), new FrameworkPropertyMetadata(typeof(SearchControl)));
        }

        public SearchControl()
        {
        }

        public SearchControl(SfDataGrid datagrid)
        {
            DataGrid = datagrid;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the DetailsViewDefinition index of the given DataGrid.
        /// </summary>
        /// <param name="dataGrid"></param>
        /// <param name="actualRowIdx"></param>
        /// <returns></returns>
        private int GetDetailsViewDefinitionIndex(SfDataGrid dataGrid, int actualRowIdx)
        {
            var counter0 = 0;
            for (int i = actualRowIdx; i > 0; i--)
            {
                if (!dataGrid.IsInDetailsViewIndex(i))
                {
                    break;
                }
                counter0++;
            }
            return counter0;
        }

        /// <summary>
        /// Method to open Search Control.
        /// </summary>
        /// <param name="visible"></param>
        internal void UpdateSearchControlVisiblity(bool visible)
        {
            if (visible)
            {
                if (this.DataGrid.SelectedDetailsViewGrid != null)
                {
                    var detailsViewIndex = this.DataGrid.GetGridDetailsViewRowIndex(this.DataGrid.SelectedDetailsViewGrid as DetailsViewDataGrid);
                    ComboBox.SelectedIndex = this.GetDetailsViewDefinitionIndex(this.DataGrid, detailsViewIndex - 1) + 1;
                }
                else
                    ComboBox.SelectedIndex = 0;
                this.Visibility = Visibility.Visible;
                this.SearchTextBox.Focus();
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
                this.SearchTextBox.Clear();
                this.DataGrid.SearchHelper.ClearSearch();
                this.DataGrid.Focus();
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FindNextButton = this.GetTemplateChild("PART_FindNext") as Button;
            FindPreviousButton = this.GetTemplateChild("PART_FindPrevious") as Button;
            CloseButton = this.GetTemplateChild("PART_Close") as Button;
            ApplyFilterCheckBox = this.GetTemplateChild("PART_ApplyFiltering") as CheckBox;
            ComboBox = this.GetTemplateChild("PART_ComboBox") as ComboBox;
            SearchTextBox = this.GetTemplateChild("PART_TextBox") as TextBox;
            CaseSensitiveSearchCheckBox = this.GetTemplateChild("PART_CaseSensitiveSearch") as CheckBox;
            AdornerLayer = this.GetTemplateChild("PART_AdornerLayer") as AdornerDecorator;
            this.SearchTextBox.Focus();
            this.WireEvents();
        }

        #endregion

        #region Events

        /// <summary>
        /// Method to wire the required events.
        /// </summary>
        private void WireEvents()
        {
            FindNextButton.Click += OnFindNextButtonClick;
            FindPreviousButton.Click += OnFindPreviousButtonClick;
            CloseButton.Click += OnCloseButtonClick;
            SearchTextBox.TextChanged += OnTextChanged;
            ApplyFilterCheckBox.Click += OnApplyFilterCheckBoxClick;
            CaseSensitiveSearchCheckBox.Click += OnCaseSensitiveSearchCheckBoxClick;
            ComboBox.SelectionChanged += OnComboBoxSelectionChanged;
            AdornerLayer.KeyDown += OnAdornerLayerKeyDown;
        }

        /// <summary>
        /// Event handler to handle AdornerLayer key down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnAdornerLayerKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if ((e.Key == Key.F) && (e.KeyboardDevice.Modifiers & ModifierKeys.Control) != ModifierKeys.None)
                this.UpdateSearchControlVisiblity(true);
            else if (e.Key == Key.Escape)
                this.UpdateSearchControlVisiblity(false);
        }

        /// <summary>
        /// Event handler to handle CaseSensitive search check box click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCaseSensitiveSearchCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var item = this.ComboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.AllowCaseSensitiveSearch = (bool)this.CaseSensitiveSearchCheckBox.IsChecked;
        }


        /// <summary>
        /// Event handler to handle when text value is changed in SearchTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var item = this.ComboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.Search(SearchTextBox.Text);
        }


        /// <summary>
        ///  Event handler to handle when clicking on FindNext button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFindNextButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.ComboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.FindNext(SearchTextBox.Text);
        }


        /// <summary>
        /// Event handler to handle when clicking on FindPrevious button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFindPreviousButtonClick(object sender, RoutedEventArgs e)
        {
            var item = this.ComboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.FindPrevious(SearchTextBox.Text);
        }

        /// <summary>
        /// Event handler to handle when clicking on Close button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.SearchTextBox.Clear();
            var item = this.ComboBox.SelectedItem;
            if (item != null)
                this.GetDataGrid(item.ToString()).SearchHelper.ClearSearch();
            this.Visibility = Visibility.Collapsed;
            this.DataGrid.Focus();
        }


        /// <summary>
        /// Event handler to handle ApplyFilter check box click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnApplyFilterCheckBoxClick(object sender, RoutedEventArgs e)
        {
            var item = this.ComboBox.SelectedItem;
            if (item == null)
                return;
            var grid = this.GetDataGrid(item.ToString());
            grid.SearchHelper.AllowFiltering = (bool)this.ApplyFilterCheckBox.IsChecked;
        }


        /// <summary>
        /// Event handler to handle selection changes in DataGrid combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var oldItem = e.RemovedItems[0];
            var newItem = e.AddedItems[0];
            if (oldItem == null || newItem == null)
                return;
            var oldGrid = this.GetDataGrid(oldItem.ToString());
            var newGrid = this.GetDataGrid(newItem.ToString());
            oldGrid.SearchHelper.ClearSearch();
            newGrid.SearchHelper.AllowFiltering = (bool)this.ApplyFilterCheckBox.IsChecked;
            newGrid.SearchHelper.AllowCaseSensitiveSearch = (bool)this.CaseSensitiveSearchCheckBox.IsChecked;
            newGrid.SearchHelper.Search(SearchTextBox.Text);
        }

        /// <summary>
        /// Method to return the DataGrid which Selected in the ComboBox.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private SfDataGrid GetDataGrid(string item)
        {
            switch (item)
            {
                case "Search first level Grid's":
                    return (this.DataGrid.DetailsViewDefinition[0] as GridViewDefinition).DataGrid;
                case "Search second level Grid's":
                    return (this.DataGrid.DetailsViewDefinition[1] as GridViewDefinition).DataGrid;
                default:
                    return this.DataGrid;
            }
        }
        #endregion

        /// <summary>
        /// Method to UnWire the wired events.
        /// </summary>
        private void UnWireEvents()
        {
            FindNextButton.Click -= OnFindNextButtonClick;
            FindPreviousButton.Click -= OnFindPreviousButtonClick;
            CloseButton.Click -= OnCloseButtonClick;
            SearchTextBox.TextChanged -= OnTextChanged;
            ApplyFilterCheckBox.Click -= OnApplyFilterCheckBoxClick;
            ComboBox.SelectionChanged -= OnComboBoxSelectionChanged;
        }

        public void Dispose()
        {
            this.UnWireEvents();
            this.DataGrid = null;
        }
    }
}
