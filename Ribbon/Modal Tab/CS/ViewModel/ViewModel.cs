#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace RibbonModelTab
{
    public class ViewModel
    {
        /// <summary>
        ///  Maintains the collection of custom ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customRibbonTabs;

        /// <summary>
        /// Maintains the richtextbox properties.
        /// </summary>
        private static RichTextBox richTextBox = null;

        /// <summary>
        /// Maintains the file path to load file.
        /// </summary>
#if NETCORE
        string filePath =  @"..\..\..\Resources\temp.rtf";
#else
        string filePath = @"Resources\temp.rtf";
#endif

        /// <summary>
        /// Indicates the command for open the model.
        /// </summary>
        private ICommand openModelTabCommand;

        /// <summary>
        /// Indicates the command for close model.
        /// </summary>
        private ICommand closeModelTabCommand;

        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for dropdown
        /// </summary>
        private ICommand dropdownCommand;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            CustomRibbonTabs = new ObservableCollection<CustomRibbonTab>();
            openModelTabCommand = new DelegateCommand<object>(ExecuteOpenModelTabCommand);
            closeModelTabCommand = new DelegateCommand<object>(ExecuteCloseModelTabCommand);
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);
            PopulateRibbonTabs();
            string readText = File.ReadAllText(filePath);
            DocContent = readText; 
        }

        /// <summary>
        /// Gets or sets the command for document content <see cref="ViewModel"/> class.
        /// </summary>
        public string DocContent { get; set; }

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
            DependencyProperty.RegisterAttached("DocumentContent", typeof(string), typeof(ViewModel), new FrameworkPropertyMetadata
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
        /// Gets or sets the custom ribbon tabs collection <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<CustomRibbonTab> CustomRibbonTabs
        {
            get
            {
                return customRibbonTabs;
            }
            set
            {
                if (customRibbonTabs != value)
                    customRibbonTabs = value;
            }
        }

        /// <summary>
        /// Gets the command for opening model tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand OpenModelTabCommand
        {
            get { return openModelTabCommand; }
        }

        /// <summary>
        /// Gets the command for opening model tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand CloseModelTabCommand
        {
            get { return closeModelTabCommand; }
        }

        /// <summary>
        /// Gets or sets the command for button <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand
        {
            get { return buttonCommand; }
        }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand DropDownCommand
        {
            get { return dropdownCommand; }
        }

        /// <summary>
        /// Method which is used to implement the openModelTab command.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        public void ExecuteOpenModelTabCommand(object parameter)
        {
            CustomRibbonTabs.Clear();
            CustomRibbonTab printPreviewTab = new CustomRibbonTab() { TabHeader = "Print Preview" };
            PopulateRibbonPrintPreviewBars(printPreviewTab);
            CustomRibbonTabs.Add(printPreviewTab);
        }

        /// <summary>
        /// Method which is used to implement the closeModelTab command.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        public void ExecuteCloseModelTabCommand(object parameter)
        {
            CustomRibbonTabs.Clear();
            PopulateRibbonTabs();
        }

        /// <summary>
        /// Method which is used to populate items to the editing ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateEditingItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Find", Image = "Search.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Replace", Image = "replace_32.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Select", Image = "start2.png",Command=ApplicationCommands.SelectAll };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
        }

        /// <summary>
        /// Method which is used to populate items to the paragraph ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateParagraphItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() {   Image = "Bullets16.png",Command=EditingCommands.ToggleBullets};
            CustomRibbonItem secondItem = new CustomRibbonItem() {   Image = "AlignTextLeft16.png",Command=EditingCommands.AlignLeft };
            CustomRibbonItem thirdItem = new CustomRibbonItem() {   Image = "DecreaseIndent16.png",Command=EditingCommands.DecreaseIndentation };
            CustomRibbonItem fourthItem = new CustomRibbonItem() {   Image = "Numbering16.png",Command=EditingCommands.ToggleNumbering};
            CustomRibbonItem fifthItem = new CustomRibbonItem() {   Image = "AlignTextCenter16.png",Command=EditingCommands.AlignCenter };
            CustomRibbonItem sixthItem = new CustomRibbonItem() {   Image = "IncreaseIndent16.png",Command=EditingCommands.IncreaseIndentation };
            CustomRibbonItem seventhItem = new CustomRibbonItem() {   Image = "MultilevelList16.png",Command= ButtonCommand };
            CustomRibbonItem eighthItem = new CustomRibbonItem() {   Image = "AlignTextRight16.png",Command=EditingCommands.AlignRight };
            CustomRibbonItem ninthItem = new CustomRibbonItem() {   Image = "LineSpacing16.png",Command= ButtonCommand };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
            Bar.CustomRibbonItems.Add(fourthItem);
            Bar.CustomRibbonItems.Add(fifthItem);
            Bar.CustomRibbonItems.Add(sixthItem);
            Bar.CustomRibbonItems.Add(seventhItem);
            Bar.CustomRibbonItems.Add(eighthItem);
            Bar.CustomRibbonItems.Add(ninthItem);
        }

        /// <summary>
        /// Method which is used to populate items to mail ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopuplateRibbonMailItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Attach File", IsLarge = true, Image = "base_paperclip_32.png", IsSplitButton = true };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Business card", IsLarge = true, Image = "base_business_contacts.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Audio", IsLarge = true, Image = "base_speaker_32.png",Command= ButtonCommand };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);

            PopulateAttachFileDropDownItems(firstItem);
        }

        /// <summary>
        /// Method which is used to populate items to model items.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateModalItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Show ModalTab", IsLarge = true, Command=OpenModelTabCommand, Image = "modal.png" };
            Bar.CustomRibbonItems.Add(firstItem);
        }

        /// <summary>
        /// Method which is used to populate ribbon bar to ribbon tab.
        /// </summary>
        void PopulateRibbonTabs()
        {
            CustomRibbonTab homeTab = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab insertTab = new CustomRibbonTab() { TabHeader = "Insert" };

            PopulateRibbonHomeBars(homeTab);
            PopulateRibbonInsertBars(insertTab);
            CustomRibbonTabs.Add(homeTab);
            CustomRibbonTabs.Add(insertTab);
        }

        /// <summary>
        /// Method which is used to populate child ribbon bars to Home ribbon bar.
        /// </summary>
        /// <param name="homeTab">Specifies the custom ribbon tab.</param>
        void PopulateRibbonHomeBars(CustomRibbonTab homeTab)
        {
            CustomRibbonBar clipBoardBar = new CustomRibbonBar() { BarHeader = "Clipboard" };
            CustomRibbonBar MDIBar = new CustomRibbonBar() { BarHeader = "MDI Styles" };
            CustomRibbonBar editingBar = new CustomRibbonBar() { BarHeader = "Editing" };
            CustomRibbonBar paragraphBar = new CustomRibbonBar() { BarHeader = "Paragraph" };
            CustomRibbonBar mailBar = new CustomRibbonBar() { BarHeader = "Mail" };
            CustomRibbonBar modalBar = new CustomRibbonBar() { BarHeader = "Modal" };

            PopulateRibbonNewItems(clipBoardBar);
            PopulateEditingItems(editingBar);
            PopulateParagraphItems(paragraphBar);
            PopuplateRibbonMailItems(mailBar);
            PopulateModalItems(modalBar);

            homeTab.CustomRibbonBars.Add(clipBoardBar);
            homeTab.CustomRibbonBars.Add(editingBar);
            homeTab.CustomRibbonBars.Add(paragraphBar);
            homeTab.CustomRibbonBars.Add(mailBar);
            homeTab.CustomRibbonBars.Add(modalBar);
        }

        /// <summary>
        /// Method which is used to populate items to home bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        void PopulateRibbonNewItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Paste", IsLarge = true, Image = "Paste32.png",Command=ApplicationCommands.Paste };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Cut", Image = "Cut16.png",Command=ApplicationCommands.Cut };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Copy", Image = "Copy16.png",Command=ApplicationCommands.Copy };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Format Painter", Image = "FormatPainter16.png",Command= ButtonCommand };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
            Bar.CustomRibbonItems.Add(fourthItem);
        }

        //Insert Tab
        /// <summary>
        /// Method which is used to populate items to insert ribbon bar.
        /// </summary>
        /// <param name="Tab">Specifies the custom ribbon tab.</param>
        void PopulateRibbonInsertBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar tableBar = new CustomRibbonBar() { BarHeader = "Table" };
            CustomRibbonBar illustrationBar = new CustomRibbonBar() { BarHeader = "Illustrations" };
            CustomRibbonBar linksBar = new CustomRibbonBar() { BarHeader = "Links" };

            PopulateRibbonTableItems(tableBar);
            PopulateRibbonIllustrationsItems(illustrationBar);
            PopulateRibbonLinkItems(linksBar);

            Tab.CustomRibbonBars.Add(tableBar);
            Tab.CustomRibbonBars.Add(illustrationBar);
            Tab.CustomRibbonBars.Add(linksBar);
        }

        /// <summary>
        /// Method which is used to populate items to illustrations ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonIllustrationsItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Picture", IsLarge = true, Image = "Picture.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Comment", IsLarge = true, Image = "0356_NewComment_32.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Shapes", IsLarge = true, IsDropDownButton = true, Image = "0202_InsertShape_32.png" };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Chart", IsLarge = true, IsDropDownButton = true, Image = "base_charts.png" };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
            Bar.CustomRibbonItems.Add(fourthItem);

            PopulateShapeDropDownItems(thirdItem);
            PopulateChartDropDownItems(fourthItem);
        }

        /// <summary>
        /// Method which is used to populate items to link ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonLinkItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, Image = "Hyperlink32.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Replace", IsLarge = true, Image = "replace_32.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png",Command= ButtonCommand };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
        }

        /// <summary>
        /// Method which is used to populate items to table ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonTableItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, Image = "Table_32.png",HasTablePicker=true };

            Bar.CustomRibbonItems.Add(firstItem);
        }

        /// <summary>
        /// Method which is used to populate items to insert the ribbon bars.
        /// </summary>
        /// <param name="Tab">Specifies the custom ribbon tab.</param>
        private void PopulateRibbonPrintPreviewBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar printBar = new CustomRibbonBar() { BarHeader = "Print" };
            CustomRibbonBar zoomBar = new CustomRibbonBar() { BarHeader = "Zoom" };
            CustomRibbonBar perviewBar = new CustomRibbonBar() { BarHeader = "Preview" };

            PopulateRibbonPrintItems(printBar);
            PopulateRibbonZoomItems(zoomBar);
            PopulateRibbonPreviewItems(perviewBar);

            Tab.CustomRibbonBars.Add(printBar);
            Tab.CustomRibbonBars.Add(zoomBar);
            Tab.CustomRibbonBars.Add(perviewBar);
        }

        /// <summary>
        /// Method which is used to populate items to print ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonPrintItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Print", IsLarge = true, Image = "PrintAreaFlat.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Options", IsLarge = true, Image = "View Setting.png",Command= ButtonCommand };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
        }

        /// <summary>
        /// Method which is used to populate items to zoom ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar</param>
        private void PopulateRibbonZoomItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "100%", IsLarge = true, Image = "portrait.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "One Page", IsLarge = false, Image = "Team Email.png",Command= ButtonCommand };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Two Pages", IsLarge = false, Image = "Reading Pane.png",Command= ButtonCommand };
            CustomRibbonItem fifthItem = new CustomRibbonItem() { ItemHeader = "Page Width", IsLarge = false, Image = "Reading Pane.png",Command= ButtonCommand };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
            Bar.CustomRibbonItems.Add(fourthItem);
            Bar.CustomRibbonItems.Add(fifthItem);

        }

        /// <summary>
        /// Method which is used to populate items to preview ribbon bar.
        /// </summary>
        /// <param name="Bar">Specifies the custom ribbon bar.</param>
        private void PopulateRibbonPreviewItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Show Ruler", IsLarge = false,IsCheckBox=true };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Show Magnifier", IsLarge = false,IsCheckBox=true };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Shrink on OnePage", IsLarge = false, Image = "Object16.png",Command= ButtonCommand };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Next Page", IsLarge = false, Image = "nextpage.png",Command= ButtonCommand };
            CustomRibbonItem fifthItem = new CustomRibbonItem() { ItemHeader = "Previous Page", IsLarge = false, Image = "previouspage.png",Command=ButtonCommand };
            CustomRibbonItem sixthItem = new CustomRibbonItem() { IsSeparator = true };
            CustomRibbonItem seventhItem = new CustomRibbonItem() { ItemHeader = "Close Print Preview", IsLarge = true,Command= CloseModelTabCommand, Image = "CloseTab32.png" };

            Bar.CustomRibbonItems.Add(firstItem);
            Bar.CustomRibbonItems.Add(secondItem);
            Bar.CustomRibbonItems.Add(thirdItem);
            Bar.CustomRibbonItems.Add(fourthItem);
            Bar.CustomRibbonItems.Add(fifthItem);
            Bar.CustomRibbonItems.Add(sixthItem);
            Bar.CustomRibbonItems.Add(seventhItem);
        }

        /// <summary>
        /// Adding items to shape dropdown button
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown item.</param>
        private void PopulateShapeDropDownItems(CustomRibbonItem customRibbonItem)
        {
            CustomDropDownItem firstItem = new CustomDropDownItem() { Name = "Square", Image = "Images/Square.png" };
            CustomDropDownItem secondItem = new CustomDropDownItem() { Name = "Circle", Image = "Images/Circle.png" };
            CustomDropDownItem fourthItem = new CustomDropDownItem() { Name = "Cylinder", Image = "Images/Cylinder.png" };
            CustomDropDownItem thirdItem = new CustomDropDownItem() { Name = "Rhombus", Image = "Images/Rhombus.png" };
            CustomDropDownItem fifthItem = new CustomDropDownItem() { Name = "Triangle", Image = "Images/Triangle.png" };

            customRibbonItem.CustomDropDownItems.Add(firstItem);
            customRibbonItem.CustomDropDownItems.Add(secondItem);
            customRibbonItem.CustomDropDownItems.Add(fourthItem);
            customRibbonItem.CustomDropDownItems.Add(thirdItem);
            customRibbonItem.CustomDropDownItems.Add(fifthItem);
        }

        /// <summary>
        /// Adding items to chart dropdown button.
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown item.</param>
        private void PopulateChartDropDownItems(CustomRibbonItem customRibbonItem)
        {
            CustomDropDownItem firstItem = new CustomDropDownItem() { Name = "Horizontal Bar", Image = "Images/Horizontal Barchart_02.png" };
            CustomDropDownItem secondItem = new CustomDropDownItem() { Name = "Vertical Bar", Image = "Images/Vertical Barchart_02.png" };
            CustomDropDownItem thirdItem = new CustomDropDownItem() { Name = "Stack Bar", Image = "Images/Stack Chart - 04.png" };
            CustomDropDownItem fourthItem = new CustomDropDownItem() { Name = "Pie", Image = "Images/Pie-Chart.png" };
            CustomDropDownItem fifthItem = new CustomDropDownItem() { Name = "Graph", Image = "Images/Graph-03.png" };
            CustomDropDownItem sixthItem = new CustomDropDownItem() { Name = "Doughnut", Image = "Images/Chart Doughnut.png" };
            CustomDropDownItem seventhItem = new CustomDropDownItem() { Name = "Radar", Image = "Images/Chart Radar.png" };
            CustomDropDownItem eighthItem = new CustomDropDownItem() { Name = "Bubble", Image = "Images/Chart Bubble.png" };

            customRibbonItem.CustomDropDownItems.Add(firstItem);
            customRibbonItem.CustomDropDownItems.Add(secondItem);
            customRibbonItem.CustomDropDownItems.Add(thirdItem);
            customRibbonItem.CustomDropDownItems.Add(fourthItem);
            customRibbonItem.CustomDropDownItems.Add(fifthItem);
            customRibbonItem.CustomDropDownItems.Add(sixthItem);
            customRibbonItem.CustomDropDownItems.Add(seventhItem);
            customRibbonItem.CustomDropDownItems.Add(eighthItem);
        }

        /// <summary>
        /// Adding items to attach file dropdown button.
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown item.</param>
        private void PopulateAttachFileDropDownItems(CustomRibbonItem customRibbonItem)
        {
            CustomDropDownItem firstItem = new CustomDropDownItem() { Name = "DOC", Image = "Images/Word1.png" };
            CustomDropDownItem secondItem = new CustomDropDownItem() { Name = "PDF", Image = "Images/PDF.png" };
            CustomDropDownItem thirdItem = new CustomDropDownItem() { Name = "ZIP", Image = "Images/Zip file-02-WF.png" };
            CustomDropDownItem fourthItem = new CustomDropDownItem() { Name = "XLS", Image = "Images/Excel Online.png" };

            customRibbonItem.CustomDropDownItems.Add(firstItem);
            customRibbonItem.CustomDropDownItems.Add(secondItem);
            customRibbonItem.CustomDropDownItems.Add(thirdItem);
            customRibbonItem.CustomDropDownItems.Add(fourthItem);
        }

        /// <summary>
        /// Method used to execute the button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ButtonCommandExecute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }

        /// <summary>
        /// Method used to execute the dropdown command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void DropDownCommandExecute(object parameter)
        {
            if(parameter!=null)
                MessageBox.Show("The dropdown item has been selected.");
        }
    }
}
