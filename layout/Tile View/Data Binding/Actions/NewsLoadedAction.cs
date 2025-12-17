using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.layoutdemos.wpf
{
    public class NewsLoadedAction : TargetedTriggerAction<UserControl>
    {
        protected override void Invoke(object parameter)
        {
        }

        public string TimeNow
        {
            get { return (string)GetValue(TimeNowProperty); }
            set { SetValue(TimeNowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimeNow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeNowProperty =
            DependencyProperty.Register("TimeNow", typeof(string), typeof(TileLoadedAction), new UIPropertyMetadata(DateTime.Now.ToString()));
    }
}
