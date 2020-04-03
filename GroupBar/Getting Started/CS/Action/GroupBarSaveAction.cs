#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Controls;

namespace GroupBarDemo
{
    /// <summary>
    /// Represents a Save action for groupbar.
    /// </summary>
    public class GroupBarSaveAction : TriggerAction<Button>
    {
        /// <summary>
        /// Notifies the method which invokes the save action.
        /// </summary>
        /// <param name="parameter">Invokes a save action</param>
        protected override void Invoke(object parameter)
        {
            Syncfusion.Windows.Tools.Controls.GroupBar GroupBarFields;
            GroupBarFields = Target as Syncfusion.Windows.Tools.Controls.GroupBar;
            if (GroupBarFields != null)
            {
                GroupBarFields.SaveBarState();
            }
        }

        /// <summary>
        /// Gets and sets the target value <see cref="GroupBarSaveAction"/> class.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(GroupBarSaveAction), new UIPropertyMetadata(null));
    }
}
