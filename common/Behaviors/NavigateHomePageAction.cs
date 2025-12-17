using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Represents a trigger action that navigates to the Homepage demo when invoked.
    /// </summary>
    public class NavigateHomePageAction : TriggerAction<Button>
    {
        /// <summary>
        /// Invokes the action, causing the navigation service to clear its content, returning to the home page.
        /// </summary>
        /// <param name="parameter">The parameter passed to the action.</param>
        protected override void Invoke(object parameter)
        {
            //if (DemosNavigationService.RootNavigationService.CanGoBack)
            {
                DemosNavigationService.RootNavigationService.Content = null;
            }
        }
    }
}