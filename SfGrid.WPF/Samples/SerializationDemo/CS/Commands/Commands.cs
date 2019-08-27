#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(Serialize, OnExecuteSerialize, OnCanExecuteSerialize));
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(Deserialize, OnExecuteDeserialize, OnCanExecuteDeserialize));
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(Reset, OnExecuteReset, OnCanExecuteReset));

            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(Add, OnExecuteAdd, OnCanExecuteAdd));
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(Remove, OnExecuteRemove, OnCanExecuteRemove));
          
        }

        #region Remove Command
        /// <summary>
        ///Occurs when the command associated with this CommandBinding executes.
        /// </summary> 
        private static void OnExecuteRemove(object sender, ExecutedRoutedEventArgs e)
        {
            ManipulatorView manipulatorwnd = new ManipulatorView();
            manipulatorwnd.addnormalCol.Visibility = Visibility.Collapsed;
            manipulatorwnd.addcolarea.Visibility = Visibility.Collapsed;
            manipulatorwnd.Height = 165;
            manipulatorwnd.ShowDialog();
        }

        public static RoutedCommand Remove = new RoutedCommand("Remove", typeof(SfDataGrid));

        private static void OnCanExecuteRemove(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion

        #region Add Command
        /// <summary>
        ///Occurs when the command associated with this CommandBinding executes.
        /// </summary> 
        private static void OnExecuteAdd(object sender, ExecutedRoutedEventArgs e)
        {
            ManipulatorView manipulatorwnd = new ManipulatorView();
            manipulatorwnd.removenormalCol.Visibility = Visibility.Collapsed;
            manipulatorwnd.removecol_Tilte.Visibility = Visibility.Collapsed;
            manipulatorwnd.ShowDialog();
        }

        public static RoutedCommand Add = new RoutedCommand("Add", typeof(SfDataGrid));

        private static void OnCanExecuteAdd(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion

        #region Reset Command
       
        public static RoutedCommand Reset = new RoutedCommand("Reset", typeof(SfDataGrid));

        /// <summary>
        ///Occurs when the command associated with this CommandBinding executes.
        /// </summary>  
        private static void OnExecuteReset(object sender, ExecutedRoutedEventArgs e)
        {
            var dataGrid = e.Source as SfDataGrid;
            MainWindow mainwnd = (MainWindow)Application.Current.MainWindow;

            List<String> selectedItemsCol = new List<string>();
            if (dataGrid == null) return;
            try
            {
                using (var file = File.Open("Reset.xml", FileMode.Open))
                {
                    dataGrid.Deserialize(file);
                }
            }
            catch (Exception)
            {

            }
        }


        private static void OnCanExecuteReset(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        #endregion

        #region Serialize Command

        public static RoutedCommand Serialize = new RoutedCommand("Serialize", typeof(SfDataGrid));

        /// <summary>
        ///Occurs when the command associated with this CommandBinding executes.
        /// </summary> 
        private static void OnExecuteSerialize(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;

            if (dataGrid == null) return;
            var options = args.Parameter as SerializationOptions;
            try
            {
                using (var file = File.Create("DataGrid.xml"))
                {
                    dataGrid.Serialize(file, options);
                }
            }
            catch (Exception)
            {

            }
        }

        private static void OnCanExecuteSerialize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

        #region Deserialize Command

        public static RoutedCommand Deserialize = new RoutedCommand("Deserialize", typeof(SfDataGrid));
        /// <summary>
        ///Occurs when the command associated with this CommandBinding executes.
        /// </summary> 
        private static void OnExecuteDeserialize(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            MainWindow mainwnd = (MainWindow)Application.Current.MainWindow;
            List<String> selectedItemsCol = new List<string>();
            if (dataGrid == null) return;
            var options = args.Parameter as DeserializationOptions;
            try
            {
                using (var file = File.Open("DataGrid.xml", FileMode.Open))
                {
                    dataGrid.Deserialize(file, options);             
                }
            }
            catch (Exception)
            {
            }
        }

        private static void OnCanExecuteDeserialize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        #endregion

        #region GetDataTemplate
        /// <summary>
        ///For load the predefined datatemplate to the GridTemplateColumn
        /// </summary>
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
