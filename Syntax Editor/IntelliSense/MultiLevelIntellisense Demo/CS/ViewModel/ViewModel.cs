#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MultiLevelIntellisenseDemo
{
    public class ViewModel
    {
        public ObservableCollection<Model> customItems{ get; set; }
        public ViewModel()
        {
            customItems = FillData();            
        }

        public ObservableCollection<Model> FillData()
        {
            customItems = new ObservableCollection<Model>();

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
            customItems.Add(new Model() { Text = "this", NestedItems = SubItem });


            // Applying custom business object collection as IntelliSenseCustomItemsSource

            return customItems;
        }

    }
}
