#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using radial = Syncfusion.Windows.Controls.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Navigation;
using Syncfusion.Windows.Utils;
using System.Collections.ObjectModel;

namespace syncfusion.navigationdemos.wpf
{
    public class RadialMenuViewModel : INotifyPropertyChanged
    {

        #region Varialbles

        private RichTextBox richTextBox;

        private radial.SfRadialMenu RadialMenu;
   
        private TextSelection prevSelection;

        private string description = string.Empty;

        private radial.SfRadialMenuItem RadialMenuBoldItem;

        private radial.SfRadialMenuItem RadialMenuItalicItem;

        private radial.SfRadialMenuItem RadialMenuUnderLineItem;

        private radial.SfRadialMenuItem RadialMenuStrikeItem;

        private radial.SfRadialMenuItem RadialMenuSubScriptItem;

        private radial.SfRadialMenuItem RadialMenuSuperScriptItem;

        #endregion

        #region Command
        public ICommand ValueChangedCommand
        {
            get;
            private set;
        }

        public ICommand TextBoxLoaded
        {
            get;
            private set;
        }

        public ICommand SelectionChangedCommand
        {
            get;
            private set;
        }

        public ICommand LostFocusCommand
        {
            get;
            private set;
        }

        public ICommand BoldCommand
        {
            get;
            private set;
        }

        public ICommand CopyCommand
        {
            get;
            private set;
        }


        public ICommand CutCommand
        {
            get;
            private set;
        }

        public ICommand PasteCommand
        {
            get;
            private set;
        }


        public ICommand ItalicCommand
        {
            get;
            private set;
        }

        public ICommand UnderLineCommand
        {
            get;
            private set;
        }

        public ICommand UndoCommand
        {
            get;
            private set;
        }

        public ICommand RedoCommand
        {
            get;
            private set;
        }

        public ICommand StrikeCommand
        {
            get;
            private set;
        }

        public ICommand SuperScriptCommand
        {
            get;
            private set;
        }

        public ICommand SubScriptCommand
        {
            get;
            private set;
        }

        public ICommand ColorCommand
        {
            get;
            private set;
        }

        public ICommand RadialMenuLoadedCommand
        {
            get;
            private set;
        }

        public ICommand RadialMenuClosedCommand
        {
            get;
            private set;
        }

        public ICommand SliderLoadedCommand
        {
            get;
            private set;
        }

        public ICommand RadialMenuColorItemLoadedCommand
        {
            get;
            private set;
        }

        public ICommand BoldLoadedCommand
        {
            get;
            private set;
        }

        public ICommand ItalicLoadedCommand
        {
            get;
            private set;
        }

        public ICommand UnderLineLoadedCommand
        {
            get;
            private set;
        }

        public ICommand StrikeLoadedCommand
        {
            get;
            private set;
        }

        public ICommand SubScriptLoadedCommand
        {
            get;
            private set;
        }

        public ICommand SuperScriptLoadedCommand
        {
            get;
            private set;
        }

        public ICommand RadialMenuOpenedCommand
        {
            get;
            private set;
        }

        #endregion


        private ObservableCollection<string> eventLogs;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        public ObservableCollection<string> EventLogs
        {
            get { return eventLogs; }
            set
            {
                eventLogs = value;
            }
        }

        #region Constructor
        public RadialMenuViewModel()
        {
            OpenEventLogs = new ObservableCollection<string>();

            TextBoxLoaded = new DelegateCommand(TextBoxLoadedMethod);
            LostFocusCommand = new DelegateCommand(LostFocusMethod);
            SelectionChangedCommand = new DelegateCommand(SelectionChangedMethod);

            RadialMenuLoadedCommand = new DelegateCommand(RadialMenuLoadedMethod);
            RadialMenuOpenedCommand = new DelegateCommand(RadialMenuOpenedMethod);
            RadialMenuClosedCommand = new DelegateCommand(RadialMenuClosedMethod);

            ValueChangedCommand = new DelegateCommand(SliderValueChangedMethod);

            RadialMenuColorItemLoadedCommand = new DelegateCommand(RadialMenuColorItemLoadedMethod);
            SliderLoadedCommand = new DelegateCommand(SliderLoadedMethod);

            BoldCommand = new DelegateCommand(BoldMethod);
            ItalicCommand = new DelegateCommand(ItalicMethod);
            UnderLineCommand = new DelegateCommand(UnderLineMethod);

            CopyCommand = new DelegateCommand(CopyMethod);
            CutCommand = new DelegateCommand(CutMethod);
            PasteCommand = new DelegateCommand(PasteMethod);

            ColorCommand = new DelegateCommand(ColorMethod);

            UndoCommand = new DelegateCommand(UndoMethod);
            RedoCommand = new DelegateCommand(RedoMethod);

            StrikeCommand = new DelegateCommand(StrikeMethod);
            SuperScriptCommand = new DelegateCommand(SuperScriptMethod);
            SubScriptCommand = new DelegateCommand(SubScriptMethod);


            BoldLoadedCommand = new DelegateCommand(BoldLoadedMethod);
            ItalicLoadedCommand = new DelegateCommand(ItalicLoadedMethod);
            UnderLineLoadedCommand = new DelegateCommand(UnderLineLoadedMethod);

            StrikeLoadedCommand = new DelegateCommand(StrikeLoadedMethod);
            SubScriptLoadedCommand = new DelegateCommand(SubScriptLoadedMethod);
            SuperScriptLoadedCommand = new DelegateCommand(SuperScriptLoadedMethod);
        }

        #endregion

        #region Methods
        private void TextBoxLoadedMethod(object obj)
        {
            if ((obj as RichTextBox) != null)
            {
                this.richTextBox = (obj as RichTextBox);
            }

            FlowDocument doc = new FlowDocument();
            Paragraph para = new Paragraph();


            description = @"Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.
Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.
Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.
Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.

Vestibulum duis integer diam mi libero felis, sollicitudin id dictum etiam blandit lacus, ac condimentum magna dictumst interdum et,
nam commodo mi habitasse enim fringilla nunc, amet aliquam sapien per tortor luctus. Conubia voluptates at nunc, congue lectus, malesuada nulla.
Rutrum quo morbi, feugiat sed mi turpis, ac cursus integer ornare dolor. Purus dui in et tincidunt, sed eros pede adipiscing tellus, est suscipit nulla,
arcu nec fringilla vel aliquam, mollis lorem rerum hac vestibulum ante nullam. Volutpat a lectus, lorem pulvinar quis. Lobortis vehicula in imperdiet orci urna.

Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.
Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet.
Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula.
Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.

Vestibulum duis integer diam mi libero felis, sollicitudin id dictum etiam blandit lacus, ac condimentum magna dictumst interdum et,
nam commodo mi habitasse enim fringilla nunc, amet aliquam sapien per tortor luctus. Conubia voluptates at nunc, congue lectus, malesuada nulla.
Rutrum quo morbi, feugiat sed mi turpis, ac cursus integer ornare dolor. Purus dui in et tincidunt, sed eros pede adipiscing tellus, est suscipit nulla,
arcu nec fringilla vel aliquam, mollis lorem rerum hac vestibulum ante nullam. Volutpat a lectus, lorem pulvinar quis. Lobortis vehicula in imperdiet orci urna.

";
            para.Inlines.Add(new Run(description));
            doc.Blocks.Add(para);
            if (this.richTextBox != null)
            {
                richTextBox.Document = doc;
            }
        }


        private void SelectionChangedMethod(object obj)
        {
            var defaultmenu = obj as radial.SfRadialMenu;

            if (defaultmenu != null && this.richTextBox != null && this.RadialMenu != null)
            {
                if (String.IsNullOrEmpty(richTextBox.Selection.Text))
                {

                    defaultmenu.Visibility = Visibility.Visible;
                    RadialMenu.Visibility = Visibility.Collapsed;
                    RadialMenu.IsOpen = false;
                }
                else
                {
                    defaultmenu.Visibility = Visibility.Collapsed;
                    defaultmenu.IsOpen = false;
                    RadialMenu.Visibility = Visibility.Visible;
                }
            }
        }

        private void LostFocusMethod(object obj)
        {
            prevSelection = (obj as RichTextBox).Selection;
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<string> eventlogs;

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<string> OpenEventLogs
        {
            get { return eventlogs; }
            set
            {
                eventlogs = value;
                OnPropertyRaised("OpenEventLogs");
            }
        }


        private void RadialMenuOpenedMethod(object obj)
        {
            if (this.richTextBox != null)
            {
                SetFocus(richTextBox);
            }
            OpenEventLogs.Add("Opened event triggered");
        }

        private void RadialMenuClosedMethod(object obj)
        {
           
            OpenEventLogs.Add("Closed event triggered");
        }

        private void SliderLoadedMethod(object obj)
        {
           if(this.richTextBox !=null)
            {
                SetFocus(richTextBox);
            }
        }

        private void SliderValueChangedMethod(object obj)
        {
            if (this.richTextBox != null)
            {
                if (richTextBox.Selection.Text != string.Empty && (obj as SfRadialSlider).Value >= 5)
                {
                    richTextBox.Selection.ApplyPropertyValue(RichTextBox.FontSizeProperty, (obj as SfRadialSlider).Value);
                }
                SetFocus(richTextBox);
            }
            }

        private void StrikeLoadedMethod(object obj)
        {
            var radialMenuitem = obj as radial.SfRadialMenuItem;
            if (radialMenuitem != null)
            {
                RadialMenuStrikeItem = radialMenuitem;
            }
        }
        private void SubScriptLoadedMethod(object obj)
        {
            var radialMenuitem = obj as radial.SfRadialMenuItem;
            if (radialMenuitem != null)
            {
                RadialMenuSubScriptItem = radialMenuitem;
            }
        }

        private void SuperScriptLoadedMethod(object obj)
        {
            var radialMenuitem = obj as radial.SfRadialMenuItem;
            if (radialMenuitem != null)
            {
                RadialMenuSuperScriptItem = radialMenuitem;
            }
        }

        private void BoldLoadedMethod(object obj)
        {
            if (richTextBox != null)
            {
                SetFocus(richTextBox);
            }
            var radialMenuitem = obj as radial.SfRadialMenuItem;
            if (radialMenuitem != null)
            {
                RadialMenuBoldItem = radialMenuitem;
            }
        }

        private void BoldMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!(RadialMenuBoldItem).IsChecked)
                    text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, "Bold");
                else
                    text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, "Normal");
            }
        }


        private void ItalicMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!(RadialMenuItalicItem).IsChecked)
                    text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, "Italic");
                else
                    text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, "Normal");
                SetFocus(text);
            }
        }


        private void ItalicLoadedMethod(object obj)
        {
            var radialMenuitem = obj as radial.SfRadialMenuItem;
            if (radialMenuitem != null)
            {
                RadialMenuItalicItem = radialMenuitem;
            }
        }

        private void UnderLineLoadedMethod(object obj)
        {
            var radialMenuitem = obj as radial.SfRadialMenuItem;
            if (radialMenuitem != null)
            {
                RadialMenuUnderLineItem = radialMenuitem;
            }
        }


        private void UnderLineMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (!(RadialMenuUnderLineItem).IsChecked)
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else if (RadialMenuStrikeItem.IsChecked)
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
            else
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, "None");
            SetFocus(text);
        }

        private void RadialMenuColorItemLoadedMethod(object obj)
        {
           if(this.richTextBox != null)
            {
                SetFocus(richTextBox);
            }
        }

        private void RadialMenuLoadedMethod(object obj)
        {
            var radialmenu = obj as radial.SfRadialMenu;
            if (radialmenu != null)
            {
                this.RadialMenu = radialmenu;
            }
        }

        private void ColorMethod(object obj)
        {
            var RadialColorItem = obj as SfRadialColorItem;
            if (richTextBox != null)
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((RadialColorItem).Color));
            }
        }

        private void SubScriptMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuSubScriptItem.IsChecked)
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
                else if (RadialMenuSuperScriptItem.IsChecked)
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
                else
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Baseline);

                SetFocus(text);
            }
        }

        private void SuperScriptMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuSuperScriptItem.IsChecked)
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
                else if (RadialMenuSubScriptItem.IsChecked)
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
                else
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Baseline);

                SetFocus(text);
            }
        }


        private void CutMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Cut();
            }
        }

        private void CopyMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Copy();
            }
        }

        private void SetFocus(RichTextBox text)
        {
            if (prevSelection != null)
            {
                text.Selection.Select(prevSelection.Start, prevSelection.End);
                text.Focus();
            }
        }

        private void UndoMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Undo();
            }
        }

        private void RedoMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Redo();
            }
        }

        private void StrikeMethod(Object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuStrikeItem.IsChecked)
                    text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);

                else if (RadialMenuUnderLineItem.IsChecked)
                    text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);

                else
                    text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, "None");
                SetFocus(text);
            }

        }

        private void PasteMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Paste();
            }
        }

        #endregion

    }


    /// <summary>
    /// Delegate Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : System.Windows.Input.ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
                return true;

            return _canExecute((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public void Execute(object parameter)
        {
            _execute((parameter == null) ? default(T) : (T)Convert.ChangeType(parameter, typeof(T)));
        }

        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
