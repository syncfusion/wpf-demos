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
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;

namespace syncfusion.ribbondemos.wpf
{
    public class ModelTabViewModel : NotificationObject
    {

        /// <summary>
        /// Maintains the ribbon properties.
        /// </summary>
        private static Ribbon ribbon = null;

        /// <summary>
        ///  Maintains the collection of custom ribbon tabs.
        /// </summary>
        private ObservableCollection<ModelRibbonTab> customRibbonTabs;

        /// <summary>
        /// Maintains the richtextbox properties.
        /// </summary>
        private static RichTextBox richTextBox = null;

        /// <summary>
        /// Maintains the file path to load file.
        /// </summary>
        string filePath = @"Data\Ribbon\temp.rtf";

        /// <summary>
        /// Indicates the command for open the model.
        /// </summary>
        private ICommand openModelTabCommand;

        /// <summary>
        /// Holds the required resouces for IconTemplate.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }

        /// <summary>
        /// Indicates the command for close model.
        /// </summary>
        private ICommand closeModelTabCommand;

        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for save as backstage item.
        /// </summary>
        private ICommand saveAsCommand;

        /// <summary>
        /// Maintains the command for open backstage item.
        /// </summary>
        private ICommand openCommand;

        /// <summary>
        /// Maintains the command for close backstage item.
        /// </summary>
        private ICommand closeCommand;

        /// <summary>
        /// Maintains the command for backStage exit click.
        /// </summary>
        private ICommand backStageExitCommand;

        /// <summary>
        /// Maintains the command for return to editor button in info backStage.
        /// </summary>
        private ICommand returnToEditorCommand;

        /// <summary>
        /// Maintains the command for onilne help button in help backStage.
        /// </summary>
        private ICommand onlineHelpCommand;

        /// <summary>
        /// Maintains the command for getting started button in help backStage.
        /// </summary>
        private ICommand gettingStartedHelpCommand;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ModelTabViewModel" /> class.
        /// </summary>
        public ModelTabViewModel()
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.ribbondemos.wpf;component/Assets/Ribbon/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
            ModelRibbonTab = new ObservableCollection<ModelRibbonTab>();
            openModelTabCommand = new DelegateCommand<object>(ExecuteOpenModelTabCommand);
            closeModelTabCommand = new DelegateCommand<object>(ExecuteCloseModelTabCommand);
            saveAsCommand = new DelegateCommand<object>(ExecuteSaveAsCommand);
            openCommand = new DelegateCommand<object>(ExecuteOpenCommand);
            closeCommand = new DelegateCommand<object>(ExecuteCloseCommand);
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            backStageExitCommand = new DelegateCommand<object>(ExecuteBackStageExitCommand);
            onlineHelpCommand = new DelegateCommand<object>(ExecuteOnlineHelpCommand);
            gettingStartedHelpCommand = new DelegateCommand<object>(ExecuteGettingStartedCommand);
            returnToEditorCommand = new DelegateCommand<object>(ExecuteReturnToEditorCommand);
            PopulateRibbonTabs();
            string readText = File.ReadAllText(filePath);
            FileContent = readText; 
        }

        /// <summary>
        /// Gets or sets the command for document content <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// Gets the document content in richtext box.
        /// </summary>
        /// <param name="obj">Specifies the dependency object parameter.</param>
        /// <returns>Specifies the string return type.</returns>
        public static string GetDocumentContent(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentContentProperty);
        }

        /// <summary>
        /// Sets the document content in richtext box.
        /// </summary>
        /// <param name="obj">Specifies the dependency object parameter.</param>
        /// <param name="value">Specifies the value.</param>
        public static void SetDocumentContent(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentContentProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for DocumentContent.This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DocumentContentProperty =
            DependencyProperty.RegisterAttached("DocumentContent", typeof(string), typeof(ModelTabViewModel), new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = (obj, e) =>
                {
                    richTextBox = (RichTextBox)obj;
                    var xaml = GetDocumentContent(richTextBox);
                    var doc = new FlowDocument();
                    var range = new TextRange(doc.ContentStart, doc.ContentEnd);
                    using (var reader = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
                    {
                        reader.Position = 0;
                        richTextBox.SelectAll();
                        richTextBox.Selection.Load(reader, DataFormats.Rtf);
                    }
                }
            });

        /// <summary>
        /// Gets or sets the custom ribbon tabs collection <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ObservableCollection<ModelRibbonTab> ModelRibbonTab
        {
            get
            {
                return customRibbonTabs;
            }
            set
            {
                if (customRibbonTabs != value)
                {
                    customRibbonTabs = value;
                    RaisePropertyChanged("ModelRibbonTab");
                }
            }
        }

        /// <summary>
        /// Gets or sets the command for button <see cref="ModelTabViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand { get { return buttonCommand; } }

        /// <summary>
        /// Gets or sets the command for saveas backstage command button <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand SaveAsCommand { get { return saveAsCommand; } }

        /// <summary>
        /// Gets or sets the command for open backstage command button <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand OpenCommand { get { return openCommand; } }

        /// <summary>
        /// Gets or sets the command for close backstage command button <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand CloseCommand { get { return closeCommand; } }

        /// <summary>
        /// Gets or sets the command for backStage exit button <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand BackStageExitCommand { get { return backStageExitCommand; } }

        /// <summary>
        /// Gets or sets the command for return to editor button in info backstage <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand ReturnToEditorCommand { get { return returnToEditorCommand; } }

        /// <summary>
        /// Gets or sets the command for online help button in help backstage <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand OnlineHelpCommand { get { return onlineHelpCommand; } }

        /// <summary>
        /// Gets or sets the command for online getting started button in help backstage <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand GettingStartedHelpCommand { get { return gettingStartedHelpCommand; } }

        /// <summary>
        /// Gets the command for opening model tab <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand OpenModelTabCommand
        {
            get
            {
                return openModelTabCommand;
            }
        }

        /// <summary>
        /// Gets the command for opening model tab <see cref="ModelTabViewModel"/> class.
        /// </summary>
        public ICommand CloseModelTabCommand
        {
            get
            {
                return closeModelTabCommand;
            }
        }

        /// <summary>
        /// Method which is used to implement the openModelTab command.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        public void ExecuteOpenModelTabCommand(object parameter)
        {
            ModelRibbonTab.Clear();
            ModelRibbonTab printPreviewTab = new ModelRibbonTab() { TabHeader = "Print Preview" };
            PopulateRibbonPrintPreviewBars(printPreviewTab);
            ModelRibbonTab.Add(printPreviewTab);
        }

        /// <summary>
        /// Method which is used to implement the closeModelTab command.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        public void ExecuteCloseModelTabCommand(object parameter)
        {
            ModelRibbonTab.Clear();
            PopulateRibbonTabs();
        }

        /// <summary>
        /// Gets the ribbon property
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns></returns>
        public static Ribbon GetRibbon(DependencyObject obj)
        {
            return (Ribbon)obj.GetValue(RibbonProperty);
        }

        /// <summary>
        /// Sets the ribbon property
        /// </summary>
        /// <param name="obj">>Specifies the dependency object.</param>
        /// <param name="value">Specifies the ribbon value.</param>
        public static void SetRibbon(DependencyObject obj, Ribbon value)
        {
            obj.SetValue(RibbonProperty, value);
        }

        /// <summary>
        /// Dependency property.
        /// </summary>
        public static readonly DependencyProperty RibbonProperty =
            DependencyProperty.RegisterAttached("Ribbon", typeof(Ribbon), typeof(ModelTabViewModel), new FrameworkPropertyMetadata(OnRibbonChanged));

        /// <summary>
        /// Method used to access the ribbon control.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="args">Specifies the dependency property changes event args.</param>
        public static void OnRibbonChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ribbon = obj as Ribbon;
        }

        /// <summary>
        /// Method which is used to populate items to the editing ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateEditingItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "One Page", ImageTemplate = CommonResourceDictionary["OnePage"] as DataTemplate, Command=RibbonCommand.ButtonCommand};
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader = "Two Pages", ImageTemplate = CommonResourceDictionary["TwoPages"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "Page Width", ImageTemplate = CommonResourceDictionary["PageWidth"] as DataTemplate, Command=ApplicationCommands.SelectAll };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
        }

        /// <summary>
        /// Method which is used to populate items to the paragraph ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateCreateBarItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader="Envelope", IsLarge=true, ImageTemplate = CommonResourceDictionary["Mail"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader= "Letter", IsLarge=true, ImageTemplate = CommonResourceDictionary["Letter"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
        }

        /// <summary>
        /// Method which is used to populate items to mail ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopuplateRibbonMailItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Attach File", IsLarge = true, ImageTemplate = CommonResourceDictionary["Attachment"] as DataTemplate, IsDropDownButton = true };
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader = "Business card", IsLarge = true, ImageTemplate = CommonResourceDictionary["BusinessCard"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "Audio", IsLarge = true, ImageTemplate = CommonResourceDictionary["Audio"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
            PopulateAttachFileDropDownItems(firstItem);
        }

        /// <summary>
        /// Method which is used to populate items to model items.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateModalItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Show ModalTab", IsLarge = true, Command=OpenModelTabCommand, ImageTemplate = CommonResourceDictionary["Copy"] as DataTemplate };
            Bar.ModelTabRibbonItem.Add(firstItem);
        }

        /// <summary>
        /// Method which is used to populate ribbon bar to ribbon tab.
        /// </summary>
        void PopulateRibbonTabs()
        {
            ModelRibbonTab homeTab = new ModelRibbonTab() { TabHeader = "Home" };
            ModelRibbonTab insertTab = new ModelRibbonTab() { TabHeader = "Insert" };
            PopulateRibbonHomeBars(homeTab);
            PopulateRibbonInsertBars(insertTab);
            ModelRibbonTab.Add(homeTab);
            ModelRibbonTab.Add(insertTab);
        }

        /// <summary>
        /// Method which is used to populate child ribbon bars to Home ribbon bar.
        /// </summary>
        /// <param name="homeTab">Specifies the custom ribbon tab.</param>
        void PopulateRibbonHomeBars(ModelRibbonTab homeTab)
        {
            ModelTabRibbonBar clipBoardBar = new ModelTabRibbonBar() { BarHeader = "Clipboard" };
            ModelTabRibbonBar MDIBar = new ModelTabRibbonBar() { BarHeader = "MDI Styles" };
            ModelTabRibbonBar editingBar = new ModelTabRibbonBar() { BarHeader = "Editing" };
            ModelTabRibbonBar paragraphBar = new ModelTabRibbonBar() { BarHeader = "Create" };
            ModelTabRibbonBar mailBar = new ModelTabRibbonBar() { BarHeader = "Mail" };
            ModelTabRibbonBar modalBar = new ModelTabRibbonBar() { BarHeader = "Modal" };
            PopulateRibbonNewItems(clipBoardBar);
            PopulateEditingItems(editingBar);
            PopulateCreateBarItems(paragraphBar);
            PopuplateRibbonMailItems(mailBar);
            PopulateModalItems(modalBar);
            homeTab.ModelTabRibbonBar.Add(clipBoardBar);
            homeTab.ModelTabRibbonBar.Add(editingBar);
            homeTab.ModelTabRibbonBar.Add(paragraphBar);
            homeTab.ModelTabRibbonBar.Add(mailBar);
            homeTab.ModelTabRibbonBar.Add(modalBar);
        }

        /// <summary>
        /// Method which is used to populate items to home bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        void PopulateRibbonNewItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Paste", IsLarge = true, ImageTemplate = CommonResourceDictionary["Paste"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader = "Cut", ImageTemplate = CommonResourceDictionary["Cut"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "Copy", ImageTemplate = CommonResourceDictionary["Copy"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem fourthItem = new ModelTabRibbonItem() { ItemHeader = "Format Painter", ImageTemplate = CommonResourceDictionary["FormatPainter"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
            Bar.ModelTabRibbonItem.Add(fourthItem);
        }

        /// <summary>
        /// Method which is used to populate items to insert ribbon bar.
        /// </summary>
        /// <param name="Tab">Specifies the custom ribbon tab.</param>
        void PopulateRibbonInsertBars(ModelRibbonTab Tab)
        {
            ModelTabRibbonBar tableBar = new ModelTabRibbonBar() { BarHeader = "Table" };
            ModelTabRibbonBar illustrationBar = new ModelTabRibbonBar() { BarHeader = "Illustrations" };
            ModelTabRibbonBar linksBar = new ModelTabRibbonBar() { BarHeader = "Links" };
            PopulateRibbonTableItems(tableBar);
            PopulateRibbonIllustrationsItems(illustrationBar);
            PopulateRibbonLinkItems(linksBar);
            Tab.ModelTabRibbonBar.Add(tableBar);
            Tab.ModelTabRibbonBar.Add(illustrationBar);
            Tab.ModelTabRibbonBar.Add(linksBar);
        }

        /// <summary>
        /// Method which is used to populate items to illustrations ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonIllustrationsItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Picture", IsLarge = true, ImageTemplate = CommonResourceDictionary["Picture"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader = "Comment", IsLarge = true, ImageTemplate = CommonResourceDictionary["Comment"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "Shapes", IsLarge = true, IsDropDownButton = true, ImageTemplate = CommonResourceDictionary["Shapes"] as DataTemplate };
            ModelTabRibbonItem fourthItem = new ModelTabRibbonItem() { ItemHeader = "Chart", IsLarge = true, IsDropDownButton = true, ImageTemplate = CommonResourceDictionary["Charts"] as DataTemplate };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
            Bar.ModelTabRibbonItem.Add(fourthItem);
            PopulateShapeDropDownItems(thirdItem);
            PopulateChartDropDownItems(fourthItem);
        }

        /// <summary>
        /// Method which is used to populate items to link ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonLinkItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, ImageTemplate = CommonResourceDictionary["HyperLink"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "Zoom", IsLarge = true, ImageTemplate = CommonResourceDictionary["Zoom"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
        }

        /// <summary>
        /// Method which is used to populate items to table ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonTableItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, ImageTemplate = CommonResourceDictionary["Tables"] as DataTemplate, HasTablePicker=true };
            Bar.ModelTabRibbonItem.Add(firstItem);
        }

        /// <summary>
        /// Method which is used to populate items to insert the ribbon bars.
        /// </summary>
        /// <param name="Tab">Specifies the custom ribbon tab.</param>
        private void PopulateRibbonPrintPreviewBars(ModelRibbonTab Tab)
        {
            ModelTabRibbonBar printBar = new ModelTabRibbonBar() { BarHeader = "Print" };
            ModelTabRibbonBar zoomBar = new ModelTabRibbonBar() { BarHeader = "Zoom" };
            ModelTabRibbonBar perviewBar = new ModelTabRibbonBar() { BarHeader = "Preview" };
            PopulateRibbonPrintItems(printBar);
            PopulateRibbonZoomItems(zoomBar);
            PopulateRibbonPreviewItems(perviewBar);
            Tab.ModelTabRibbonBar.Add(printBar);
            Tab.ModelTabRibbonBar.Add(zoomBar);
            Tab.ModelTabRibbonBar.Add(perviewBar);
        }

        /// <summary>
        /// Method which is used to populate items to print ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonPrintItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Print", IsLarge = true, ImageTemplate = CommonResourceDictionary["QuickPrint"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            Bar.ModelTabRibbonItem.Add(firstItem);
        }

        /// <summary>
        /// Method which is used to populate items to zoom ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar</param>
        private void PopulateRibbonZoomItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Zoom", IsLarge = true, ImageTemplate = CommonResourceDictionary["Zoom"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader = "100%", IsLarge = true, ImageTemplate = CommonResourceDictionary["100%"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "One Page", ImageTemplate = CommonResourceDictionary["OnePage"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem fourthItem = new ModelTabRibbonItem() { ItemHeader = "Two Pages", ImageTemplate = CommonResourceDictionary["TwoPages"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            ModelTabRibbonItem fifthItem = new ModelTabRibbonItem() { ItemHeader = "Page Width", ImageTemplate = CommonResourceDictionary["PageWidth"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
            Bar.ModelTabRibbonItem.Add(fourthItem);
            Bar.ModelTabRibbonItem.Add(fifthItem);

        }

        /// <summary>
        /// Method which is used to populate items to preview ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonPreviewItems(ModelTabRibbonBar Bar)
        {
            ModelTabRibbonItem firstItem = new ModelTabRibbonItem() { ItemHeader = "Show Ruler", IsLarge = false,IsCheckBox=true };
            ModelTabRibbonItem secondItem = new ModelTabRibbonItem() { ItemHeader = "Show Magnifier", IsLarge = false,IsCheckBox=true };
            ModelTabRibbonItem thirdItem = new ModelTabRibbonItem() { ItemHeader = "Shrink on OnePage", IsLarge = false, ImageTemplate = CommonResourceDictionary["PageWidth"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            ModelTabRibbonItem fourthItem = new ModelTabRibbonItem() { ItemHeader = "Next Page", IsLarge = false, ImageTemplate = CommonResourceDictionary["TwoPages"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            ModelTabRibbonItem fifthItem = new ModelTabRibbonItem() { ItemHeader = "Previous Page", IsLarge = false, ImageTemplate = CommonResourceDictionary["OnePage"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            ModelTabRibbonItem sixthItem = new ModelTabRibbonItem() { IsSeparator = true };
            ModelTabRibbonItem seventhItem = new ModelTabRibbonItem() { ItemHeader = "Close Print Preview", IsLarge = true,Command= CloseModelTabCommand, ImageTemplate = CommonResourceDictionary["CloseTab"] as DataTemplate };
            Bar.ModelTabRibbonItem.Add(firstItem);
            Bar.ModelTabRibbonItem.Add(secondItem);
            Bar.ModelTabRibbonItem.Add(thirdItem);
            Bar.ModelTabRibbonItem.Add(fourthItem);
            Bar.ModelTabRibbonItem.Add(fifthItem);
            Bar.ModelTabRibbonItem.Add(sixthItem);
            Bar.ModelTabRibbonItem.Add(seventhItem);
        }

        /// <summary>
        /// Adding items to shape dropdown button
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown item.</param>
        private void PopulateShapeDropDownItems(ModelTabRibbonItem customRibbonItem)
        {
            ModelTabDropDownItem firstItem = new ModelTabDropDownItem() { Name = "Square", ImageTemplate = CommonResourceDictionary["Square"] as DataTemplate };
            ModelTabDropDownItem secondItem = new ModelTabDropDownItem() { Name = "Circle", ImageTemplate = CommonResourceDictionary["Circle"] as DataTemplate };
            ModelTabDropDownItem thirdItem = new ModelTabDropDownItem() { Name = "Rhombus", ImageTemplate = CommonResourceDictionary["Rhombus"] as DataTemplate };
            customRibbonItem.ModelTabDropDownItem.Add(firstItem);
            customRibbonItem.ModelTabDropDownItem.Add(secondItem);
            customRibbonItem.ModelTabDropDownItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding items to chart dropdown button.
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown item.</param>
        private void PopulateChartDropDownItems(ModelTabRibbonItem customRibbonItem)
        {
            ModelTabDropDownItem firstItem = new ModelTabDropDownItem() { Name = "Horizontal Bar", ImageTemplate = CommonResourceDictionary["HorizontalBar"] as DataTemplate };
            ModelTabDropDownItem secondItem = new ModelTabDropDownItem() { Name = "Vertical Bar", ImageTemplate = CommonResourceDictionary["VerticalBar"] as DataTemplate };
            ModelTabDropDownItem thirdItem = new ModelTabDropDownItem() { Name = "Pie", ImageTemplate = CommonResourceDictionary["Pie"] as DataTemplate };
            customRibbonItem.ModelTabDropDownItem.Add(firstItem);
            customRibbonItem.ModelTabDropDownItem.Add(secondItem);
            customRibbonItem.ModelTabDropDownItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding items to attach file dropdown button.
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown item.</param>
        private void PopulateAttachFileDropDownItems(ModelTabRibbonItem customRibbonItem)
        {
            ModelTabDropDownItem firstItem = new ModelTabDropDownItem() { Name = "DOC", ImageTemplate = CommonResourceDictionary["DOC"] as DataTemplate };
            ModelTabDropDownItem secondItem = new ModelTabDropDownItem() { Name = "PDF", ImageTemplate = CommonResourceDictionary["PDF"] as DataTemplate };
            ModelTabDropDownItem thirdItem = new ModelTabDropDownItem() { Name = "ZIP", ImageTemplate = CommonResourceDictionary["ZIP"] as DataTemplate };
            ModelTabDropDownItem fourthItem = new ModelTabDropDownItem() { Name = "XLS", ImageTemplate = CommonResourceDictionary["XLS"] as DataTemplate };
            customRibbonItem.ModelTabDropDownItem.Add(firstItem);
            customRibbonItem.ModelTabDropDownItem.Add(secondItem);
            customRibbonItem.ModelTabDropDownItem.Add(thirdItem);
            customRibbonItem.ModelTabDropDownItem.Add(fourthItem);
        }

        /// <summary>
        /// Method to execute returnToEditorCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteReturnToEditorCommand(object parameter)
        {
            ribbon.HideBackStage();
        }

        /// <summary>
        /// Method which is used to execute the saveas command.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of saveas command.</param>
        private void ExecuteSaveAsCommand(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            FileStream rtfFile = null;
            saveFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (saveFile.ShowDialog().Value)
            {
                rtfFile = saveFile.OpenFile() as FileStream;
                XamlWriter.Save(richTextBox, rtfFile);
                TextRange t = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                t.Save(rtfFile, System.Windows.DataFormats.Rtf);
                rtfFile.Close();
            }
        }

        /// <summary>
        /// Method which is used to execute the open command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteOpenCommand(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (openFile.ShowDialog().Value)
            {
                ribbon.HideBackStage();
            }
        }

        /// <summary>
        /// Method to hide the backstage for close backstage button.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteCloseCommand(object parameter)
        {
            ribbon.HideBackStage();
        }

        /// <summary>
        /// Method to execute backStageExitCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteBackStageExitCommand(object parameter)
        {
            ModelTab modelTabDemosView = parameter as ModelTab;
            if (modelTabDemosView != null)
            {
                modelTabDemosView.Close();
            }
        }

        /// <summary>
        ///Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteOnlineHelpCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the help page ?", "Online Help", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
            }
        }

        /// <summary>
        /// Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGettingStartedCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the getting started page ?", "Getting Started", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/ribbon/gettingstarted");
            }
        }

        /// <summary>
        /// Method used to execute the button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ButtonCommandExecute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }
    }
}
