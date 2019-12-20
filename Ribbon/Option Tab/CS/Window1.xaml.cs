#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Threading;
using Syncfusion.SfSkinManager;

namespace RibbonSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : RibbonWindow
    {
        /// <summary>
        /// 
        /// </summary>
        public static RoutedUICommand CustomCommand = new RoutedUICommand("CustomCommand", "CustomCommand",
            typeof(SplitMenuButton));

        private DispatcherTimer timer = new DispatcherTimer();

        //Command Execute / CanExecute Methods

        #region Command Execute / CanExecute Methods

        /// <summary>
        /// Customs the command execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CustomCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Custom command executed");
        }

        /// <summary>
        /// Opens the command execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void OpenCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            FlowDocument content = null;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*";
            if (openFile.ShowDialog().Value)
            {
                FileStream xamlFile = openFile.OpenFile() as FileStream;
                if (xamlFile == null) return;
                else
                {
                    try
                    {
                        content = XamlReader.Load(xamlFile) as FlowDocument;
                        if (content == null)
                            throw (new XamlParseException
                                ("The specified file could not be loaded as a FlowDocument."));
                    }
                    catch (Exception ex)
                    {
                        String error = "There was a problem loading the specified file:\n\n";
                        error += openFile.FileName;
                        error += "\n\nException details:\n\n";
                        error += ex.Message;
                        System.Windows.MessageBox.Show(error);
                        return;
                    }
                    Editor.Document = content;
                    xamlFile.Close();
                }
            }
        }

        /// <summary>
        /// Saves the command execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void SaveCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            FileStream xamlFile = null;
            saveFile.Filter = "FlowDocument Files (*.xaml)|*.xaml|All Files (*.*)|*.*";
            if (saveFile.ShowDialog().Value)
            {
                try
                {
                    xamlFile = saveFile.OpenFile() as FileStream;
                }
                catch (Exception ex)
                {
                    String error = "There was a opening the file:\n\n";
                    error += saveFile.FileName;
                    error += "\n\nException details:\n\n";
                    error += ex.Message;
                    System.Windows.MessageBox.Show(error);
                    return;
                }
                if (xamlFile == null) return;
                else
                {
                    XamlWriter.Save(Editor.Document, xamlFile);
                    xamlFile.Close();
                }
            }
        }

        /// <summary>
        /// Closes the command execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.ExecutedRoutedEventArgs"/> instance containing the event data.</param>
        private void CloseCommandExecute(object sender, ExecutedRoutedEventArgs e) { }

        /// <summary>
        /// Aligns the left can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void AlignLeftCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionAlignLeft != null)
            {
                parameter.IsSelected = this.SelectionAlignLeft.Value;
            }
        }

        /// <summary>
        /// Aligns the center can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void AlignCenterCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionAlignCenter != null)
            {
                parameter.IsSelected = this.SelectionAlignCenter.Value;
            }
        }

        /// <summary>
        /// Aligns the right can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void AlignRightCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionAlignRight != null)
            {
                parameter.IsSelected = this.SelectionAlignRight.Value;
            }
        }

        /// <summary>
        /// Aligns the justify can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void AlignJustifyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionAlignJustify != null)
            {
                parameter.IsSelected = this.SelectionAlignJustify.Value;
            }
        }

        /// <summary>
        /// Toggles the bold can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleBoldCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionBold != null)
            {
                parameter.IsSelected = this.SelectionBold.Value;
            }
        }

        /// <summary>
        /// Toggles the italic can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleItalicCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionItalic != null)
            {
                parameter.IsSelected = this.SelectionItalic.Value;
            }
        }

        /// <summary>
        /// Toggles the underline can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleUnderlineCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            SplitButton parameter = e.Parameter as SplitButton;
            if (parameter != null) { }
        }

        /// <summary>
        /// Toggles the subscript can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleSubscriptCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionSubscript != null)
            {
                parameter.IsSelected = this.SelectionSubscript.Value;
            }
        }

        /// <summary>
        /// Toggles the superscript can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleSuperscriptCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionSuperscript != null)
            {
                parameter.IsSelected = this.SelectionSuperscript.Value;
            }
        }

        /// <summary>
        /// Cuts the can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void CutCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Editor.Selection.IsEmpty;
        }

        /// <summary>
        /// Copies the can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void CopyCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Editor.Selection.IsEmpty;
        }

        /// <summary>
        /// Pastes the can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void PasteCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Toggles the bullets can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleBulletsCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionBullets != null)
            {
                parameter.IsSelected = this.SelectionBullets.Value;
            }
        }

        /// <summary>
        /// Toggles the numbering can execute.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.CanExecuteRoutedEventArgs"/> instance containing the event data.</param>
        private void ToggleNumberingCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            RibbonButton parameter = e.Parameter as RibbonButton;
            if (parameter != null && SelectionNumbering != null)
            {
                parameter.IsSelected = this.SelectionNumbering.Value;
            }
        }

        #endregion

        //Editor Formatting Properties

        #region Editor Formatting Properties

        /// <summary>
        /// Coerces the boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="trueValue">The true value.</param>
        /// <returns></returns>
        private bool? CoerceBooleanValue(object value, object trueValue)
        {
            if (value == null)
                return null;
            else if (value.Equals(trueValue))
                return true;
            else if (value == DependencyProperty.UnsetValue)
                return null;
            else
                return false;
        }

        /// <summary>
        /// Gets or sets the selection align center.
        /// </summary>
        /// <value>The selection align center.</value>
        public bool? SelectionAlignCenter
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextBlock.TextAlignmentProperty),
                    TextAlignment.Center);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Editor.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty,
                        TextAlignment.Center);
            }
        }

        /// <summary>
        /// Gets or sets the selection align justify.
        /// </summary>
        /// <value>The selection align justify.</value>
        public bool? SelectionAlignJustify
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextBlock.TextAlignmentProperty),
                    TextAlignment.Justify);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Editor.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty,
                        TextAlignment.Justify);
            }
        }

        /// <summary>
        /// Gets or sets the selection align left.
        /// </summary>
        /// <value>The selection align left.</value>
        public bool? SelectionAlignLeft
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextBlock.TextAlignmentProperty),
                    TextAlignment.Left);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Editor.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty,
                        TextAlignment.Left);
            }
        }

        /// <summary>
        /// Gets or sets the selection align right.
        /// </summary>
        /// <value>The selection align right.</value>
        public bool? SelectionAlignRight
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextBlock.TextAlignmentProperty),
                    TextAlignment.Right);
            }
            set
            {
                if ((value.HasValue) && (value.Value))
                    Editor.Selection.ApplyPropertyValue(TextBlock.TextAlignmentProperty,
                        TextAlignment.Right);
            }
        }

        /// <summary>
        /// Gets or sets the selection background.
        /// </summary>
        /// <value>The selection background.</value>
        public Brush SelectionBackground
        {
            get
            {
                object value = Editor.Selection.GetPropertyValue(TextElement.BackgroundProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                else
                    return (Brush)value;
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selection bold.
        /// </summary>
        /// <value>The selection bold.</value>
        public bool? SelectionBold
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextElement.FontWeightProperty),
                    FontWeights.Bold);
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(TextElement.FontWeightProperty,
                    (value != false ? FontWeights.Bold : FontWeights.Normal));
            }
        }

        /// <summary>
        /// Gets or sets the selection font family.
        /// </summary>
        /// <value>The selection font family.</value>
        public FontFamily SelectionFontFamily
        {
            get
            {
                object value = Editor.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                else
                    return (FontFamily)value;
            }
            set
            {
                if (value != null)
                    Editor.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the selection font.
        /// </summary>
        /// <value>The size of the selection font.</value>
        public double SelectionFontSize
        {
            get
            {
                object value = Editor.Selection.GetPropertyValue(TextElement.FontSizeProperty);
                if (value == DependencyProperty.UnsetValue)
                    return double.NaN;
                else
                    return (double)value;
            }
            set
            {
                if (!value.Equals(double.NaN))
                    Editor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the selection foreground.
        /// </summary>
        /// <value>The selection foreground.</value>
        public Brush SelectionForeground
        {
            get
            {
                object value = Editor.Selection.GetPropertyValue(TextElement.ForegroundProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                else
                    return (Brush)value;
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty,
                    (value != null ? value : Brushes.Black));
            }
        }

        /// <summary>
        /// Gets or sets the selection italic.
        /// </summary>
        /// <value>The selection italic.</value>
        public bool? SelectionItalic
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextElement.FontStyleProperty),
                    FontStyles.Italic);
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(TextElement.FontStyleProperty,
                    (value != false ? FontStyles.Italic : FontStyles.Normal));
            }
        }

        /// <summary>
        /// Gets or sets the selection strikethrough.
        /// </summary>
        /// <value>The selection strikethrough.</value>
        public bool? SelectionStrikethrough
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextBlock.TextDecorationsProperty),
                    TextDecorations.Strikethrough);
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty,
                    (value != false ? TextDecorations.Strikethrough : null));
            }
        }

        /// <summary>
        /// Gets or sets the selection subscript.
        /// </summary>
        /// <value>The selection subscript.</value>
        public bool? SelectionSubscript
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(Typography.VariantsProperty),
                    FontVariants.Subscript);
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(Typography.VariantsProperty,
                    (value != false ? FontVariants.Subscript : FontVariants.Normal));
            }
        }

        /// <summary>
        /// Gets or sets the selection superscript.
        /// </summary>
        /// <value>The selection superscript.</value>
        public bool? SelectionSuperscript
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(Typography.VariantsProperty),
                    FontVariants.Superscript);
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(Typography.VariantsProperty,
                    (value != false ? FontVariants.Superscript : FontVariants.Normal));
            }
        }

        /// <summary>
        /// Gets or sets the selection underline.
        /// </summary>
        /// <value>The selection underline.</value>
        public bool? SelectionUnderline
        {
            get
            {
                return this.CoerceBooleanValue(Editor.Selection.GetPropertyValue(TextBlock.TextDecorationsProperty),
                    TextDecorations.Underline);
            }
            set
            {
                Editor.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty,
                    (value != false ? TextDecorations.Underline : null));
            }
        }

        /// <summary>
        /// Gets the selection bullets.
        /// </summary>
        /// <value>The selection bullets.</value>
        public bool? SelectionBullets
        {
            get
            {
                bool isBullets = false;
                List list = GetSelectionList();

                if (list != null)
                {
                    TextMarkerStyle style = list.MarkerStyle;

                    isBullets = ((int)style > 0 && (int)style < 5);
                }

                return CoerceBooleanValue(isBullets, true);
            }
        }

        /// <summary>
        /// Gets the selection numbering.
        /// </summary>
        /// <value>The selection numbering.</value>
        public bool? SelectionNumbering
        {
            get
            {
                bool isNumbering = false;
                List list = GetSelectionList();

                if (list != null)
                {
                    TextMarkerStyle style = list.MarkerStyle;

                    isNumbering = ((int)style > 4 && (int)style < 10);
                }

                return CoerceBooleanValue(isNumbering, true);
            }
        }

        /// <summary>
        /// Gets the selection list.
        /// </summary>
        /// <value>The selection list.</value>
        public TextMarkerStyle SelectionList
        {
            get
            {
                TextMarkerStyle style = TextMarkerStyle.None;
                List list = GetSelectionList();

                if (list != null)
                {
                    style = list.MarkerStyle;
                }

                return style;
            }
        }

        #endregion

        //Class Fields

        #region Class Fields

        private MiniToolbar toolBar;
        private bool m_bAcceptFormatting;
        private System.IO.Stream m_TextSelectionStream;
        MiniToolbar miniToolbar = new MiniToolbar();
        MiniToolbar tool = new MiniToolbar();

        #endregion

        //Class Helper Methods

        #region Class Helper Methods

        /// <summary>
        /// Initializes the ribbon command manager.
        /// </summary>
        private void InitializeRibbonCommandManager()
        {
            RibbonCommandManager.Register(EditingCommands.AlignCenter,
              new RibbonCommandProvider("Paragraph Commands", "Center", "/Resources/AlignTextCenter16.png",
              GetScreenTip("Center (Ctrl+E)", "Center text.")));
            RibbonCommandManager.Register(EditingCommands.AlignJustify,
              new RibbonCommandProvider("Paragraph Commands", "Justify", "/Resources/AlignTextJustify16.png",
              GetScreenTip("Justify (Ctrl+J)",
              "Align text to both the left and right margins, adding extra space between words as necessary." +
              "\r\n\r\nThis creates a clean look along the left and right sides of the page.")));
            RibbonCommandManager.Register(EditingCommands.AlignLeft,
              new RibbonCommandProvider("Paragraph Commands", "Align Text Left", "/Resources/AlignTextLeft16.png",
              GetScreenTip("Align Text Left (Ctrl+L)", "Align text to the left.")));
            RibbonCommandManager.Register(EditingCommands.AlignRight,
              new RibbonCommandProvider("Paragraph Commands", "Align Text Right", "/Resources/AlignTextRight16.png",
              GetScreenTip("Align Text Right (Ctrl+R)", "Align text to the right.")));
            RibbonCommandManager.Register(EditingCommands.IncreaseIndentation,
              new RibbonCommandProvider("Paragraph Commands", "Increase Indent", "/Resources/IncreaseIndent16.png",
              GetScreenTip("Increase Indent", "Increase the indent level of the paragraph")));
            RibbonCommandManager.Register(EditingCommands.DecreaseIndentation,
              new RibbonCommandProvider("Paragraph Commands", "Decrease Indent", "/Resources/DecreaseIndent16.png",
              GetScreenTip("Decrease Indent", "Decrease the indent level of the paragraph")));
            RibbonCommandManager.Register(EditingCommands.ToggleBullets,
              new RibbonCommandProvider("Paragraph Commands", "Bullets", "/Resources/Bullets16.png",
              GetScreenTip("Bullets",
              "Start a bulleted list.\r\n\r\nClick the arrow to choose different bullet styles.")));
            RibbonCommandManager.Register(EditingCommands.ToggleNumbering,
             new RibbonCommandProvider("Paragraph Commands", "Numbering", "/Resources/Numbering16.png",
             GetScreenTip("Numbering",
             "Start a numbered list.\r\n\r\nClick the arrow to choose different numbering formatting.")));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Close,
              new RibbonCommandProvider("Document Commands", "Close", "/Resources/Close32.png", "Close the Ribbon"));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Copy,
              new RibbonCommandProvider("Clipboard Commands", "Copy", "/Resources/Copy16.png",
                  "Copy the selection and put it on the Clipboard."));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Cut, new RibbonCommandProvider
                     ("Clipboard Commands", "Cut", "/Resources/Cut16.png",
                     "Cut the selection from the document and put it on the Clipboard."));
            RibbonCommandManager.Register(EditingCommands.DecreaseFontSize, new RibbonCommandProvider
                    ("Font Commands", "Shrink Font", "/Resources/ShrinkFont16.png", "Decrease the font size."));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Find,
                new RibbonCommandProvider("Editing Commands", "Find:", "/Resources/Find16.png",
                    "Finds text in the text editor."));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Help,
                new RibbonCommandProvider("Help Commands", "About Ribbon", "/Resources/Help16.png",
                    "See the About window for this product."));
            RibbonCommandManager.Register(EditingCommands.IncreaseFontSize,
                new RibbonCommandProvider("Font Commands", "Grow Font", "/Resources/GrowFont16.png",
                    "Increase the font size."));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.New,
                new RibbonCommandProvider("Document Commands", "New", "/Resources/New32.png", null));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Open,
                new RibbonCommandProvider("Document Commands", "Open", "/Resources/Open32.png", null));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Paste,
                new RibbonCommandProvider("Clipboard Commands", "Paste", "/Resources/Paste16.png"));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Redo,
                new RibbonCommandProvider("Editing Commands", "Redo", "/Resources/Redo16.png"));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Save,
                new RibbonCommandProvider("Document Commands", "Save", "/Resources/Save16.png",
                    "Save the document"));
            RibbonCommandManager.Register(EditingCommands.ToggleBold,
                new RibbonCommandProvider("Font Commands", "Bold", "/Resources/Bold16.png",
                    GetScreenTip("Bold (Ctrl+B)", "Make the selected text bold.")));
            RibbonCommandManager.Register(EditingCommands.ToggleItalic,
                new RibbonCommandProvider("Font Commands", "Italic", "/Resources/Italic16.png",
                     GetScreenTip("Italic(Ctrl+I)","Italicize the selected text.")));
            RibbonCommandManager.Register(EditingCommands.ToggleSubscript,
                new RibbonCommandProvider("Font Commands", "Subscript", "/Resources/Subscript16.png",
                    "Create small letters below the text baseline."));
            RibbonCommandManager.Register(EditingCommands.ToggleSuperscript,
                new RibbonCommandProvider("Font Commands", "Superscript", "/Resources/Superscript16.png",
                    "Create small letters above the line of text."));
            RibbonCommandManager.Register(EditingCommands.ToggleUnderline,
                new RibbonCommandProvider("Font Commands", "Underline", "/Resources/Underline16.png",
                    GetScreenTip("Underline(Ctrl+U)","Underline the selected text.")));
            RibbonCommandManager.Register(System.Windows.Input.ApplicationCommands.Undo,
                new RibbonCommandProvider("Editing Commands", "Undo", "/Resources/Undo16.png"));
        }

        /// <summary>
        /// Initializes the editor commands.
        /// </summary>
        private void InitializeEditorCommands()
        {
            CommandBindings.Add
                (new CommandBinding(ApplicationCommands.Cut, null, CutCanExecute));
            CommandBindings.Add
                (new CommandBinding(ApplicationCommands.Copy, null, CutCanExecute));
            CommandBindings.Add
                (new CommandBinding(ApplicationCommands.Paste, null, PasteCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.AlignLeft, null, AlignLeftCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.AlignCenter, null, AlignCenterCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.AlignRight, null, AlignRightCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.AlignJustify, null, AlignJustifyCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.ToggleItalic, null, ToggleItalicCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.ToggleUnderline, null, ToggleUnderlineCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.ToggleSubscript, null, ToggleSubscriptCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.ToggleSuperscript, null, ToggleSuperscriptCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.IncreaseFontSize, null, null));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.DecreaseFontSize, null, null));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.IncreaseIndentation, null, null));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.DecreaseIndentation, null, null));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.ToggleBullets, null, ToggleBulletsCanExecute));
            CommandBindings.Add
                (new CommandBinding(EditingCommands.ToggleNumbering, null, ToggleNumberingCanExecute));
        }

        private void ApplySkin(string skin)
        {
            SkinStorage.SetVisualStyle(this, skin);
        }

        /// <summary>
        /// Handles the MouseUp event of the Editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Editor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("MouseUP");

            if (!Editor.Selection.IsEmpty)
            {
                RibbonComboBox toolbarfont = (RibbonComboBox)toolBar.Items[0];
                RibbonComboBox toolbarfontsize = (RibbonComboBox)toolBar.Items[1];

                RibbonButton boldBtn = (RibbonButton)toolBar.Items[4];
                RibbonButton italicBtn = (RibbonButton)toolBar.Items[5];
                RibbonButton underlineBtn = (RibbonButton)toolBar.Items[6];
                RibbonButton strikeBtn = (RibbonButton)toolBar.Items[7];

                if (SelectionFontFamily != null)
                    toolbarfont.Text = SelectionFontFamily.Source;

                if (!double.IsNaN(SelectionFontSize))
                    toolbarfontsize.Text = SelectionFontSize.ToString();

                if (SelectionStrikethrough.HasValue)
                    strikeBtn.IsSelected = SelectionStrikethrough.Value;

                if (SelectionBold.HasValue)
                    boldBtn.IsSelected = SelectionBold.Value;

                if (SelectionItalic.HasValue)
                    italicBtn.IsSelected = SelectionItalic.Value;

                if (SelectionUnderline.HasValue)
                    underlineBtn.IsSelected = SelectionUnderline.Value;

                toolBar.Show();
            }

            else
                toolBar.Hide();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the Editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextSelection selection = Editor.Selection;
            bool EmptySelection = selection.IsEmpty;
            if (EmptySelection)
                toolBar.Hide();

            ResetCurrentEditorStyles();
        }       

        /// <summary>
        /// Initializes the font combo box.
        /// </summary>
        /// <param name="r_Combo">The r_ combo.</param>
        private void InitializeFontComboBox(RibbonComboBox r_Combo)
        {
            if (r_Combo != null)
            {
                r_Combo.DropDownOpened -= new EventHandler(OnStartFormattingPreview);
                r_Combo.DropDownClosed -= new EventHandler(OnEndFormattingPreview);
            }

            r_Combo.Items.Clear();
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                RibbonComboBoxItem item = new RibbonComboBoxItem();
                item.Content = fontFamily;
                item.PreviewMouseMove += new MouseEventHandler(OnFontNameChanged);
                item.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(OnAcceptFormatting);
                r_Combo.Items.Add(item);
            }
            r_Combo.SelectedIndex = 0;
            r_Combo.DropDownOpened += new EventHandler(OnStartFormattingPreview);
            r_Combo.DropDownClosed += new EventHandler(OnEndFormattingPreview);
        }

        /// <summary>
        /// Initializes the font size combo box.
        /// </summary>
        /// <param name="r_combo">The r_combo.</param>
        private void InitializeFontSizeComboBox(RibbonComboBox r_combo)
        {
            if (r_combo != null)
            {
                r_combo.DropDownOpened -= new EventHandler(OnStartFormattingPreview);
                r_combo.DropDownClosed -= new EventHandler(OnEndFormattingPreview);
            }

            r_combo.Items.Clear();
            int[] sizes = new int[15] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            for (int i = 0, cnt = sizes.Length; i < cnt; ++i)
            {
                RibbonComboBoxItem item = new RibbonComboBoxItem();
                item.Content = sizes[i];
                item.PreviewMouseMove += new MouseEventHandler(OnFontSizeChanged);
                item.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(OnAcceptFormatting);
                r_combo.Items.Add(item);
            }

            r_combo.SelectedIndex = 0;

            r_combo.DropDownOpened += new EventHandler(OnStartFormattingPreview);
            r_combo.DropDownClosed += new EventHandler(OnEndFormattingPreview);
        }

        /// <summary>
        /// Called when [start formatting preview].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnStartFormattingPreview(object sender, EventArgs e)
        {
            SaveSelection();
        }

        /// <summary>
        /// Called when [end formatting preview].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnEndFormattingPreview(object sender, EventArgs e)
        {
            if (!m_bAcceptFormatting)
                LoadSelection();
            ReleaseSelectionStream();
            m_bAcceptFormatting = false;
        }

        /// <summary>
        /// Called when [accept formatting].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void OnAcceptFormatting(object sender, MouseButtonEventArgs e)
        {
            m_bAcceptFormatting = true;
        }

        /// <summary>
        /// Loads the selection.
        /// </summary>
        private void LoadSelection()
        {
            if (m_TextSelectionStream != null)
                Editor.Selection.Load(m_TextSelectionStream, System.Windows.DataFormats.Rtf);
        }

        /// <summary>
        /// Saves the selection.
        /// </summary>
        private void SaveSelection()
        {
            if (m_TextSelectionStream == null)
                m_TextSelectionStream = new System.IO.MemoryStream();
            Editor.Selection.Save(m_TextSelectionStream, System.Windows.DataFormats.Rtf);
        }

        /// <summary>
        /// Releases the selection stream.
        /// </summary>
        private void ReleaseSelectionStream()
        {
            if (m_TextSelectionStream != null)
            {
                m_TextSelectionStream.Close();
                m_TextSelectionStream.Dispose();
                m_TextSelectionStream = null;
            }
        }

        /// <summary>
        /// Called when [font name changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnFontNameChanged(object sender, RoutedEventArgs e)
        {
            RibbonComboBoxItem item = sender as RibbonComboBoxItem;
            if (item != null)
            {
                SelectionFontFamily = item.Content as FontFamily;
            }
        }

        /// <summary>
        /// Called when [font size changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void OnFontSizeChanged(object sender, RoutedEventArgs e)
        {
            RibbonComboBoxItem item = sender as RibbonComboBoxItem;
            if (item != null)
            {
                SelectionFontSize = (int)item.Content;
            }
        }

        /// <summary>
        /// Called when [strike through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnStrikeThrough(object sender, EventArgs e)
        {
            SelectionStrikethrough = !SelectionStrikethrough;
        }

        /// <summary>
        /// Called when [bold through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnBoldThrough(object sender, EventArgs e)
        {
            SelectionBold = !SelectionBold;
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Called when [italic through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnItalicThrough(object sender, EventArgs e)
        {
            SelectionItalic = !SelectionItalic;
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Called when [underline through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnUnderlineThrough(object sender, EventArgs e)
        {
            SelectionUnderline = !SelectionUnderline;
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Called when [increase font through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnIncreaseFontThrough(object sender, EventArgs e)
        {
            SelectionFontSize = SelectionFontSize + 1;
        }

        /// <summary>
        /// Called when [decrease font through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnDecreaseFontThrough(object sender, EventArgs e)
        {
            if (SelectionFontSize > 1)
                SelectionFontSize = SelectionFontSize - 1;
        }

        /// <summary>
        /// Called when [sub script through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSubScriptThrough(object sender, EventArgs e)
        {
            SelectionSubscript = !SelectionSubscript;
        }

        /// <summary>
        /// Called when [super script through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSuperScriptThrough(object sender, EventArgs e)
        {
            SelectionSuperscript = !SelectionSuperscript;
        }

        /// <summary>
        /// Gets the selection list.
        /// </summary>
        /// <returns></returns>
        private List GetSelectionList()
        {
            List list = null;
            TextPointer textPointer = Editor.Selection.Start;
            if (textPointer != null)
            {
                TextElement ancestor = textPointer.Parent as TextElement;
                while (ancestor != null && !(ancestor is System.Windows.Documents.ListItem))
                {
                    ancestor = ancestor.Parent as TextElement;
                }

                System.Windows.Documents.ListItem item = ancestor as System.Windows.Documents.ListItem;

                if (item != null)
                {
                    list = item.Parent as List;
                }
            }

            return list;
        }

        /// <summary>
        /// Called when [flow direction].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnFlowDirection(object sender, EventArgs e)
        {
            FlowDirection = (FlowDirection)(1 - (int)FlowDirection);
        }

        /// <summary>
        /// Handles the MouseEnter event of the MyRibbon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseEventArgs"/> instance containing the event data.</param>
        private void MyRibbon_MouseEnter(object sender, MouseEventArgs e)
        {
            toolBar.Hide();
        }

        /// <summary>
        /// Handles the PreviewKeyUp event of the MyRibbon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.KeyEventArgs"/> instance containing the event data.</param>
        private void MyRibbon_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                toolBar.Hide();
                tool.Hide();
            }
        }

        /// <summary>
        /// Gets the screen tip.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        private ScreenTip GetScreenTip(string description, string content)
        {
            ScreenTip tip = new ScreenTip();
            tip.Description = description;
            TextBlock text = new TextBlock();
            text.TextWrapping = TextWrapping.Wrap;
            text.Foreground = Brushes.Black;
            text.Text = content;
            tip.Content = text;
            tip.MaxWidth = 250;

            return tip;
        }

        /// <summary>
        /// RTBs this instance.
        /// </summary>
        public void RTB()
        {
            Paragraph pg;
            List ls1;
            System.Windows.Documents.ListItem lsit;
            this.Document.Background = new SolidColorBrush(Colors.White);
            foreach (object obj in Document.Blocks)
            {
                if (obj is Paragraph)
                {
                    pg = (Paragraph)obj;
                    pg.Foreground = new SolidColorBrush(Colors.Black);
                }
                if (obj is List)
                {
                    ls1 = (List)obj;
                    foreach (System.Windows.Documents.ListItem obj1 in ls1.ListItems)
                    {
                        lsit = (System.Windows.Documents.ListItem)obj1;
                        foreach (object obj2 in lsit.Blocks)
                        {
                            if (obj2 is Paragraph)
                            {
                                pg = (Paragraph)obj2;
                                pg.Foreground = new SolidColorBrush(Colors.Black);
                            }
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Resets the current editor styles.
        /// </summary>
        private void ResetCurrentEditorStyles()
        {
            
            if (SelectionBold.HasValue)
            {
                format_btnBold.IsSelected = SelectionBold.Value;
            }

            if (SelectionItalic.HasValue)
            {
                format_btnItalic.IsSelected = SelectionItalic.Value;
            }


            RibbonComboBox toolbarfont = (RibbonComboBox)toolBar.Items[0];
            RibbonComboBox toolbarfontsize = (RibbonComboBox)toolBar.Items[1];

            RibbonButton boldBtn = (RibbonButton)toolBar.Items[4];
            RibbonButton italicBtn = (RibbonButton)toolBar.Items[5];
            RibbonButton underlineBtn = (RibbonButton)toolBar.Items[6];
            RibbonButton strikeBtn = (RibbonButton)toolBar.Items[7];

            if (SelectionFontFamily != null)
                toolbarfont.Text = SelectionFontFamily.Source;

            if (!double.IsNaN(SelectionFontSize))
                toolbarfontsize.Text = SelectionFontSize.ToString();

            if (SelectionStrikethrough.HasValue)
                strikeBtn.IsSelected = SelectionStrikethrough.Value;

            if (SelectionBold.HasValue)
                boldBtn.IsSelected = SelectionBold.Value;

            if (SelectionItalic.HasValue)
                italicBtn.IsSelected = SelectionItalic.Value;

            if (SelectionUnderline.HasValue)
                underlineBtn.IsSelected = SelectionUnderline.Value;
        }

        #endregion

        //Initialization

        #region Initialization

       /// <summary>
       /// constructor Window1
       /// </summary>
        public Window1()
        {
            try
            {
                CreateMiniToolBar();
                
                InitializeComponent();
                this.DataContext = new ViewModel();
                toolBar.PlacementTarget = Editor;
                InitializeRibbonCommandManager();
                InitializeEditorCommands();
                CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommandExecute));
                CommandBindings.Add(new CommandBinding(EditingCommands.ToggleBold, null, ToggleBoldCanExecute));
                CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommandExecute));
                CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, CloseCommandExecute));
                InitializeFontSizeComboBox(format_fontSizeBox);
                InitializeFontComboBox(format_fontNameBox);
                Editor.SelectionChanged += new RoutedEventHandler(Editor_SelectionChanged);
                Editor.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(Editor_MouseUp);
                Editor.PreviewKeyUp += new KeyEventHandler(MyRibbon_PreviewKeyUp);
                paragraphs.Add(para1);
                paragraphs.Add(para3);
                paragraphs.Add(para5);
                paragraphs.Add(para6);
                paragraphs.Add(para7);
                paragraphs.Add(para8);
                paragraphs.Add(para9);
                paragraphs.Add(para10);
                paragraphs.Add(para11);
                paragraphs.Add(para12);


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
           
#if SyncfusionFramework4_0
            this.UseLayoutRounding = true;
#endif
        }

       
        /// <summary>
        /// Creates the mini tool bar.
        /// </summary>
        private void CreateMiniToolBar()
        {
            toolBar = new MiniToolbar();

            RibbonComboBox ribbonComboBox1 = new RibbonComboBox();
            RibbonComboBox ribbonComboBox2 = new RibbonComboBox();
            ribbonComboBox2.IsEditable = true;

            ribbonComboBox1.Width = 100;
            ribbonComboBox1.IsEditable = true;
            ribbonComboBox2.Width = 40;

            RibbonButton ribbonButton1 = new RibbonButton();
            RibbonButton ribbonButton2 = new RibbonButton();
            RibbonButton ribbonButton3 = new RibbonButton();
            RibbonButton ribbonButton4 = new RibbonButton();
            RibbonButton ribbonButton5 = new RibbonButton();
            RibbonButton ribbonButton6 = new RibbonButton();
            RibbonButton ribbonButton7 = new RibbonButton();
            RibbonButton ribbonButton8 = new RibbonButton();
            RibbonButton ribbonButton9 = new RibbonButton();
            RibbonButton ribbonButton10 = new RibbonButton();

            ribbonButton1.CommandBindings.Add(new CommandBinding(EditingCommands.IncreaseFontSize));
            ribbonButton2.CommandBindings.Add(new CommandBinding(EditingCommands.DecreaseFontSize));
            ribbonButton3.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleBold));
            ribbonButton4.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleItalic));
            ribbonButton5.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleUnderline));

            ribbonButton7.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleSubscript));
            ribbonButton8.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleSuperscript));

            ribbonButton1.Click += new RoutedEventHandler(OnIncreaseFontThrough);
            ribbonButton2.Click += new RoutedEventHandler(OnDecreaseFontThrough);
            ribbonButton6.Click += new RoutedEventHandler(OnStrikeThrough);
            ribbonButton3.Click += new RoutedEventHandler(OnBoldThrough);
            ribbonButton4.Click += new RoutedEventHandler(OnItalicThrough);
            ribbonButton5.Click += new RoutedEventHandler(OnUnderlineThrough);
            ribbonButton7.Click += new RoutedEventHandler(OnSubScriptThrough);
            ribbonButton8.Click += new RoutedEventHandler(OnSuperScriptThrough);

            ribbonButton1.SmallIcon = new BitmapImage(new Uri("/Resources/GrowFont16.png", UriKind.Relative));
            ribbonButton2.SmallIcon = new BitmapImage(new Uri("/Resources/ShrinkFont16.png", UriKind.Relative));
            ribbonButton3.SmallIcon = new BitmapImage(new Uri("/Resources/Bold16.png", UriKind.Relative));
            ribbonButton4.SmallIcon = new BitmapImage(new Uri("/Resources/Italic16.png", UriKind.Relative));
            ribbonButton5.SmallIcon = new BitmapImage(new Uri("/Resources/Underline16.png", UriKind.Relative));
            ribbonButton7.SmallIcon = new BitmapImage(new Uri("/Resources/Subscript16.png", UriKind.Relative));
            ribbonButton8.SmallIcon = new BitmapImage(new Uri("/Resources/Superscript16.png", UriKind.Relative));

            ribbonButton6.SmallIcon = new BitmapImage(new Uri("/Resources/Strike.png", UriKind.Relative));
            ribbonButton9.SmallIcon = new BitmapImage(new Uri("/Resources/FontColor.png", UriKind.Relative));
            ribbonButton10.SmallIcon = new BitmapImage(new Uri("/Resources/TextHighlight.png", UriKind.Relative));

            ribbonButton1.SizeForm = SizeForm.ExtraSmall;
            ribbonButton2.SizeForm = SizeForm.ExtraSmall;
            ribbonButton3.SizeForm = SizeForm.ExtraSmall;
            ribbonButton4.SizeForm = SizeForm.ExtraSmall;
            ribbonButton5.SizeForm = SizeForm.ExtraSmall;
            ribbonButton6.SizeForm = SizeForm.ExtraSmall;
            ribbonButton7.SizeForm = SizeForm.ExtraSmall;
            ribbonButton8.SizeForm = SizeForm.ExtraSmall;
            ribbonButton9.SizeForm = SizeForm.ExtraSmall;
            ribbonButton10.SizeForm = SizeForm.ExtraSmall;

            toolBar.Items.Add(ribbonComboBox1);
            toolBar.Items.Add(ribbonComboBox2);
            toolBar.Items.Add(ribbonButton1);
            toolBar.Items.Add(ribbonButton2);
            toolBar.Items.Add(ribbonButton3);
            toolBar.Items.Add(ribbonButton4);
            toolBar.Items.Add(ribbonButton5);
            toolBar.Items.Add(ribbonButton6);
            toolBar.Items.Add(ribbonButton7);
            toolBar.Items.Add(ribbonButton8);
            toolBar.Items.Add(ribbonButton9);
            toolBar.Items.Add(ribbonButton10);
        }

        #endregion


        #region Events
        /// <summary>
        /// override OnApplyTemplate
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            RibbonComboBox toolbarfont = (RibbonComboBox)toolBar.Items[0];
            InitializeFontComboBox(toolbarfont);
            RibbonComboBox toolbarfontsize = (RibbonComboBox)toolBar.Items[1];
            InitializeFontSizeComboBox(toolbarfontsize);
            (toolBar.Items[2] as RibbonButton).CommandTarget = Editor;
            (toolBar.Items[3] as RibbonButton).CommandTarget = Editor;
            (toolBar.Items[4] as RibbonButton).CommandTarget = Editor;
            (toolBar.Items[5] as RibbonButton).CommandTarget = Editor;
            (toolBar.Items[6] as RibbonButton).CommandTarget = Editor;
            (toolBar.Items[8] as RibbonButton).CommandTarget = Editor;
            (toolBar.Items[9] as RibbonButton).CommandTarget = Editor;
        }


        private void ribbonwindow_Loaded(object sender, RoutedEventArgs e)
        {
        
        }

        private void StrikeButton_Click(object sender, RoutedEventArgs e)
        {
            SelectionStrikethrough = !SelectionStrikethrough;
        }

        #endregion
        
        private void Return(object sender, RoutedEventArgs e)
        {
            MyRibbon.HideBackStage();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private RibbonButton button;


        private void OnLauncherClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Launcher button clicked");
        }
        
        private void ColorPickerPalette_MoreColorWindowOpening(object sender, MoreColorCancelEventArgs args)
        {
            highlighticon.IsDropDownOpen = false;
            fontcolor.IsDropDownOpen = false;
            format_btnShading.IsDropDownOpen = false;
        }

        List<Paragraph> paragraphs = new List<Paragraph>();
        private void RibbonGallery_SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ( gallery.SelectedItem== item1)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                   
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    SelectionFontSize = 14;
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.LineHeight = 20;
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                        paragraph.FontSize = 14;
                    }
                }
            }
            else if(gallery.SelectedItem == item2)
            {
                para1.LineHeight = 18;
            }
            else if(gallery.SelectedItem == item3)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionFontSize = 18;
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.FontSize = 18;
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
                    }
                }

            }
            else if (gallery.SelectedItem == item4)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionFontSize = 16;
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.FontSize = 16;
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
                    }
                }

            }
            else if (gallery.SelectedItem == item5)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionFontSize = 14;
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.FontSize = 14;
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
                    }
                }

            }
            else if (gallery.SelectedItem == item6)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionFontSize = 24;
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.FontSize = 24;
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                }

            }
            else if (gallery.SelectedItem == item7)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionFontSize = 14;
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.FontSize = 14;
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    }
                }

            }
            else if (gallery.SelectedItem == item10)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionForeground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    }
                }

            }
            else if (gallery.SelectedItem == item12)
            {
                if (Editor.Selection.Text != string.Empty)
                {
                    SelectionFontSize = 16;
                }
                else
                {
                    foreach (Paragraph paragraph in paragraphs)
                    {
                        paragraph.FontSize = 16;
                    }
                }

            }
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            SelectionFontSize = 14;
            foreach (Paragraph paragraph in paragraphs)
            {
                paragraph.LineHeight = 20;
                paragraph.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                paragraph.FontSize = 14;
            }
        }
    }
}