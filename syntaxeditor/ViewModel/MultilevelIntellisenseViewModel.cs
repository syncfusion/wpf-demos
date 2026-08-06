#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Edit;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.syntaxeditordemos.wpf
{
    public class MultilevelIntellisenseViewModel:NotificationObject
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
        private double intellisenseHeight;

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
        /// Maintains a collection of <see cref="IntellisenseModel"/>class to populate edit control
        /// </summary>
        private ObservableCollection<IntellisenseModel> customItems;
        
        /// <summary>
        /// Initializes the instance of <see cref="MultilevelIntellisenseViewModel"/>class 
        /// </summary>
        public MultilevelIntellisenseViewModel()
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
            showContextMenuCommand = new DelegateCommand<object>(ExecuteContextMenu);
            Language = Languages.CSharp;
        }

        /// <summary>
        ///Gets or sets a collection of <see cref="IntellisenseModel"/> class to populate edit control 
        /// </summary>
        public ObservableCollection<IntellisenseModel> CustomItems
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
        public double IntellisenseHeight
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
        /// Method for window loaded event 
        /// </summary>
        /// <param name="param">Specifies the object parameter</param>
        private void ExecuteWindowLoaded(object param)
        {           
            if (LineNumber)
                IsChecked = true;

            if (ContextMenu)
                ContextMenuChecked = true;           
            IntellisenseHeight = 98;
        }

        /// <summary>
        /// Method to populate data
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<IntellisenseModel> FillData()
        {
            CustomItems = new ObservableCollection<IntellisenseModel>();

            //Intializing sub-items for customItems

            ObservableCollection<IntellisenseModel> SubItem = new ObservableCollection<IntellisenseModel>();

            //Intializing sub-items for TextBox

            ObservableCollection<IntellisenseModel> ChildItem_TextBox = new ObservableCollection<IntellisenseModel>();

            //Intializing sub-items for Button

            ObservableCollection<IntellisenseModel> ChildItem_Button = new ObservableCollection<IntellisenseModel>();

            //Intializing sub-items for EditControl

            ObservableCollection<IntellisenseModel> ChildItem_EditControl = new ObservableCollection<IntellisenseModel>();

            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ActualWidth", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Background", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ClearAllText", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "DataContext", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "DocumentSource", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Dispose", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Drop", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "EnableIntellisense", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "EnableOutlining", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "EndInit", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ExpandLine", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Focus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "FocusableChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Foreground", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "GetType", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Height", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Initialized", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "IntellisenseBoxClosed", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "IntellisenseBoxOpening", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "IntellisenseMode", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "IsMultiLine", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "LineNumber", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "LoadFile", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Loaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MinWidth", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MinHeight", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MouseDown", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MouseUp", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MoveToNextLine", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "MoveToPreviousLine", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "PointToScreen", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Resources", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "SelectedText", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "SelectedTextChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "SelectedLines", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ShowDefaultContextMenu", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ShowLineNumber", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ShowOutlining", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "ShowPrintPreview", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Style", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "UpdateLayout", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_EditControl.Add(new IntellisenseModel() { Text = "Visibility", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });

            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "AcceptsTab", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "AllowDrop", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "AppendText", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ApplyTemplate", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Arrange", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Background", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "BindingGroup", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "CanRedo", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "CanUndo", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "CaretIndex", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Clear", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Copy", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Cut", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "DataContext", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "DataContextChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "DragEnter", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "DragLeave", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "DragOver", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Drop", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Effect", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "EndInit", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "FindName", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Focus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "FocusChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "FontFamily", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "FontSize", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ForeGround", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "GetLineLength", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "GetLineText", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "GetType", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "GotKeyBoardFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Height", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "HorizontalAlignment", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Initialized", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "IsEnabled", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "IsEnabledChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "IsLoaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "IsVisible", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "IsVisibleChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "LineDown", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "LineUp", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Loaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "LostFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Measure", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "MouseEnter", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "MouseLeave", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Name", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "MouseEnter", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "MouseLeave", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Padding", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Parent", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Paste", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "PointToScreen", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Redo", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "RemoveHandler", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "RenderTransform", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Select", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "SelectAll", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "SelectedText", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "SetValue", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Style", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Text", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "TextAlignment", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "TextChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "TextInput", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ToolTip", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ToolTipClosing", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ToolTipOpening", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "ToString", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Undo", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Unloaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "VerticalAlignment", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Visibility", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_TextBox.Add(new IntellisenseModel() { Text = "Width", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });

            ChildItem_Button.Add(new IntellisenseModel() { Text = "ActualWidth", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "AddHandler", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "AllowDrop", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ApplyTemplate", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Arrange", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Background", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "BeginInit", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "BindingGroup", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "BorderBrush", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "BorderThickness", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "BringIntoView", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ClearValue", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Click", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ClickMode", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "CommandBindings", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Content", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ContentStringFormat", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ContentTemplate", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ContextMenu", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ContextMenuClosing", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ContextMenuOpening", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "DataContext", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "DataContextChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "DragEnter", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "DragLeave", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "DragOver", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Drop", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "EndInit", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "FindName", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "FlowDirection", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Focus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "FocusableChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "FontFamily", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "FontSize", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Foreground", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "GetLocalValueEnumerator", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "GotFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "GotKeyboardFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Height", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "HorizontalAlignment", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Initialized", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "IsEnabled", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "IsEnabledChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "IsLoaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "IsPressed", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "IsVisible", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "IsVisibleChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "KeyDown", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "KeyUp", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "LayoutTransform", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Loaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "LostFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Margin", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Measure", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "MouseDown", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "MouseUp", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "MoveFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Name", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "OnApplyTemplate", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Parent", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "PredictFocus", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "QueryCursor", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "RaiseEvent", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "RemoveHandler", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "RenderTransform", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "SetValue", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "SizeChanged", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "SourceUpdated", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Style", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "TabIndex", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Tag", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "TemplateParent", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "TextInput", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ToolTip", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ToolTipClosing", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ToolTipOpening", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "ToString", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Triggers", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Unloaded", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Event.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "UpdateLayout", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Methods.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "VerticalAlignment", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Visibility", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            ChildItem_Button.Add(new IntellisenseModel() { Text = "Width", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Properties.png", UriKind.Relative)) });
            
            SubItem.Add(new IntellisenseModel() { Text = "editControl1", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Class.png", UriKind.Relative)), NestedItems = ChildItem_EditControl });         
            SubItem.Add(new IntellisenseModel() { Text = "textBox1",Icon=new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Class.png", UriKind.Relative)), NestedItems = ChildItem_TextBox });
            SubItem.Add(new IntellisenseModel() { Text = "button1", Icon = new BitmapImage(new Uri("/syncfusion.syntaxeditordemos.wpf;component/Assets/syntaxeditor/Class.png", UriKind.Relative)), NestedItems = ChildItem_Button });
            CustomItems.Add(new IntellisenseModel() { Text = "this", NestedItems = SubItem });
            return CustomItems;
        }
    }
}
