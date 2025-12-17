using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace syncfusion.visualstudiodemo.wpf
{
    public class ErrorListViewModel : NotificationObject
    {
        public ErrorListViewModel()
        {
            Items = new ObservableCollection<ErrorListModel>()
            {
              new ErrorListModel  
              { 
                  Number = "1", 
                  Description = "Method must have a return type", 
                  File = "MainWindow.xaml.cs", 
                  Column = "66", 
                  Line = "16", 
                  Project = "DockingManagerMVVMCaliburnDemo_2010" 
              },
              new ErrorListModel 
              { 
                  Number = "2", 
                  Description = "Key Value not found", 
                  File = "MainWindow.xaml", 
                  Column = "26", 
                  Line = "23", 
                  Project = "DockingManagerMVVMCaliburnDemo_2010" 
              },
            };
        }

        private ObservableCollection<ErrorListModel> items;

        public ObservableCollection<ErrorListModel> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}
