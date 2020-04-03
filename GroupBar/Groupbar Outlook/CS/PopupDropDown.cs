#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
 	/// Represents a class of PopupDropDown class.
 	/// </summary>
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
        #region Fields
        /// <summary>
        /// Maintains a part list box.
        /// </summary>
        private ListBox PART_ListBox;

        /// <summary>
        /// Maintains a part label.
        /// </summary>
        private Label PART_Label;
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets the item source.
        /// </summary>
        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        ///  Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<string>), typeof(PopupDropDown), new PropertyMetadata(null));
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PopupDropDown" /> class.
        /// </summary>    
        static PopupDropDown()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupDropDown), new FrameworkPropertyMetadata(typeof(PopupDropDown)));
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Apply templates to the listbox and label.
        /// </summary>
        public override void OnApplyTemplate()
        {
            PART_ListBox = base.GetTemplateChild("PART_ListBox") as ListBox;
            PART_Label = base.GetTemplateChild("PART_Label") as Label;
            this.Loaded += PopupDropDown_Loaded;
            if(PART_ListBox != null)
                PART_ListBox.SelectionChanged += PART_ListBox_SelectionChanged;
            base.OnApplyTemplate();
        }

        /// <summary>
        /// Moves data from list box item content to label.
        /// </summary>
        /// <param name="sender">Sender as list box to change the selected item</param>
        /// <param name="e">Event handler for selected changed event</param>
        void PART_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PART_Label.Content = (sender as ListBox).SelectedItem;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <param name="sender">Sender as textblock to popup items to the dropdown</param>
        /// <param name="e">Event handler method for popup loaded items</param>
        void PopupDropDown_Loaded(object sender, RoutedEventArgs e)
        {
            if (PART_Label != null && this.ItemsSource != null)
            {
                PART_Label.Content = this.ItemsSource.ToList()[0];
            }
        }
        #endregion
    }
}
