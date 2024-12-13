#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Pdf.Interactive;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Windows.PdfViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows.Threading;

namespace syncfusion.pdfviewerdemos.wpf
{
    internal class SmartFillViewModel
    {
        #region Fields
        private SemanticKernelAI semanticKernelOpenAI;
        private Button aIAssistButton;
        private Stream m_documentStream;
        private SmartFill fillWindow;
        private ICommand loadedCommand;
        private DispatcherTimer toolTipTimer;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the path for the document.
        /// </summary>
        public Stream DocumentStream
        {
            get
            {
                return m_documentStream;
            }
            set
            {
                m_documentStream = value;
            }
        }

        /// <summary>
        /// Get or set the document loaded command.
        /// </summary>
        public ICommand LoadedCommand
        {
            get
            {
                if (loadedCommand == null)
                {
                    loadedCommand = new DelegateCommand<PdfViewerControl>(OnLoaded);
                }
                return loadedCommand;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartRedactionViewModel"/> class.
        /// </summary>
        public SmartFillViewModel()
        {
            m_documentStream = GetFileStream("form_document_new.pdf");
            // Initialize the timer for the tooltip of the button
            toolTipTimer = new DispatcherTimer();
            toolTipTimer.Interval = new TimeSpan(0, 0, 1);
            toolTipTimer.Tick += ToolTipTimer_Tick;
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Loaded event of the Smart Fill window
        /// </summary>
        /// <param name="sender">Smart fill window</param>
        /// <param name="e">Routed event arguments</param>
        public void Loaded(object sender, RoutedEventArgs e)
        {
            fillWindow = (sender as SmartFill).FindName("smartFill") as SmartFill;
            fillWindow.userData1.MouseEnter += new MouseEventHandler(Border_MouseEnter);
            fillWindow.userData1.MouseLeave += new MouseEventHandler(Border_MouseLeave);
            fillWindow.userData2.MouseEnter += new MouseEventHandler(Border_MouseEnter);
            fillWindow.userData2.MouseLeave += new MouseEventHandler(Border_MouseLeave);
            fillWindow.userData3.MouseEnter += new MouseEventHandler(Border_MouseEnter);
            fillWindow.userData3.MouseLeave += new MouseEventHandler(Border_MouseLeave);
            fillWindow.copyUserDataButton1.Click += new RoutedEventHandler(CopyButton_Click);
            fillWindow.copyUserDataButton2.Click += new RoutedEventHandler(CopyButton_Click);
            fillWindow.copyUserDataButton3.Click += new RoutedEventHandler(CopyButton_Click);
        }

        /// <summary>
        /// Tick event of the tool tip timer of the button
        /// </summary>
        /// <param name="sender">Tool tip timer</param>
        /// <param name="e">Event arguments</param>
        private void ToolTipTimer_Tick(object sender, EventArgs e)
        {
            //Stop the timer and close the tooltip of the button
            toolTipTimer.Stop();
            if (fillWindow.copyUserDataButton1.ToolTip != null)
            {
                (fillWindow.copyUserDataButton1.ToolTip as ToolTip).IsOpen = false;
                fillWindow.copyUserDataButton1.ToolTip = null;
            }
            else if (fillWindow.copyUserDataButton2.ToolTip != null)
            {
                (fillWindow.copyUserDataButton2.ToolTip as ToolTip).IsOpen = false;
                fillWindow.copyUserDataButton2.ToolTip = null;
            }
            else if (fillWindow.copyUserDataButton3.ToolTip != null)
            {
                (fillWindow.copyUserDataButton3.ToolTip as ToolTip).IsOpen = false;
                fillWindow.copyUserDataButton3.ToolTip = null;
            }
        }

        /// <summary>
        /// Closed event of the Smart Fill window
        /// </summary>
        /// <param name="sender">Smart fill window</param>
        /// <param name="e">Routed event arguments</param>
        public void Closed(object sender, RoutedEventArgs e)
        { 
            fillWindow.userData1.MouseEnter -= new MouseEventHandler(Border_MouseEnter);
            fillWindow.userData1.MouseLeave -= new MouseEventHandler(Border_MouseLeave);
            fillWindow.userData2.MouseEnter -= new MouseEventHandler(Border_MouseEnter);
            fillWindow.userData2.MouseLeave -= new MouseEventHandler(Border_MouseLeave);
            fillWindow.userData3.MouseEnter -= new MouseEventHandler(Border_MouseEnter);
            fillWindow.userData3.MouseLeave -= new MouseEventHandler(Border_MouseLeave);
            fillWindow.copyUserDataButton1.Click -= new RoutedEventHandler(CopyButton_Click);
            fillWindow.copyUserDataButton2.Click -= new RoutedEventHandler(CopyButton_Click);
            fillWindow.copyUserDataButton3.Click -= new RoutedEventHandler(CopyButton_Click);
        }
        /// <summary>
        /// Handle the loaded event of the pdfViewer
        /// </summary>
        /// <param name="sender">PdfViewer control</param>
        /// <param name="e">Event arguments</param>
        private void OnLoaded(PdfViewerControl pdfViewer)
        {
            // Get the text search stack panel from the toolbar of the PDF Viewer
            Syncfusion.Windows.PdfViewer.DocumentToolbar toolbar = (Syncfusion.Windows.PdfViewer.DocumentToolbar)pdfViewer.Template.FindName("PART_Toolbar", pdfViewer);
            // Collapse the open menu in the toolbar
            CollapseOpenMenu(toolbar);
            // Add the AI Assistance button to the toolbar
            AddAIAssistanceButton(toolbar);
            //Validate the AI credentials
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }
            //Initialize the Semantic Kernel AI
            if (AISettings.IsCredentialValid)
            {
                semanticKernelOpenAI = new SemanticKernelAI(AISettings.Key, AISettings.EndPoint, AISettings.ModelName);
            }
            else
            {
                semanticKernelOpenAI = null;
                string copiedText = Clipboard.GetText();
                // Enable the AI Assist button only if the copied text is the same as the user data text
                if (!string.IsNullOrEmpty(copiedText) && (copiedText == fillWindow.userDataText1.Text || copiedText == fillWindow.userDataText2.Text || copiedText == fillWindow.userDataText3.Text))
                {
                    aIAssistButton.IsEnabled = true;
                }
                else
                {
                    aIAssistButton.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Click event of the Smart Fill button
        /// </summary>
        /// <param name="sender">Smart Fill button</param>
        /// <param name="e">Event arguments</param>
        private async void smartFillButton_Click(object sender, RoutedEventArgs e)
        {
            //Display the loading indicator
            fillWindow.loadingCanvas.Visibility = Visibility.Visible;
            fillWindow.loadingIndicator.Visibility = Visibility.Visible;

            string result = string.Empty;
            if (semanticKernelOpenAI != null)
            {
                // Get the answer from GPT using the semantic kernel AI
                result = await GetDataFromAI();
            }
            if(string.IsNullOrEmpty(result))
            {
                // Get the XFDF data from the assets folder
                result = GetDataFromHelper(Clipboard.GetText());
            }
            //Import the data to the PDF Viewer
            ImportDataToPdfViewer(result);

            // Hide the loading indicator
            fillWindow.loadingCanvas.Visibility = Visibility.Collapsed;
            fillWindow.loadingIndicator.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Mouse enter event of the border
        /// </summary>
        /// <param name="sender">Text border</param>
        /// <param name="e">Mouse event arguments</param>
        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border border = sender as Border;
            //Display the copy button on mouse enter of the border
            if (border != null)
            {
                if (border.Name.Contains("1"))
                {
                    fillWindow.copyUserDataButton1.Visibility = Visibility.Visible;
                }
                else if (border.Name.Contains("2"))
                {
                    fillWindow.copyUserDataButton2.Visibility = Visibility.Visible;
                }
                else if (border.Name.Contains("3"))
                {
                    fillWindow.copyUserDataButton3.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Mouse leave event of the border
        /// </summary>
        /// <param name="sender">Text border</param>
        /// <param name="e">Mouse event arguments</param>
        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Border border = sender as Border;
            //Hide the copy button on mouse leave of the border
            if (border != null)
            {
                if (border.Name.Contains("1"))
                {
                    fillWindow.copyUserDataButton1.Visibility = Visibility.Collapsed;
                }
                else if (border.Name.Contains("2"))
                {
                    fillWindow.copyUserDataButton2.Visibility = Visibility.Collapsed;
                }
                else if (border.Name.Contains("3"))
                {
                    fillWindow.copyUserDataButton3.Visibility = Visibility.Collapsed;
                }
            }
        }

        /// <summary>
        /// Click event of the copy button
        /// </summary>
        /// <param name="sender">Copy button</param>
        /// <param name="e">Routed event arguments</param>
        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            aIAssistButton.IsEnabled = true;
            Button button = sender as Button;
            if (button != null)
            {
                //Add a tooltip to the button
                ToolTip toolTip = new ToolTip();
                toolTip.Content = "Text Copied";
                toolTip.PlacementTarget = button;
                button.ToolTip = toolTip;
                toolTip.IsOpen = true;
                toolTipTimer.Start();
                //Clear the clipboard and set the text to the clipboard
                Clipboard.Clear();
                if (button.Name.Contains("1"))
                {
                    Clipboard.SetText(fillWindow.userDataText1.Text);
                }
                else if (button.Name.Contains("2"))
                {
                    Clipboard.SetText(fillWindow.userDataText2.Text);
                }
                else if (button.Name.Contains("3"))
                {
                    Clipboard.SetText(fillWindow.userDataText3.Text);
                }
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Get the file stream from the assets folder.
        /// </summary>
        /// <param name="fileName">Name of the PDF</param>
        /// <returns>Returns the stream of the PDF</returns>
        private Stream GetFileStream(string fileName)
        {
            Uri uriResource = new Uri("/syncfusion.pdfviewerdemos.wpf;component/Assets/" + fileName, UriKind.Relative);
            StreamResourceInfo streamResourceInfo = Application.GetResourceStream(uriResource);
            return streamResourceInfo.Stream;
        }

        /// <summary>
        /// Exports the form details from the PDF Viewer in XFDF format.
        /// </summary>
        /// <returns>Returns the exported details from PdfViewer</returns>
        private string ExportFormDetails()
        {
            if (fillWindow.pdfviewer1.LoadedDocument != null && fillWindow.pdfviewer1.LoadedDocument.Form != null)
            {
                // Create a new memory stream and use it to export the form data
                MemoryStream stream = new MemoryStream();
                // Export form data in XFDF format to the stream
                fillWindow.pdfviewer1.LoadedDocument.Form.ExportEmptyFields = true;
                fillWindow.pdfviewer1.LoadedDocument.Form.ExportData(stream, Syncfusion.Pdf.Parsing.DataFormat.XFdf, fillWindow.pdfviewer1.DocumentInfo.FileName);
                if (stream != null)
                {
                    stream.Position = 0;
                    // Create a StreamReader to read from the stream
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }

            return "";
        }

        /// <summary>
        /// Provides the hint values for the form fields to the semantic kernel AI.
        /// </summary>
        /// <returns></returns>
        private string HintValuesforFields()
        {
            string hintData = null;
            if (fillWindow.pdfviewer1.LoadedDocument == null || fillWindow.pdfviewer1.LoadedDocument.Form == null || fillWindow.pdfviewer1.LoadedDocument.Form.Fields.Count <= 0)
            {
                return "";
            }
            // Iterate through each form field in the PDF viewer
            foreach (PdfField field in fillWindow.pdfviewer1.LoadedDocument.Form.Fields)
            {
                if (field is PdfLoadedComboBoxField)
                {
                    PdfLoadedComboBoxField combo = field as PdfLoadedComboBoxField;
                    // Append ComboBox name and items to the hintData string
                    hintData += "\n" + combo.Name + " : Collection of Items are :";
                    foreach (PdfLoadedListItem item in combo.Values)
                    {
                        hintData += item.Text + ", ";
                    }
                }
                else if (field is PdfLoadedRadioButtonListField)
                {
                    PdfLoadedRadioButtonListField radio = field as PdfLoadedRadioButtonListField;
                    // Append RadioButton name and items to the hintData string
                    hintData += "\n" + radio.Name + " : Collection of Items are :";
                    foreach (PdfLoadedRadioButtonItem item in radio.Items)
                    {
                        hintData += item.Value + ", ";
                    }
                }
                else if (field is PdfLoadedListBoxField)
                {
                    PdfLoadedListBoxField list = field as PdfLoadedListBoxField;
                    // Append ListBox name and items to the hintData string
                    hintData += "\n" + list.Name + " : Collection of Items are :";
                    foreach (PdfLoadedListItem item in list.Values)
                    {
                        hintData += item.Text + ", ";
                    }
                }
                else if (field.Name.Contains("Date") || field.Name.Contains("dob") || field.Name.Contains("date"))
                {
                    // Append instructions for date format to the hintData string
                    hintData += "\n" + field.Name + " : Write Date in MMM/dd/YYYY format";
                }

                // Append other form field names to the hintData string
            }
            // Return the hintData string if not null, otherwise return an empty string
            if (hintData != null)
            {
                return hintData;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Provide the data to be filled in the form fields when the AI fails to provide the data.
        /// </summary>
        /// <param name="text">Text copied in clipboard</param>
        /// <returns></returns>
        private string GetDataFromHelper(string text)
        {
            DataHelper dataHelper = new DataHelper();
            if (text == fillWindow.userDataText1.Text)
            {
                return dataHelper.UserDetail1;
            }
            else if (text == fillWindow.userDataText2.Text)
            {
                return dataHelper.UserDetail2;
            }
            else if (text == fillWindow.userDataText3.Text)
            {
                return dataHelper.UserDetail3;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Collapse the open menu in the toolbar.
        /// </summary>
        /// <param name="toolbar">Toolbar of the PdfViewer</param>
        private void CollapseOpenMenu(Syncfusion.Windows.PdfViewer.DocumentToolbar toolbar)
        {
            //Get the instance of the file menu button using its template name.
            ToggleButton FileButton = (ToggleButton)toolbar.Template.FindName("PART_FileToggleButton", toolbar);
            //Get the instance of the file menu button context menu and the item collection.
            ContextMenu FileContextMenu = FileButton.ContextMenu;
            foreach (MenuItem FileMenuItem in FileContextMenu.Items)
            {
                //Get the instance of the open menu item using its template name and disable its visibility.
                if (FileMenuItem.Name == "PART_OpenMenuItem")
                    FileMenuItem.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Add the AI Assistance button to the toolbar.
        /// </summary>
        /// <param name="toolbar">Toolbar of the PdfViewer</param>
        private void AddAIAssistanceButton(Syncfusion.Windows.PdfViewer.DocumentToolbar toolbar)
        {
            // Get the text search stack panel and annotation button from the toolbar
            StackPanel textSeacrchStack = (StackPanel)toolbar.Template.FindName("PART_TextSearchStack", toolbar);
            Button textSearchButton = (Button)toolbar.Template.FindName("PART_ButtonTextSearch", toolbar);
            //Create a new toggle button for AI Assist
            aIAssistButton = new Button();
            TextBlock aIAssistText = new TextBlock();
            aIAssistText.Text = "Smart Fill";
            aIAssistText.FontSize = 14;
            aIAssistButton.Content = aIAssistText;
            aIAssistButton.Click += smartFillButton_Click;
            aIAssistButton.Margin = new Thickness(0, 0, 8, 0);
            aIAssistButton.Padding = new Thickness(3);
            aIAssistButton.VerticalAlignment = VerticalAlignment.Center;
            // Set the style of the AI Assist button
            aIAssistButton.SetResourceReference(Button.StyleProperty, "WPFPrimaryButtonStyle");
            aIAssistText.SetResourceReference(Button.ForegroundProperty, "PrimaryForeground");
            if (textSearchButton != null)
            {
                fillWindow.copyUserDataButton1.Style = textSearchButton.Style;
                fillWindow.copyUserDataButton2.Style = textSearchButton.Style;
                fillWindow.copyUserDataButton3.Style = textSearchButton.Style;
            }
            // Add AI Assist button to the text search stack of the toolbar
            if (textSeacrchStack.Children != null && textSeacrchStack.Children.Count > 0)
            {
                textSeacrchStack.Children.Insert(0, aIAssistButton);
            }
            else
            {
                textSeacrchStack.Children.Add(aIAssistButton);
            }

            // Apply the color to the buttons in the toolbar
            ApplyColorToButtons(textSearchButton.Foreground, toolbar);
            AddIconForCopyButton(textSearchButton.Foreground);
        }

        #region PathHelper Methods
        /// <summary>
        /// Add the icon for the copy button.
        /// </summary>
        /// <param name="foreground">foreground color</param>
        private void AddIconForCopyButton(System.Windows.Media.Brush foreground)
        {
            string skinManagerStyle = Syncfusion.Windows.Shared.SfSkinManagerExtension.GetBaseThemeName(fillWindow);
            if (!string.IsNullOrEmpty(skinManagerStyle))
            {
                //Iterate to a maximum of 3 as we have 3 copy buttons.
                for (int buttonIndex = 0; buttonIndex < 3; buttonIndex++)
                {
                    //Create a new path for the copy button based on the skin manager style
                    System.Windows.Shapes.Path iconPath = new System.Windows.Shapes.Path();
                    string pathData = string.Empty;
                    if (skinManagerStyle.ToString().ToLower().Contains("windows11") || skinManagerStyle.ToString().ToLower().Contains("fluent"))
                    {
                        pathData = "M4 1H10C10.5523 1 11 1.44772 11 2V12C11 12.5523 10.5523 13 10 13H4C3.44772 13 3 12.5523 3 12V2C3 1.44772 3.44772 1 4 1ZM2 2C2 0.89543 2.89543 0 4 0H10C11.1046 0 12 0.895431 12 2V12C12 13.1046 11.1046 14 10 14H4C2.89543 14 2 13.1046 2 12V2ZM4 15H8H9.73244C9.38663 15.5978 8.74028 16 8 16H3.5C1.567 16 0 14.433 0 12.5V4C0 3.25972 0.402199 2.61337 1 2.26756V4V12V12.5C1 13.8807 2.11929 15 3.5 15H4Z";
                        iconPath.Width = 12;
                        iconPath.Height = 16;
                    }
                    else if (skinManagerStyle.ToString().ToLower().Contains("material3"))
                    {
                        pathData = "M2.33334 0.833332H11.5V2.5H2.33334L2.33334 14.1667H0.666672V2.5C0.666672 1.57952 1.41286 0.833332 2.33334 0.833332ZM5.66667 5.83333H14.8333V17.5H5.66667V5.83333ZM4 5.83333C4 4.91286 4.74619 4.16667 5.66667 4.16667H14.8333C15.7538 4.16667 16.5 4.91286 16.5 5.83333V17.5C16.5 18.4205 15.7538 19.1667 14.8333 19.1667H5.66667C4.74619 19.1667 4 18.4205 4 17.5V5.83333Z";
                        iconPath.Width = 17;
                        iconPath.Height = 20;
                    }
                    else if (skinManagerStyle.ToString().ToLower().Contains("material"))
                    {
                        pathData = "M11.5 0.833332H11.5V4.16667H14.8333H16.5V5.83333V17.5V19.1667H14.8333H5.66667H4V17.5V5.83333V4.16667H5.66667H11.5V2.5H2.33332V14.1667H0.666656V2.5V0.833332H2.33332H11.5ZM11.5 5.83333H5.66667V17.5H14.8333V5.83333H11.5V14.1667L11.5 14.1667V5.83333Z";
                        iconPath.Width = 17;
                        iconPath.Height = 20;
                    }
                    else
                    {
                        pathData = "M0.5 0H0V0.5V12.5V13H0.5H4V15.5V16H4.5H13.5H14V15.5V6.5V6.29289L13.8536 6.14645L10.8536 3.14645L10.7071 3H10.5H9.70711L6.85355 0.146447L6.70711 0H6.5H0.5ZM4 3.5V12H1V1H6.29289L8.29289 3H4.5H4V3.5ZM5 12.5V4H9.5H10V6.5V7H10.5H13V15H5V12.5ZM12.2929 6L11 4.70711V6H12.2929Z";
                        iconPath.Width = 14;
                        iconPath.Height = 16;
                    }

                    iconPath.Data = PathMarkupToGeometry(pathData);
                    iconPath.Fill = foreground;
                    //Add the path to the copy button based on the index
                    if (buttonIndex == 0)
                    {
                        fillWindow.copyUserDataButton1.Content = iconPath;
                    }
                    else if (buttonIndex == 1)
                    {
                        fillWindow.copyUserDataButton2.Content = iconPath;
                    }
                    else
                    {
                        fillWindow.copyUserDataButton3.Content = iconPath;
                    }
                }
            }
        }

        internal Geometry PathMarkupToGeometry(string pathMarkup)
        {
            string xaml =
            "<Path " +
            "xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>" +
            "<Path.Data>" + pathMarkup + "</Path.Data></Path>";
            var path = System.Windows.Markup.XamlReader.Load(GenerateStreamFromString(xaml)) as System.Windows.Shapes.Path;
            // Detach the PathGeometry from the Path
            Geometry geometry = path.Data;
            path.Data = null;
            return geometry;
        }

        internal static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
        #endregion

        /// <summary>
        /// Method to find the visual child of the parent element.
        /// </summary>
        /// <typeparam name="T">Type of the child</typeparam>
        /// <param name="parent">Parent element</param>
        /// <returns>Returns the specified type of child</returns>
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null && VisualTreeHelper.GetChildrenCount(parent) > 0)
            {
                // Traverse the visual tree to find the first child of the specified type
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    // Check if the child is of the specified type
                    if (child is T tChild)
                    {
                        return tChild;
                    }

                    // Recursively search the child elements
                    var result = FindVisualChild<T>(child);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Apply the color to the buttons in the toolbar.
        /// </summary>
        /// <param name="foregroundBrush">Fore ground color</param>
        private void ApplyColorToButtons(System.Windows.Media.Brush foregroundBrush, Syncfusion.Windows.PdfViewer.DocumentToolbar toolbar)
        {
            // Retrieve the root element of the template
            var rootElement = VisualTreeHelper.GetChild(toolbar, 0) as FrameworkElement;
            System.Windows.Media.Brush background = System.Windows.Media.Brushes.Transparent;
            if (rootElement != null)
            {
                // Traverse the visual tree to find the first Border
                var border = FindVisualChild<Border>(rootElement);
                if (border != null && border.Name != "Part_AnnotationToolbar")
                {
                    background = border.Background;
                    fillWindow.aI_Title.BorderBrush = border.BorderBrush;
                    fillWindow.aI_Title.BorderThickness = border.BorderThickness;
                    fillWindow.separator.Background = border.BorderBrush;
                    fillWindow.userData1.BorderBrush = border.BorderBrush;
                    fillWindow.userData2.BorderBrush = border.BorderBrush;
                    fillWindow.userData3.BorderBrush = border.BorderBrush;
                }
            }

            //Set the background and foreground for the buttons
            fillWindow.aI_Title.Background = background;
            fillWindow.aI_Title.Foreground = foregroundBrush;
        }

        /// <summary>
        /// Import the data to the PDF Viewer.
        /// </summary>
        /// <param name="resultData">Result from the AI</param>
        private async void ImportDataToPdfViewer(string resultData)
        {
            var inputFileStream = new MemoryStream();
            // Write the merged XFDF content to the MemoryStream
            var writer = new StreamWriter(inputFileStream);
            await writer.WriteAsync(resultData);
            await writer.FlushAsync();
            inputFileStream.Position = 0;
            // Import the data to the PDF Viewer from the MemoryStream
            byte[] formData = new byte[inputFileStream.Length];
            inputFileStream.Read(formData, 0, formData.Length);
            fillWindow.pdfviewer1.ImportFormData(formData, Syncfusion.Pdf.Parsing.DataFormat.XFdf);
        }
        #endregion

        #region OpenAI
        /// <summary>
        /// Method to get the answer from GPT using the semantic kernel AI
        /// </summary>
        /// <returns>Returns the data to be imported in pdfViewer</returns>
        private async Task<string> GetDataFromAI()
        {
            string result = string.Empty;
            // Get the selected user details from the combo box
            string copiedDetails = Clipboard.GetText();
            if (!string.IsNullOrEmpty(copiedDetails))
            {
                // Get the XFDF file content from the PDF Viewer
                string loadedFileDetails = ExportFormDetails();
                // Get the hint values for the form fields
                string CustomValues = HintValuesforFields();
                // Create a prompt message for the semantic kernel AI
                string mergePrompt = $"Merge the input data into the XFDF file content. Hint text: {CustomValues}. " +
                                $"Ensure the input data matches suitable field names. " +
                                $"Here are the details: " +
                                $"input data: {copiedDetails}, " +
                                $"XFDF information: {loadedFileDetails}. " +
                                $"Provide the resultant XFDF directly. " +
                                $"Some conditions need to follow: " +
                                $"1. input data is not directly provided as the field name; you need to think and merge appropriately. " +
                                $"2. When comparing input data and field names, ignore case sensitivity. " +
                                $"3. First, determine the best match for the field name. If there isn’t an exact match, use the input data to find a close match. " +
                                $"remove ```xml and remove ``` if it is there in the code.";
                // Get the answer from GPT using the semantic kernel AI
                result = await semanticKernelOpenAI.GetAnswerFromGPT(mergePrompt);
            }

            return result;
        }
        #endregion
    }
}
