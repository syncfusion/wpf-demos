using System;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the show progress bar action. 
    /// </summary>
    public class ShowProgressBarBehavior : TargetedTriggerAction<Button>
    {
        /// <summary>
        /// Method which invokes the show progress bar action.
        /// </summary>
        /// <param name="parameter">Invokes the show progress bar action</param>
        protected override void Invoke(object parameter)
        {
            var hierarchyNavigator = TargetObject as HierarchyNavigator;
            if (hierarchyNavigator == null)
                return;

            hierarchyNavigator.ShowProgressBar(new TimeSpan(0, 0, 0, 0,ShowValue));
        }

        /// <summary>
        /// Gets or sets the show value.
        /// </summary>
        public int ShowValue
        {
            get { return (int)GetValue(ShowValueProperty); }
            set { SetValue(ShowValueProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ShowValue.  This enables animation, styling, binding, etc...
        /// </summary>
       public static readonly DependencyProperty ShowValueProperty =
            DependencyProperty.Register("ShowValue", typeof(int), typeof(ShowProgressBarBehavior), new UIPropertyMetadata(null));
    }
}
