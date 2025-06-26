#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using syncfusion.richtextboxdemos.wpf.Helper;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.richtextboxdemos.wpf
{
    /// <summary>
    /// Interaction logic for SmartWriterDemo.xaml
    /// </summary>
    public partial class SmartWriterDemo : RibbonWindow
    {
        #region Fileds
        AIWriteDemo aIWrite = null;
        private MenuItem aiWriteMenuItem;
        private bool IsCredentialValid = false;
        SemanticKernelAI semanticKernelOpenAI { get; set; }
        #endregion

        #region Constructor
        public SmartWriterDemo()
        {
            InitializeComponent();
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
        /// <param name="args">The <see cref="RequestNavigateEventArgs"/> instance containing the event data.</param>
        void RichTextBoxAdv_RequestNavigate(object obj, RequestNavigateEventArgs args)
        {
            if (args.Hyperlink.LinkType == HyperlinkType.Webpage || args.Hyperlink.LinkType == HyperlinkType.Email)
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
        #endregion

        #region Smart Writer Implementation
        /// <summary>
        /// Adds custom context menu items (Rewrite) to the SfRichTextBoxAdv context menu.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the ContextMenuEventArgs.</param>
        private void RichTextBoxAdv_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (!IsCredentialValid)
                return;

            if (aiWriteMenuItem == null)
            {
                aiWriteMenuItem = CreateAiWriteMenuItem();
                richTextBoxAdv.ContextMenu.Items.Add(aiWriteMenuItem);
            }
        }

        /// <summary>
        /// Craetes a new menu item for AIwrite.
        /// </summary>
        /// <returns></returns>
        private MenuItem CreateAiWriteMenuItem()
        {
            var menuItem = new MenuItem
            {
                Header = "AI Write",
                Margin = new Thickness(4),
                Icon = CreateMenuItemIcon()
            };

            menuItem.Click += OnGenerateContentClicked;
            return menuItem;
        }

        /// <summary>
        /// create icon for the AIwrite option.
        /// </summary>
        /// <returns></returns>
        private Grid CreateMenuItemIcon()
        {
            Theme currentTheme = SfSkinManager.GetTheme(this);
            Grid grid = new Grid
            {
                Width = 14,
                Height = 18,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            System.Windows.Shapes.Path aiWritePath = new System.Windows.Shapes.Path
            {
                Stretch = Stretch.Uniform,
                Data = Geometry.Parse("M12.7393 0.396994C12.6915 0.170186 12.4942 0.00592917 12.2625 0.000156701C12.0307 -0.00561577 11.8255 0.14861 11.7665 0.372759L11.6317 0.88471C11.4712 1.49477 10.9948 1.97121 10.3847 2.13174L9.87276 2.26646C9.66167 2.32201 9.51101 2.50807 9.50058 2.72609C9.49014 2.94412 9.62234 3.14371 9.82715 3.21917L10.5469 3.48434C11.0663 3.67572 11.4646 4.10158 11.6208 4.63266L11.7703 5.14108C11.8343 5.35877 12.0369 5.50605 12.2637 5.49981C12.4906 5.49358 12.6847 5.3354 12.7367 5.11453L12.8292 4.72158C12.9661 4.1398 13.3904 3.66811 13.9545 3.47067L14.6652 3.22193C14.8737 3.14895 15.0096 2.94777 14.9995 2.72708C14.9894 2.50639 14.8356 2.31851 14.6213 2.26493L14.1122 2.13768C13.4624 1.97521 12.9622 1.45598 12.8242 0.800453L12.7393 0.396994ZM11.3796 2.78214C11.7234 2.57072 12.0165 2.28608 12.2378 1.94927C12.458 2.28452 12.7496 2.56851 13.0919 2.77995C12.7482 2.99134 12.4564 3.27526 12.2359 3.60987C12.015 3.2757 11.7229 2.99268 11.3796 2.78214ZM4.85357 10.4744C4.91635 10.6878 5.11235 10.8336 5.33379 10.8333L5.34711 10.8331C5.57393 10.8269 5.76811 10.6687 5.82009 10.4478L5.98446 9.74927C6.25825 8.5857 7.10693 7.64233 8.23516 7.24744L9.49856 6.80524C9.7035 6.73351 9.83872 6.53772 9.83322 6.32066C9.82772 6.1036 9.68277 5.9149 9.47446 5.85363L8.57059 5.58779C7.50843 5.2754 6.65671 4.47887 6.27396 3.43999L5.80255 2.16046C5.72974 1.96284 5.54135 1.83282 5.33236 1.83331C5.10615 1.83366 4.90757 1.98624 4.84972 2.20607L4.61022 3.11621C4.28914 4.33632 3.33626 5.2892 2.11615 5.61027L1.20601 5.84978C0.994926 5.90532 0.844266 6.09138 0.833828 6.3094C0.82339 6.52743 0.955587 6.72703 1.1604 6.80249L2.43993 7.2739C3.47881 7.65665 4.27534 8.50837 4.58773 9.57053L4.85357 10.4744ZM7.68415 6.38731C6.62743 6.82043 5.78274 7.636 5.309 8.65736C4.83249 7.63465 3.985 6.82144 2.92852 6.39092C3.98451 5.95938 4.83592 5.14232 5.31175 4.11073C5.78498 5.13721 6.63136 5.95377 7.68415 6.38731ZM11.9893 7.39699C11.9415 7.17019 11.7442 7.00593 11.5125 7.00016C11.2807 6.99438 11.0755 7.14861 11.0165 7.37276L10.8368 8.05536C10.6075 8.92687 9.92687 9.6075 9.05536 9.83684L8.37276 10.0165C8.16167 10.072 8.01101 10.2581 8.00058 10.4761C7.99014 10.6941 8.12233 10.8937 8.32715 10.9692L9.2868 11.3227C10.0289 11.5961 10.5978 12.2045 10.8209 12.9632L11.0203 13.6411C11.0843 13.8588 11.2869 14.006 11.5137 13.9998C11.7406 13.9936 11.9347 13.8354 11.9867 13.6145L12.11 13.0906C12.3056 12.2595 12.9118 11.5856 13.7176 11.3036L14.6652 10.9719C14.8737 10.8989 15.0096 10.6978 14.9995 10.4771C14.9894 10.2564 14.8356 10.0685 14.6213 10.0149L13.9426 9.84526C13.0141 9.61316 12.2997 8.87141 12.1025 7.93494L11.9893 7.39699ZM9.99771 10.543C10.6264 10.2254 11.1444 9.72499 11.4838 9.10985C11.8215 9.72215 12.3367 10.2219 12.9632 10.5402C12.3344 10.8584 11.8194 11.3576 11.4815 11.9678C11.1422 11.3576 10.6262 10.8597 9.99771 10.543Z")
            };
            if (currentTheme.ThemeName.ToLower().Contains("system")) { aiWritePath.Fill = Brushes.Black; }
            else { aiWritePath.SetResourceReference(System.Windows.Shapes.Path.FillProperty, "IconColor"); }
            grid.Children.Add(aiWritePath);
            return grid;
        }

        /// <summary>
        /// Removes the custom context menu items (Rewrite, Grammar, and Translate) from the SfRichTextBoxAdv context menu
        /// when the context menu is closing.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Event data for the ContextMenuEventArgs.</param>
        private void RichTextBoxAdv_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            // Remove custom items first if they are already added
            richTextBoxAdv.ContextMenu.Items.Remove(aiWriteMenuItem);
            aiWriteMenuItem = null;
        }

        /// <summary>
        /// Handles the click event for generating content for Smart writer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void OnGenerateContentClicked(object sender, RoutedEventArgs e)
        {
            Theme currentTheme = SfSkinManager.GetTheme(this);
            if (currentTheme != null)
            {
                aIWrite = new AIWriteDemo(currentTheme);
                aIWrite.semanticKernelOpenAI = semanticKernelOpenAI;
            }

            if (aIWrite.ShowDialog() == true)
            {
                string contentToPaste = aIWrite.GeneratedContent;
                if (!string.IsNullOrWhiteSpace(contentToPaste) && richTextBoxAdv != null)
                {
                    // Use Clipboard to paste content into SfRichTextBoxAdv
                    DataObject dataObject = new DataObject();
                    dataObject.SetData(DataFormats.Html, contentToPaste);
                    Clipboard.SetDataObject(dataObject);

                    // Execute the paste command on the SfRichTextBoxAdv
                    SfRichTextBoxAdv.PasteCommand.Execute(null, richTextBoxAdv);
                }
            }
        }

        /// <summary>
        /// Handles the Loaded event for the SfRichTextBoxAdv.
        /// </summary>
        /// <param name="sender">The source of the event, typically the SfRichTextBoxAdv control.</param>
        /// <param name="e">The event data containing information about the Loaded event.</param>
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
                IsCredentialValid = AISettings.IsCredentialValid;
                // Initialize the semantic kernel object
                semanticKernelOpenAI = new SemanticKernelAI(AISettings.Key, AISettings.EndPoint, AISettings.ModelName);
            }
            else
            {
                semanticKernelOpenAI = null;
                AIWriteButton.IsEnabled = false;
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
                richTextBoxAdv.ContextMenuOpening -= RichTextBoxAdv_ContextMenuOpening;
                richTextBoxAdv.ContextMenuClosing -= RichTextBoxAdv_ContextMenuClosing;
                richTextBoxAdv.Loaded -= richTextBoxAdv_Loaded;
                richTextBoxAdv.Dispose();
                richTextBoxAdv = null;
            }
            if (aIWrite != null)
            {
                aIWrite = null;
            }
            if (semanticKernelOpenAI != null)
            {
                semanticKernelOpenAI = null;
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
