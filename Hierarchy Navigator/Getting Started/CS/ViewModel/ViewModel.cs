#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace HierarchyNavigator_2008
{
    /// <summary>
    /// Represents a view model for the hierarchy navigator control.
    /// </summary>
    public class ViewModel : NotificationObject
    { 
        /// <summary>
        ///  Maintains the collection of eventLog.
        /// </summary>
        private ObservableCollection<string> eventLog = new ObservableCollection<string>();

        /// <summary>
        ///  Maintains slected value property.
        /// </summary>
        private object hierarchyItems;

        /// <summary>
        ///  Maintains refereshCommand.
        /// </summary>
        private DelegateCommand<object> refereshCommand;

        /// <summary>
        ///  Maintains listBox items collection.
        /// </summary>
        private ObservableCollection<Model> listBoxItems;

        /// <summary>
        /// Maintains the collection of file items.
        /// </summary>
        public ObservableCollection<Model> fileItems;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            fileItems = new ObservableCollection<Model>();
            listBoxItems = new ObservableCollection<Model>(); 
           
            Model fileItem = new Model() { Content = "Desktop"};
            Model MajorDirectory1 = new Model() { Content = "Computer",  FolderImage = new BitmapImage(new Uri("/Images/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            Model MajorDirectory2 = new Model() { Content = "Documents", FolderImage = new BitmapImage(new Uri("/Images/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            Model MajorDirectory3 = new Model() { Content = "Control Panel", FolderImage = new BitmapImage(new Uri("/Images/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            Model MajorDirectory4 = new Model() { Content = "Devices and Printers",FolderImage = new BitmapImage(new Uri("/Images/DesktopOpen.png", UriKind.RelativeOrAbsolute)) } ;
            Model MajorDirectory5 = new Model() { Content = "Default Programs", FolderImage = new BitmapImage(new Uri("/Images/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            Model MajorDirectory6 = new Model() { Content = "Help and Support", FolderImage = new BitmapImage(new Uri("/Images/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };

            Model SubDirectory1 = new Model() { Content = "Local Disk (C:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) };       
            Model SubDirectory2 = new Model() { Content = "Local Disk (D:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) };
            Model SubDirectory3 = new Model() { Content = "Local Disk (E:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) };
            Model SubDirectory4 = new Model() { Content = "Local Disk (F:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) };
            Model SubDirectory5 = new Model() { Content = "Pictures", FolderImage = new BitmapImage(new Uri("/Images/Picture.png", UriKind.RelativeOrAbsolute)) };         
            Model SubDirectory6 = new Model() { Content = "Music", FolderImage = new BitmapImage(new Uri("/Images/Music.png", UriKind.RelativeOrAbsolute)) } ;          
            Model SubDirectory7 = new Model() { Content = "Downloads", FolderImage = new BitmapImage(new Uri("/Images/HDDownloads.png", UriKind.RelativeOrAbsolute)) } ;

            SubDirectory1.FolderItems.Add(new Model() { Content = "Program Files", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Windows", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Syncfusion", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Drivers", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Perlogs", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Users", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Common", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory2.FolderItems.Add(new Model() { Content = "My Studio", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new Model() { Content = "Windows 7", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new Model() { Content = "Desert", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new Model() { Content = "Jelly Fish", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new Model() { Content = "Koala", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new Model() { Content = "Penguins", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory6.FolderItems.Add(new Model() { Content = "Melody", FolderImage = new BitmapImage(new Uri("/Images/Music.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory6.FolderItems.Add(new Model() { Content = "Pop", FolderImage = new BitmapImage(new Uri("/Images/Music.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory7.FolderItems.Add(new Model() { Content = "Syncfusion Policies", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory7.FolderItems.Add(new Model() { Content = "Syncfusion Products", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory7.FolderItems.Add(new Model() { Content = "Syncfusion Guests", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });

            MajorDirectory1.FolderItems.Add(SubDirectory1);
            MajorDirectory1.FolderItems.Add(SubDirectory2);
            MajorDirectory1.FolderItems.Add(SubDirectory3);
            MajorDirectory1.FolderItems.Add(SubDirectory4);
            MajorDirectory2.FolderItems.Add(SubDirectory5);
            MajorDirectory2.FolderItems.Add(SubDirectory6);
            MajorDirectory2.FolderItems.Add(SubDirectory7);

            MajorDirectory3.FolderItems.Add(new Model() { Content = "System and Security", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new Model() { Content = "User Accounts", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new Model() { Content = "Network and Internet", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new Model() { Content = "Appearance and Personalization", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory3.FolderItems.Add(new Model() { Content = "Hardware and Sound", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory3.FolderItems.Add(new Model() { Content = "Clock,Languages and Region", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new Model() { Content = "Ease of Access", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new Model() { Content = "Programs", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );

            fileItem.FolderItems.Add(MajorDirectory1);
            fileItem.FolderItems.Add(MajorDirectory2);
            fileItem.FolderItems.Add(MajorDirectory3);
            fileItem.FolderItems.Add(MajorDirectory4);
            fileItem.FolderItems.Add(MajorDirectory5);
            fileItem.FolderItems.Add(MajorDirectory6);

            fileItems.Add(fileItem);
            HierarchyItems = fileItem;
        }

        /// <summary>
        /// Gets or sets the event log collection <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<string> EventLog
        {
            get
            {
                return eventLog;
            }
            set
            {
                eventLog = value;
                RaisePropertyChanged("EventLog");
            }
        }

        /// <summary>
        /// Gets or sets the selected value property <see cref="ViewModel"/> class.
        /// </summary>
        public object HierarchyItems
        {
            get
            {
                return hierarchyItems;
            }
            set
            {
                hierarchyItems = value;
                PropertyChangedHandler();
                RaisePropertyChanged("HierarchyItems");
            }
        }

        /// <summary>
        /// Gets or sets the file items collection <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FileItems
        {
            get
            {
                return fileItems;
            }
            set
            {
                fileItems = value;
                RaisePropertyChanged("FileItems");
            }
        }

        /// <summary>
        /// Gets or sets the refresh refereshCommand <see cref="ViewModel"/> class.
        /// </summary>
        public DelegateCommand<object> RefreshCommand
        {
            get
            {
                refereshCommand = new DelegateCommand<object>(CommandExecute);
                return refereshCommand;
            }
        }

        /// <summary>
        /// Gets or sets the listBox items collection <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> ListBoxItems
        {
            get
            {
                return listBoxItems;
            }
            set
            {
                listBoxItems = value;
                RaisePropertyChanged("ListBoxItems");
            }
        }

        /// <summary>
        /// Handling the selected changed event.
        /// </summary> 
        public void PropertyChangedHandler()
        {
            if (HierarchyItems != null)
            {
                EventLog.Add("Selection Changed:" + (HierarchyItems as Model).Content.ToString());
                ListBoxItems = (HierarchyItems as Model).FolderItems;
            }
        }

        /// <summary>
        /// Method used to execute the refereshCommand.
        /// </summary>
        /// <param name="parameter">Parameter which passes a method to the refereshCommand</param>
        private void CommandExecute(object parameter)
        {
            (parameter as HierarchyNavigator).ShowProgressBar(new TimeSpan(0, 0, 0, 0, 200));
        }
    }
}
