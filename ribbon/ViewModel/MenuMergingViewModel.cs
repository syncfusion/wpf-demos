#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace syncfusion.ribbondemos.wpf
{ 
    /// <summary>
    /// Represents the viewmodel.
    /// </summary>
    public class MenuMergingViewModel :NotificationObject
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
        ///  Maintains the collection of ribbon tabs.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonTab> customRibbonTabs;

        /// <summary>
        ///  Maintains the collection of firstChildRibbon ribbon tabs.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonTab> firstChildRibbonTab;

        /// <summary>
        ///  Maintains the collection of secondChildRibbon ribbon tabs.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonTab> secondChildRibbonTab;

        /// <summary>
        /// Holds the required resouces for IconTemplate.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MenuMergingViewModel" /> class.
        /// </summary>
        public MenuMergingViewModel()
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.ribbondemos.wpf;component/Assets/Ribbon/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
            ModelRibbonTab = new ObservableCollection<MenuMergingRibbonTab>();
            FirstChildRibbonTab = new ObservableCollection<MenuMergingRibbonTab>();
            SecondChildRibbonTab = new ObservableCollection<MenuMergingRibbonTab>();
            modeMDICommand = new DelegateCommand<object>(ActionMDI);
            modeTDICommand = new DelegateCommand<object>(ActionTDI);
            PopulateRibbonTabs();
            PopulateFirstChildRibbonTabs();
            PopulateSecondChildRibbonTabs();
        }

        /// <summary>
        /// Gets or sets the collection of ribbon tabs <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonTab> ModelRibbonTab
        {
            get
            {
                return customRibbonTabs;
            }
            set
            {
                if (customRibbonTabs != value)
                    customRibbonTabs = value;
                RaisePropertyChanged("ModelRibbonTab");
            }
        }

        /// <summary>
        /// Gets or sets the collection of firstChildRibbon ribbon tabs <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonTab> FirstChildRibbonTab
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
        /// Gets or sets the collection of secondChildRibbon ribbon tabs <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonTab> SecondChildRibbonTab
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
        /// Gets and sets the document mode <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public DocumentContainerMode DocumentMode
        {
            get { return mode; }
            set
            {
                mode = value;
                RaisePropertyChanged("DocumentMode");
            }
        }  

        /// <summary>
        /// Gets or sets the MDI command <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand MDICommand
        {
            get
            {
                return modeMDICommand;
            }
        }

        /// <summary>
        /// Gets or sets the TDI command <see cref="MenuMergingViewModel"/> class.
        /// </summary>
        public ICommand TDICommand
        {
            get
            {
                return modeTDICommand;
            }
        }

        /// <summary>
        /// Action takes place for the relevent mode.
        /// </summary>
        /// <param name="parameter"></param>
        public void ActionTDI(object parameter)
        {
            DocumentMode = DocumentContainerMode.TDI;
        }
            
        /// <summary>
        /// Action takes place for the relevent mode.
        /// </summary>
        /// <param name="parameter"></param>
        public void ActionMDI(object parameter)
        {
            DocumentMode = DocumentContainerMode.MDI;
        }
           
        /// <summary>
        /// Adding ribbon tabs to the control.
        /// </summary>
        private void PopulateFirstChildRibbonTabs()
        {
            MenuMergingRibbonTab firstTab = new MenuMergingRibbonTab() { TabHeader = "Home" };
            MenuMergingRibbonTab secondTab = new MenuMergingRibbonTab() { TabHeader = "Design" };
            PopulateChildHomeBar(firstTab);
            PopulateDesignBar(secondTab);
            FirstChildRibbonTab.Add(firstTab);
            FirstChildRibbonTab.Add(secondTab);
        }

        /// <summary>
        /// Populating ribbon items to the ribbon bar.
        /// </summary>
        /// <param name="customRibbonTab">Ribbontab.</param>
        private void PopulateDesignBar(MenuMergingRibbonTab customRibbonTab)
        {
            MenuMergingRibbonBar firstBar = new MenuMergingRibbonBar() { BarHeader = "Table Style Options" };
            PopulateDesignItems(firstBar);
            customRibbonTab.CustomFirstChildRibbonBars.Add(firstBar);
        }

        /// <summary>
        /// Adding ribbon design items items to the ribbon bar.
        /// </summary>
        /// <param name="customRibbonBar">Ribbonbar.</param>
        private void PopulateDesignItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Header Row", IsCheckBox=true, Checked=true};
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Total Row", IsCheckBox=true, Checked=false};
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "Banded Row", IsCheckBox=true, Checked=true};
            MenuMergingRibbonItem fourthItem = new MenuMergingRibbonItem() { ItemHeader = "First Column", IsCheckBox = true, Checked = true };
            MenuMergingRibbonItem fifthItem = new MenuMergingRibbonItem() { ItemHeader = "Last Column", IsCheckBox = true, Checked = false };
            MenuMergingRibbonItem sixthItem = new MenuMergingRibbonItem() { ItemHeader = "Banded Column", IsCheckBox = true, Checked = false };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
            customRibbonBar.ModelTabRibbonItem.Add(fourthItem);
            customRibbonBar.ModelTabRibbonItem.Add(fifthItem);
            customRibbonBar.ModelTabRibbonItem.Add(sixthItem);
        }

        /// <summary>
        /// Populating child ribbon bar inside the parent bar.
        /// </summary>
        /// <param name="customRibbonTab">Child ribbon tab.</param>
        private void PopulateChildHomeBar(MenuMergingRibbonTab customRibbonTab)
        {
            MenuMergingRibbonBar firstBar = new MenuMergingRibbonBar() { BarHeader = "Editing" };
            MenuMergingRibbonBar secondBar = new MenuMergingRibbonBar() { BarHeader = "Paragraph" };
            PopulateEditingItems(firstBar);
            PopulateCreateBarItems(secondBar);
            customRibbonTab.CustomFirstChildRibbonBars.Add(firstBar);
            customRibbonTab.CustomFirstChildRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// Adding ribbon items to the child(Editing) ribbon bar.
        /// </summary>
        /// <param name="customRibbonBar">Child ribbon tab.</param>
        private void PopulateEditingItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "One Page", ImageTemplate = CommonResourceDictionary["OnePage"] as DataTemplate, Command=RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Two Pages", ImageTemplate = CommonResourceDictionary["TwoPages"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "Page Width", ImageTemplate = CommonResourceDictionary["PageWidth"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding ribbon items to the child(paragraph) ribbon bar.
        /// </summary>
        /// <param name="customRibbonBar">Child ribbon tab.</param>
        private void PopulateCreateBarItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Envelope", IsLarge = true, ImageTemplate = CommonResourceDictionary["Mail"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Letter", IsLarge = true, ImageTemplate = CommonResourceDictionary["Letter"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
        }

        /// <summary>
        /// Allocating tabs to the child2ribbon ber.
        /// </summary>
        private void PopulateSecondChildRibbonTabs()
        {
            MenuMergingRibbonTab firstTab = new MenuMergingRibbonTab() { TabHeader = "Mailings" , MergeOrder= 1 };
            MenuMergingRibbonTab secondTab = new MenuMergingRibbonTab() { TabHeader = "Print" };
            PopulateMailingsBars(firstTab);
            PopulatePrintBars(secondTab);
            SecondChildRibbonTab.Add(firstTab);
            SecondChildRibbonTab.Add(secondTab);
        }

        /// <summary>
        /// Allocating ribbon bars inside the secondChildRibbon ribbon  tab.
        /// </summary>
        /// <param name="Tab">Specifies the ribbon tab.</param>
        private void PopulatePrintBars(MenuMergingRibbonTab Tab)
        {
            MenuMergingRibbonBar firstBar = new MenuMergingRibbonBar() { BarHeader = "Print" };
            PopulatePrintItems(firstBar);
            MenuMergingRibbonBar secondBar = new MenuMergingRibbonBar() { BarHeader = "Zoom" };
            PopuplateZoomItems(secondBar);
            Tab.CustomSecondChildRibbonBars.Add(firstBar);
            Tab.CustomSecondChildRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// Adding ribbon items to the first ribbon bar(Print).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulatePrintItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Print", IsLarge = true, ImageTemplate = CommonResourceDictionary["QuickPrint"] as DataTemplate, Command= RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
        }

        /// <summary>
        /// Adding ribbon items to the second ribbon bar(Zoom).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopuplateZoomItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Zoom", IsLarge = true, ImageTemplate = CommonResourceDictionary["Zoom"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "100%", IsLarge = true, ImageTemplate = CommonResourceDictionary["100%"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "One Page", ImageTemplate = CommonResourceDictionary["OnePage"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem fourthItem = new MenuMergingRibbonItem() { ItemHeader = "Two Pages", ImageTemplate = CommonResourceDictionary["TwoPages"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem fifthItem = new MenuMergingRibbonItem() { ItemHeader = "Page Width", ImageTemplate = CommonResourceDictionary["PageWidth"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
            customRibbonBar.ModelTabRibbonItem.Add(fourthItem);
            customRibbonBar.ModelTabRibbonItem.Add(fifthItem);
        }

        /// <summary>
        /// Allocating ribbon bars to secong ribbon tab inside the child2ribbon tabs.
        /// </summary>
        /// <param name="Tab">Specifies the ribbon tab.</param>
        private void PopulateMailingsBars(MenuMergingRibbonTab Tab)
        {
            MenuMergingRibbonBar firstBar = new MenuMergingRibbonBar() { BarHeader = "Link" };
            PopulateCreateItems(firstBar);
            MenuMergingRibbonBar secondBar = new MenuMergingRibbonBar() { BarHeader = "Mail" };
            PopuplateRibbonMailItems(secondBar);
            Tab.CustomSecondChildRibbonBars.Add(firstBar);
            Tab.CustomSecondChildRibbonBars.Add(secondBar);
        }

        /// <summary>
        /// Adding ribbon items to the first ribbon bar(Create items) inside the secondChildRibbon ribbon tabs.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar</param>
        private void PopulateCreateItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, ImageTemplate = CommonResourceDictionary["HyperLink"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Zoom", IsLarge = true, ImageTemplate = CommonResourceDictionary["Zoom"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
        }

        /// <summary>
        /// Adding ribbon items to the second ribbon bar(Mail items) inside the secondChildRibbon ribbon tabs.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar</param>
        private void PopuplateRibbonMailItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Attach File", IsLarge = true, ImageTemplate = CommonResourceDictionary["Attachment"] as DataTemplate, IsDropDownButton = true };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Business card", IsLarge = true, ImageTemplate = CommonResourceDictionary["BusinessCard"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "Audio", IsLarge = true, ImageTemplate = CommonResourceDictionary["Audio"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            PopulateAttachFileItems(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding ribbon tabs to the main ribbon window.
        /// </summary>
        void PopulateRibbonTabs()
        {
            MenuMergingRibbonTab firstTab = new MenuMergingRibbonTab() { TabHeader = "Home" };
            MenuMergingRibbonTab secondTab = new MenuMergingRibbonTab() { TabHeader = "Insert" };
            PopulateRibbonHomeBars(firstTab);
            PopulateRibbonInsertBars(secondTab);
            ModelRibbonTab.Add(firstTab);
            ModelRibbonTab.Add(secondTab);
        }

        /// <summary>
        /// Adding child ribbon bars to the ribbon tab(Home).
        /// </summary>
        /// <param name="Tab">Specifies the ribbon bar</param>
        void PopulateRibbonHomeBars(MenuMergingRibbonTab Tab)
        {
            MenuMergingRibbonBar firstBar = new MenuMergingRibbonBar() { BarHeader = "Clipboard" };
            MenuMergingRibbonBar secondBar = new MenuMergingRibbonBar() { BarHeader = "MDI Styles" };
            PopulateRibbonNewItems(firstBar);
            PopulateMDIItems(secondBar);
            Tab.ModelTabRibbonBar.Add(firstBar);
            Tab.ModelTabRibbonBar.Add(secondBar);
        }

        /// <summary>
        /// populate ribbon items(MDI items) to the ribbon bars(Home).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar</param>
        private void PopulateMDIItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "MDI", ImageTemplate = CommonResourceDictionary["TwoPages"] as DataTemplate, Command=MDICommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "TDI", ImageTemplate = CommonResourceDictionary["OnePage"] as DataTemplate, Command=TDICommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
        }

        /// <summary>
        /// Populate ribbon items (New items) to the ribbon bar(Home).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        void PopulateRibbonNewItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Paste", IsLarge = true, ImageTemplate = CommonResourceDictionary["Paste"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Cut", ImageTemplate = CommonResourceDictionary["Cut"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "Copy", ImageTemplate = CommonResourceDictionary["Copy"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem fourthItem = new MenuMergingRibbonItem() { ItemHeader = "Format Painter", ImageTemplate = CommonResourceDictionary["FormatPainter"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
            customRibbonBar.ModelTabRibbonItem.Add(fourthItem);
        }

        /// <summary>
        /// Adding ribbon bars to the ribbon tab.
        /// </summary>
        /// <param name="Tab">Specifies the ribbon bar.</param>
        void PopulateRibbonInsertBars(MenuMergingRibbonTab Tab)
        {
            MenuMergingRibbonBar firstBar = new MenuMergingRibbonBar() { BarHeader = "Table" };
            MenuMergingRibbonBar secondBar = new MenuMergingRibbonBar() { BarHeader = "Illustrations" };
            MenuMergingRibbonBar thirdBar = new MenuMergingRibbonBar() { BarHeader = "Links" };
            PopulateRibbonTableItems(firstBar);
            PopulateRibbonIllustrationsItems(secondBar);
            PopulateRibbonLinkItems(thirdBar);
            Tab.ModelTabRibbonBar.Add(firstBar);
            Tab.ModelTabRibbonBar.Add(secondBar);
            Tab.ModelTabRibbonBar.Add(thirdBar);
        }

        /// <summary>
        /// populate ribbon items (illustration) to the insert tab.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulateRibbonIllustrationsItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Picture", IsLarge = true, ImageTemplate = CommonResourceDictionary["Picture"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem secondItem = new MenuMergingRibbonItem() { ItemHeader = "Comment", IsLarge = true, ImageTemplate = CommonResourceDictionary["Comment"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "Shapes", IsLarge = true, IsDropDownButton = true, ImageTemplate = CommonResourceDictionary["Shapes"] as DataTemplate };
            MenuMergingRibbonItem fourthItem = new MenuMergingRibbonItem() { ItemHeader = "Chart", IsLarge = true, IsDropDownButton = true, ImageTemplate = CommonResourceDictionary["Charts"] as DataTemplate };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(secondItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
            customRibbonBar.ModelTabRibbonItem.Add(fourthItem);
            PopulateShapeDropDownItems(thirdItem);
            PopulateChartDropDownItems(fourthItem);
        }

        /// <summary>
        /// Populate ribbon items (link items to the insert tab.
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulateRibbonLinkItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, ImageTemplate = CommonResourceDictionary["HyperLink"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            MenuMergingRibbonItem thirdItem = new MenuMergingRibbonItem() { ItemHeader = "Zoom", IsLarge = true, ImageTemplate = CommonResourceDictionary["Zoom"] as DataTemplate, Command = RibbonCommand.ButtonCommand };
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
            customRibbonBar.ModelTabRibbonItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding ribbon tables to the ribbon tab (insert).
        /// </summary>
        /// <param name="customRibbonBar">Specifies the ribbon bar.</param>
        private void PopulateRibbonTableItems(MenuMergingRibbonBar customRibbonBar)
        {
            MenuMergingRibbonItem firstItem = new MenuMergingRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, ImageTemplate = CommonResourceDictionary["Tables"] as DataTemplate, HasTablePicker=true};
            customRibbonBar.ModelTabRibbonItem.Add(firstItem);
        }

        /// <summary>
        /// Adding items to shape dropdown button
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown items.</param>
        private void PopulateShapeDropDownItems(MenuMergingRibbonItem customRibbonItem)
        {
            MenuMergingDropDownItem firstItem = new MenuMergingDropDownItem() { Name = "Square", ImageTemplate = CommonResourceDictionary["Square"] as DataTemplate };
            MenuMergingDropDownItem secondItem = new MenuMergingDropDownItem() { Name = "Circle", ImageTemplate = CommonResourceDictionary["Circle"] as DataTemplate };
            MenuMergingDropDownItem thirdItem = new MenuMergingDropDownItem() { Name = "Rhombus", ImageTemplate = CommonResourceDictionary["Rhombus"] as DataTemplate };
            customRibbonItem.ModelTabDropDownItem.Add(firstItem);
            customRibbonItem.ModelTabDropDownItem.Add(secondItem);
            customRibbonItem.ModelTabDropDownItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding items to chart dropdown button.
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown items.</param>
        private void PopulateChartDropDownItems(MenuMergingRibbonItem customRibbonItem)
        {
            MenuMergingDropDownItem firstItem = new MenuMergingDropDownItem() { Name = "Horizontal Bar", ImageTemplate = CommonResourceDictionary["HorizontalBar"] as DataTemplate };
            MenuMergingDropDownItem secondItem = new MenuMergingDropDownItem() { Name = "Vertical Bar", ImageTemplate = CommonResourceDictionary["VerticalBar"] as DataTemplate };
            MenuMergingDropDownItem thirdItem = new MenuMergingDropDownItem() { Name = "Pie", ImageTemplate = CommonResourceDictionary["Pie"] as DataTemplate };
            customRibbonItem.ModelTabDropDownItem.Add(firstItem);
            customRibbonItem.ModelTabDropDownItem.Add(secondItem);
            customRibbonItem.ModelTabDropDownItem.Add(thirdItem);
        }

        /// <summary>
        /// Adding items to attach file dropdown button
        /// </summary>
        /// <param name="customRibbonItem">Specifies the dropdown items.</param>
        private void PopulateAttachFileItems(MenuMergingRibbonItem customRibbonItem)
        {
            MenuMergingDropDownItem firstItem = new MenuMergingDropDownItem() { Name = "DOC", ImageTemplate = CommonResourceDictionary["DOC"] as DataTemplate };
            MenuMergingDropDownItem secondItem = new MenuMergingDropDownItem() { Name = "PDF", ImageTemplate = CommonResourceDictionary["PDF"] as DataTemplate };
            MenuMergingDropDownItem thirdItem = new MenuMergingDropDownItem() { Name = "ZIP", ImageTemplate = CommonResourceDictionary["ZIP"] as DataTemplate };
            MenuMergingDropDownItem fourthItem = new MenuMergingDropDownItem() { Name = "XLS", ImageTemplate = CommonResourceDictionary["XLS"] as DataTemplate };
            customRibbonItem.ModelTabDropDownItem.Add(firstItem);
            customRibbonItem.ModelTabDropDownItem.Add(secondItem);
            customRibbonItem.ModelTabDropDownItem.Add(thirdItem);
            customRibbonItem.ModelTabDropDownItem.Add(fourthItem);
        }
    }
}
