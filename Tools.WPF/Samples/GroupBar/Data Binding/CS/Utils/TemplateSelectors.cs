using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;

namespace ItemsSourceDemo
{
    public class SampleTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Window win = Application.Current.MainWindow;
            GroupBar gBar = Syncfusion.Windows.Shared.VisualUtils.FindDescendant(win, typeof(GroupBar)) as GroupBar;

            if (gBar != null)
            {
                if (gBar.Orientation == Orientation.Vertical)
                {
                    return win.Resources["vertical"] as DataTemplate;
                }
                else
                {
                    return win.Resources["horizantal"] as DataTemplate;
                }
            }
            else
            {
                return win.Resources["vertical"] as DataTemplate;
            }
        }
    }
}
