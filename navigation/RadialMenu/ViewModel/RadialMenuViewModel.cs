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
using Syncfusion.Windows.Shared;
using DelegateCommand = Syncfusion.Windows.Utils.DelegateCommand;

namespace syncfusion.navigationdemos.wpf
{
    public class RadialMenuViewModel : NotificationObject
    {
        #region Varialbles

        private RichTextBox richTextBox;

        private radial.SfRadialMenu RadialMenu;

        private TextSelection prevSelection;

        private Visibility defaultMenuVisibility = Visibility.Collapsed;

        private Visibility selectionMenuVisibility = Visibility.Visible;

        private bool defaultMenuIsOpen = false;
        
        private bool selectionMenuIsOpen = true;

        private bool RadialMenuBold = false;

        private bool RadialMenuItalic = false; 

        private bool RadialMenuUnderLine = false; 

        private bool RadialMenuStrike = false;

        private bool RadialMenuSubScript = false;

        private bool RadialMenuSuperScript = false;

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

        public ICommand RadialMenuOpenedCommand
        {
            get;
            private set;
        }

        #endregion

        private FlowDocument document;
        private Paragraph paragraph;
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        public FlowDocument Document
        {
            get { return document; }
            set
            {
                document = value;
            }
        }

        public Paragraph Paragraph
        {
            get { return paragraph; }
            set
            {
                paragraph = value;
            }
        }

        public Visibility DefaultMenuVisibility
        {
            get { return defaultMenuVisibility; }
            set
            {
                defaultMenuVisibility = value;
                RaisePropertyChanged("DefaultMenuVisibility");
            }
        }

        public Visibility SelectionMenuVisibility
        {
            get { return selectionMenuVisibility; }
            set
            {
                selectionMenuVisibility = value;
                RaisePropertyChanged("SelectionMenuVisibility");
            }
        }

        public bool DefaultMenuIsOpen
        {
            get { return defaultMenuIsOpen; }
            set
            {
                defaultMenuIsOpen = value;
                RaisePropertyChanged("DefaultMenuIsOpen");
            }
        }

        public bool SelectionMenuIsOpen
        {
            get { return selectionMenuIsOpen; }
            set
            {
                selectionMenuIsOpen = value;
                RaisePropertyChanged("SelectionMenuIsOpen");
            }
        }

        private ObservableCollection<string> eventLogs;
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
            this.OpenEventLogs = new ObservableCollection<string>();
            this.Paragraph = new Paragraph();
            this.Document = new FlowDocument();


            TextBoxLoaded = new DelegateCommand(TextBoxLoadedMethod);
            LostFocusCommand = new DelegateCommand(LostFocusMethod);
            SelectionChangedCommand = new DelegateCommand(SelectionChangedMethod);

            RadialMenuOpenedCommand = new DelegateCommand(RadialMenuOpenedMethod);
            RadialMenuClosedCommand = new DelegateCommand(RadialMenuClosedMethod);

            ValueChangedCommand = new DelegateCommand(SliderValueChangedMethod);

            RadialMenuColorItemLoadedCommand = new DelegateCommand(RadialMenuColorItemLoadedMethod);
            SliderLoadedCommand = new DelegateCommand(SliderLoadedMethod);
            RadialMenuLoadedCommand = new DelegateCommand(RadialMenuLoadedMethod);

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
        }

        private void SubScriptMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuSubScript)
                {
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
                    RadialMenuSubScript = true;
                }
                else if (RadialMenuSuperScript)
                {
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
                    RadialMenuSuperScript = false;
                }
                else
                {
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Baseline);
                    RadialMenuSubScript = false;
                }
                this.SetFocus(text);
            }

        }

        private void SuperScriptMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuSuperScript)
                {
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
                    RadialMenuSuperScript = true;
                }
                else if (RadialMenuSubScript)
                {
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
                    RadialMenuSubScript = false;
                }
                else
                {
                    text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Baseline);
                    RadialMenuSuperScript = false;
                }

                this.SetFocus(text);
            }
        }

        private void StrikeMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (!RadialMenuStrike)
            {
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
                RadialMenuStrike = true;
            }
            else if (RadialMenuUnderLine)
            {
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                RadialMenuUnderLine = false;
            }
            else
            {
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, "None");
                RadialMenuStrike = false;
            }
        }

        private void RedoMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Redo();
            }
        }

        private void UndoMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Undo();
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

        private void PasteMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Paste();
            }
        }

        private void CutMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Cut();
            }
        }

        private void CopyMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                text.Copy();
            }
        }

        private void UnderLineMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (!RadialMenuUnderLine)
            {
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                RadialMenuUnderLine = true;
            }
            else if (RadialMenuStrike)
            {
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
                RadialMenuStrike = false;
            }
            else
            {
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, "None");
                RadialMenuUnderLine = false;
            }

            this.SetFocus(text);
        }

        private void SetFocus(RichTextBox text)
        {
            if (prevSelection != null)
            {
                text.Selection.Select(prevSelection.Start, prevSelection.End);
                text.Focus();
            }
        }

        private void ItalicMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuItalic)
                {
                    text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, "Italic");
                    RadialMenuItalic = true;
                }              
                else
                {
                    text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, "Normal");
                    RadialMenuItalic = false;
                }
                
                this.SetFocus(text);
            }
        }

        private void BoldMethod(object obj)
        {
            var text = obj as RichTextBox;
            if (text != null)
            {
                if (!RadialMenuBold)
                {
                    text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, "Bold");
                    RadialMenuBold = true;
                }          
                else
                {
                    text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, "Normal");
                    RadialMenuBold = false;
                }  
            }
        }

        private void SliderLoadedMethod(object obj)
        {
            if (this.richTextBox != null)
            {
                this.SetFocus(richTextBox);
            }
        }

        private void RadialMenuColorItemLoadedMethod(object obj)
        {
            if (this.richTextBox != null)
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
                
                this.SetFocus(richTextBox);
            }
        }

        private void RadialMenuClosedMethod(object obj)
        {
            this.OpenEventLogs.Add("Closed event triggered");
        }

        private void RadialMenuOpenedMethod(object obj)
        {
            if (this.richTextBox != null)
            {
                this.SetFocus(richTextBox);
            }
            
            this.OpenEventLogs.Add("Opened event triggered");
        }

        private void RadialMenuLoadedMethod(object obj)
        {
            var radialmenu = obj as radial.SfRadialMenu;
            if (radialmenu != null)
            {
                this.RadialMenu = radialmenu;
            }
        }


        private void SelectionChangedMethod(object obj)
        {
            var defaultmenu = obj as radial.SfRadialMenu;
            if (defaultmenu != null && this.richTextBox != null && this.RadialMenu != null)
            {
                if (String.IsNullOrEmpty(richTextBox.Selection.Text))
                {
                    DefaultMenuVisibility = Visibility.Visible;
                    SelectionMenuVisibility = Visibility.Collapsed;
                    SelectionMenuIsOpen = false;
                }
                else
                {
                    DefaultMenuVisibility = Visibility.Collapsed;
                    DefaultMenuIsOpen = false;
                    SelectionMenuVisibility = Visibility.Visible;
                }
            }
        }

        private void LostFocusMethod(object obj)
        {
            prevSelection = (obj as RichTextBox).Selection;
        }

        private void TextBoxLoadedMethod(object obj)
        {
            if ((obj as RichTextBox) != null)
            {
                this.richTextBox = (obj as RichTextBox);
            }

            if (obj != null)
            {
                this.Description = @"Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus.
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
                this.Paragraph.Inlines.Add(new Run(this.Description));
                this.Document.Blocks.Add(this.Paragraph);
                (obj as RichTextBox).Document = this.Document;
            }
        }

        #endregion

        #region Methods

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
                RaisePropertyChanged("OpenEventLogs");
            }
        }

        #endregion
    }
}
