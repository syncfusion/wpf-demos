#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UMLDiagramDesigner
{
    public partial class AppBarView : UserControl
    {
        public AppBarView()
        {
            this.InitializeComponent();
        }

        public ICommand ExportFiles
        {
            get { return (ICommand)GetValue(ExportFilesProperty); }
            set { SetValue(ExportFilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ExportFiles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExportFilesProperty =
            DependencyProperty.Register("ExportFiles", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand ImportFiles
        {
            get { return (ICommand)GetValue(ImportFilesProperty); }
            set { SetValue(ImportFilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImportFiles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImportFilesProperty =
            DependencyProperty.Register("ImportFiles", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Undo
        {
            get { return (ICommand)GetValue(UndoProperty); }
            set { SetValue(UndoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Undo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UndoProperty =
            DependencyProperty.Register("Undo", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Redo
        {
            get { return (ICommand)GetValue(RedoProperty); }
            set { SetValue(RedoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Redo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RedoProperty =
            DependencyProperty.Register("Redo", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Delete
        {
            get { return (ICommand)GetValue(DeleteProperty); }
            set { SetValue(DeleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Delete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteProperty =
            DependencyProperty.Register("Delete", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));


        public ICommand ShowProperties
        {
            get { return (ICommand)GetValue(ShowPropertiesProperty); }
            set { SetValue(ShowPropertiesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowProperties.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowPropertiesProperty =
            DependencyProperty.Register("ShowProperties", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));


        public ICommand Connector
        {
            get { return (ICommand)GetValue(ConnectorProperty); }
            set { SetValue(ConnectorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Connect.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConnectorProperty =
            DependencyProperty.Register("Connector", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Split
        {
            get { return (ICommand)GetValue(SplitProperty); }
            set { SetValue(SplitProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Split.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SplitProperty =
            DependencyProperty.Register("Split", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Save
        {
            get { return (ICommand)GetValue(SaveProperty); }
            set { SetValue(SaveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Save.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveProperty =
            DependencyProperty.Register("Save", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Load
        {
            get { return (ICommand)GetValue(LoadProperty); }
            set { SetValue(LoadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Load.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadProperty =
            DependencyProperty.Register("Load", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand AddINodeType
        {
            get { return (ICommand)GetValue(AddINodeTypeProperty); }
            set { SetValue(AddINodeTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AddINodeType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AddINodeTypeProperty =
            DependencyProperty.Register("AddINodeType", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        public ICommand Clear
        {
            get { return (ICommand)GetValue(ClearProperty); }
            set { SetValue(ClearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clear.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearProperty =
            DependencyProperty.Register("Clear", typeof(ICommand), typeof(AppBarView), new PropertyMetadata(null));

        //private void Viewbox_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Delete != null)
        //    {
        //        Delete.Execute(null);
        //    }
        //}

        //private void Viewbox_PointerPressed_2(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Connector != null)
        //    {
        //        Connector.Execute(null);
        //    }
        //}

        //private void Viewbox_PointerPressed_3(object sender, PointerRoutedEventArgs e)
        //{
        //    if (ShowProperties != null)
        //    {
        //        ShowProperties.Execute(null);
        //    }
        //}

        //private void StackPanel_PointerReleased_1(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Split != null)
        //    {
        //        Split.Execute(null);
        //    }
        //}

        //private void Save_Released(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Save != null)
        //    {
        //        Save.Execute(null);
        //    }
        //}

        //private void Load_Released(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Load != null)
        //    {
        //        Load.Execute(null);
        //    }
        //}

        private void AddClass_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (AddINodeType != null)
            {
                AddINodeType.Execute(NewNodeType.Class);
            }
        }
        private void AddInterface_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (AddINodeType != null)
            {
                AddINodeType.Execute(NewNodeType.Interface);
            }
        }
        private void AddNote_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (AddINodeType != null)
            {
                AddINodeType.Execute(NewNodeType.Note);
            }
        }
        private void AddText_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (AddINodeType != null)
            {
                AddINodeType.Execute(NewNodeType.Text);
            }
        }

        private void Clear_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Clear != null)
            {
                Clear.Execute(null);
            }
        }

        private void Undo_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Undo != null)
            {
                Undo.Execute(null);
            }
        }

        private void Redo_Clicked(object sender, MouseButtonEventArgs e)
        {
            if (Redo != null)
            {
                Redo.Execute(null);
            }
        }

        private void ExportFiles_Clicked(object sender, MouseButtonEventArgs e)
        {
            ExportFiles.Execute(null);            
        }

        private void ImportFiles_Clicked(object sender, MouseButtonEventArgs e)
        {
            ImportFiles.Execute(null);
        }

        private void Delete_Clicked(object sender, MouseButtonEventArgs e)
        {
            (this.DataContext as UMLViewModel).DeleteFiles.Execute(null);
        }

        private void Rename_Clicked(object sender, MouseButtonEventArgs e)
        {
        }

        private void ClearSelection_Clicked(object sender, MouseButtonEventArgs e)
        {

        }


    }

    public class VisibiliyCommandBinding : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ICommand cmd = value as ICommand;
            if (cmd!=null)
            {
                if (cmd.CanExecute(null))
                {
                    return Visibility.Visible;
                } 
            }
            //else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

    public class VisibilityInverse : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility vis = (Visibility)value;
            if (vis == Visibility.Collapsed)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
