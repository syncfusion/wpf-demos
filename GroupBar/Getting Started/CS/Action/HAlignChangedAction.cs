#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;

namespace GroupBarDemo
{
    /// <summary>
    /// Represents a action for horizontal alignment changes.
    /// </summary>
    public class HAlignChangedAction : TriggerAction<ComboBox>
    {
        /// <summary>
        /// Notifies the method which invokes the horizontal alignment.
        /// </summary>
        /// <param name="parameter">Invokes a method for horizontal alignment</param>
        protected override void Invoke(object parameter)
        {           
            Syncfusion.Windows.Tools.Controls.GroupView groupView;
            groupView = Target as Syncfusion.Windows.Tools.Controls.GroupView;
            if (groupView != null && parameter is SelectionChangedEventArgs && (parameter as SelectionChangedEventArgs).AddedItems.Count>0)
            {
                groupView.HorizontalContentAlignment = (HorizontalAlignment)(parameter as SelectionChangedEventArgs).AddedItems[0];
            }
        }

        /// <summary>
        /// Gets and sets the target value <see cref="HAlignChangedAction"/> class.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        ///  Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        /// </summary>
         public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(HAlignChangedAction), new UIPropertyMetadata(null));
    }
}
