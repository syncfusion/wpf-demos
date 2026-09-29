using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.treegriddemos.wpf
{
    public class ComboBoxColumnBehavior : Behavior<ComboBox>
    {
        /// <summary>
        ///   Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.SelectionChanged += OnComboBoxSelectionChanged;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectionChanged -= OnComboBoxSelectionChanged;
        }

        /// <summary>
        /// Event handler when the SelectionChanged in ComboBox.
        /// </summary>  
        void OnComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            ManipulatorView manipulatorwnd = ManipulatorView.manipulatorView;
            manipulatorwnd.Height = 230;
            manipulatorwnd.err_textblock.Visibility = Visibility.Collapsed;
            manipulatorwnd.mappingname_cmbbox.Visibility = Visibility.Visible;
            manipulatorwnd.Mappingname_Label.Visibility = Visibility.Visible;
           
        }
    }
}
