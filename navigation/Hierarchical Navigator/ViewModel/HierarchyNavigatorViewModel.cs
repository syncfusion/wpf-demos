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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents a view model for the hierarchy navigator control.
    /// </summary>
    public class HierarchyNavigatorViewModel : NotificationObject
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
        private demoscommon.wpf.DelegateCommand<object> refereshCommand;

        /// <summary>
        ///  Maintains listBox items collection.
        /// </summary>
        private ObservableCollection<HierarchyNavigatorModel> listBoxItems;

        /// <summary>
        /// Maintains the collection of file items.
        /// </summary>
        public ObservableCollection<HierarchyNavigatorModel> fileItems;

        /// <summary>
        ///  Initializes a new instance of the <see cref="HierarchyNavigatorViewModel" /> class.
        /// </summary>
        public HierarchyNavigatorViewModel()
        {
            fileItems = new ObservableCollection<HierarchyNavigatorModel>();
            listBoxItems = new ObservableCollection<HierarchyNavigatorModel>(); 
           
            HierarchyNavigatorModel fileItem = new HierarchyNavigatorModel() { Content = "Desktop"};
            HierarchyNavigatorModel MajorDirectory1 = new HierarchyNavigatorModel() { Content = "Computer",  FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel MajorDirectory2 = new HierarchyNavigatorModel() { Content = "Documents", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel MajorDirectory3 = new HierarchyNavigatorModel() { Content = "Control Panel", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel MajorDirectory4 = new HierarchyNavigatorModel() { Content = "Devices and Printers",FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/DesktopOpen.png", UriKind.RelativeOrAbsolute)) } ;
            HierarchyNavigatorModel MajorDirectory5 = new HierarchyNavigatorModel() { Content = "Default Programs", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel MajorDirectory6 = new HierarchyNavigatorModel() { Content = "Help and Support", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/DesktopOpen.png", UriKind.RelativeOrAbsolute)) };

            HierarchyNavigatorModel SubDirectory1 = new HierarchyNavigatorModel() { Content = "Local Disk (C:)", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HardDisk.png", UriKind.RelativeOrAbsolute)) };       
            HierarchyNavigatorModel SubDirectory2 = new HierarchyNavigatorModel() { Content = "Local Disk (D:)", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HardDisk.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel SubDirectory3 = new HierarchyNavigatorModel() { Content = "Local Disk (E:)", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HardDisk.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel SubDirectory4 = new HierarchyNavigatorModel() { Content = "Local Disk (F:)", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HardDisk.png", UriKind.RelativeOrAbsolute)) };
            HierarchyNavigatorModel SubDirectory5 = new HierarchyNavigatorModel() { Content = "Pictures", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/Picture.png", UriKind.RelativeOrAbsolute)) };         
            HierarchyNavigatorModel SubDirectory6 = new HierarchyNavigatorModel() { Content = "Music", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/Music.png", UriKind.RelativeOrAbsolute)) } ;          
            HierarchyNavigatorModel SubDirectory7 = new HierarchyNavigatorModel() { Content = "Downloads", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HDDownloads.png", UriKind.RelativeOrAbsolute)) } ;

            HierarchyNavigatorModel childDirectory1 = new HierarchyNavigatorModel() { Content = "Program Files", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory1.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Common Files", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            childDirectory1.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Microsoft", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            childDirectory1.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Microsoft Office", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            childDirectory1.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Windows Defender", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(childDirectory1);

            HierarchyNavigatorModel childDirectory2 = new HierarchyNavigatorModel() { Content = "Windows", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory2.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Boot", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            childDirectory2.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Cursors", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(childDirectory2);

            HierarchyNavigatorModel childDirectory3 = new HierarchyNavigatorModel() { Content = "Syncfusion", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Essential Studio", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            childDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Metro Studio", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(childDirectory3);

            HierarchyNavigatorModel childDirectory4 = new HierarchyNavigatorModel() { Content = "Perlogs", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory4.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Admin", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(childDirectory4);

            HierarchyNavigatorModel childDirectory5 = new HierarchyNavigatorModel() { Content = "Users", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory5.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Public", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(childDirectory5);

            HierarchyNavigatorModel childDirectory6 = new HierarchyNavigatorModel() { Content = "Common", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory6.FolderItems.Add(new HierarchyNavigatorModel() { Content = "System", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(childDirectory6);

            HierarchyNavigatorModel childDirectory7 = new HierarchyNavigatorModel() { Content = "My Studio", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory7.FolderItems.Add(new HierarchyNavigatorModel() { Content = "WPF", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory2.FolderItems.Add(childDirectory7);

            HierarchyNavigatorModel childDirectory8 = new HierarchyNavigatorModel() { Content = "Utilities", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory8.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Tools", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory2.FolderItems.Add(childDirectory8);

            HierarchyNavigatorModel childDirectory9 = new HierarchyNavigatorModel() { Content = "Movies", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory9.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Dunkirk", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory3.FolderItems.Add(childDirectory9);

            HierarchyNavigatorModel childDirectory10 = new HierarchyNavigatorModel() { Content = "Songs", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory10.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Pop", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory3.FolderItems.Add(childDirectory10);

            HierarchyNavigatorModel childDirectory11 = new HierarchyNavigatorModel() { Content = "Scripts", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory11.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Pop", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory4.FolderItems.Add(childDirectory11);

            HierarchyNavigatorModel childDirectory12 = new HierarchyNavigatorModel() { Content = "Videos", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory12.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Latest Videos", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory4.FolderItems.Add(childDirectory12);

            HierarchyNavigatorModel childDirectory13 = new HierarchyNavigatorModel() { Content = "Windows 10", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory13.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Boot", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(childDirectory13);

            SubDirectory5.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Desert", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Jelly Fish", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Koala", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory5.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Penguins", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory6.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Melody", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/Music.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory6.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Pop", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/Music.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory7.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Syncfusion Policies", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );

            HierarchyNavigatorModel childDirectory14 = new HierarchyNavigatorModel() { Content = "Syncfusion Products", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) };
            childDirectory13.FolderItems.Add(new HierarchyNavigatorModel() { Content = "WPF", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            childDirectory13.FolderItems.Add(new HierarchyNavigatorModel() { Content = "WinUI", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory7.FolderItems.Add(childDirectory14);

            MajorDirectory1.FolderItems.Add(SubDirectory1);
            MajorDirectory1.FolderItems.Add(SubDirectory2);
            MajorDirectory1.FolderItems.Add(SubDirectory3);
            MajorDirectory1.FolderItems.Add(SubDirectory4);
            MajorDirectory2.FolderItems.Add(SubDirectory5);
            MajorDirectory2.FolderItems.Add(SubDirectory6);
            MajorDirectory2.FolderItems.Add(SubDirectory7);

            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "System and Security", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "User Accounts", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Network and Internet", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Appearance and Personalization", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Hardware and Sound", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Clock,Languages and Region", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Ease of Access", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );
            MajorDirectory3.FolderItems.Add(new HierarchyNavigatorModel() { Content = "Programs", FolderImage = new BitmapImage(new Uri(@"/syncfusion.navigationdemos.wpf;component/Assets/HierarchyNavigator/HierarchyFolder.png", UriKind.RelativeOrAbsolute)) } );

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
        /// Gets or sets the event log collection <see cref="HierarchyNavigatorViewModel"/> class.
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
        /// Gets or sets the selected value property <see cref="HierarchyNavigatorViewModel"/> class.
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
        /// Gets or sets the file items collection <see cref="HierarchyNavigatorViewModel"/> class.
        /// </summary>
        public ObservableCollection<HierarchyNavigatorModel> FileItems
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
        /// Gets or sets the refresh refereshCommand <see cref="HierarchyNavigatorViewModel"/> class.
        /// </summary>
        public demoscommon.wpf.DelegateCommand<object> RefreshCommand
        {
            get
            {
                refereshCommand = new demoscommon.wpf.DelegateCommand<object>(CommandExecute);
                return refereshCommand;
            }
        }

        /// <summary>
        /// Gets or sets the listBox items collection <see cref="HierarchyNavigatorViewModel"/> class.
        /// </summary>
        public ObservableCollection<HierarchyNavigatorModel> ListBoxItems
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
                EventLog.Add("Selection Changed:" + (HierarchyItems as HierarchyNavigatorModel).Content.ToString());
                ListBoxItems = (HierarchyItems as HierarchyNavigatorModel).FolderItems;
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
