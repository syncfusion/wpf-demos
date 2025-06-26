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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.richtextboxdemos.wpf.Views
{
    /// <summary>
    /// Interaction logic for ReWriteDemo.xaml
    /// </summary>
    public partial class ReWriteDemo : ChromelessWindow
    {
        #region Fields
        internal SemanticKernelAI semanticKernelOpenAI;
        List<string> customerRequestOutputList = new List<string>();
        private int currentIndex = 0;
        private bool isGenerationInProgress = false;
        Theme currentTheme = null;
        #endregion

        #region property
        public string GeneratedContent { get; private set; }
        public string RTEContent { get; private set; }
        private SmartEditorDemo mainWindow { get; set; }
        #endregion

        #region Constructor
        public ReWriteDemo(SmartEditorDemo owner, Theme theme)
        {
            if (theme != null)
            {
                currentTheme = theme;
                SfSkinManager.SetTheme(this, theme);
                SfSkinManager.ApplyStylesOnApplication = true;
            }
            InitializeComponent();
            UpdateDocumentBackground();
            InitializeComboBoxItems();
            mainWindow = owner;
        }
        #endregion

        #region Dialog ComboBox

        /// <summary>
        /// Populates the specified ComboBox with the given list of items.
        /// </summary>
        /// <param name="comboBox">The ComboBox to populate.</param>
        /// <param name="items">The collection of items to set as the data source.</param>
        private void PopulateComboBox(ComboBox comboBox, IEnumerable<string> items)
        {
            if (comboBox == null) return;
            comboBox.ItemsSource = items;
        }

        /// <summary>
        /// Initializes and populates the ComboBoxes with predefined tone, format, and length options.
        /// </summary>
        private void InitializeComboBoxItems()
        {
            PopulateComboBox(toneComboBox, new[]
            {
             "Professional", "Friendly", "Instructional", "Marketing",
             "Academic", "Legal", "Technical", "Narrative", "Direct"
            });

            PopulateComboBox(formatComboBox, new[]
            {
             "Paragraph", "Blog post", "Technical Documentation",
             "Report", "Research Papers", "Tutorial", "Meeting Notes"
            });

            PopulateComboBox(lengthComboBox, new[]
            {
            "Medium", "Short", "Long"
            });
        }
        #endregion

        #region Dialog Button events
        /// <summary>
        /// Handles the Settings button click event by displaying the Settings panel 
        /// and hiding the Settings button and page panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Show Settings Panel and hide Settings Button.
            pagePanel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles the Close Settings button click event by hiding the Settings panel 
        /// and displaying the Settings button and page panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void CloseSettings_Click(object sender, RoutedEventArgs e)
        {
            // Hide Settings Panel and show Settings Button.
            pagePanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles the event to close the dialog window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void CloseDialog(object sender, RoutedEventArgs e)
        {
            // Close the dialog window.
            DialogResult = false;
            Close();
        }

        /// <summary>
        /// Handles the event to insert content by closing the dialog window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void InsertContent(object sender, RoutedEventArgs e)
        {
            // Close the dialog window.
            DialogResult = true;
            Close();
        }

        /// <summary>
        /// Handles the click event for rewriting content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void rewriteContent_Click(object sender, RoutedEventArgs e)
        {
            SmartWrite("rewrite");
        }

        /// <summary>
        /// Handles the click event for the Previous button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                UpdateIndexAndDisplayContent();
                UpdateButtonStates();
            }
        }

        /// <summary>
        /// Handles the click event for the next button.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < customerRequestOutputList.Count - 1)
            {
                currentIndex++;
                UpdateIndexAndDisplayContent();
                UpdateButtonStates();
            }
        }

        /// <summary>
        /// Update the states of the previous and next suggestion buttons.
        /// </summary>
        private void UpdateButtonStates()
        {
            // Enable the previous button only if not at the start
            previousButton.IsEnabled = currentIndex > 0;

            // Enable the next button only if not at the end
            nextButton.IsEnabled = currentIndex < customerRequestOutputList.Count - 1;
        }

        /// <summary>
        /// Enables or disables the generate and rewrite buttons based on the content.
        /// </summary>
        private void UpdateRewriteButtons(string currentParagraph)
        {
            if (!string.IsNullOrWhiteSpace(currentParagraph))
            {
                generateButton.IsEnabled = true;
                //rewriteContent.IsEnabled = true;
            }
            else
            {
                generateButton.IsEnabled = false;
                //rewriteContent.IsEnabled = false;
            }
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

        #region AI ReWrite Implementation
        /// <summary>
        /// Asynchronously generates or rewrites content based on the user's input.
        /// and updates the UI with the generated or rewritten content.
        /// </summary>
        /// <param name="writeAction">The action to perform, either "rewrite" or "generate".</param>
        private async void SmartWrite(string writeAction)
        {
            // Show the busy indicator
            busyIndicator.Visibility = Visibility.Visible;
            isGenerationInProgress = true;
            pagePanel.IsEnabled = false;
            generateButton.IsEnabled = false;
            // Disable editing in SfRichTextBoxAdv
            richTextBoxAdv.IsReadOnly = true;

            string userQuery = GetTextContent();
            string mergePrompt = string.Empty;
            string action = writeAction.ToLower();

            if (action == "rewrite")
            {
                mergePrompt = $"You are a helpful assistant. Your task is to analyze the text \"{userQuery}\" and rephrase it. " +
                              $"Please adjust the content to reflect a tone of '{toneComboBox.SelectedValue}', formatted in '{formatComboBox.SelectedValue}' style, " +
                              $"and maintain a length of '{lengthComboBox.SelectedValue}'. " +
                              $"Always respond in proper HTML format, including <html> and <body> tags.";
            }
            customerRequestOutputList.Clear();

            // Fetch responses
            for (int i = 0; i < 3; i++)
            {
                string contents = await semanticKernelOpenAI.GetAnswerFromGPT(mergePrompt);
                if (!customerRequestOutputList.Contains(contents))
                {
                    customerRequestOutputList.Add(contents);
                }
            }

            // Update UI with the first response
            if (customerRequestOutputList.Count > 0)
            {
                UpdateIndexAndDisplayContent();
            }

            // Enable editing in SfRichTextBoxAdv
            richTextBoxAdv.IsReadOnly = false;
            isGenerationInProgress = false;
            richTextBoxAdv.IsReadOnly = false;
            isGenerationInProgress = false;
            pagePanel.IsEnabled = true;
            generateButton.IsEnabled = true;
            pagePanel.Visibility = Visibility.Visible;
            // Hide the busy indicator
            busyIndicator.Visibility = Visibility.Collapsed;
            UpdateButtonStates();
        }

        /// <summary>
        /// Updates the displayed index and total content count, then shows the content for the current index.
        /// </summary>
        private void UpdateIndexAndDisplayContent()
        {
            totalContents.Text = customerRequestOutputList.Count.ToString();
            pageNum.Text = (currentIndex + 1).ToString();
            DisplayContent(currentIndex);
        }

        /// <summary>
        /// Displays the content in the SfRichTextBoxAdv.
        /// </summary>
        /// <param name="index">The index of the content to display.</param>
        private void DisplayContent(int index)
        {
            SfRichTextBoxAdv.NewDocumentCommand.Execute(null, richTextBoxAdv);
            GeneratedContent = customerRequestOutputList[index];
            LoadHTMLContent(GeneratedContent);
        }

        /// <summary>
        /// Loads the provided HTML content into the SfRichTextBoxAdv.
        /// </summary>
        /// <param name="htmlData">The HTML content to load into the SfRichTextBoxAdv.</param>
        private void LoadHTMLContent(string htmlData)
        {
            // Convert the HTML string to a byte array and load directly into the MemoryStream.
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(htmlData)))
            {
                // Load the HTML stream into the SfRichTextBoxAdv.
                richTextBoxAdv.Load(stream, FormatType.Html);
            }
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
            SmartWrite("rewrite");
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
            previousButton.Click -= PreviousButton_Click;
            nextButton.Click -= NextButton_Click;
            toneComboBox.ItemsSource = null;
            formatComboBox.ItemsSource = null;
            lengthComboBox.ItemsSource = null;
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
            if (customerRequestOutputList != null)
            {
                customerRequestOutputList.Clear();
                customerRequestOutputList = null;
            }
            semanticKernelOpenAI = null;
            currentTheme = null;
            if (busyIndicator != null)
            {
                busyIndicator.Dispose();
                busyIndicator = null;
            }
            mainWindow = null;
            base.OnClosing(e);
        }
        #endregion
    }
}
