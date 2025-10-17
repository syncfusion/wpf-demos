using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    public class NavigateHomePageAction : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            //if (DemosNavigationService.RootNavigationService.CanGoBack)
            {
                DemosNavigationService.RootNavigationService.Content = null;
            }
        }
    }
}