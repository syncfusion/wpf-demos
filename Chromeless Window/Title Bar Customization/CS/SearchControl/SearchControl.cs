#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace TitleBarCustomization
{
    /// <summary>
    /// class which helps to Search the Text in the DataGrid.
    /// </summary>
    [TemplatePart(Name = "PART_FindNext", Type = typeof(Button))]
    [TemplatePart(Name = "PART_FindPrevious", Type = typeof(Button))]
    [TemplatePart(Name = "PART_AdornerLayer", Type = typeof(AdornerDecorator))]
    public class SearchControl : Control,IDisposable
    {
        #region Fields

        /// <summary>
        /// Holds the next button.
        /// </summary>
        internal Button FindNextButton;

        /// <summary>
        /// Holds the previous button.
        /// </summary>
        internal Button FindPreviousButton;

        /// <summary>
        /// Holds the search text box
        /// </summary>
        internal TextBox SearchTextBox;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of the Search control
        /// </summary>
        public SearchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchControl), new FrameworkPropertyMetadata(typeof(SearchControl)));
        }

        /// <summary>
        /// Constructor of the Search control
        /// </summary>
        public SearchControl(SfDataGrid datagrid)
        {
            DataGrid = datagrid;
        }
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

        /// <summary>
        /// Dependency property of the DataGrid
        /// </summary>
        public static readonly DependencyProperty DataGridProperty =
            DependencyProperty.Register("DataGrid", typeof(SfDataGrid), typeof(SearchControl), new PropertyMetadata(null));

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
        /// This method is invoked whenever the OnApplyTemplate is invoked in the base.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FindNextButton = this.GetTemplateChild("PART_FindNext") as Button;
            FindPreviousButton = this.GetTemplateChild("PART_FindPrevious") as Button;
            SearchTextBox = this.GetTemplateChild("PART_TextBox") as TextBox;
            this.WireEvents();
        }

        #endregion

        #region Events

        /// <summary>
        /// Raise when this control is disposed
        /// </summary>
        public void Dispose()
        {
            this.UnWireEvents();
            this.DataGrid = null;
        }

        /// <summary>
        /// Method to wire the required events.
        /// </summary>
        private void WireEvents()
        {
            FindNextButton.Click += OnFindNextButtonClick;
            FindPreviousButton.Click += OnFindPreviousButtonClick;
            SearchTextBox.TextChanged += OnTextChanged;
        }

        /// <summary>
        /// Event handler to handle when text value is changed in SearchTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.DataGrid.SearchHelper.Search(SearchTextBox.Text);
        }
        
        /// <summary>
        ///  Event handler to handle when clicking on FindNext button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFindNextButtonClick(object sender, RoutedEventArgs e)
        {
            this.DataGrid.SearchHelper.FindNext(SearchTextBox.Text);
        }
        
        /// <summary>
        /// Event handler to handle when clicking on FindPrevious button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFindPreviousButtonClick(object sender, RoutedEventArgs e)
        {
            this.DataGrid.SearchHelper.FindPrevious(SearchTextBox.Text);
        }

        /// <summary>
        /// Method to UnWire the wired events.
        /// </summary>
        private void UnWireEvents()
        {
            FindNextButton.Click -= OnFindNextButtonClick;
            FindPreviousButton.Click -= OnFindPreviousButtonClick;
            SearchTextBox.TextChanged -= OnTextChanged;
        }

        #endregion
    }

    public class TextInputToVisibilityConverter : IValueConverter
    {
        #region Fields
        /// <summary>
        /// Holds the window instance
        /// </summary>
        Window window;

        /// <summary>
        /// Holds the data grid instance
        /// </summary>
        SfDataGrid dataGrid;
        #endregion

        #region Implementation
        /// <summary>
        /// Converts and returns a bool value to update the visibility of the Next and Previous button
        /// </summary>
        /// <returns>Returns boolean value</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (window == null)
                window = Application.Current.MainWindow;
            if (dataGrid == null)
                dataGrid = window.FindName("dataGrid") as SfDataGrid;
            dataGrid.SearchHelper.Search(value.ToString());
            if (value.ToString() == String.Empty || (dataGrid != null && dataGrid.SearchHelper.GetSearchRecords() != null && dataGrid.SearchHelper.GetSearchRecords().Count == 0))
                return false;
            return true;
        }

        /// <summary>
        /// This method is not implemented
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }
        #endregion
    }
}
