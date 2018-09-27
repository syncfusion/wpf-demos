using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace TradingGridDemo
{
    public class Behaviour : Behavior<Window>
    {
        /// <summary>
        /// Attaches to the specified object.
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
            AssociatedObject.Unloaded += AssociatedObject_Unloaded;
        }

        /// <summary>
        /// Window Loaded event.
        /// </summary>
        /// <param name="sender">MainWindow</param>
        /// <param name="e"></param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            //Start the Timer for updation in WindowLoaded Event
            (AssociatedObject.DataContext as StocksViewModel).StartTimer();
        }

        /// <summary>
        /// Window Unloaded event. 
        /// </summary>
        /// <param name="sender">MainWindow</param>
        /// <param name="e"></param>
        void AssociatedObject_Unloaded(object sender, RoutedEventArgs e)
        {
            //Stop the Timer in WindowUnLoaded Event
            (AssociatedObject.DataContext as StocksViewModel).StopTimer();
        }

        /// <summary>
        /// Detaches this instance from its associated object.
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.Unloaded -= AssociatedObject_Unloaded;
        }
    }
    
}
