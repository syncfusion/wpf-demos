#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.ComponentModel;

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for ForumDemo.xaml
    /// </summary>
    public partial class ForumDemo : ChromelessWindow
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ForumDemo"/> class.
        /// </summary>
        public ForumDemo()
        {
            InitializeComponent();
            InitForumContent();
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
            Button minimizeButton = GetTemplateChild("Window_MinimizeButton") as Button;
            if (minimizeButton != null)
                minimizeButton.Click += WindowMinimizeButton_Click;
            Button closeButton = GetTemplateChild("Window_CloseButton") as Button;
            if (closeButton != null)
                closeButton.Click += WindowCloseButton_Click;
            System.Windows.Controls.Border titleBar = GetTemplateChild("Window_TitleBar") as System.Windows.Controls.Border;
            if (titleBar != null)
                titleBar.MouseLeftButtonDown += WindowHeader_MouseLeftButtonDown;
        }
        /// <summary>
        /// Handles the Click event of the window minimize button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WindowMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// Handles the Click event of the window close button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void WindowCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Handles the mouse left button down event of the window header control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void WindowHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
       
        /// <summary>
        /// Raises the Closing event.
        /// </summary>
        /// <param name="e">CancelEventArgs that contains the event dat</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Loaded -= OnLoaded;
            listView.Items.Clear();
            Button minimizeButton = GetTemplateChild("Window_MinimizeButton") as Button;
            if (minimizeButton != null)
                minimizeButton.Click -= WindowMinimizeButton_Click;
            Button closeButton = GetTemplateChild("Window_CloseButton") as Button;
            if (closeButton != null)
                closeButton.Click -= WindowCloseButton_Click;
            System.Windows.Controls.Border titleBar = GetTemplateChild("Window_TitleBar") as System.Windows.Controls.Border;
            if (titleBar != null)
                titleBar.MouseLeftButtonDown -= WindowHeader_MouseLeftButtonDown;

            base.OnClosing(e);
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Clears the items from the ListView
        /// </summary>
        void ClearListViewItems()
        {
            if (listView == null || listView.Items == null || listView.Items.Count == 0)
                return;
            for (int i = 0; i < listView.Items.Count; i++)
            {
                object item = listView.Items[i];
                listView.Items.Remove(item);
                i--;
                if (item is ForumPostControl)
                    (item as ForumPostControl).Dispose();
                else if (item is ForumReplyControl)
                    (item as ForumReplyControl).Dispose();
            }
        }
        /// <summary>
        /// Initializes the content of the forum.
        /// </summary>
        private void InitForumContent()
        {
            AddReplyControl();
            //Sets title to the current forum thread.
            titleTextBlock.Text = "How to add SfRichTextBoxAdv into the WPF application?";
            Assembly assembly = typeof(ForumDemo).Assembly;
            //Loads the initial query from a RTF file.
            Stream stream = assembly.GetManifestResourceStream("syncfusion.richtextboxdemos.wpf.Assets.richtextbox.InitialQuery.docx");
            PostContent(stream, true, FormatType.Docx);
            stream.Dispose();
            //Loads the reply for initial query from a RTF file.
            stream = assembly.GetManifestResourceStream("syncfusion.richtextboxdemos.wpf.Assets.richtextbox.ReplyContent.docx");
            PostContent(stream, false, FormatType.Docx);
            stream.Dispose();
            listView.ScrollIntoView(listView.Items[0]);
        }
        /// <summary>
        /// Adds the forum reply control.
        /// </summary>
        private void AddReplyControl()
        {
            ForumReplyControl replyControl = new ForumReplyControl(this);
            ClearListViewItems();
            listView.Items.Add(replyControl);
        }
        /// <summary>
        /// Posts the content to RichTextBoxAdv in block layout type.
        /// </summary>
        /// <param name="contentStream">The content stream.</param>
        /// <param name="isInitialQuery">if set to <c>true</c> [is initial query].</param>
        /// <param name="formatType">Type of the format.</param>
        public void PostContent(Stream contentStream, bool isInitialQuery, FormatType formatType)
        {
            if (contentStream != null)
            {
                ForumPostControl forumPostControl = new ForumPostControl();
                forumPostControl.richTextBoxAdv.Load(contentStream, formatType);
                contentStream.Dispose();
                forumPostControl.updatedOnTextBlock.Text = "Updated On " + DateTime.Now.ToString();
                if (!isInitialQuery)
                    forumPostControl.imgPostedBy.Source = new BitmapImage(new Uri("/syncfusion.richtextboxdemos.wpf;component/Assets/richtextbox/User32.png", UriKind.RelativeOrAbsolute));
                listView.Items.Insert(listView.Items.Count - 1, forumPostControl);
            }
        }
        #endregion
    }
}
