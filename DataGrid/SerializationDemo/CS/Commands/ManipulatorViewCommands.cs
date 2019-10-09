#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using SerializationDemo.Views;


namespace SerializationDemo
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
            ManipulatorView manipulatorwnd = sender as ManipulatorView;
            MainWindow mainwnd = (MainWindow)Application.Current.MainWindow;
            if (manipulatorwnd.mappingname_cmbbox.SelectedItem == null)
            {
                manipulatorwnd.err_textblock.Text = "MappingName is mandatory";
                manipulatorwnd.err_textblock.Visibility = Visibility.Visible;
                return;
            }
            var mappingName = manipulatorwnd.mappingname_cmbbox.SelectedItem.ToString();

            if (mappingName.Contains(" (TemplateColumn)") || mappingName.Contains(" (UnBoundColumn)"))
            {
                mappingName = mappingName.Substring(0, mappingName.IndexOf('(') - 1);
            }
            foreach (var col in mainwnd.dataGrid.Columns)
            {
                if (mappingName == col.HeaderText)
                {
                    mainwnd.dataGrid.Columns.Remove(col);
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
            MainWindow mainwnd = (MainWindow)Application.Current.MainWindow;
            ManipulatorView manipulatorwnd = sender as ManipulatorView;
            int index = manipulatorwnd.colType_combobox.SelectedIndex;

            if (manipulatorwnd.mappingname_cmbbox.SelectedItem == null && index == 1)
            {
                if (!String.IsNullOrEmpty(manipulatorwnd.unboundcol_mappingname_txtbox.Text) && manipulatorwnd.exprsn_combobox.SelectedItem != null)
                {
                    foreach (var col in mainwnd.dataGrid.Columns)
                    {
                        if (col.MappingName == manipulatorwnd.unboundcol_mappingname_txtbox.Text)
                        {
                            manipulatorwnd.err_textblock.Text = "The given MappingName already exists";
                            manipulatorwnd.err_textblock.Visibility = Visibility.Visible;
                            return;
                        }
                    }
                    mainwnd.dataGrid.Columns.Add(new GridUnBoundColumn() { MappingName = manipulatorwnd.unboundcol_mappingname_txtbox.Text, Expression = manipulatorwnd.exprsn_combobox.Text });
                    manipulatorwnd.exprsn_combobox.SelectedItem = null;
                    manipulatorwnd.unboundcol_mappingname_txtbox.Clear();
                    manipulatorwnd.Close();
                }
                else
                {
                    manipulatorwnd.err_textblock.Text = "Experssion/MappingName is mandatory";
                    manipulatorwnd.err_textblock.Visibility = Visibility.Visible;
                    return;
                }
                return;
            }

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

                switch (index)
                {
                    case 0:
                        mainwnd.dataGrid.Columns.Add(new GridTextColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case 2:
                        mainwnd.dataGrid.Columns.Add(new GridPercentColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case 3:
                        mainwnd.dataGrid.Columns.Add(new GridNumericColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case 4:
                        mainwnd.dataGrid.Columns.Add(new GridDateTimeColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case 5:
                        mainwnd.dataGrid.Columns.Add(new GridCurrencyColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case 6:
                        mainwnd.dataGrid.Columns.Add(new GridCheckBoxColumn() { MappingName = mappingName, HeaderText = headerText });
                        break;
                    case 7:
                        GridTemplateColumn tempCol = new GridTemplateColumn();
                        tempCol.MappingName = mappingName.ToString();
                        tempCol.HeaderText = headerText;
                        tempCol.CellTemplate = GetDataTemplate(tempCol);
                        mainwnd.dataGrid.Columns.Add(tempCol);
                        break;
                }
                manipulatorwnd.mappingname_cmbbox.SelectedItem = null;
                manipulatorwnd.Close();
            }
        }

        #endregion

        #region GetDataTemplate
        private static DataTemplate GetDataTemplate(GridTemplateColumn col)
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
