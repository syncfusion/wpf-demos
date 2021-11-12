#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace syncfusion.richtextboxdemos.wpf
{
    public sealed partial class ForumReplyControl : UserControl
    {
        #region Fields
        Window parentWindow = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the parent window.
        /// </summary>
        /// <value>
        /// The parent window.
        /// </value>
        private object ParentWindow
        {
            get
            {
                return parentWindow;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ForumReplyControl"/> class.
        /// </summary>
        /// <param name="parentWindow">The parent window.</param>
        public ForumReplyControl(Window parentWindow)
        {
            this.InitializeComponent();
            this.parentWindow = parentWindow;
#if NETCORE
            this.richTextBoxAdv.SpellChecker.CustomDictionaries = new ObservableCollection<string>() { @"Assets\richtextbox\CustomDictionary.dic" };
#else
            this.richTextBoxAdv.SpellChecker.CustomDictionaries = new ObservableCollection<string>() { @"Assets\richtextbox\CustomDictionary.dic" };
#endif
            this.Loaded += ForumReplyControl_Loaded;
#if !Framework3_5
            //Enables touch manipulation.
            this.richTextBoxAdv.IsManipulationEnabled = true;
#endif
            this.richTextBoxAdv.RequestNavigate += richTextBoxAdv_RequestNavigate;
        }
        #endregion

        #region Hyperlink navigation
        /// <summary>
        /// Handles the request navigate event of the richTextBoxAdv control.
        /// </summary>
        /// <param name="obj">The source of the event.</param>
        /// <param name="args">The <see cref="RequestNavigateEventArgs"/> instance containing the event data.</param>
        void richTextBoxAdv_RequestNavigate(object obj, RequestNavigateEventArgs args)
        {
            if (args.Hyperlink.LinkType == HyperlinkType.Webpage || args.Hyperlink.LinkType == HyperlinkType.Email)
            {
                Uri uri = new Uri(args.Hyperlink.NavigationLink);
                LaunchUri(uri);
            }
        }
        /// <summary>
        /// Launches the URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        void LaunchUri(Uri uri)
        {
#if NETCORE
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = "cmd",
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"/c start " + uri.AbsoluteUri
            };
            Process.Start(processStartInfo);
#else
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
#endif
        }
        #endregion

        #region Events
        /// <summary>
        /// Handles the loaded event of the ForumReplyControl.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void ForumReplyControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (richTextBoxAdv.Document != null && richTextBoxAdv.Document.CharacterFormat != null)
                richTextBoxAdv.Document.CharacterFormat.FontColor = Color.FromArgb(255, 153, 153, 153);
            richTextBoxAdv.Focus();
        }
        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (parentWindow is ForumDemo)
            {
                Stream stream = new MemoryStream();
                richTextBoxAdv.Save(stream, FormatType.Rtf);
                (parentWindow as ForumDemo).PostContent(stream, false, FormatType.Rtf);
                stream.Dispose();
            }
            ClearContent();
        }
        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearContent();
        }
        /// <summary>
        /// Clears the content.
        /// </summary>
        private void ClearContent()
        {
            SfRichTextBoxAdv.NewDocumentCommand.Execute(null, richTextBoxAdv);
            if (richTextBoxAdv.Document.CharacterFormat != null)
                richTextBoxAdv.Document.CharacterFormat.FontColor = Color.FromArgb(255, 153, 153, 153);
        }
        #endregion
        #region  Helper Methods
        /// <summary>
        /// Disposes the resources of ForumReplyControl.
        /// </summary>
        public void Dispose()
        {
            this.Loaded -= ForumReplyControl_Loaded;
            if (this.Content is Panel)
                (this.Content as Panel).Children.Clear();
            this.richTextBoxAdv.RequestNavigate -= richTextBoxAdv_RequestNavigate;
            //Disposes the SfRichTextBoxAdv contents explicitly.
            this.richTextBoxAdv.Dispose();
            this.richTextBoxAdv = null;
        }
        #endregion
    }
}
