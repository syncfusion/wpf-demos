#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace syncfusion.treegriddemos.wpf
{
    public static class ManipulatorViewCommands
    {
        static ManipulatorViewCommands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(AddColumn, OnExecuteAddColumn, OnCanExecuteAddColumn));
            CommandManager.RegisterClassCommandBinding(typeof(Window), new CommandBinding(RemoveColumn, OnExecuteRemoveColumn, OnCanExecuteRemoveColumn));
        }

        #region RemoveColumn Command

        public static RoutedCommand RemoveColumn = new RoutedCommand("RemoveColumn", typeof(Window));

        private static void OnCanExecuteRemoveColumn(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the command associated with this CommandBinding executes.
        /// </summary>
        private static void OnExecuteRemoveColumn(object sender, ExecutedRoutedEventArgs e)
        {
            SerializationDemo mainwnd = SerializationDemo.demoControl;
            ManipulatorView manipulatorwnd = sender as ManipulatorView;

            if (manipulatorwnd.mappingname_cmbbox.SelectedItem == null)
            {
                manipulatorwnd.err_textblock.Text = "MappingName is mandatory";
                manipulatorwnd.err_textblock.Visibility = Visibility.Visible;
                return;
            }
            var mappingName = manipulatorwnd.mappingname_cmbbox.SelectedItem.ToString();

            if (mappingName.Contains(" (TemplateColumn)"))
            {
                mappingName = mappingName.Substring(0, mappingName.IndexOf('(') - 1);
            }
            foreach (var col in mainwnd.treeGrid.Columns)
            {
                if (mappingName == col.HeaderText)
                {
                    mainwnd.treeGrid.Columns.Remove(col);
                    manipulatorwnd.Close();
                    return;
                }
            }
            manipulatorwnd.mappingname_cmbbox.SelectedItem = null;
        }

        #endregion

        #region AddColumn Command

        public static RoutedCommand AddColumn = new RoutedCommand("AddColumn", typeof(Window));

        private static void OnCanExecuteAddColumn(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Occurs when the command associated with this CommandBinding executes.
        /// </summary>
        private static void OnExecuteAddColumn(object sender, ExecutedRoutedEventArgs e)
        {
            SerializationDemo mainwnd = SerializationDemo.demoControl;
            ManipulatorView manipulatorwnd = sender as ManipulatorView;
            int index = manipulatorwnd.colType_combobox.SelectedIndex;

            if (index == -1 || manipulatorwnd.mappingname_cmbbox.SelectedItem == null)
            {
                manipulatorwnd.err_textblock.Text = "ColumnType/MappingName is mandatory";
                manipulatorwnd.err_textblock.Visibility = Visibility.Visible;
                return;
            }
            if (index != -1)
            {
                MappingNameDictionary dic = new MappingNameDictionary();
                var headerText = manipulatorwnd.mappingname_cmbbox.SelectedItem.ToString();
                var mappingName = dic.FirstOrDefault(x => x.Value == headerText).Key;

                var selectedItem = manipulatorwnd.colType_combobox.SelectedItem as ComboBoxItem;
                var colTypeText = selectedItem != null ? selectedItem.Content.ToString() : string.Empty;

                switch (colTypeText)
                {
                    case "TreeGridTextColumn":
                        mainwnd.treeGrid.Columns.Add(new TreeGridTextColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case "TreeGridNumericColumn":
                        mainwnd.treeGrid.Columns.Add(new TreeGridNumericColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case "TreeGridDateTimeColumn":
                        mainwnd.treeGrid.Columns.Add(new TreeGridDateTimeColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case "TreeGridCurrencyColumn":
                        mainwnd.treeGrid.Columns.Add(new TreeGridCurrencyColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case "TreeGridCheckBoxColumn":
                        mainwnd.treeGrid.Columns.Add(new TreeGridCheckBoxColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case "TreeGridTemplateColumn":
                        TreeGridTemplateColumn tempCol = new TreeGridTemplateColumn();
                        tempCol.MappingName = mappingName.ToString();
                        tempCol.HeaderText = headerText;
                        tempCol.CellTemplate = GetDataTemplate(tempCol);
                        mainwnd.treeGrid.Columns.Add(tempCol);
                        break;
                }
                manipulatorwnd.mappingname_cmbbox.SelectedItem = null;
                manipulatorwnd.Close();
            }
        }

        #endregion

        #region GetDataTemplate
        private static DataTemplate GetDataTemplate(TreeGridTemplateColumn col)
        {
            FrameworkElementFactory btn = new FrameworkElementFactory(typeof(TextBlock));
            var bind = new Binding
            {
                Path = new PropertyPath(col.MappingName),
                Mode = BindingMode.TwoWay
            };
            btn.SetBinding(TextBlock.TextProperty, bind);
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = btn;
            return dataTemplate;
        }

        #endregion
    }
}
