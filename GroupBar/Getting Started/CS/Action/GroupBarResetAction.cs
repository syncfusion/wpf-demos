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
    /// Represents a Reset action for groupbar.
    /// </summary>
    public class GroupBarResetAction : TriggerAction<Button>
    {
        /// <summary>
        /// Notifies the method which invokes reset action.
        /// </summary>
        /// <param name="parameter">Invokes the reset action</param>
        protected override void Invoke(object parameter)
        {
            Syncfusion.Windows.Tools.Controls.GroupBar GroupBarFields;
            GroupBarFields = Target as Syncfusion.Windows.Tools.Controls.GroupBar;
            if (GroupBarFields != null)
            {
                GroupBarFields.ResetBarState();
            }
        }

        /// <summary>
        /// Gets and sets the target value <see cref="GroupBarResetAction"/> class.
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
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(GroupBarResetAction), new UIPropertyMetadata(null));
    }
}
