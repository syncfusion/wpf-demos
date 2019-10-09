#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PropertyGridConfigurationDemo
{
    /// <summary>
    /// Interaction logic for PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();
        }



        public object Selectedobject
        {
            get { return (object)GetValue(SelectedobjectProperty); }
            set { SetValue(SelectedobjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Selectedobject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedobjectProperty =
            DependencyProperty.Register("Selectedobject", typeof(object), typeof(PropertyView), new PropertyMetadata(null));

        private void selobj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Selectedobject = e.AddedItems[0];
        }
        
    }
}
