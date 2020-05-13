#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;

namespace HierarchyNavigator_2008
{
    /// <summary>
    /// Represents a view model for the hierarchy navigator control.
    /// </summary>
      public class ViewModel : INotifyPropertyChanged
         {
        #region Fields 
        /// <summary>
        ///  Maintains event log command.
        /// </summary>
        private ICommand EventLogCommand=null;

        /// <summary>
        ///  Maintains the collection of eventlog.
        /// </summary>
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();

        /// <summary>
        ///  Maintains slected value property.
        /// </summary>
        private object selectedValue;

        /// <summary>
        ///  Maintains myCommand2.
        /// </summary>
        private DelegateCommand<object> myCommand2;

        /// <summary>
        ///  Maintains listBox items collection.
        /// </summary>
        private ObservableCollection<Model> listBoxItems;

        /// <summary>
        ///  Maintains comboBox items source collection.
        /// </summary>
        private List<string> comboBoxItemsSource = new List<string>();

        /// <summary>
        /// Maintains the collection of file items.
        /// </summary>
        public ObservableCollection<Model> fileItems;

        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            comboBoxItemsSource = styleName.ToList();
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
            SubDirectory1.FolderItems.Add(new Model() { Content = "Program Files", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute))});
            SubDirectory1.FolderItems.Add(new Model() { Content = "Windows", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Syncfusion", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute))});
            SubDirectory1.FolderItems.Add(new Model() { Content = "Drivers", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Perlogs", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Users", FolderImage =  new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory1.FolderItems.Add(new Model() { Content = "Common", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory1.FolderItems.Add(SubDirectory1);
            Model SubDirectory2 = new Model() { Content = "Local Disk (D:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) } ;
            SubDirectory2.FolderItems.Add(new Model() { Content = "My Studio", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory1.FolderItems.Add(SubDirectory2);
            Model SubDirectory3 = new Model() { Content = "Local Disk (E:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) } ;
            Model SubDirectory4 = new Model() { Content = "Local Disk (F:)", FolderImage = new BitmapImage(new Uri("/Images/HardDisk.png", UriKind.RelativeOrAbsolute)) } ;
            MajorDirectory1.FolderItems.Add(SubDirectory3);
            MajorDirectory1.FolderItems.Add(SubDirectory4);
            Model SubDirectory21 = new Model() { Content = "Pictures", FolderImage = new BitmapImage(new Uri("/Images/Picture.png", UriKind.RelativeOrAbsolute)) };
            SubDirectory21.FolderItems.Add(new Model() { Content = "Windows 7", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory21.FolderItems.Add(new Model() { Content = "Desert", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory21.FolderItems.Add(new Model() { Content = "Jelly Fish", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            SubDirectory21.FolderItems.Add(new Model() { Content = "Koala", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory21.FolderItems.Add(new Model() { Content = "Penguins", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            Model SubDirectory22 = new Model() { Content = "Music", FolderImage = new BitmapImage(new Uri("/Images/Music.png", UriKind.RelativeOrAbsolute)) } ;
            SubDirectory22.FolderItems.Add(new Model() { Content = "Melody", FolderImage = new BitmapImage(new Uri("/Images/Music.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory22.FolderItems.Add(new Model() { Content = "Pop", FolderImage = new BitmapImage(new Uri("/Images/Music.png", UriKind.RelativeOrAbsolute)) } );
            Model SubDirectory23 = new Model() { Content = "Downloads", FolderImage = new BitmapImage(new Uri("/Images/HDDownloads.png", UriKind.RelativeOrAbsolute)) } ;
            SubDirectory23.FolderItems.Add(new Model() { Content = "Syncfusion Policies", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory23.FolderItems.Add(new Model() { Content = "Syncfusion Products", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) } );
            SubDirectory23.FolderItems.Add(new Model() { Content = "Syncfusion Guests", FolderImage = new BitmapImage(new Uri("/Images/Folder.png", UriKind.RelativeOrAbsolute)) });
            MajorDirectory2.FolderItems.Add(SubDirectory21);
            MajorDirectory2.FolderItems.Add(SubDirectory22);
            MajorDirectory2.FolderItems.Add(SubDirectory23);
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
             SelectedValue = fileItem;
        }
        #endregion

        #region Event
        /// <summary>
        /// Initialize the event which notifies when the selected item changes. 
        /// </summary> 
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event handling method for notified changes.
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the event log collection.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<string> EventLog
        {
            get
            {
                return eventlog;
            }
            set
            {
                eventlog = value;
                OnPropertyChanged("EventLog");
            }
        }

        /// <summary>
        /// Gets or sets the selected item command property.
        /// </summary>
        [Category("Summary")]
        public ICommand SelectedItem
        {
            get
            {
                return EventLogCommand;
            }
        }

        /// <summary>
        /// Gets or sets the selected value property.
        /// </summary>
        [Category("Summary")]
        public object SelectedValue
        {
            get
            {
                return selectedValue;
            }
            set
            {
                selectedValue = value;
                PropertyChangedHandler();
                OnPropertyChanged("SelectedValue");
            }
        }

        /// <summary>
        /// Gets or sets the file items collection.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<Model> FileItems
        {
            get
            {
                return fileItems;
            }
            set
            {
                fileItems = value;
                OnPropertyChanged("FileItems");
            }
        }

        /// <summary>
        /// Gets or sets the refresh command.
        /// </summary>
        [Category("Summary")]
        public DelegateCommand<object> RefreshCommand
        {
            get
            {
                myCommand2 = new DelegateCommand<object>(MyCommand2Method);
                return myCommand2;
            }
        }

        /// <summary>
        /// Gets or sets the listBox items collection.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<Model> ListBoxItems
        {
            get
            {
                return listBoxItems;
            }
            set
            {
                listBoxItems = value;
                OnPropertyChanged("ListBoxItems");
            }
        }

        /// <summary>
        /// Gets or sets the combocox items source collection.
        /// </summary>
        [Category("Summary")]
        public List<string> ComboBoxItemsSource
        {
            get { return comboBoxItemsSource; }
            set
            {
                comboBoxItemsSource = value;
                OnPropertyChanged("ComboBoxItemsSource");
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Handling the selected changed event.
        /// </summary> 
        public void PropertyChangedHandler()
        {
            if (SelectedValue != null)
            {
                EventLog.Add("Selection Changed:" + (SelectedValue as Model).Content.ToString());
                ListBoxItems = (SelectedValue as Model).FolderItems;
            }
        }

        /// <summary>
        /// Passing a method to command.
        /// </summary>
        /// <param name="Parameter">Parameter which passes a method to the command</param>
        private void MyCommand2Method(object Parameter)
        {
            (Parameter as HierarchyNavigator).ShowProgressBar(new TimeSpan(0, 0, 0, 0, 200));
        }

        /// <summary>
        /// Adding themes to style names.
        /// </summary>
        private static string[] styleName = new string[] {
            "Default",
            "Material Light",
            "Material Light Blue",
            "Material Dark",
            "Material Dark Blue",
            "Office2016Colorful",
            "Office2016DarkGray",
            "Office2016White",
            "Office365",
            "Office2013DarkGray",
            "Office2013LightGray",
            "Office2013White",
            "Office2010Black",
            "Office2010Blue",
            "Office2010Silver",
            "VisualStudio2015",
            "VisualStudio2013",
            "SystemTheme",
            "Metro",
            "Blend",
            "Lime",
            "Saffron",
        };
        #endregion
    }
}
