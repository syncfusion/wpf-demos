#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace syncfusion.floorplanner.wpf
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FloorPlanAppBarView : UserControl
    {
        public FloorPlanAppBarView()
        {
            this.InitializeComponent();
        }

        public ICommand Delete
        {
            get { return (ICommand)GetValue(DeleteProperty); }
            set { SetValue(DeleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Delete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeleteProperty =
            DependencyProperty.Register("Delete", typeof(ICommand), typeof(FloorPlanAppBarView), new PropertyMetadata(null));



        public ICommand Save
        {
            get { return (ICommand)GetValue(SaveProperty); }
            set { SetValue(SaveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Save.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SaveProperty =
            DependencyProperty.Register("Save", typeof(ICommand), typeof(FloorPlanAppBarView), new PropertyMetadata(null));

        public ICommand Load
        {
            get { return (ICommand)GetValue(LoadProperty); }
            set { SetValue(LoadProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Load.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadProperty =
            DependencyProperty.Register("Load", typeof(ICommand), typeof(FloorPlanAppBarView), new PropertyMetadata(null));



        public ICommand Clear
        {
            get { return (ICommand)GetValue(ClearProperty); }
            set { SetValue(ClearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Clear.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearProperty =
            DependencyProperty.Register("Clear", typeof(ICommand), typeof(FloorPlanAppBarView), new PropertyMetadata(null));    

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
