using System.Windows.Interactivity;
using Syncfusion.Windows.Shared;

namespace XlsFileUsingXlsIO
{
    class ButtonAction : TargetedTriggerAction<ChromelessWindow>
    {
        protected override void Invoke(object parameter)
        {
            switch (((parameter as System.Windows.RoutedEventArgs).Source as System.Windows.Controls.Button).Name)
            {
                case "button61":

                    break;
                case "button2":

                    break;
            }
        }
    }
}
