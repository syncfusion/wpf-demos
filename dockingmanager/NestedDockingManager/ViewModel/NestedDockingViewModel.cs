using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class NestedDockingViewModel : NotificationObject
    {
       private ICommand loaded;
       public ICommand Loaded
       {
           get
           {
               return loaded;
           }
           set
           {
               loaded = value;
               RaisePropertyChanged("Loaded");
           }
       }
      
       private DockingManager clientdockingManager;
       public NestedDockingViewModel()
       {
           Loaded = new DelegateCommand<object>(documentcontainer_Loaded);
       }
       private void documentcontainer_Loaded(object parameter)
       {
           clientdockingManager= parameter as DockingManager;
           DocumentContainer documentcontainer = clientdockingManager.DocContainer as DocumentContainer;
           documentcontainer.Loaded += Documentcontainer_Loaded;
       }

       private void Documentcontainer_Loaded(object sender, RoutedEventArgs e)
       {
           TabPanelAdv tabpanel = VisualUtils.FindDescendant(sender as Visual, typeof(TabPanelAdv)) as TabPanelAdv;
           if (tabpanel != null)
           {
               Button prevbutton = tabpanel.Template.FindName("PART_PrevTab", tabpanel) as Button;
               Button nextbutton = tabpanel.Template.FindName("PART_NextTab", tabpanel) as Button;
               if (prevbutton != null)
               {
                   ToolTipService.SetShowOnDisabled(prevbutton, true);
                   prevbutton.ToolTip = "Previous";
               }
               if (nextbutton != null)
               {
                   ToolTipService.SetShowOnDisabled(nextbutton, true);
                   nextbutton.ToolTip = "Next";
               }
           }
       }
    }
}
