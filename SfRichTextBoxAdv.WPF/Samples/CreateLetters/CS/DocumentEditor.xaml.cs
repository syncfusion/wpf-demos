#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml;
using System.Linq;

namespace DocumentEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        # region Private Members
        RibbonComboBox recipients;
        Dictionary<string, CustomerInfo> CustomerInfoCollection = new Dictionary<string, CustomerInfo>();
        
        #endregion
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
            richTextBoxAdv.IsReadOnly = true;
            richTextBoxAdv.DocumentTitle = "Letter";
            richTextBoxAdv.RequestNavigate += RichTextBoxAdv_RequestNavigate;
            richTextBoxAdv.SelectionChanged += RichTextBoxAdv_SelectionChanged;
            this.Loaded += OnLoaded;
            this.Unloaded += OnUnloaded;
            richTextRibbon.Loaded += RichTextRibbon_Loaded;
            richTextBoxAdv.ExportSettings.UIContainerExporting += ExportSettings_UIContainerExporting;
        }

        private void ExportSettings_UIContainerExporting(object obj, UIContainerExportingEventArgs args)
        {
            string controltext = null;
            if (args.ExportType == UIContainerExportType.Xaml)
                return;
            if (args.UIContainer.UIElement is DateTimeEdit)
            {
                DateTimeEdit dateTimeEdit = args.UIContainer.UIElement as DateTimeEdit;
                controltext = dateTimeEdit.Text;
                if (dateTimeEdit.FontWeight.ToString() == "Bold")
                    args.UIContainer.CharacterFormat.Bold = true;
                args.UIContainer.CharacterFormat.FontColor = (dateTimeEdit.Foreground as SolidColorBrush).Color;
            }
            else if (args.UIContainer.UIElement is TextBox)
            {
                controltext = (args.UIContainer.UIElement as TextBox).Text;
            }
            if (controltext != null)
            {
                args.Text = controltext;
                args.ExportType = UIContainerExportType.Text;
            }

        }

        private void RichTextRibbon_Loaded(object sender, RoutedEventArgs e)
        {
            ParseData();

            InitializeReportTab();

            //Bind the listview
            Binding bind = new Binding();
            if(recipients != null)
            {
                foreach(string key in CustomerInfoCollection.Keys)
                {
                    RibbonComboBoxItem comboBoxItem = new RibbonComboBoxItem() { Content = key };
                    recipients.Items.Add(comboBoxItem);
                }
                recipients.SetBinding(RibbonComboBox.ItemsSourceProperty, bind);
                recipients.SelectionChanged += Recipients_SelectionChanged;
                recipients.SelectedIndex = 0;
            }

        }

        private void Recipients_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((sender as RibbonComboBox).SelectedValue == null)
                return;
            string text = ((sender as RibbonComboBox).SelectedValue as ComboBoxItem).Content.ToString();
            CustomerInfo cusIn = CustomerInfoCollection[text];

            // map the data row values to the uicontainer text blocks.
            ContactName2.Text = ContactName.Text = cusIn.Name;
            CompanyName.Text = cusIn.CompanyName;
            Address.Text = cusIn.Address;
            City.Text = cusIn.City;
            //Region.Text = cusIn.Region;
            Country.Text = cusIn.Country;
            Phone.Text = cusIn.PhoneNumber;
            Fax.Text = cusIn.Fax;

        }

        void ParseData()
        {
            Assembly assembly = typeof(MainWindow).Assembly;
            Stream stream = assembly.GetManifestResourceStream("DocumentEditor.Assets.Records.xml");
            XmlReader reader = XmlReader.Create(stream);

            if (reader == null)
                throw new Exception("reader");

            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (reader.LocalName != "customers")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);

            reader.Read();

            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();

            while (reader.LocalName != "customers")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "customer":
                            CustomerInfo customerinfo = GetCustomerInformation(reader);
                           
                                CustomerInfoCollection.Add(customerinfo.CompanyName, customerinfo);
                                break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "customers") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }

#if !Framework4_0 && !Framework3_5
            reader.Dispose();
#else
            reader = null;
#endif
            stream.Dispose();
        }

        CustomerInfo GetCustomerInformation(XmlReader reader)
        {
            if (reader == null)
                throw new Exception("reader");

            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            if (reader.LocalName != "customer")
                throw new XmlException("Unexpected xml tag " + reader.LocalName);

            reader.Read();

            while (reader.NodeType == XmlNodeType.Whitespace)
                reader.Read();

            CustomerInfo customerInformation = new CustomerInfo();
            while (reader.LocalName != "customer")
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.LocalName)
                    {
                        case "companyname":
                            customerInformation.CompanyName = reader.ReadElementContentAsString();
                            break;
                        case "name":
                            customerInformation.Name = reader.ReadElementContentAsString();
                            break;
                        case "address":
                            customerInformation.Address = reader.ReadElementContentAsString();
                            break;
                        case "city":
                            customerInformation.City = reader.ReadElementContentAsString();
                            break;
                        case "region":
                            customerInformation.Region = reader.ReadElementContentAsString();
                            break;
                        case "country":
                            customerInformation.Country = reader.ReadElementContentAsString();
                            break;
                        case "phone":
                            customerInformation.PhoneNumber = reader.ReadElementContentAsString();
                            break;
                        case "fax":
                            customerInformation.Fax = reader.ReadElementContentAsString();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
                else
                {
                    reader.Read();
                    if ((reader.LocalName == "customers") && reader.NodeType == XmlNodeType.EndElement)
                        break;
                }
            }
            return customerInformation;
        }
          
        

        private void InitializeReportTab()
        {
            DependencyObject obj = richTextRibbon;
            IEnumerable<Visual> childRibbon = Syncfusion.Windows.Shared.VisualUtils.EnumChildrenOfType(richTextRibbon, typeof(Ribbon));
            if (childRibbon == null || childRibbon.Count() == 0)
                return;
            Ribbon ribbon = childRibbon.First() as Ribbon;
            if (ribbon != null)
            {
                RibbonTab skinTab = null;
                for (int i = 0; i < ribbon.Items.Count; i++)
                {
                    RibbonTab tab = ribbon.Items[i] as RibbonTab;
                    if (tab.Caption == "Reports")
                    {
                        skinTab = tab;
                        break;
                    }
                }
                if (skinTab != null)
                {
                    recipients = (skinTab.Items[0] as RibbonBar).Items[1] as RibbonComboBox;
                }
            }
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
