#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace RibbonMenuMerging
{ 
    /// <summary>
    /// Represents the viewmodel.
    /// </summary>
    public class ViewModel :NotificationObject
    {
        /// <summary>
        /// Maintains the command for TDI.
        /// </summary>
        private ICommand modeTDICommand;

        /// <summary>
        /// Maintains the type of command modes.
        /// </summary>
        private DocumentContainerMode mode;

        /// <summary>
        /// Maintains the command for modeMDICommand.
        /// </summary>
        private ICommand modeMDICommand;

        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for dropdown
        /// </summary>
        private ICommand dropdownCommand;

        /// <summary>
        ///  Maintains the collection of ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customRibbonTabs;

        /// <summary>
        ///  Maintains the collection of firstChildRibbon ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> firstChildRibbonTab;

        /// <summary>
        ///  Maintains the collection of secondChildRibbon ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> secondChildRibbonTab;
       

        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            CustomRibbonTabs = new ObservableCollection<CustomRibbonTab>();
            FirstChildRibbonTab = new ObservableCollection<CustomRibbonTab>();
            SecondChildRibbonTab = new ObservableCollection<CustomRibbonTab>();
            modeMDICommand = new DelegateCommand<object>(ActionMDI);
            modeTDICommand = new DelegateCommand<object>(ActionTDI);
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);
            PopulateRibbonTabs();
            PopulateFirstChildRibbonTabs();
            PopulateSecondChildRibbonTabs();
        }

        /// <summary>
        /// Gets or sets the collection of ribbon tabs <see cref="ViewModel"/> class.
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
                RaisePropertyChanged("CustomRibbonTabs");
            }
        }

        /// <summary>
        /// Gets or sets the collection of firstChildRibbon ribbon tabs <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<CustomRibbonTab> FirstChildRibbonTab
        {
            get
            {
                return firstChildRibbonTab;
            }
            set
            {
                if (firstChildRibbonTab != value)
                    firstChildRibbonTab = value;
                RaisePropertyChanged("FirstChildRibbonTab");
            }
        }

        /// <summary>
        /// Gets or sets the collection of secondChildRibbon ribbon tabs <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<CustomRibbonTab> SecondChildRibbonTab
        {
            get
            {
                return secondChildRibbonTab;
            }
            set
            {
                if (secondChildRibbonTab != value)
                    secondChildRibbonTab = value;
                RaisePropertyChanged("SecondChildRibbonTab");
            }
        }

        /// <summary>
        /// Gets and sets the document mode <see cref="ViewModel"/> class.
        /// </summary>
        public DocumentContainerMode DocMode
        {
            get { return mode; }
            set
            {
                mode = value;
                RaisePropertyChanged("DocMode");
            }
        }  

        /// <summary>
        /// Gets or sets the MDI command <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand MDICommand
        {
            get { return modeMDICommand; }
        }

        /// <summary>
        /// Gets or sets the TDI command <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand TDICommand
        {
            get { return modeTDICommand; }
        }

        /// <summary>
        /// Gets or sets the command for button <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand { get { return buttonCommand; } }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand DropDownCommand { get { return dropdownCommand; } }

        /// <summary>
        /// Action takes place for the relevent mode.
        /// </summary>
        /// <param name="parameter"></param>
        public void ActionTDI(object parameter)
        {
            DocMode = DocumentContainerMode.TDI;
        }
            
        /// <summary>
        /// Action takes place for the relevent mode.
        /// </summary>
        /// <param name="parameter"></param>
        public void ActionMDI(object parameter)
        {
            DocMode = DocumentContainerMode.MDI;
        }
           
        /// <summary>
        /// Adding ribbon tabs to the control.
        /// </summary>
        private void PopulateFirstChildRibbonTabs()
        {
            CustomRibbonTab firstTab = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab secondTab = new CustomRibbonTab() { TabHeader = "Design" };
            PopulateChildHomeBar(firstTab);
            PopulateDesignBar(secondTab);
            FirstChildRibbonTab.Add(firstTab);
            FirstChildRibbonTab.Add(secondTab);
        }

        /// <summary>
        /// Populating ribbon items to the ribbon bar.
        /// </summary>
        /// <param name="customRibbonTab">Ribbontab.</param>
        private void PopulateDesignBar(CustomRibbonTab customRibbonTab)
        {
            CustomRibbonBar firstBar = new CustomRibbonBar() { BarHeader = "Table Style Options" };
            PopulateDesignItems(firstBar);
            customRibbonTab.CustomFirstChildRibbonBars.Add(firstBar);
        }

        /// <summary>
        /// Adding ribbon design items items to the ribbon bar.
        /// </summary>
        /// <param name="customRibbonBar">Ribbonbar.</param>
        private void PopulateDesignItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Header Row", IsCheckBox=true, Checked=true};
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Total Row", IsCheckBox=true, Checked=false};
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Banded Row", IsCheckBox=true, Checked=true};
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "First Column", IsCheckBox = true, Checked = true };
            CustomRibbonItem fifthItem = new CustomRibbonItem() { ItemHeader = "Last Column", IsCheckBox = true, Checked = false };
            CustomRibbonItem sixthItem = new CustomRibbonItem() { ItemHeader = "Banded Column", IsCheckBox = true, Checked = false };

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
            customRibbonBar.CustomRibbonItems.Add(fourthItem);
            customRibbonBar.CustomRibbonItems.Add(fifthItem);
            customRibbonBar.CustomRibbonItems.Add(sixthItem);
        }

        /// <summary>
        /// Populating child ribbon bar inside the parent bar.
        /// </summary>
        /// <param name="customRibbonTab">Child ribbon tab.</param>
        private void PopulateChildHomeBar(CustomRibbonTab customRibbonTab)
        {
            CustomRibbonBar firstBar = new CustomRibbonBar() { BarHeader = "Editing" };
            CustomRibbonBar secondBar = new CustomRibbonBar() { BarHeader = "Paragraph" };
            PopulateEditingItems(firstBar);
            PopulateParagraphItems(secondBar);
            customRibbonTab.CustomFirstChildRibbonBars.Add(firstBar);
            customRibbonTab.CustomFirstChildRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// Adding ribbon items to the child(Editing) ribbon bar.
        /// </summary>
        /// <param name="customRibbonBar">Child ribbon tab.</param>
        private void PopulateEditingItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Find", Image = "Search.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Replace", Image = "replace_32.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Select", Image = "start2.png",Command= ButtonCommand };

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
        }

        /// <summary>
        /// Adding ribbon items to the child(paragraph) ribbon bar.
        /// </summary>
        /// <param name="customRibbonBar">Child ribbon tab.</param>
        private void PopulateParagraphItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { Image = "Bullets16.png" ,Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() {  Image = "AlignTextLeft16.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() {  Image = "DecreaseIndent16.png",Command= ButtonCommand };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { Image = "Numbering16.png",Command= ButtonCommand };
            CustomRibbonItem fifthItem = new CustomRibbonItem() {  Image = "AlignTextCenter16.png",Command= ButtonCommand };
            CustomRibbonItem sixthItem = new CustomRibbonItem() {  Image = "IncreaseIndent16.png",Command= ButtonCommand };
            CustomRibbonItem seventhItem = new CustomRibbonItem() { Image = "MultilevelList16.png",Command= ButtonCommand };
            CustomRibbonItem eigthItem = new CustomRibbonItem() {  Image = "AlignTextRight16.png",Command= ButtonCommand };
            CustomRibbonItem ninthItem = new CustomRibbonItem() { Image = "LineSpacing16.png",Command= ButtonCommand };

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
            customRibbonBar.CustomRibbonItems.Add(fourthItem);
            customRibbonBar.CustomRibbonItems.Add(fifthItem);
            customRibbonBar.CustomRibbonItems.Add(sixthItem);
            customRibbonBar.CustomRibbonItems.Add(seventhItem);
            customRibbonBar.CustomRibbonItems.Add(eigthItem);
            customRibbonBar.CustomRibbonItems.Add(ninthItem);
        }

        /// <summary>
        /// Allocating tabs to the child2ribbon ber.
        /// </summary>
        private void PopulateSecondChildRibbonTabs()
        {
            CustomRibbonTab firstTab = new CustomRibbonTab() { TabHeader = "Mailings" , MergeOrder= 1 };
            CustomRibbonTab secondTab = new CustomRibbonTab() { TabHeader = "Print" };
            PopulateMailingsBars(firstTab);
            PopulatePrintBars(secondTab);
            SecondChildRibbonTab.Add(firstTab);
            SecondChildRibbonTab.Add(secondTab);
        }

        /// <summary>
        /// Allocating ribbon bars inside the secondChildRibbon ribbon  tab.
        /// </summary>
        /// <param name="Tab">Specifies the ribbon tab.</param>
        private void PopulatePrintBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar firstBar = new CustomRibbonBar() { BarHeader = "Print" };
            PopulatePrintItems(firstBar);
            CustomRibbonBar secondBar = new CustomRibbonBar() { BarHeader = "Zoom" };
            PopuplateZoomItems(secondBar);
            Tab.CustomSecondChildRibbonBars.Add(firstBar);
            Tab.CustomSecondChildRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// Adding ribbon items to the first ribbon bar(Print).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulatePrintItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Print", IsLarge = true, Image = "PrintAreaflat.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Options", IsLarge = true, Image = "View Setting.png" ,Command= ButtonCommand };
            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
        }

        /// <summary>
        /// Adding ribbon items to the second ribbon bar(Zoom).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopuplateZoomItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "100%", IsLarge = true, Image = "portrait.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "One Page", Image = "Team Email.png",Command= ButtonCommand };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Two Pages", Image = "Reading Pane.png",Command= ButtonCommand };
            CustomRibbonItem fifthItem = new CustomRibbonItem() { ItemHeader = "Page Width", Image = "Reading Pane.png" ,Command= ButtonCommand };
            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
            customRibbonBar.CustomRibbonItems.Add(fourthItem);
            customRibbonBar.CustomRibbonItems.Add(fifthItem);
        }

        /// <summary>
        /// Allocating ribbon bars to secong ribbon tab inside the child2ribbon tabs.
        /// </summary>
        /// <param name="Tab">Specifies the ribbon tab.</param>
        private void PopulateMailingsBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar firstBar = new CustomRibbonBar() { BarHeader = "Create" };
            PopulateCreateItems(firstBar);
            CustomRibbonBar secondBar = new CustomRibbonBar() { BarHeader = "Mail" };
            PopuplateRibbonMailItems(secondBar);
            Tab.CustomSecondChildRibbonBars.Add(firstBar);
            Tab.CustomSecondChildRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// Adding ribbon items to the first ribbon bar(Create items) inside the secondChildRibbon ribbon tabs.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar</param>
        private void PopulateCreateItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Envelopes", IsLarge = true, Image = "Read unread.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Labels", IsLarge = true, Image = "Send and recive all folder.png",Command= ButtonCommand };
            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
        }

        /// <summary>
        /// Adding ribbon items to the second ribbon bar(Mail items) inside the secondChildRibbon ribbon tabs.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar</param>
        private void PopuplateRibbonMailItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Attach File", IsLarge = true, Image = "base_paperclip_32.png", IsDropDownButton = true };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Business card", IsLarge = true, Image = "base_business_contacts.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Audio", IsLarge = true, Image = "base_speaker_32.png",Command= ButtonCommand };

            PopulateAttachFileItems(firstItem);

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
        }

        /// <summary>
        /// Adding ribbon tabs to the main ribbon window.
        /// </summary>
        void PopulateRibbonTabs()
        {
            CustomRibbonTab firstTab = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab secondTab = new CustomRibbonTab() { TabHeader = "Insert" };
            PopulateRibbonHomeBars(firstTab);
            PopulateRibbonInsertBars(secondTab);
            CustomRibbonTabs.Add(firstTab);
            CustomRibbonTabs.Add(secondTab);
        }

        /// <summary>
        /// Adding child ribbon bars to the ribbon tab(Home).
        /// </summary>
        /// <param name="Tab">Specifies the ribbon bar</param>
        void PopulateRibbonHomeBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar firstBar = new CustomRibbonBar() { BarHeader = "Clipboard" };
            CustomRibbonBar secondBar = new CustomRibbonBar() { BarHeader = "MDI Styles" };
            PopulateRibbonNewItems(firstBar);
            PopulateMDIItems(secondBar);
            Tab.CustomRibbonBars.Add(firstBar);
            Tab.CustomRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// populate ribbon items(MDI items) to the ribbon bars(Home).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar</param>
        private void PopulateMDIItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "MDI", Image = "MDI_blue.png", Command=MDICommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "TDI", Image = "Tabblue.png", Command=TDICommand };
            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
        }

        /// <summary>
        /// Populate ribbon items (New items) to the ribbon bar(Home).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        void PopulateRibbonNewItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Paste", IsLarge = true, Image = "Paste32.png", Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Cut", Image = "Cut16.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Copy", Image = "Copy16.png",Command= ButtonCommand };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Format Painter", Image = "FormatPainter16.png",Command= ButtonCommand };

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
            customRibbonBar.CustomRibbonItems.Add(fourthItem);
        }

        /// <summary>
        /// Adding ribbon bars to the ribbon tab.
        /// </summary>
        /// <param name="Tab">Specifies the ribbon bar.</param>
        void PopulateRibbonInsertBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar firstBar = new CustomRibbonBar() { BarHeader = "Table" };
            CustomRibbonBar secondBar = new CustomRibbonBar() { BarHeader = "Illustrations" };
            CustomRibbonBar thirdBar = new CustomRibbonBar() { BarHeader = "Links" };
            PopulateRibbonTableItems(firstBar);
            PopulateRibbonIllustrationsItems(secondBar);
            PopulateRibbonLinkItems(thirdBar);
            Tab.CustomRibbonBars.Add(firstBar);
            Tab.CustomRibbonBars.Add(secondBar);
            Tab.CustomRibbonBars.Add(thirdBar);
        }

        /// <summary>
        /// populate ribbon items (illustration) to the insert tab.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulateRibbonIllustrationsItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Picture", IsLarge = true, Image = "Picture.png",Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Comment", IsLarge = true, Image = "0356_NewComment_32.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Shapes", IsLarge = true, IsDropDownButton=true, Image = "0202_InsertShape_32.png" };
            CustomRibbonItem fourthItem = new CustomRibbonItem() { ItemHeader = "Chart", IsLarge = true, IsDropDownButton=true, Image = "base_charts.png" };

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
            customRibbonBar.CustomRibbonItems.Add(fourthItem);

            PopulateShapeDropDownItems(thirdItem);
            PopulateChartDropDownItems(fourthItem);
        }

        /// <summary>
        /// Populate ribbon items (link items to the insert tab.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulateRibbonLinkItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, Image = "Hyperlink32.png" , Command= ButtonCommand };
            CustomRibbonItem secondItem = new CustomRibbonItem() { ItemHeader = "Replace", IsLarge = true, Image = "replace_32.png",Command= ButtonCommand };
            CustomRibbonItem thirdItem = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png",Command= ButtonCommand };

            customRibbonBar.CustomRibbonItems.Add(firstItem);
            customRibbonBar.CustomRibbonItems.Add(secondItem);
            customRibbonBar.CustomRibbonItems.Add(thirdItem);
        }

        /// <summary>
        /// Adding ribbon tables to the ribbon tab (insert).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulateRibbonTableItems(CustomRibbonBar customRibbonBar)
        {
            CustomRibbonItem firstItem = new CustomRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, Image = "Table_32.png" ,HasTablePicker=true};

            customRibbonBar.CustomRibbonItems.Add(firstItem);
        }

        /// <summary>
        /// Adding items to shape dropdown button
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown items.</param>
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
        /// <param name="customRibbonItem">Specifies the dropdown items.</param>
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
        /// Adding items to attach file dropdown button
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown items.</param>
        private void PopulateAttachFileItems(CustomRibbonItem customRibbonItem)
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
