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

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for AIWrite.xaml
    /// </summary>
    public partial class AIWriteDemo : ChromelessWindow
    {
        #region Fields
        List<string> customerRequestOutputList = new List<string>();
        private int currentIndex = 0;
        internal SemanticKernelAI semanticKernelOpenAI;
        private bool isGenerationInProgress = false;
        Theme currentTheme = null;
        #endregion

        #region Property
        public string GeneratedContent { get; private set; }
        public string RTEContent { get; private set; }
        #endregion

        #region Constructor
        public AIWriteDemo()
        {

        }

        public AIWriteDemo(Theme theme)
        {
            if(theme != null)
            {
                currentTheme = theme;
                SfSkinManager.SetTheme(this, theme);
                SfSkinManager.ApplyStylesOnApplication = true;
            }
            InitializeComponent();
            UpdateDocumentBackground();
            InitializeComboBoxItems();
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
        /// Initializes and populates the combo boxes with predefined items for tone, format, and length.
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
        /// Handles the click event for generating content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void GenerateContent_Click(object sender, RoutedEventArgs e)
        {
            SmartWrite("generate");
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
        /// Handles the click event for the Next button.
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
        /// Handles the click event for showing the Settings panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            // Show Settings Panel and hide Settings Button.
            pagePanel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles the click event for closing the Settings panel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void CloseSettings_Click(object sender, RoutedEventArgs e)
        {
            // Hide Settings Panel and show Settings Button.
            pagePanel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles the click event for closing the dialog.
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
        /// Handles the click event for inserting content.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the RoutedEventArgs.</param>
        private void InsertContent(object sender, RoutedEventArgs e)
        {
            // Close the dialog window.
            DialogResult = true;
            Close();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the content changed event for the SfRichTextBoxAdv.
        /// Enables or disables the generate and rewrite buttons based on the content.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="args">Event data for the ContentChangedEventArgs.</param>
        private void richTextBoxAdv_ContentChanged(object obj, ContentChangedEventArgs args)
        {
            bool hasContent = !string.IsNullOrEmpty(GetTextContent());

            generateButton.IsEnabled = hasContent;
            nextButton.IsEnabled = hasContent;
            previousButton.IsEnabled = hasContent;
        }

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
            }
        }
        #endregion

        #region AI Write Implementation
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
            insertButton.IsEnabled = false;

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
            else if (action == "generate")
            {
                mergePrompt = $"You are a helpful assistant. Your task is to generate content based on the text \"{userQuery}\". " +
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
            pagePanel.IsEnabled = true;
            pagePanel.Visibility = Visibility.Visible;
            generateButton.IsEnabled = true;
            insertButton.IsEnabled = true;
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
            if (richTextBoxAdv.Document == null)
            {
                return string.Empty;
            }

            using (var stream = new MemoryStream())
            {
                // Save the document as a text stream.
                richTextBoxAdv.Save(stream, FormatType.Txt);
                stream.Position = 0;

                // Read the stream to a string and return it.
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
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
            richTextBoxAdv.ContentChanged -= richTextBoxAdv_ContentChanged;
            previousButton.Click -= PreviousButton_Click;
            nextButton.Click -= NextButton_Click;
            generateButton.Click -= GenerateContent_Click;
            toneComboBox.ItemsSource = null;
            formatComboBox.ItemsSource = null;
            lengthComboBox.ItemsSource = null;
            if (richTextBoxAdv != null)
            {
                richTextBoxAdv.DocumentChanged -= richTextBoxAdv_DocumentChanged;
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
            if (customerRequestOutputList != null)
            {
                customerRequestOutputList.Clear();
            }
            semanticKernelOpenAI = null;
            currentTheme = null;
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
