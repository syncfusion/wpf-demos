using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Controls;

namespace GroupBarDemo
{
    public class GroupBarSaveAction : TriggerAction<Button>
    {
        Syncfusion.Windows.Tools.Controls.GroupBar myGroupBar;

        protected override void Invoke(object parameter)
        {
            myGroupBar = Target as Syncfusion.Windows.Tools.Controls.GroupBar;
            if (myGroupBar != null)
            {
                myGroupBar.SaveBarState();
            }
        }

        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(GroupBarSaveAction), new UIPropertyMetadata(null));
    }
}
