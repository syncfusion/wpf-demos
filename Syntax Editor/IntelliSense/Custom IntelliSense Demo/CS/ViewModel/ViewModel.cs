#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CustomIntellisenseDemo
{
    /// <summary>
    /// Represents the view model class for edit control 
    /// </summary>
    public class ViewModel : NotificationObject
    {
               
       /// <summary>
        /// Maintians the font family of the content of edit control
        /// </summary>
        private FontFamily selectedItem;

        /// <summary>
        /// Maintains the command to exit the window
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Maintains the command for adding intellisense item
        /// </summary>
        private ICommand addItemCommand;
        /// <summary>
        /// Maintains the command for adding commit characrters and drill down chars in intellisense
        /// </summary>
        private ICommand editcommand;

        /// <summary>
        /// Maintains the command for removing intelllise items 
        /// </summary>
        private ICommand removeItemcommand;

        /// <summary>
        /// Maintains the items to be populated in Intellisense 
        /// </summary>
        private IEnumerable<CustomIntellisenseItem> itemsSource;

        /// <summary>
        /// Maintains a collection of<see cref="CustomIntellisenseItem"/> class 
        /// </summary>
        ObservableCollection<CustomIntellisenseItem> customItems = null;
        
        /// <summary>
        /// Maintains the command for button click
        /// </summary>
        private ICommand clickCommand;

        /// <summary>
        /// Initializes the instance of <see cref="ViewModel"/>class
        /// </summary>
        public ViewModel()
        {
            SelectedItem = new FontFamily("Verdana");
            InitializeCustomIntellisenseItems();
            addItemCommand = new DelegateCommand<object>(ExecuteAddItemCommand);
            removeItemcommand = new DelegateCommand<object>(ExecuteRemoveItemCommand);
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            editcommand = new DelegateCommand<object>(ExecuteEdit);
            clickCommand = new DelegateCommand<object>(ExecuteClickCommand);
         }

        /// <summary>
        /// Gets or sets the button click on property window
        /// </summary>
        public ICommand ClickCommand
        {
            get { return clickCommand; }
        }

        /// <summary>
        /// Gets or sets the command for edit control loaded
        /// </summary>
        public ICommand EditCommand
        {
            get
            {
                return editcommand;
            }
        }

        /// <summary>
        /// Gets or sets the font family of the content in the edit control
        /// </summary>
        public FontFamily SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets or sets the items to be populated in intellisense
        /// </summary>
        public IEnumerable<CustomIntellisenseItem> ItemsSource
        {
            get
            {
                return itemsSource;
            }
            set
            {
                itemsSource = value;
                RaisePropertyChanged("ItemsSource");
            }
        }

        /// <summary>
        /// Gets or sets the command for adding new intellisense items
        /// </summary>
        public ICommand AddItemCommnad
        {
            get
            {
                return addItemCommand;
            }
        }

        /// <summary>
        /// Gets or sets the value for exiting the window
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for removing intellisense item
        /// </summary>
        public ICommand RemoveItemCommand
        {
            get
            {
                return removeItemcommand;
            }
        }

        /// <summary>
        /// Methodto execute button click
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteClickCommand(object param)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Image Files |*.png;*.bmp;*.gif; *.jpg";
            if ((bool)fileDialog.ShowDialog())
            {
                (param as TextBox).SetValue(TextBox.TextProperty, fileDialog.FileName);
            }
        }


        /// <summary>
        /// Method to execute add intellisense items
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteAddItemCommand(object param)
        {
            IntellisenseItemProperties properties = new IntellisenseItemProperties();
            properties.ShowDialog();
            string item = properties.text.Text;
            string icon = properties.txtIcon.Text;
            if (item != null && item.Trim() != string.Empty )
            {
                customItems.Add(new CustomIntellisenseItem() { Text = item, Icon = new BitmapImage(new Uri(icon, UriKind.RelativeOrAbsolute)) });
            }            
        }

        /// <summary>
        /// Method to execute remove intellisense items
        /// </summary>
        /// <param name="param">Specifes the object parameter</param>
        private void ExecuteRemoveItemCommand(object param)
        {
            if ((param as ListBox).SelectedItem != null)
            {
                customItems.Remove((param as ListBox).SelectedItem as CustomIntellisenseItem);
            }
        }

        /// <summary>
        /// Method to populate intellisense items
        /// </summary>
        private void InitializeCustomIntellisenseItems()
        {
            customItems = new ObservableCollection<CustomIntellisenseItem>();
            customItems.Add(new CustomIntellisenseItem() { Text = "Syncfusion", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/syncfusion.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "ASP.NET", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/aspnet.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "MVC", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/aspnet-mvc.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "BI", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/reporting.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "Silverlight", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/silverlight.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "WinForms", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/winforms.png", UriKind.Relative)) });
            customItems.Add(new CustomIntellisenseItem() { Text = "WPF", Icon = new BitmapImage(new Uri("/CustomIntellisenseDemo;component/Resources/wpf.png", UriKind.Relative)) });
            ItemsSource = customItems;

        }

        /// <summary>
        /// Method for executing exit option in the menu item
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteExitCommand(object param)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Method to execute edit loaded
        /// </summary>
        /// <param name="param">Specifies the ibject parameter</param>
        private void ExecuteEdit(object param)
        {
            //Changed IntellisenseCommitCharacters property to remove "." from the commit characters to
            //enable usage of "." in intellisense items as in ASP.NET
            (param as EditControl).CurrentLanguage.IntellisenseCommitCharacters = @"{}[](),:;+-*/%&|^!~=<>?@#'\\""";

            //Changed IntellisenseDrillDownChar from '.' to '>' to enable usage of '.' in Intellisense Item
            (param as EditControl).CurrentLanguage.IntellisenseDrillDownChar = '>';
        }
    }
}
