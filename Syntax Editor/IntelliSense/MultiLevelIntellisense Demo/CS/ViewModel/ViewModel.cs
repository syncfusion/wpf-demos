#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MultiLevelIntellisenseDemo
{
    public class ViewModel:NotificationObject
    {
        /// <summary>
        /// Maintains the command for window loaded
        /// </summary>
        private ICommand windowLoadedCommand;

        /// <summary>
        /// Represents the language of the code displayed
        /// </summary>
        private Languages language;

        /// <summary>
        /// Maintains the value indicating whether the LineNumber is visibile 
        /// </summary>
        private bool lineNumber;

        /// <summary>
        /// Maintains the value indicating whether the ContextMenu is visible
        /// </summary>
        private bool contextMenu;

        /// <summary>
        /// Maintains the command for ShowLineNumber property of edit control
        /// </summary>
        private ICommand showLineNumberCommand;

        /// <summary>
        /// Maintains the command for exit option in the menu item
        /// </summary>
        private ICommand exitCommand;

        /// <summary>
        /// Maintains the command for ShowContextMenu property  of edit control
        /// </summary>
        private ICommand showContextMenuCommand;

        /// <summary>
        /// Maintains the content to be dispalyed
        /// </summary>
        private string text;

        /// <summary>
        /// Maintains the pop up height of the intellisense list box
        /// </summary>
        private int intellisenseHeight;

        /// <summary>
        /// Maintains the value indicating whether the ShowContextMenu property is checkable
        /// </summary>
        private bool contextMenuChecked;

        /// <summary>
        /// Maintains the value indicating whether the ShowLineNumber property is checkable
        /// </summary>
        private bool isChecked;

        /// <summary>
        /// Maintains the font family of the content to be displayed 
        /// </summary>
        private FontFamily selectedItem;

        /// <summary>
        /// Maintains a collection of <see cref="Model"/>class to populate edit control
        /// </summary>
        private ObservableCollection<Model> customItems;
        
        /// <summary>
        /// Initializes the instance of <see cref="ViewModel"/>class 
        /// </summary>
        public ViewModel()
        {
            SelectedItem = new FontFamily("Verdana");
            Text = @"/* To see how the intellisense popup works, type ""this."" or ""this.editControl1."" 

In an intellisense popup, you can see controls such as Edit Control, TextBox, and Button along with 
their properties, methods and events.

In Context Prompt[Intellisense Popup] you can see the controls[Edit Control, TextBox, Button]  and 
their classes are available in it. 

If you have closed the popup, you can re-open it with the CTRL+Space shortcut key.

To see how the intellisense works,*/

// Examples:  
this. //<- Press CTRL+Space to display an intellisense popup with a choice..

this.editControl1. /*Press '. ' after ""EditControl"" and you will see that the intellisense popup 
will be opened with a list of properties, methods and events that are available in the ""EdiControl"" class.*/";
            IsChecked = true;
            ContextMenuChecked = true;
            LineNumber = true;
            ContextMenu = true;
            customItems = FillData();
            windowLoadedCommand = new DelegateCommand<object>(ExecuteWindowLoaded);
            showLineNumberCommand = new DelegateCommand<object>(ExecuteLineNumber);
            exitCommand = new DelegateCommand<object>(ExecuteExitCommand);
            showContextMenuCommand = new DelegateCommand<object>(ExecuteContextMenu);
            Language = Languages.CSharp;
            IntellisenseHeight = 98;
        }

        /// <summary>
        ///Gets or sets a collection of <see cref="Model"/> class to populate edit control 
        /// </summary>
        public ObservableCollection<Model> CustomItems
        {
            get
            {
                return customItems;
            }
            set
            {
                customItems = value;
                RaisePropertyChanged("CustomItems");
            }
        }

        /// <summary>
        /// Gets or sets the command for exit option
        /// </summary>
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }

        /// <summary>
        /// Gets or sets the language of the code displayed 
        /// </summary>
        public Languages Language
        {
            get
            {
                return language;
            }
            set
            {
                language = value;
                RaisePropertyChanged("Language");
            }
        }
        /// <summary>
        /// Gets or sets the value indicating whether the ShowContextMenu property is checkable
        /// </summary>
        public bool ContextMenuChecked
        {
            get
            {
                return contextMenuChecked;
            }
            set
            {
                contextMenuChecked = value;
                RaisePropertyChanged("ContextMenuChecked");
            }
        }
        
        /// <summary>
        /// Gets or sets the value indicating whether the LineNumber is visible
        /// </summary>
        public bool LineNumber
        {
            get
            {
                return lineNumber;
            }
            set
            {
                lineNumber = value;
                RaisePropertyChanged("LineNumber");
            }
        }

        /// <summary>
        /// Gets or sets the value indicating whether the ContextMenu is visible
        /// </summary>
        public bool ContextMenu
        {
            get
            {
                return contextMenu;
            }
            set
            {
                contextMenu = value;
                RaisePropertyChanged("ContextMenu");
            }
        }
        /// <summary>
        /// Gets or sets the value for height of intellisense list box
        /// </summary>
        public int IntellisenseHeight
        {
            get
            {
                return intellisenseHeight;
            }
            set
            {
                intellisenseHeight = value;
                RaisePropertyChanged("IntellisenseHeight");
            }
        }
        /// <summary>
        /// Gets or sets the content to be displayed
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                RaisePropertyChanged("Text");
            }
        }

        /// <summary>
        /// Gets or sets the command for ShowContextMenu property  of edit control
        /// </summary>
        public ICommand ShowContextMenuCommand
        {
            get
            {
                return showContextMenuCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for ShowLineNumber property of edit control
        /// </summary>
        public ICommand ShowLineNumberCommand
        {
            get
            {
                return showLineNumberCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for window loaded 
        /// </summary>
        public ICommand WindowLoadedCommand
        {
            get
            {
                return windowLoadedCommand;
            }
        }
               
        /// <summary>
        /// Gets or sets the font family of the content to be displayed
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
        /// Gets or sets the value indicating whether the ShowLineNumber property is checkable
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
                isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// Method to display context menu
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteContextMenu(object param)
        {
           if (ContextMenuChecked)
            {
                ContextMenu= true;
            }
            else
            {
                ContextMenu = false;
            }
        }

        /// <summary>
        /// Method to  display line number
        /// </summary>
        /// <param name="param">Specifies teh object parameter</param>
        private void ExecuteLineNumber(object param)
        {
            if (IsChecked)
            {
                LineNumber = true;
            }
            else
            {
               LineNumber = false;
            }
        }

        /// <summary>
        /// Method to execute exit option in the menu item
        /// </summary>
        /// <param name="param">Specifies the obejct parameter</param>
        private void ExecuteExitCommand(object param)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Method for window loaded event 
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteWindowLoaded(object param)
        {           
            if (LineNumber)
                IsChecked = true;

            if (ContextMenu)
                ContextMenuChecked = true;           
        }

        /// <summary>
        /// Method to populate data
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Model> FillData()
        {
            CustomItems = new ObservableCollection<Model>();

            //Intializing sub-items for customItems

            ObservableCollection<Model> SubItem = new ObservableCollection<Model>();

            //Intializing sub-items for TextBox

            ObservableCollection<Model> ChildItem_TextBox = new ObservableCollection<Model>();

            //Intializing sub-items for Button

            ObservableCollection<Model> ChildItem_Button = new ObservableCollection<Model>();

            //Intializing sub-items for EditControl

            ObservableCollection<Model> ChildItem_EditControl = new ObservableCollection<Model>();

#if NETCORE
            ChildItem_EditControl.Add(new Model() { Text = "ActualWidth", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Background", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ClearAllText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "DataContext", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "DocumentSource", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Dispose", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Drop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "EnableIntellisense", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "EnableOutlining", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "EndInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ExpandLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Focus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "FocusableChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Foreground", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "GetType", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Height", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Initialized", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IntellisenseBoxClosed", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IntellisenseBoxOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IntellisenseMode", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IsMultiLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "LineNumber", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "LoadFile", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Loaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MinWidth", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MinHeight", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MouseDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MouseUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MoveToNextLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MoveToPreviousLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "PointToScreen", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Resources", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SelectedText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SelectedTextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SelectedLines", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowDefaultContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowLineNumber", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowOutlining", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowPrintPreview", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Style", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "UpdateLayout", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Visibility", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });

            ChildItem_TextBox.Add(new Model() { Text = "AcceptsTab", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AllowDrop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AppendText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ApplyTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Arrange", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Background", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BindingGroup", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "CanRedo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "CanUndo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "CaretIndex", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Clear", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Copy", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Cut", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DataContext", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DataContextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DragEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DragLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DragOver", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Drop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Effect", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "EndInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FindName", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Focus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FocusChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FontFamily", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FontSize", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ForeGround", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GetLineLength", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GetLineText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GetType", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GotKeyBoardFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Height", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "HorizontalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Initialized", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsEnabled", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsEnabledChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsLoaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsVisible", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsVisibleChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "LineDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "LineUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Loaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "LostFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Measure", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Name", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Padding", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Parent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Paste", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "PointToScreen", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Redo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "RemoveHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "RenderTransform", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Select", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SelectAll", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SelectedText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SetValue", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Style", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Text", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "TextAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "TextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "TextInput", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToolTip", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToolTipClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToolTipOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToString", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Undo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Unloaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "VerticalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Visibility", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Width", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });

            ChildItem_Button.Add(new Model() { Text = "ActualWidth", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "AllowDrop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ApplyTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Arrange", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Background", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BindingGroup", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BorderThickness", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ClearValue", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Click", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ClickMode", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "CommandBindings", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Content", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContentStringFormat", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContentTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DataContext", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DataContextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DragEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DragLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DragOver", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Drop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "EndInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FindName", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Focus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FocusableChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FontFamily", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FontSize", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Foreground", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "GetLocalValueEnumerator", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "GotKeyboardFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Height", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "HorizontalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Initialized", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsEnabled", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsEnabledChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsLoaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsPressed", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsVisible", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsVisibleChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "LayoutTransform", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Loaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "LostFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Margin", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Measure", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "MouseDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "MouseUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Name", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "OnApplyTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Parent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "PredictFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "QueryCursor", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "RaiseEvent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "RemoveHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "RenderTransform", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "SetValue", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "SourceUpdated", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Style", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "TabIndex", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Tag", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "TemplateParent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "TextInput", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToolTip", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToolTipClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToolTipOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToString", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Triggers", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Unloaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "UpdateLayout", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "VerticalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Visibility", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Width", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Properties.png", UriKind.Relative)) });

#else
            ChildItem_EditControl.Add(new Model() { Text = "ActualWidth", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Background", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ClearAllText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "DataContext", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "DocumentSource", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Dispose", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Drop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "EnableIntellisense", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "EnableOutlining", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "EndInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ExpandLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Focus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "FocusableChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Foreground", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "GetType", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Height", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Initialized", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IntellisenseBoxClosed", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IntellisenseBoxOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IntellisenseMode", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "IsMultiLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "LineNumber", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "LoadFile", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Loaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MinWidth", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MinHeight", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MouseDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MouseUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MoveToNextLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "MoveToPreviousLine", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "PointToScreen", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Resources", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SelectedText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SelectedTextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SelectedLines", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowDefaultContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowLineNumber", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowOutlining", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "ShowPrintPreview", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Style", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "UpdateLayout", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new Model() { Text = "Visibility", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });

            ChildItem_TextBox.Add(new Model() { Text = "AcceptsTab", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AllowDrop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AppendText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ApplyTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Arrange", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Background", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BindingGroup", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "CanRedo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "CanUndo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "CaretIndex", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Clear", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Copy", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Cut", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DataContext", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DataContextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DragEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DragLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "DragOver", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Drop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Effect", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "EndInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FindName", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Focus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FocusChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FontFamily", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "FontSize", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ForeGround", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GetLineLength", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GetLineText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GetType", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "GotKeyBoardFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Height", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "HorizontalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Initialized", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsEnabled", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsEnabledChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsLoaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsVisible", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "IsVisibleChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "LineDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "LineUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Loaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "LostFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Measure", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Name", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "MouseLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Padding", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Parent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Paste", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "PointToScreen", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Redo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "RemoveHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "RenderTransform", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Select", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SelectAll", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SelectedText", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SetValue", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Style", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Text", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "TextAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "TextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "TextInput", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToolTip", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToolTipClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToolTipOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "ToString", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Undo", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Unloaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "VerticalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Visibility", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new Model() { Text = "Width", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });

            ChildItem_Button.Add(new Model() { Text = "ActualWidth", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "AllowDrop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ApplyTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Arrange", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Background", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BindingGroup", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BorderThickness", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ClearValue", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Click", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ClickMode", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "CommandBindings", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Content", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContentStringFormat", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContentTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DataContext", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DataContextChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DragEnter", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DragLeave", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "DragOver", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Drop", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "EndInit", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FindName", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Focus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FocusableChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FontFamily", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "FontSize", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Foreground", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "GetLocalValueEnumerator", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "GotKeyboardFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Height", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "HorizontalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Initialized", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsEnabled", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsEnabledChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsLoaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsPressed", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsVisible", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "IsVisibleChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "LayoutTransform", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Loaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "LostFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Margin", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Measure", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "MouseDown", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "MouseUp", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Name", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "OnApplyTemplate", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Parent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "PredictFocus", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "QueryCursor", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "RaiseEvent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "RemoveHandler", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "RenderTransform", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "SetValue", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "SourceUpdated", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Style", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "TabIndex", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Tag", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "TemplateParent", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "TextInput", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToolTip", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToolTipClosing", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToolTipOpening", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "ToString", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Triggers", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Unloaded", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "UpdateLayout", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "VerticalAlignment", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Visibility", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new Model() { Text = "Width", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Properties.png", UriKind.Relative)) });
#endif
            //adding items to main collection
#if NETCORE
            SubItem.Add(new Model() { Text = "editControl1", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Class.png", UriKind.Relative)), NestedItems = ChildItem_EditControl });

            SubItem.Add(new Model() { Text = "textBox1",Icon=new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Class.png", UriKind.Relative)), NestedItems = ChildItem_TextBox });

            SubItem.Add(new Model() { Text = "button1", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/../Icons/Class.png", UriKind.Relative)), NestedItems = ChildItem_Button });
#else
            SubItem.Add(new Model() { Text = "editControl1", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Class.png", UriKind.Relative)), NestedItems = ChildItem_EditControl });
            
            SubItem.Add(new Model() { Text = "textBox1",Icon=new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Class.png", UriKind.Relative)), NestedItems = ChildItem_TextBox });

            SubItem.Add(new Model() { Text = "button1", Icon = new BitmapImage(new Uri("/MultiLevelIntellisenseDemo;component/Icons/Class.png", UriKind.Relative)), NestedItems = ChildItem_Button });
#endif
            CustomItems.Add(new Model() { Text = "this", NestedItems = SubItem });
            // Applying custom business object collection as IntelliSenseCustomItemsSource
            return CustomItems;
        }

    }
}
