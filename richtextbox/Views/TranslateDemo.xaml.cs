#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.richtextboxdemos.wpf.Helper;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Shared;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for TranslateDemo.xaml
    /// </summary>
    public partial class TranslateDemo : ChromelessWindow
    {
        #region Field
        internal SemanticKernelAI semanticKernelOpenAI;
        public string GeneratedContent { get; private set; }
        private SmartEditorDemo mainWindow;
        private bool isGenerationInProgress = false;
        #endregion

        #region Constructor
        public TranslateDemo(SmartEditorDemo owner, Theme theme)
        {
            InitializeComponent();
            if (theme != null)
            {
                SfSkinManager.SetTheme(this, theme);
                SfSkinManager.ApplyStylesOnApplication = true;
            }
            InitializeComponent();
           UpdateDocumentBackground();
            InitializeComboBoxItems();
            mainWindow = owner;
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
            SolidColorBrush colorResource = FindResource("ContentBackground") as SolidColorBrush;
            if (colorResource != null)
            {
                richTextBoxAdv.Document.Background.Color = colorResource.Color;
                showParagraphRTE.Document.Background.Color = colorResource.Color;
            }
        }
        #endregion

        #region Dialog ComboBox
        /// <summary>
        /// Initializes the items for the translation language ComboBox to a predefined list of language options.
        /// </summary>
        private void InitializeComboBoxItems()
        {
            if (translateComboBox != null)
            {
                translateComboBox.ItemsSource = new string[]
                {
            "English",
            "Simplified Chinese",
            "Spanish",
            "French",
            "Arabic",
            "Portuguese",
            "Russian",
            "Urdu",
            "Indonesian",
            "German",
            "Japanese"
                };
            }
        }
        #endregion

        #region Dialog Button events
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

        #region AI Translate Implementation
        /// <summary>
        /// Handles the translation of the text in the SfRichTextBoxAdv when the Translate button is clicked.
        /// </summary>
        private async void Translate_Click(object sender, RoutedEventArgs e)
        {
            busyIndicator.Visibility = Visibility.Visible;
            isGenerationInProgress = true;
            translateComboBox.IsEnabled = false;
            translateButton.IsEnabled = false;
            richTextBoxAdv.IsReadOnly = true;
            string userQuery = GetTextContent();

            // Create a prompt message for the AI model that clearly states the task: translating the text to the target language
            string mergePrompt = $"You are a helpful assistant. Your task is to translate the text \"{userQuery}\" into {translateComboBox.SelectedValue.ToString()} language. " +
                                 $"Always respond in proper HTML format, including <html>, <head>, and <body> tags. " +
                                 $"Return only the translated text inside the <body> tag without any additional explanations or extra content.";

            // Asynchronously call the AI service to generate translated content based on the prompt
            GeneratedContent = await semanticKernelOpenAI.GetAnswerFromGPT(mergePrompt);

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(GeneratedContent)))
            {
                // Load the HTML stream into the RichTextBox, setting its format to HTML
                richTextBoxAdv.Load(stream, FormatType.Html);
            }
            richTextBoxAdv.IsReadOnly = false;
            isGenerationInProgress = false;
            translateComboBox.IsEnabled = true;
            translateButton.IsEnabled = true;
            busyIndicator.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Sets the text content with the provided text.
        /// </summary>
        /// <param name="text">The text to be inserted into the SfRichTextBoxAdv.</param>
        public void SetRichTextContent(string text)
        {
            InsertText(text);
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
            translateComboBox.ItemsSource = null;
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
            semanticKernelOpenAI = null;
            mainWindow = null;
            base.OnClosing(e);
        }
        #endregion
    }
}
