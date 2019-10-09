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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Navigation;

namespace SfRadialMenu
{
    /// <summary>
    /// Interaction logic for RadialMenuDemo.xaml
    /// </summary>
    public partial class RadialMenuDemo : UserControl
    {
        public RadialMenuDemo()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(RadialMenuDemo_Loaded);
            selectionmenu.Opened += selectionmenu_Opened;
            
        }

        private void SetFocus()
        {
            if (prevSelection != null)
            {
                text.Selection.Select(prevSelection.Start, prevSelection.End);
                text.Focus();
            }
        }

        void selectionmenu_Opened(object sender, RoutedEventArgs e)
        {
          SetFocus();
        }

        private TextSelection prevSelection;
        string description = string.Empty;

        void RadialMenuDemo_Loaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= RadialMenuDemo_Loaded;

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

            text.Document = doc;
            

            text.SelectionChanged += (s, args) =>
            {
                if (text.Selection != null && text.Selection.GetPropertyValue(RichTextBox.FontSizeProperty) != DependencyProperty.UnsetValue)
                    FontsizeSlider.SetValue(SfRadialSlider.ValueProperty, Convert.ToDouble(text.Selection.GetPropertyValue(RichTextBox.FontSizeProperty)));
            };
        }

        private void Cut(object sender, RoutedEventArgs e)
        {
            text.Cut();
            prevSelection = null;

        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            text.Copy();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            text.Paste();
        }

        private void Bold(object sender, RoutedEventArgs e)
        {
            if (!(sender as SfRadialMenuItem).IsChecked)
                text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, "Bold");
            else
                text.Selection.ApplyPropertyValue(RichTextBox.FontWeightProperty, "Normal");
        }

        private void Color(object sender, RoutedEventArgs e)
        {
            text.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush((sender as SfRadialColorItem).Color));
        }
        private void RadialSlider_Value_Changed(object sender, RoutedEventArgs e)
        {
            if (text.Selection.Text != string.Empty && (sender as SfRadialSlider).Value >= 5)
            {
                text.Selection.ApplyPropertyValue(RichTextBox.FontSizeProperty, (sender as SfRadialSlider).Value);
            }
            SetFocus();
        }
        private void Undo(object sender, RoutedEventArgs e)
        {
            text.Undo();
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            text.Redo();
        }

        private void Italic(object sender, RoutedEventArgs e)
        {
            if (!(sender as SfRadialMenuItem).IsChecked)
                text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, "Italic");
            else
                text.Selection.ApplyPropertyValue(RichTextBox.FontStyleProperty, "Normal");
           SetFocus();
        }

        private void Strike(object sender, RoutedEventArgs e)
        {
            if (!(sender as SfRadialMenuItem).IsChecked)
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);

            else if (underline.IsChecked)
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
           
            else 
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, "None");
           
            SetFocus();
        }

        private void superScript(object sender, RoutedEventArgs e)
        {
            if (!(sender as SfRadialMenuItem).IsChecked)
                text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);

            else if (subscript.IsChecked)
                text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
            else
                text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Baseline);

            SetFocus();
        }

        private void SubScript(object sender, RoutedEventArgs e)
        {
            if (!(sender as SfRadialMenuItem).IsChecked)
                text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Subscript);
            else if (superscript.IsChecked)
                text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Superscript);
            else
                text.Selection.ApplyPropertyValue(Inline.BaselineAlignmentProperty, BaselineAlignment.Baseline);

            SetFocus();
        }

        private void Underline(object sender, RoutedEventArgs e)
        {
            if (!(sender as SfRadialMenuItem).IsChecked)
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else if (strike.IsChecked)
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);
            else
                text.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, "None");
            SetFocus();
        }

        private Point rect;
        private void text_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
          
           
            
       
            if (String.IsNullOrEmpty(text.Selection.Text))
            {
              
                defaultmenu.Visibility = Visibility.Visible;
                selectionmenu.Visibility = Visibility.Collapsed;
                selectionmenu.IsOpen = false;
            }
            else
            {
                defaultmenu.Visibility = Visibility.Collapsed;
                defaultmenu.IsOpen = false;
                selectionmenu.Visibility = Visibility.Visible;
            }
        }
        //bool firstLost = true;
        private void Text_OnLostFocus(object sender, RoutedEventArgs e)
        {
            prevSelection = text.Selection;
        }


        private void RadialMenuItem_OnLoaded(object sender, RoutedEventArgs e)
        {
            SetFocus();
        }

        private void FontsizeSlider_OnLoaded(object sender, RoutedEventArgs e)
        {
            SetFocus();
        }

        private void Text_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Text_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            rect=e.GetPosition(text);
            defaultmenu.IsOpen = false;
            selectionmenu.IsOpen = false;
        }

        private void Text_OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            rect = e.GetPosition(text);
            if (rect != null)
            {
                double left = text.ActualWidth - 200;
                double top = text.ActualHeight - 200;
                if (rect.X > left)
                {
                    rect.X = Math.Abs(left - (rect.X - left));
                }
                transform1.X = transform2.X = rect.X - 50;
                if (transform1.X < 0 && transform2.X < 0)
                {
                    transform1.X = transform2.X = 0.0;
                }

                if (rect.Y > top)
                {
                    rect.Y = Math.Abs(top - (rect.Y - top));
                }

                transform1.Y = transform2.Y = rect.Y - 100;
            }
        }
    }
}
