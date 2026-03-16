#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.IO;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace syncfusion.treegriddemos.wpf
{
    public static class SerializationCommands
    {
        static SerializationCommands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(Serialize, OnExecuteSerialize, OnCanExecuteSerialize));
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(Deserialize, OnExecuteDeserialize, OnCanExecuteDeserialize));
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(Reset, OnExecuteReset, OnCanExecuteReset));

            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(Add, OnExecuteAdd, OnCanExecuteAdd));
            CommandManager.RegisterClassCommandBinding(typeof(SfTreeGrid), new CommandBinding(Remove, OnExecuteRemove, OnCanExecuteRemove));
        }

        private static void OnExecuteRemove(object sender, ExecutedRoutedEventArgs e)
        {
            var manipulatorwnd = new ManipulatorView();
            manipulatorwnd.addnormalCol.Visibility = Visibility.Collapsed;
            manipulatorwnd.addcolarea.Visibility = Visibility.Collapsed;
            manipulatorwnd.Height = 165;
            manipulatorwnd.ShowDialog();
        }

        public static RoutedCommand Remove = new RoutedCommand("Remove", typeof(SfTreeGrid));

        private static void OnCanExecuteRemove(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private static void OnExecuteAdd(object sender, ExecutedRoutedEventArgs e)
        {
            var manipulatorwnd = new ManipulatorView();
            manipulatorwnd.removenormalCol.Visibility = Visibility.Collapsed;
            manipulatorwnd.removecol_Tilte.Visibility = Visibility.Collapsed;
            manipulatorwnd.ShowDialog();
        }

        public static RoutedCommand Add = new RoutedCommand("Add", typeof(SfTreeGrid));

        private static void OnCanExecuteAdd(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public static RoutedCommand Reset = new RoutedCommand("Reset", typeof(SfTreeGrid));

        private static void OnExecuteReset(object sender, ExecutedRoutedEventArgs e)
        {
            var treeGrid = e.Source as SfTreeGrid;
            if (treeGrid == null) return;
            try
            {
                using (var file = File.Open("Reset.xml", FileMode.Open))
                {
                    treeGrid.Deserialize(file);
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

        public static RoutedCommand Serialize = new RoutedCommand("Serialize", typeof(SfTreeGrid));

        private static void OnExecuteSerialize(object sender, ExecutedRoutedEventArgs args)
        {
            var treeGrid = args.Source as SfTreeGrid;
            var options = args.Parameter as TreeGridSerializationOptions;
            if (treeGrid == null || options == null)
                return;
            try
            {
                using (var file = File.Create("TreeGrid.xml"))
                {
                    treeGrid.Serialize(file, options);
                }
                MessageBox.Show("Serialization Completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {

            }
        }

        private static void OnCanExecuteSerialize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        public static RoutedCommand Deserialize = new RoutedCommand("Deserialize", typeof(SfTreeGrid));

        private static void OnExecuteDeserialize(object sender, ExecutedRoutedEventArgs args)
        {
            var treeGrid = args.Source as SfTreeGrid;
            var options = args.Parameter as TreeGridDeserializationOptions;
            if (treeGrid == null || options == null)
                return;
            try
            {
                using (var file = File.Open("TreeGrid.xml", FileMode.Open))
                {
                    treeGrid.Deserialize(file, options);
                }
                MessageBox.Show("Deserialization Completed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {

            }
        }

        private static void OnCanExecuteDeserialize(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = true;
        }

        private static DataTemplate GetDataTemplate(TreeGridTemplateColumn col)
        {
            FrameworkElementFactory txt = new FrameworkElementFactory(typeof(TextBlock));
            var bind = new Binding
            {
                Path = new PropertyPath(col.MappingName),
                Mode = BindingMode.TwoWay
            };
            txt.SetBinding(TextBlock.TextProperty, bind);
            DataTemplate dataTemplate = new DataTemplate();
            dataTemplate.VisualTree = txt;
            return dataTemplate;
        }
    }
}
