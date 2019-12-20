#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace TreeContextMenuDemo
{
    public class Folder : NotificationObject, IFileItem
    {
        public Folder()
        {
            SubFolders = new ObservableCollection<IFileItem>();
            BitmapImage image = new BitmapImage(new Uri("Folder_Expanded.png", UriKind.RelativeOrAbsolute));
            Image = image;
            ContextItems = new ObservableCollection<object>();

            Image add = new System.Windows.Controls.Image();
            BitmapImage bmpadd = new BitmapImage(new Uri("add.png", UriKind.RelativeOrAbsolute));
            add.Source = bmpadd;
            ContextItems.Add(new MenuItem() { Header = "Add New Folder", Command = new DelegateCommand<object>(param => AddFolder()), Icon = add });


            Image delete = new System.Windows.Controls.Image();
            BitmapImage bmpdelete = new BitmapImage(new Uri("delete.png", UriKind.RelativeOrAbsolute));
            delete.Source = bmpdelete;
            ContextItems.Add(new MenuItem() { Header = "Delete Folder", Command = new DelegateCommand<object>(param => Delete()), Icon = delete });

            Image rename = new System.Windows.Controls.Image();
            BitmapImage bmprename = new BitmapImage(new Uri("rename.png", UriKind.RelativeOrAbsolute));
            rename.Source = bmprename;
            ContextItems.Add(new MenuItem() { Header = "Rename Folder", Command = new DelegateCommand<object>(param => Rename()), Icon = rename });
            ContextItems.Add(new Separator());
            ContextItems.Add(new MenuItem() { Header = "Empty Folder", Command = new DelegateCommand<object>(param => Empty()) });
        }

        private string caption=string.Empty;

        public string Caption
        {
            get 
            {
                return caption; 
            }
            set
            {
                caption= value;
                this.RaisePropertyChanged(() => this.Caption);
            }
        }

        private bool isEditing;

        public bool IsEditing
        {
            get 
            { 
                return isEditing; 
            }
            set
            {
                isEditing = value;
                this.RaisePropertyChanged(() => this.IsEditing);
            }
        }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        

        private ImageSource image=null;

        public ImageSource Image
        {
            get 
            {
                return image; 
            }
            set
            {
                image = value;
                this.RaisePropertyChanged(() => this.Image);
            }
        }


        private ObservableCollection<object> contextItems;

        public ObservableCollection<object> ContextItems
        {
            get
            {
                return contextItems; 
            }
            set
            {
                contextItems = value;
                this.RaisePropertyChanged(() => this.ContextItems);
            }
        }

        private ObservableCollection<IFileItem> subFolders = null;

        public ObservableCollection<IFileItem> SubFolders
        {
            get 
            {
                return subFolders; 
            }
            set
            {
                subFolders = value;
                this.RaisePropertyChanged(() => this.SubFolders);
            }
        }
        

       
        private void AddFolder()
        {
            this.SubFolders.Add(new Folder() { Caption = "New Folder",Parent=this,IsSelected = true});           
        }

        private void Rename()
        {
            if (!this.IsEditing)
            {
                this.IsEditing = true;
            }
        }

        private void Delete()
        {
            if(Parent!=null)
                Parent.SubFolders.Remove(this);
        }

        private void Empty()
        {
            this.SubFolders.Clear();
        }

        internal Folder Parent;      
    }


    public class File : NotificationObject, IFileItem
    {
        internal Folder Parent;

        public File()
        {
            BitmapImage image = new BitmapImage(new Uri("Image.png", UriKind.RelativeOrAbsolute));
            Image = image;

            ContextItems = new ObservableCollection<MenuItem>();

            Image delete = new System.Windows.Controls.Image();
            BitmapImage bmpdelete = new BitmapImage(new Uri("delete.png", UriKind.Relative));
            delete.Source = bmpdelete;
            ContextItems.Add(new MenuItem() { Header = "Delete File", Command = new DelegateCommand<object>(param => Delete()), Icon = delete });

            Image rename = new System.Windows.Controls.Image();
            BitmapImage bmprename = new BitmapImage(new Uri("rename.png", UriKind.RelativeOrAbsolute));
            rename.Source = bmprename;
            ContextItems.Add(new MenuItem() { Header = "Rename File", Command = new DelegateCommand<object>(param => Rename()), Icon = rename });
        }

        private void Rename()
        {
            if (!this.IsEditing)
            {
                this.IsEditing = true;
            }
        }

        private void Delete()
        {
            if(Parent!=null)
                Parent.SubFolders.Remove(this);
        }

        private ObservableCollection<MenuItem> contextItems;

        public ObservableCollection<MenuItem> ContextItems
        {
            get
            {
                return contextItems; 
            }
            set
            {
                contextItems = value;
                this.RaisePropertyChanged(() => this.ContextItems);
            }
        }

        private ObservableCollection<IFileItem> subFolders = null;

        public ObservableCollection<IFileItem> SubFolders
        {
            get
            {
                return subFolders;
            }
            set
            {
                subFolders = value;
                this.RaisePropertyChanged(() => this.SubFolders);
            }
        }      

        private string caption = string.Empty;

        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
                this.RaisePropertyChanged(() => this.Caption);
            }
        }

        private bool isEditing;

        public bool IsEditing
        {
            get
            {
                return isEditing;
            }
            set
            {
                isEditing = value;
                this.RaisePropertyChanged(() => this.IsEditing);
            }
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
                this.RaisePropertyChanged(() => this.IsSelected);
            }
        }


        private ImageSource image = null;

        public ImageSource Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                this.RaisePropertyChanged(() => this.Image);
            }
        }                       
    }

    public class ContextItem:NotificationObject
    {
        private string header;

        public string Header
        {
            get 
            { 
                return header; 
            }
            set
            {
                header = value;
                this.RaisePropertyChanged(() => this.Header);
            }
        }

        private ImageSource image=null;

        public ImageSource Image
        {
            get
            {
                return image; 
            }
            set
            {
                image = value;
                this.RaisePropertyChanged(() => this.Image);
            }
        }   

    
        private DelegateCommand<object> contextCommand;

        public DelegateCommand<object> ContextCommand
        {
            get
            {
                return contextCommand;
            }

            set
            {
                contextCommand = value;
                this.RaisePropertyChanged(() => this.ContextCommand);
            }
        }       
    }

    public interface IFileItem
    {
        string Caption { get; set; }

        bool IsEditing { get; set; }
    }          
}
