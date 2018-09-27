using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace HierarchyNavigator_2008
{
    public class Model : NotificationObject
    {        
       
        private DelegateCommand<object> myCommand2;
       

        public DelegateCommand<object> RefreshCommand
        {
            get
            {
                myCommand2 = new DelegateCommand<object>(MyCommand2Method);
                return myCommand2;
            }
        }
       
        
        private void MyCommand2Method(object Parameter)
        {
            (Parameter as HierarchyNavigator).ShowProgressBar(new TimeSpan(0, 0, 0, 0, 200));
        }

        private string content;
        public string Content 
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                RaisePropertyChanged("Content");
            }
        }

        private ImageSource folderImage;
        public ImageSource FolderImage 
        { 
            get
            {
                return folderImage;
            }
            set
            {
                folderImage = value;
                RaisePropertyChanged("FolderImage");
            }
        }

        private ObservableCollection<Model> folderItems;
        public ObservableCollection<Model> FolderItems 
        { 
            get
            {
                return folderItems;
            }
            set
            {
                folderItems = value;
                RaisePropertyChanged("FolderItems");
            }
        }

        public Model()
        {
            folderItems = new ObservableCollection<Model>();
        }
    }
}
