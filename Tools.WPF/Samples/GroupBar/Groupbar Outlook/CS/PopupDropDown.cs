#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GroupbarOutlookDemo"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GroupbarOutlookDemo;assembly=GroupbarOutlookDemo"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    /// 
    
    

    /// 
    ///     <MyNamespace:PopupDropDown/>
    ///
    /// </summary>
    public class PopupDropDown : Control
    {


        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<string>), typeof(PopupDropDown), new PropertyMetadata(null));



        private ListBox PART_ListBox;
        private Label PART_Label;
        static PopupDropDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupDropDown), new FrameworkPropertyMetadata(typeof(PopupDropDown)));
        }
        public override void OnApplyTemplate()
        {
            PART_ListBox = base.GetTemplateChild("PART_ListBox") as ListBox;
            PART_Label = base.GetTemplateChild("PART_Label") as Label;
            this.Loaded += PopupDropDown_Loaded;
            if(PART_ListBox != null)
                PART_ListBox.SelectionChanged += PART_ListBox_SelectionChanged;
            base.OnApplyTemplate();
        }

        void PART_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PART_Label.Content = (sender as ListBox).SelectedItem;
        }

        void PopupDropDown_Loaded(object sender, RoutedEventArgs e)
        {
            if (PART_Label != null && this.ItemsSource != null)
            {
                PART_Label.Content = this.ItemsSource.ToList()[0];
            }
        }
    }
}
