#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using System.Windows.Media;

namespace MindMap
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MindAppBarView : UserControl

    {
        public MindAppBarView()
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
            DependencyProperty.Register("ExportFiles", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));

        public ICommand ImportFiles
        {
            get { return (ICommand)GetValue(ImportFilesProperty); }
            set { SetValue(ImportFilesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImportFiles.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImportFilesProperty =
            DependencyProperty.Register("ImportFiles", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));

      
        public ICommand Delete
        {
            get { return (ICommand)GetValue(DeleteProperty); }
            set { SetValue(DeleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Delete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteProperty =
            DependencyProperty.Register("Delete", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));



        public ICommand Save
        {
            get { return (ICommand)GetValue(SaveProperty); }
            set { SetValue(SaveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Save.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveProperty =
            DependencyProperty.Register("Save", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));

        public ICommand Load
        {
            get { return (ICommand)GetValue(LoadProperty); }
            set { SetValue(LoadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Load.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadProperty =
            DependencyProperty.Register("Load", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));

    

        public ICommand Clear
        {
            get { return (ICommand)GetValue(ClearProperty); }
            set { SetValue(ClearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clear.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearProperty =
            DependencyProperty.Register("Clear", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));



        public ICommand ApplyBowtieLayout
        {
            get { return (ICommand)GetValue(ApplyBowtieLayoutProperty); }
            set { SetValue(ApplyBowtieLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ApplyBowtieLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ApplyBowtieLayoutProperty =
            DependencyProperty.Register("ApplyBowtieLayout", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));




        public ICommand ApplyCircularLayout
        {
            get { return (ICommand)GetValue(ApplyCircularLayoutProperty); }
            set { SetValue(ApplyCircularLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ApplyCircularLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ApplyCircularLayoutProperty =
            DependencyProperty.Register("ApplyCircularLayout", typeof(ICommand), typeof(MindAppBarView), new PropertyMetadata(null));

        
        //private void Viewbox_PointerPressed_1(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Delete != null)
        //    {
        //        Delete.Execute(null);
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

   
        //private void Clear_Clicked(object sender, PointerRoutedEventArgs e)
        //{
        //    if (Clear != null)
        //    {
        //        Clear.Execute(null);
        //    }
        //}
    


        //private void ExportFiles_Clicked(object sender, PointerRoutedEventArgs e)
        //{
        //    ExportFiles.Execute(null);            
        //}

        //private void ImportFiles_Clicked(object sender, PointerRoutedEventArgs e)
        //{
        //    ImportFiles.Execute(null);
        //}

        //private void Delete_Clicked(object sender, PointerRoutedEventArgs e)
        //{
        //    (this.DataContext as MapViewModel).DeleteFiles.Execute(null);
        //}

        //private void Rename_Clicked(object sender, PointerRoutedEventArgs e)
        //{
        //}

        //private void ClearSelection_Clicked(object sender, PointerRoutedEventArgs e)
        //{

        //}


    }

    public class VisibiliyCommandBinding : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ICommand cmd = value as ICommand;
            if (cmd.CanExecute(null))
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

    public class ContentPresenters : ContentPresenter
    {

        public ContentPresenters()
        {

        }

        public SolidColorBrush Foreground
        {
            get { return (SolidColorBrush)GetValue(ForegroundProperty); }
            set { SetValue(ForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Foreground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ForegroundProperty =
            DependencyProperty.Register("Foreground", typeof(SolidColorBrush), typeof(ContentPresenters), new PropertyMetadata(new SolidColorBrush(Colors.DarkGray)));


    }
}
