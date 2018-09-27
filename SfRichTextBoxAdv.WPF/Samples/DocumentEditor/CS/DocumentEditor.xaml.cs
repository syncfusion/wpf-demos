using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
#if !Framework3_5
using System.Linq;
#endif

namespace DocumentEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if !Framework3_5
            //Enables touch manipulation.
            richTextBoxAdv.IsManipulationEnabled = true;
#endif
            DataContext = richTextBoxAdv;
            Assembly assembly = typeof(MainWindow).Assembly;
            Stream stream = assembly.GetManifestResourceStream("DocumentEditor.Assets.GettingStarted.docx");
            richTextBoxAdv.Load(stream, FormatType.Docx);
            richTextBoxAdv.DocumentTitle = "Getting Started";
            richTextBoxAdv.RequestNavigate += RichTextBoxAdv_RequestNavigate;
            richTextBoxAdv.SelectionChanged += RichTextBoxAdv_SelectionChanged;
            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
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
                richTextBoxAdv.Focus();
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
                LaunchUri(new Uri(args.Hyperlink.NavigationLink));
            else if (args.Hyperlink.LinkType == HyperlinkType.File && File.Exists(args.Hyperlink.NavigationLink))
                Process.Start(args.Hyperlink.NavigationLink);
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
        /// <summary>
        /// Calle when [unloaded].
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void OnUnloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= OnUnloaded;
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
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
            WindowTitleBarButton HelpButton = null;
            Syncfusion.Windows.Tools.Controls.TitleBar titleBar = VisualUtils.FindDescendant(sender as RibbonWindow, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            if (titleBar != null)
                HelpButton = titleBar.Template.FindName("HelpButton", titleBar) as WindowTitleBarButton;
            if (HelpButton != null)
                HelpButton.Click -= HelpButton_Click;
        }
        #endregion

        #region Implementation
        /// <summary>
        /// Launches the URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        private void LaunchUri(Uri uri)
        {
            Process.Start(new ProcessStartInfo(uri.AbsoluteUri));
        }
        /// <summary>
        /// Launches the Help URI
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            LaunchUri(new Uri("http://help.syncfusion.com/wpf/sfrichtextboxadv/overview"));
        }
        #endregion
    }
}
