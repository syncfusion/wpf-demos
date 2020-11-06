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
// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.floorplanner.wpf
{
    public sealed partial class AddAnnotation : UserControl
    {
        public AddAnnotation()
        {
            this.InitializeComponent();
            text.Focus();
        }

        void text_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text == "Text")
            {
                (sender as TextBox).Select(0, 3);
            }
        }

        private void text_Loaded_1(object sender, RoutedEventArgs e)
        {

        }


        public FloorPlannerViewModel DataViewModel
        {
            get { return (FloorPlannerViewModel)GetValue(DataViewModelProperty); }
            set { SetValue(DataViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataViewModelProperty =
            DependencyProperty.Register("DataViewModel", typeof(FloorPlannerViewModel), typeof(AddAnnotation), new PropertyMetadata(null, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AddAnnotation a = d as AddAnnotation;
            if (a != null)
            {
                if (a.DataViewModel != null)
                {
                    (a.DataViewModel as FloorPlannerViewModel).textbox = a.text;
                    a.text.Select(0, 4);
                }
            }
        }

        private void text_Loaded_2(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Focus();
            (sender as TextBox).Select(0, 4);
        }
    }
}
