using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace Virtualization
{
    public class TreeViewVisibility:TargetedTriggerAction<TreeViewAdv>
    {
        protected override void Invoke(object parameter)
        {
            ((TreeViewAdv)TargetObject).Visibility = Visibility.Visible;
        }

#if Framework3_5
        public FrameworkElement TargetObject
        {
            get { return (FrameworkElement)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(FrameworkElement), typeof(TreeViewVisibility), new UIPropertyMetadata(null));
#endif

    }
}
