#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.richtextboxdemos.wpf.Helper;
using Syncfusion.SfSkinManager;
using Syncfusion.Themes.Material3Dark.WPF;
using Syncfusion.Themes.Material3Light.WPF;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for Grammar.xaml
    /// </summary>
    public partial class GrammarDemo : ChromelessWindow
    {
        #region Field
        internal SemanticKernelAI semanticKernelOpenAI;
        private SmartEditorDemo mainWindow;
        ObservableCollection<object> selectedItems = null;
        private bool isGenerationInProgress = false;
        Theme currentTheme = null;
        public string GeneratedContent { get; private set; }
        #endregion

        #region Constructor
        public GrammarDemo(SmartEditorDemo owner, Theme theme)
        {
            InitializeComponent();
            if (theme != null)
            {
                currentTheme = theme;
                SfSkinManager.SetTheme(this, theme);
                SfSkinManager.ApplyStylesOnApplication = true;
            }
            UpdateDocumentBackground();
            InitializeComboBoxItems();
            mainWindow = owner;
            selectedItems = new ObservableCollection<object>();
        }
        #endregion

        #region SfRichTextBoxAdv
        /// <summary>
        /// Handles the event when the document inside the SfRichTextBoxAdv changes.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="args">The event arguments, containing details about the document change.</param>
        private void richTextBoxAdv_DocumentChanged(object obj, DocumentChangedEventArgs args)
        {
            UpdateDocumentBackground();
        }

        /// <summary>
        /// Updates the background color of the document in the SfRichTextBoxAdv controls
        /// </summary>
        private void UpdateDocumentBackground()
        {
            SolidColorBrush colorResource = null;
            if (currentTheme != null && (currentTheme.ThemeName == "Material3Light" || currentTheme.ThemeName == "Material3Dark"))
            {
                ThemeKey themeKey = new ThemeKey
                {
                    Theme = currentTheme.ThemeName == "Material3Light" ? typeof(Material3LightSkinHelper) : typeof(Material3DarkSkinHelper),
                    Key = "ContentBackground"
                };
                colorResource = TryFindResource(themeKey) as SolidColorBrush;
            }
            else
            {
                colorResource = FindResource("ContentBackground") as SolidColorBrush;
            }

            if (colorResource != null)
            {
                richTextBoxAdv.Document.Background.Color = colorResource.Color;
                showParagraphRTE.Document.Background.Color = colorResource.Color;
            }
        }
        #endregion

        #region Dialog ComboBox
        /// <summary>
        /// Initializes the items for the grammarComboBox with a predefined list of grammar-related topics.
        /// </summary>
        /// <remarks>
        /// This method sets the ItemsSource of the grammarComboBox to a collection of common grammar issues.
        /// </remarks>
        private void InitializeComboBoxItems()
        {
            if (grammarComboBox != null)
            {
                grammarComboBox.ItemsSource = new string[]
                {
                    "Subject-Verb Agreement",
                    "Tense Consistency",
                    "Pronoun Agreement",
                    "Comma Usage",
                    "Parallel Structure",
                    "Misplaced Modifiers",
                    "Dangling Modifiers",
                    "Word Choice",
                    "Redundancy",
                    "Use of Articles",
                    "Punctuation Marks",
                    "Apostrophes for Possessives and Contractions",
                    "Spelling Errors"
                };
            }
        }
        /// <summary>
        /// Handles the DropDownClosed event for the grammarComboBox.
        /// </summary>
        /// <param name="sender">The source of the event, the grammarComboBox.</param>
        /// <param name="e">Event data for the DropDownClosed event.</param>
        private void grammarComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (grammarComboBox != null && grammarComboBox.SelectedItem != null)
            {
                foreach (var item in grammarComboBox.SelectedItems)
                {
                    selectedItems.Add(item);
                }
            }
        }
        #endregion

        #region Dialog Button Events
        /// <summary>
        /// Enables or disables the grammar button based on the content.
        /// </summary>
        private void UpdateGrammarButton(string currentParagraph)
        {
            if (!string.IsNullOrWhiteSpace(currentParagraph))
            {
                rewriteButton.IsEnabled = true;
            }
            else
            {
                rewriteButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the event to insert content by closing the dialog window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void InsertContent(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Handles the event to close the dialog window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
        #endregion

        #region AI Grammar Implementation
        /// <summary>
        /// Handles the click event for the "Rewrite" button. It sends the user's selected grammar checks and the provided text
        /// to the GPT-based assistant for processing and rewriting, then loads the revised content back into the SfRichTextBoxAdv.
        /// </summary>
        /// <param name="sender">The source of the event, the Rewrite button.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void Rewrite_Click(object sender, RoutedEventArgs e)
        {
            OnGrammerCheck();
        }

        /// <summary>
        /// Retrieves the text content from the SfRichTextBoxAdv as a string.
        /// </summary>
        /// <returns>The text content of the SfRichTextBoxAdv.</returns>
        private string GetTextContent()
        {
            string rteText = string.Empty;
            if (showParagraphRTE.Document != null)
            {
                using (Stream stream = new MemoryStream())
                {
                    // Saves the document as text Stream.
                    showParagraphRTE.Save(stream, FormatType.Txt);
                    stream.Position = 0;

                    // Reads the stream and assigns the string to the rteText variable
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        rteText = reader.ReadToEnd();
                    }
                }
            }
            return rteText;
        }

        /// <summary>
        /// Sets the text content with the provided text.
        /// </summary>
        /// <param name="text">The text to be inserted into the SfRichTextBoxAdv.</param>
        public void SetRichTextContent(string text)
        {
            InsertText(text);
            OnGrammerCheck();
        }

        /// <summary>
        /// Inserts the specified text at the current selection in the editor.
        /// </summary>
        /// <param name="text">The text to be inserted into the rich text editor.</param>
        private void InsertText(string text)
        {
            SfRichTextBoxAdv.NewDocumentCommand.Execute(null, showParagraphRTE);
            showParagraphRTE.Selection.InsertText(text);
        }

        private async void OnGrammerCheck()
        {
            // Show the busy indicator
            busyIndicator.Visibility = Visibility.Visible;
            isGenerationInProgress = true;
            grammarComboBox.IsEnabled = false;
            rewriteButton.IsEnabled = false;

            // Disable editing in SfRichTextBoxAdv
            richTextBoxAdv.IsReadOnly = true;

            string userQuery = GetTextContent();
            string mergePrompt = null;

            if (selectedItems != null && selectedItems.Count > 0)
            {
                string grammarOptions = string.Empty;

                // Construct grammar options string
                foreach (string item in selectedItems)
                {
                    grammarOptions += item + ",";
                }

                // Remove the trailing comma
                if (grammarOptions.EndsWith(","))
                {
                    grammarOptions = grammarOptions.Substring(0, grammarOptions.Length - 1);
                }

                mergePrompt = $"You are a helpful assistant. Your task is to analyze the text \"{userQuery}\" " +
                              $"and perform the following grammar checks: '{grammarOptions}'. Please ensure that the revised text reflects these corrections. " +
                              "Always respond in proper HTML format, including <html> and <body> tags.";
            }
            else
            {
                mergePrompt = $"You are a helpful assistant. Your task is to analyze the text \"{userQuery}\", check for and correct any grammatical errors, and rephrase it. " +
                              "Always respond in proper HTML format, including <html> and <body> tags.";
            }

            GeneratedContent = await semanticKernelOpenAI.GetAnswerFromGPT(mergePrompt);

            // Load the HTML content into SfRichTextBoxAdv
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(GeneratedContent)))
            {
                richTextBoxAdv.Load(stream, FormatType.Html);
            }

            // Re-enable editing in SfRichTextBoxAdv
            richTextBoxAdv.IsReadOnly = false;
            isGenerationInProgress = false;
            grammarComboBox.IsEnabled = true;
            rewriteButton.IsEnabled = true;

            // Hide the busy indicator
            busyIndicator.Visibility = Visibility.Collapsed;
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Handles cleanup when the window is closing.
        /// Unsubscribes from event handlers, clears ComboBox data sources, and disposes of resources.
        /// </summary>
        /// <param name="e">The event data for the closing event.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (isGenerationInProgress)
            {
                e.Cancel = true;
                return;
            }
            grammarComboBox.DropDownClosed -= grammarComboBox_DropDownClosed;
            if (grammarComboBox != null)
            {
                grammarComboBox.ItemsSource = null;
            }
            if (richTextBoxAdv != null)
            {
                richTextBoxAdv.DocumentChanged -= richTextBoxAdv_DocumentChanged;
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
            if (showParagraphRTE != null)
            {
                showParagraphRTE.DocumentChanged -= richTextBoxAdv_DocumentChanged;
                showParagraphRTE.Dispose();
                showParagraphRTE = null;
            }
            if (selectedItems != null)
            {
                selectedItems.Clear();
                selectedItems = null;
            }
            semanticKernelOpenAI = null;
            currentTheme = null;
            mainWindow = null;
            if (busyIndicator != null)
            {
                busyIndicator.Visibility = Visibility.Collapsed;
                busyIndicator = null;
            }
            base.OnClosing(e);
        }
        #endregion
    }
}