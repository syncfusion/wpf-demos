#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
using System.Windows.Markup;
using Syncfusion.SfSkinManager;

namespace DocumentEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region Fields
        private string currentVisualStyle;
        RibbonTab skinTab = null;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the current visual style.
        /// </summary>
        /// <value></value>
        /// <remarks></remarks>
        public string CurrentVisualStyle
        {
            get
            {
                return currentVisualStyle;
            }
            set
            {
                currentVisualStyle = value;
                OnVisualStyleChanged();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
#if NETCORE
            richTextBoxAdv.SpellChecker.CustomDictionaries = new ObservableCollection<string>() { "../../../Assets/CustomDictionary.dic"};
#else
            richTextBoxAdv.SpellChecker.CustomDictionaries = new ObservableCollection<string>() { "../../Assets/CustomDictionary.dic"};
#endif
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
            richTextRibbon.Loaded += RichTextRibbon_Loaded;
            richTextRibbon.LayoutUpdated += RichTextRibbon_LayoutUpdated;
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
            CurrentVisualStyle = "Metro";
            if (richTextBoxAdv != null)
                richTextBoxAdv.Focus();
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
        /// Called on rich text ribbon loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void RichTextRibbon_Loaded(object sender, RoutedEventArgs e)
        {
            // Hooks the event handler for RibbonWindow title bar help button.
            Syncfusion.Windows.Tools.Controls.TitleBar titleBar = VisualUtils.FindDescendant(this, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            WindowTitleBarButton HelpButton = null;
            if (titleBar != null)
                HelpButton = titleBar.Template.FindName("HelpButton", titleBar) as WindowTitleBarButton;
            if (HelpButton != null)
            {
                HelpButton.Click += HelpButton_Click;
                HelpButton.ToolTip = "Help";
            }
            // Initializes the skin tab.
            InitializeSkinTab();
        }

        /// <summary>
        ///  Occurs when the layout of the various visual elements associated with the current.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.RoutedEventArgs">RoutedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        private void RichTextRibbon_LayoutUpdated(object sender, EventArgs e)
        {
            if (skinTab == null)
            {
                InitializeSkinTab();
            }
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
        /// Called on combo box selection changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An <see cref="T:System.Windows.Controls.SelectionChangedEventArgs">SelectionChangedEventArgs</see> that contains the event data.</param>
        /// <remarks></remarks>
        void VisualStyleComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((sender as RibbonComboBox).SelectedValue != null)
            {
                CurrentVisualStyle = (sender as RibbonComboBox).SelectedValue.ToString();
            }
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
                richTextRibbon.Loaded -= RichTextRibbon_Loaded;
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

            if(skinTab != null)
            {
                skinTab.Dispose();
                skinTab = null;
            }
        }
#endregion

#region Implementation
        /// <summary>
        /// On Visual Style Changed.
        /// </summary>
        /// <remarks></remarks>
        private void OnVisualStyleChanged()
        {
            // Unhooks the event handler for RibbonWindow title bar help button.
            Syncfusion.Windows.Tools.Controls.TitleBar titleBar = VisualUtils.FindDescendant(this, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            WindowTitleBarButton HelpButton = null;
            if (titleBar != null)
                HelpButton = titleBar.Template.FindName("HelpButton", titleBar) as WindowTitleBarButton;
            if (HelpButton != null)
                HelpButton.Click -= HelpButton_Click;
            VisualStyles visualStyle = VisualStyles.Default;
            Enum.TryParse(CurrentVisualStyle, out visualStyle);
            string path = "pack://application:,,/Assets/Syncfusion.png";
            if (visualStyle == VisualStyles.Blend || visualStyle == VisualStyles.Office2010Black
                || visualStyle == VisualStyles.Office2010Blue || visualStyle == VisualStyles.VisualStudio2013)
                path = "pack://application:,,/Assets/SyncfusionWhite.png";
            ImageSourceConverter imgConv = new ImageSourceConverter();
            ImageSource imageSource = (ImageSource)imgConv.ConvertFromString(path);
            this.Office2010Icon = imageSource;
            if (visualStyle != VisualStyles.Default)
            {
                SfSkinManager.ApplyStylesOnApplication = true;
                SfSkinManager.SetVisualStyle(this, visualStyle);
                SfSkinManager.ApplyStylesOnApplication = false;
            }
        }
        /// <summary>
        /// Launches the URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        private void LaunchUri(Uri uri)
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
        /// <summary>
        /// Called when help button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event args.</param>
        void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            LaunchUri(new Uri("http://help.syncfusion.com/wpf/sfrichtextboxadv/overview"));
        }
        /// <summary>
        /// Initializes the skin tab.
        /// </summary>
        /// <remarks></remarks>
        private void InitializeSkinTab()
        {
            DependencyObject obj = richTextRibbon;
            IEnumerable<Visual> childRibbon = Syncfusion.Windows.Shared.VisualUtils.EnumChildrenOfType(richTextRibbon, typeof(Ribbon));
            if (childRibbon == null || childRibbon.Count() == 0)
                return;
            Ribbon ribbon = childRibbon.First() as Ribbon;
            if (ribbon != null)
            {
                for (int i = 0; i < ribbon.Items.Count; i++)
                {
                    RibbonTab tab = ribbon.Items[i] as RibbonTab;
                    if (tab.Caption == "Skin")
                    {
                        skinTab = tab;
                        break;
                    }
                }
                if (skinTab != null)
                {
                    RibbonComboBox visualStylesBox = (skinTab.Items[0] as RibbonBar).Items[1] as RibbonComboBox;
                    if (visualStylesBox != null)
                    {
                        visualStylesBox.SelectedValue = CurrentVisualStyle;
                        visualStylesBox.SelectionChanged += VisualStyleComboBox_SelectionChanged;
                    }
                }
            }
        }
#endregion
    }
}
