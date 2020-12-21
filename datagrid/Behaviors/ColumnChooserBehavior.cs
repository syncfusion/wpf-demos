#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.datagriddemos.wpf
{
    public class ColumnChooserBehavior : Behavior<ColumnChooserDemo>
    {
        ColumnChooser chooserWindow;

        #region Overrides

        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += OnAssociatedObjectLoaded;
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
            chooserWindow.Closing -= chooserWindow_Closing;
            base.OnDetaching();
        }

        #endregion

        OrderInfoViewModel viewModel;

        void OnAssociatedObjectLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            viewModel = (this.AssociatedObject.DataContext) as OrderInfoViewModel;
            viewModel.ColumnChooserCommand = new DelegateCommand<object>(ColumnChooserCommandHandler);
            InitializeColumnChooserPopup();
        }

        public void ColumnChooserCommandHandler(object param)
        {
            if (param == null)
                ShowColumnChooser();
            else if (param.ToString().Equals("ShowColumnChooser"))
            {
                if (viewModel.ShowColumnChooser)
                    ShowColumnChooser();
                else
                    chooserWindow.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        void ShowColumnChooser()
        {
            if (viewModel.ShowColumnChooser && viewModel.UseDefaultColumnChooser)
                chooserWindow.Visibility = System.Windows.Visibility.Visible;
            else
            {
                if (!viewModel.ShowColumnChooser)
                    return;
                var visibleColumns = this.AssociatedObject.dataGrid.Columns;
                ObservableCollection<OrderInfo> totalColumns = GetColumnsDetails(visibleColumns);
                OrderInfoViewModel chooserViewModel = new OrderInfoViewModel(totalColumns);
                CustomColumnChooser ColumnChooserView = new CustomColumnChooser(chooserViewModel);
                ColumnChooserView.Owner = this.AssociatedObject;
                chooserWindow.Visibility = System.Windows.Visibility.Collapsed;
                if ((bool)ColumnChooserView.ShowDialog())
                    ClickOKButton(chooserViewModel.ColumnCollection, this.AssociatedObject.dataGrid);
                viewModel.ShowColumnChooser = false;
            }
            
            
        }

        void InitializeColumnChooserPopup()
        {
            chooserWindow = new ColumnChooser(this.AssociatedObject.dataGrid);
            chooserWindow.Width = 200;
            chooserWindow.Height = 220;
            chooserWindow.Resources.MergedDictionaries.Clear();
            chooserWindow.ClearValue(ColumnChooser.StyleProperty);
            SfSkinManagerExtension.SetTheme(this.AssociatedObject, chooserWindow);
            this.AssociatedObject.dataGrid.GridColumnDragDropController = new GridColumnChooserController(this.AssociatedObject.dataGrid, chooserWindow);
            chooserWindow.Show();

            chooserWindow.Owner = this.AssociatedObject;
            chooserWindow.Closing += chooserWindow_Closing;
        }

        void chooserWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            chooserWindow.Visibility = System.Windows.Visibility.Collapsed;
            viewModel.ShowColumnChooser = false;
        }

        public void ClickOKButton(ObservableCollection<OrderInfo> ColumnCollection, SfDataGrid dataGrid)
        {
            foreach (var item in ColumnCollection)
            {
                var column = dataGrid.Columns.FirstOrDefault(v => v.MappingName == item.Name);
                if (column != null)
                {
                    if (item.IsChecked == false && !column.IsHidden)
                        column.IsHidden = true;
                    else if (item.IsChecked == true && column.IsHidden == true)
                    {
                        if (column.Width == 0)
                            column.Width = 150;
                        column.IsHidden = false;
                    }
                }
            }
            viewModel.ShowColumnChooser = false;
        }

        public static ObservableCollection<OrderInfo> GetColumnsDetails(Columns totalVisibleColumns)
        {
            ObservableCollection<OrderInfo> totalColumns = new ObservableCollection<OrderInfo>();
            foreach (var actualColumn in totalVisibleColumns)
            {
                OrderInfo item = new OrderInfo();
                if (actualColumn.IsHidden)
                {
                    item.IsChecked = false;
                    item.Name = actualColumn.MappingName;
                }
                else
                {
                    item.IsChecked = true;
                    item.Name = actualColumn.MappingName;
                }
                totalColumns.Add(item);
            }
            return totalColumns;
        }
    }
}
