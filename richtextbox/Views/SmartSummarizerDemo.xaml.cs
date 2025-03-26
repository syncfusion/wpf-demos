#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.richtextboxdemos.wpf.Helper;
using Syncfusion.UI.Xaml.Chat;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for AIAssitView.xaml
    /// </summary>
    public partial class SmartSummarizerDemo : RibbonWindow
    {
        #region Fields
        private readonly SmartSummarizerViewModel smartSummarizerviewModel;
        private readonly DocumentManager documentManager;
        #endregion

        #region Constructor
        public SmartSummarizerDemo()
        {
            InitializeComponent();
            documentManager = new DocumentManager();
            smartSummarizerviewModel = new SmartSummarizerViewModel(documentManager, Resources["AIICon"] as DataTemplate);
            DataContext = smartSummarizerviewModel;
            richTextBoxAdv.DocumentChanged += RichTextBoxAdv_DocumentChanged;
            richTextBoxAdv.Load(@"Assets\documenteditor\GettingStarted.docx");
            richTextBoxAdv.DocumentTitle = "Getting Started";
            richTextBoxAdv.RequestNavigate += RichTextBoxAdv_RequestNavigate;
            richTextBoxAdv.SelectionChanged += RichTextBoxAdv_SelectionChanged;
            this.Loaded += OnLoaded;
        }
        #endregion

        #region Events
        /// <summary>
        /// Called when [loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (richTextBoxAdv != null)
            {
                richTextBoxAdv.Selection.Select(richTextBoxAdv.Document.DocumentStart, richTextBoxAdv.Document.DocumentStart);
                richTextBoxAdv.Focus();
            }
            WindowTitleBarButton HelpButton = null;
            Syncfusion.Windows.Tools.Controls.TitleBar titleBar = VisualUtils.FindDescendant(sender as RibbonWindow, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            if (titleBar != null)
                HelpButton = titleBar.Template.FindName("HelpButton", titleBar) as WindowTitleBarButton;
            if (HelpButton != null)
            {
                HelpButton.Click += HelpButton_Click;
                HelpButton.ToolTip = "Help";
            }
        }
        /// <summary>
        /// Handles the RequestNavigate event of the richTextBoxAdv control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.RichTextBoxAdv.RequestNavigateEventArgs"/> instance containing the event data.</param>
        void RichTextBoxAdv_RequestNavigate(object obj, Syncfusion.Windows.Controls.RichTextBoxAdv.RequestNavigateEventArgs args)
        {
            if (args.Hyperlink.LinkType == Syncfusion.Windows.Controls.RichTextBoxAdv.HyperlinkType.Webpage || args.Hyperlink.LinkType == Syncfusion.Windows.Controls.RichTextBoxAdv.HyperlinkType.Email)
                LaunchUri(new Uri(args.Hyperlink.NavigationLink).AbsoluteUri);
            else if (args.Hyperlink.LinkType == HyperlinkType.File && File.Exists(args.Hyperlink.NavigationLink))
                LaunchUri(args.Hyperlink.NavigationLink);
        }
        /// <summary>
        /// Called on RichTextBoxAdv selection changes.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args">An <see cref="T:Syncfusion.Windows.Controls.RichTextBoxAdv.SelectionChangedEventArgs">SelectionChangedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void RichTextBoxAdv_SelectionChanged(object obj, Syncfusion.Windows.Controls.RichTextBoxAdv.SelectionChangedEventArgs args)
        {
            pagecountRun.RunText = richTextBoxAdv.PageCount.ToString();
            currentPageNumberRun.RunText = richTextBoxAdv.CurrentPageNumber.ToString();
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Launches the URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        private void LaunchUri(string navigationLink)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(navigationLink) { UseShellExecute = true };
            process.Start();
        }
        /// <summary>
        /// Launches the Help URI
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            LaunchUri(new Uri("http://help.syncfusion.com/wpf/sfrichtextboxadv/overview").AbsoluteUri);
        }

        /// <summary>
        /// Retrieves the text content from the SfRichTextBoxAdv as a string.
        /// </summary>
        /// <returns>The text content of the SfRichTextBoxAdv.</returns>
        private string GetTextContent()
        {
            if (richTextBoxAdv.Document == null) return string.Empty;

            using (var stream = new MemoryStream())
            {
                richTextBoxAdv.Save(stream, FormatType.Txt);
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        #endregion

        #region Smart Summarizer Implementation
        /// <summary>
        /// Handles the event when the content of the SfRichTextBoxAdv is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The event data containing information about the document change.</param>
        private async void RichTextBoxAdv_DocumentChanged(object sender, DocumentChangedEventArgs args)
        {
            if (AiAssistView.Visibility == Visibility.Visible)
            {
                documentManager.LoadText(GetTextContent());
                smartSummarizerviewModel.ClearChatAndSuggestion();
                await smartSummarizerviewModel.InitializeAiAssist();
            }
        }

        /// <summary>
        /// Toggles the visibility of the AI Assist View.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private async void ToggleAIAssistView_Click(object sender, RoutedEventArgs e)
        {
            if (AiAssistView.Visibility == Visibility.Visible)
            {
                AiAssistView.Visibility = Visibility.Collapsed;
                AIAssistColumn.Width = new GridLength(0);
            }
            else
            {
                AiAssistView.Visibility = Visibility.Visible;
                AIAssistColumn.Width = new GridLength(450);
                documentManager.LoadText(GetTextContent());
                await smartSummarizerviewModel.InitializeAiAssist();
            }
        }

        /// <summary>
        /// Handles the event when a suggestion is selected from the AI Assist view.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data containing the selected suggestion.</param>
        private async void AiAssistView_SuggestionSelected(object sender, SuggestionClickedEventArgs e)
        {
            string question = e.Item?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(question)) return;

            await smartSummarizerviewModel.HandleSuggestionSelected(question);
        }

        /// <summary>
        /// Handles the menu item click event for the AiAssistView.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data containing details about the menu item clicked.</param>
        private void AiAssistView_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            SmartSummarizerViewModel msgs = AiAssistView.DataContext as SmartSummarizerViewModel;
            msgs.chat_MenuItemClicked(e);
        }

        /// <summary>
        /// Handles the Loaded event of the SfRichTextBoxAdv.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void richTextBoxAdv_Loaded(object sender, RoutedEventArgs e)
        {
            // Ensure AI Creadentials are valid
            if (!AISettings.IsCredentialValid)
            {
                AISettings.ShowAISettingsWindow();
            }

            // Proceed only if credentials are valid
            if (AISettings.IsCredentialValid)
            {
                smartSummarizerviewModel.semanticKernelOpenAI = new SemanticKernelAI(AISettings.Key, AISettings.EndPoint, AISettings.ModelName);
                AIAssistBtn.IsEnabled = true;
            }
            else
            {
                smartSummarizerviewModel.semanticKernelOpenAI = null;
                AIAssistBtn.IsEnabled = false;
            }
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Raises the Closing event.
        /// </summary>
        /// <param name="e">CancelEventArgs that contains the event dat</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Loaded -= OnLoaded;
            if (richTextRibbon != null)
            {
                richTextRibbon.Dispose();
                richTextRibbon = null;
            }
            if (richTextBoxAdv != null)
            {
                richTextBoxAdv.SelectionChanged -= RichTextBoxAdv_SelectionChanged;
                richTextBoxAdv.RequestNavigate -= RichTextBoxAdv_RequestNavigate;
                richTextBoxAdv.DocumentChanged -= RichTextBoxAdv_DocumentChanged;
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
            if(AiAssistView!= null)
            {
                AiAssistView.SuggestionSelected -= AiAssistView_SuggestionSelected;
                AiAssistView.MenuItemClicked -= AiAssistView_MenuItemClicked;
                AiAssistView = null;
            }
            if(AIAssistBtn != null)
            {
                AIAssistBtn.Click -= ToggleAIAssistView_Click;
            }
            if (smartSummarizerviewModel != null)
            {
                smartSummarizerviewModel.Dispose();
            }
            WindowTitleBarButton HelpButton = null;
            Syncfusion.Windows.Tools.Controls.TitleBar titleBar = VisualUtils.FindDescendant(this as RibbonWindow, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            if (titleBar != null)
                HelpButton = titleBar.Template.FindName("HelpButton", titleBar) as WindowTitleBarButton;
            if (HelpButton != null)
                HelpButton.Click -= HelpButton_Click;

            base.OnClosing(e);
        }
        #endregion
    }
}