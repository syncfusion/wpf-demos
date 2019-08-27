#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Media;
using System.Drawing;
using System.Windows;
using System.Windows.Threading;

namespace WindowsExplorerDemo
{
    public class ViewModel : NotificationObject
    {
      
        private DispatcherTimer timer;

        private IFile currentItem;

        private TreeViewItemAdv TreeItem;
        
        private ICommand selectedItemChangedCommand;
        public ICommand
           SelectedItemChangedCommand
        {
            get
            {
                return selectedItemChangedCommand;
            }
            set
            {
                selectedItemChangedCommand = value;
            }
        }            

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
                this.RaisePropertyChanged(() => this.Files);
            }
        }

        private object selectedItem;
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                this.RaisePropertyChanged(() => this.SelectedItem);
            }
        }      

        public void SelectedItemChanged(object param)
        {
            if (param != null)
            {               
                IFile file = param as IFile;
                if (file != null)
                {
                    this.SelectedItem = file;
                    BuildItemsTree(TreeItem, file);
                }
            }
        }

        public void OnDemandLoad(TreeViewItemAdv treeitem)
        {

            if (treeitem != null)
            {
                this.TreeItem = treeitem as TreeViewItemAdv;
                this.currentItem = TreeItem.DataContext as IFile;
                timer.Start();
            }
        }

        private ImageSource ExtractIcon(FileInfo directory)
        {
            System.Drawing.Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(directory.FullName);
            Bitmap bmp = ico.ToBitmap();
            MemoryStream strm = new MemoryStream();
            bmp.Save(strm, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage bmpImage = new BitmapImage();

            bmpImage.BeginInit();
            strm.Seek(0, SeekOrigin.Begin);
            bmpImage.StreamSource = strm;
            bmpImage.EndInit();
            ImageSource source = bmpImage;
            return source;
        }

        private void BuildItemsTree(TreeViewItemAdv item, IFile file)
        {
            string path = "";
            if (file != null)
            {
                bool isloaded = ((Directory)file).Items.Count > 0;
                if (file != null)
                {
                    if (file.Info is DriveInfo)
                    {
                        path = ((DriveInfo)file.Info).Name;

                    }
                    else if (file.Info is DirectoryInfo)
                    {
                        path = ((DirectoryInfo)file.Info).FullName;
                    }

                    if (!isloaded)
                    {

                        DirectoryInfo info = new DirectoryInfo(path);
                        if (info.Exists)
                        {
                            try
                            {
                                DirectoryInfo[] infos = info.GetDirectories();
                                foreach (DirectoryInfo directory in infos)
                                {
                                    Directory _file = new Directory();
                                    _file.Name = directory.Name;
                                    _file.Info = directory;

                                    _file.FileType = "File Folder";
                                    BitmapImage image = new BitmapImage(new Uri("/WindowsExplorerDemo;component/folder.png", UriKind.RelativeOrAbsolute));
                                    _file.Icon = image;
                                    _file.DateModified = directory.LastWriteTime;
                                    ((Directory)file).Files.Add(_file);
                                    ((Directory)file).Items.Add(_file);
                                }

                                FileInfo[] files = info.GetFiles();
                                foreach (FileInfo directory in files)
                                {
                                    Directory _file = new Directory();
                                    _file.Name = directory.Name;
                                    _file.Info = directory;
                                    _file.FileType = directory.Extension;
                                    _file.Size = directory.Length / 1024;
                                    _file.Icon = ExtractIcon(directory);
                                    _file.DateModified = directory.LastWriteTime;
                                    ((Directory)file).Items.Add(_file);

                                }
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("The Device is not ready.", "Disk Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }                                      
                }
            }
        }
    
        private void BuildDirectoryTree(TreeViewItemAdv item,IFile file)
        {
            string path = "";

            if (item!=null && file != null)
            {
                if (file.Info is DriveInfo)
                {
                    path = ((DriveInfo)file.Info).Name;
                }
                else if (file.Info is DirectoryInfo)
                {
                    path = ((DirectoryInfo)file.Info).FullName;
                }

                if (String.IsNullOrEmpty(path))
                {
                    return;
                }
                DirectoryInfo info = new DirectoryInfo(path);
                if (info.Exists)
                {
                    try
                    {
                        DirectoryInfo[] infos = info.GetDirectories();
                        foreach (DirectoryInfo directory in infos)
                        {
                            Directory _file = new Directory();
                            _file.Name = directory.Name;
                            _file.Info = directory;
                            BitmapImage image = new BitmapImage(new Uri("folder.png", UriKind.RelativeOrAbsolute));
                            _file.Icon = image;
                            ((Directory)file).Files.Add(_file);
                            ((Directory)file).Items.Add(_file);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                else
                {
                    MessageBox.Show("The Device is not ready.", "Disk Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }               
                item.IsLoadOnDemand = false;
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {           
            IFile file = currentItem as IFile;
            BuildDirectoryTree(TreeItem, file);
            timer.Stop();
        }

        public ViewModel()
        {
            selectedItemChangedCommand = new DelegateCommand<object>(SelectedItemChanged);
            
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 150);
            timer.Tick += new EventHandler(timer_Tick);

            files = new ObservableCollection<IFile>();
            DriveInfo[] drives = DriveInfo.GetDrives();
            int count = 0;

            foreach (DriveInfo info in drives)
            {
                Directory directory = new Directory();
                directory.Name = "Local Disk " + info.Name;
                BitmapImage bmp = new BitmapImage(new Uri("CD_Drive.png", UriKind.RelativeOrAbsolute));
                directory.Icon = bmp;
                directory.Info = info;
                if (count == 0)
                {
                    directory.IsSelected = true;
                }
                Files.Add(directory);
                count++;
            }
        }
    }
}
