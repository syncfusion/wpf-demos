using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace WindowsExplorerDemo
{
    public class File : IFile, INotifyPropertyChanged
    {

        public string Name
        {
            get;

            set;
        }

        public DateTime DateModified
        {
            get;

            set;
        }

        public string FileType
        {
            get;

            set;
        }

        public double Size
        {
            get;

            set;
        }

        public object Info
        {
            get;

            set;
        }

        public ImageSource Icon
        {
            get;

            set;
        }

        private bool isSelected;

        public bool IsSelected
        {
            get 
            { 
                return isSelected; 
            }
            set 
            { 
                isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }


        public void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class Directory : File
    {
        private ObservableCollection<IFile> files;

        public ObservableCollection<IFile> Files
        {
            get
            {
                return files;
            }

            set
            {
                files = value;
                base.OnPropertyChanged("Files");
            }
        }

        private ObservableCollection<IFile> items;

        public ObservableCollection<IFile> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
               base.OnPropertyChanged("Items");
            }
        }

        public Directory()
        {
            Files = new ObservableCollection<IFile>();
            Items = new ObservableCollection<IFile>();
        }

    }
}
