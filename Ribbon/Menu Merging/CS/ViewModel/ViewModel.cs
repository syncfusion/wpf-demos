#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace RibbonMenuMerging
{ 
    /// <summary>
    /// Represents the viewmodel.
    /// </summary>
    public class ViewModel :INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        ///  Maintains the collection of ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customRibbonTabs;

        /// <summary>
        ///  Maintains the collection of child1 ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customChild1RibbonTabs;

        /// <summary>
        ///  Maintains the collection of child2 ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customChild2RibbonTabs;
        /// <summary>
        ///  Maintains the Ribbon.
        /// </summary>

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the collection of ribbon tabs .
        /// </summary>
        [Category("Summary")]
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
        /// Gets or sets the collection of child1 ribbon tabs.
        /// </summary>
        public ObservableCollection<CustomRibbonTab> CustomChild1RibbonTabs
        {
            get
            {
                return customChild1RibbonTabs;
            }
            set
            {
                if (customChild1RibbonTabs != value)
                    customChild1RibbonTabs = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of child2 ribbon tabs.
        /// </summary>
        public ObservableCollection<CustomRibbonTab> CustomChild2RibbonTabs
        {
            get
            {
                return customChild2RibbonTabs;
            }
            set
            {
                if (customChild2RibbonTabs != value)
                    customChild2RibbonTabs = value;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            CustomRibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild1RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild2RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            PopulateRibbonTabs();
            PopulateChild1RibbonTabs();
            PopulateChild2RibbonTabs();
        }
        #endregion

        #region Command

        /// <summary>
        /// Maintains the type of command modes.
        /// </summary>
        private DocumentContainerMode mode;

        /// <summary>
        /// Maintains the command for modes.
        /// </summary>
        private ICommand modeCommand;

        /// <summary>
        /// Gets and sets the document mode.
        /// </summary>
        public DocumentContainerMode DocMode
        {
            get { return mode; }
            set
            {
                mode = value;
                OnPropertyChanged("DocMode");
            }
        }

       /// <summary>
       /// Indicates the command for MDI.
       /// </summary>
        public ICommand MDICommand
        {
            get { return modeCommand ?? (modeCommand = new CommandHandler(true, () => MyAction("MDI"))); }
        }

        /// <summary>
        /// Maintains the command for TDI.
        /// </summary>
        private ICommand modeTDICommand;

        /// <summary>
        /// Initialize the event which Notifies when the selected item changes. 
        /// </summary>  
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Event handling method for notified changes.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        /// <summary>
        /// Method which is used to indicate the TDI command.
        /// </summary>
        public ICommand TDICommand
        {
            get { return modeTDICommand ?? (modeTDICommand = new CommandHandler(true, () => MyAction("TDI"))); }
        }

        /// <summary>
        /// Action takes place for the relevent mode.
        /// </summary>
        /// <param name="parameter"></param>
        public void MyAction(string parameter)
        {
           if(parameter.Equals("TDI"))
            {
                DocMode = DocumentContainerMode.TDI;
            }
           else
            {
                DocMode = DocumentContainerMode.MDI;
            }
        }
        #endregion

        #region Child Ribbon1
        /// <summary>
        /// Adding ribbon tabs to the control.
        /// </summary>
        private void PopulateChild1RibbonTabs()
        {
            CustomRibbonTab Tab1 = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab Tab2 = new CustomRibbonTab() { TabHeader = "Design" };
            PopulateChildHomeBar(Tab1);
            PopulateDesignBar(Tab2);
            CustomChild1RibbonTabs.Add(Tab1);
            CustomChild1RibbonTabs.Add(Tab2);
        }

        /// <summary>
        /// Populating ribbon items to the ribbon bar.
        /// </summary>
        /// <param name="tab">Ribbontab.</param>
        private void PopulateDesignBar(CustomRibbonTab tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Table Style Options" };
            PopulateDesignItems(Bar1);
            tab.CustomChild1RibbonBars.Add(Bar1);
        }

        /// <summary>
        /// Adding ribbon design items items to the ribbon bar.
        /// </summary>
        /// <param name="Bar">Ribbonbar.</param>
        private void PopulateDesignItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Header Row", IsCheckBox=true, Checked=true};
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Total Row", IsCheckBox=true, Checked=false};
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Banded Row", IsCheckBox=true, Checked=true};
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "First Column", IsCheckBox = true, Checked = true };
            CustomRibbonItem Item5 = new CustomRibbonItem() { ItemHeader = "Last Column", IsCheckBox = true, Checked = false };
            CustomRibbonItem Item6 = new CustomRibbonItem() { ItemHeader = "Banded Column", IsCheckBox = true, Checked = false };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
            Bar.CustomRibbonItems.Add(Item5);
            Bar.CustomRibbonItems.Add(Item6);
        }

        /// <summary>
        /// Populating child ribbon bar inside the parent bar.
        /// </summary>
        /// <param name="tab">Child ribbon tab.</param>
        private void PopulateChildHomeBar(CustomRibbonTab tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Editing" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Paragraph" };
            PopulateEditingItems(Bar1);
            PopulateParagraphItems(Bar2);
            tab.CustomChild1RibbonBars.Add(Bar1);
            tab.CustomChild1RibbonBars.Add(Bar2);
        }

        /// <summary>
        /// Adding ribbon items to the child(Editing) ribbon bar.
        /// </summary>
        /// <param name="Bar">Child ribbon tab.</param>
        private void PopulateEditingItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Find", Image = "Search.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Replace", Image = "replace_32.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Select", Image = "start2.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
        }

        /// <summary>
        /// Adding ribbon items to the child(paragraph) ribbon bar.
        /// </summary>
        /// <param name="Bar">Child ribbon tab.</param>
        private void PopulateParagraphItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "", Image = "Bullets16.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "", Image = "AlignTextLeft16.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "", Image = "DecreaseIndent16.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "", Image = "Numbering16.png" };
            CustomRibbonItem Item5 = new CustomRibbonItem() { ItemHeader = "", Image = "AlignTextCenter16.png" };
            CustomRibbonItem Item6 = new CustomRibbonItem() { ItemHeader = "", Image = "IncreaseIndent16.png" };
            CustomRibbonItem Item7 = new CustomRibbonItem() { ItemHeader = "", Image = "MultilevelList16.png" };
            CustomRibbonItem Item8 = new CustomRibbonItem() { ItemHeader = "", Image = "AlignTextRight16.png" };
            CustomRibbonItem Item9 = new CustomRibbonItem() { ItemHeader = "", Image = "LineSpacing16.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
            Bar.CustomRibbonItems.Add(Item5);
            Bar.CustomRibbonItems.Add(Item6);
            Bar.CustomRibbonItems.Add(Item7);
            Bar.CustomRibbonItems.Add(Item8);
            Bar.CustomRibbonItems.Add(Item9);
        }
        #endregion

        #region Child Ribbon 2
        /// <summary>
        /// Allocating tabs to the child2ribbon ber.
        /// </summary>
        private void PopulateChild2RibbonTabs()
        {
            CustomRibbonTab Tab1 = new CustomRibbonTab() { TabHeader = "Mailings" , MergeOrder= 1 };
            CustomRibbonTab Tab2 = new CustomRibbonTab() { TabHeader = "Print" };
            PopulateMailingsBars(Tab1);
            PopulatePrintBars(Tab2);
            CustomChild2RibbonTabs.Add(Tab1);
            CustomChild2RibbonTabs.Add(Tab2);
        }

        /// <summary>
        /// Allocating ribbon bars inside the child2 ribbon  tab.
        /// </summary>
        /// <param name="Tab">Ribbon tab.</param>
        private void PopulatePrintBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Print" };
            PopulatePrintItems(Bar1);
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Zoom" };
            PopuplateZoomItems(Bar2);
            Tab.CustomChild2RibbonBars.Add(Bar1);
            Tab.CustomChild2RibbonBars.Add(Bar2);
        }

        /// <summary>
        /// Adding ribbon items to the first ribbon bar(Print).
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulatePrintItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Print", IsLarge = true, Image = "PrintAreaflat.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Options", IsLarge = true, Image = "View Setting.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

        /// <summary>
        /// Adding ribbon items to the second ribbon bar(Zoom).
        /// </summary>
        /// <param name="Bar">Ribbonbar.</param>
        private void PopuplateZoomItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "100%", IsLarge = true, Image = "portrait.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "One Page", Image = "Team Email.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "Two Pages", Image = "Reading Pane.png" };
            CustomRibbonItem Item5 = new CustomRibbonItem() { ItemHeader = "Page Width", Image = "Reading Pane.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
            Bar.CustomRibbonItems.Add(Item5);
        }

        /// <summary>
        /// Allocating ribbon bars to secong ribbon tab inside the child2ribbon tabs.
        /// </summary>
        /// <param name="Tab">Ribbon tab.</param>
        private void PopulateMailingsBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Create" };
            PopulateCreateItems(Bar1);
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Mail" };
            PopuplateRibbonMailItems(Bar2);
            Tab.CustomChild2RibbonBars.Add(Bar1);
            Tab.CustomChild2RibbonBars.Add(Bar2);
        }

        /// <summary>
        /// Adding ribbon items to the first ribbon bar(Create items) inside the child2 ribbon tabs.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateCreateItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Envelopes", IsLarge = true, Image = "Read unread.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Labels", IsLarge = true, Image = "Send and recive all folder.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

        /// <summary>
        /// Adding ribbon items to the second ribbon bar(Mail items) inside the child2 ribbon tabs.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopuplateRibbonMailItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Attach File", IsLarge = true, Image = "base_paperclip_32.png", IsSplitButton = true };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Business card", IsLarge = true, Image = "base_business_contacts.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Audio", IsLarge = true, Image = "base_speaker_32.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
        }
        #endregion

        #region Main Ribbon
        /// <summary>
        /// Adding ribbon tabs to the main ribbon window.
        /// </summary>
        void PopulateRibbonTabs()
        {
            CustomRibbonTab Tab1 = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab Tab2 = new CustomRibbonTab() { TabHeader = "Insert" };
            PopulateRibbonHomeBars(Tab1);
            PopulateRibbonInsertBars(Tab2);
            CustomRibbonTabs.Add(Tab1);
            CustomRibbonTabs.Add(Tab2);
        }

        #region Hometab
        /// <summary>
        /// Adding child ribbon bars to the ribbon tab(Home).
        /// </summary>
        /// <param name="Tab">Ribbon tab.</param>
        void PopulateRibbonHomeBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Clipboard" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "MDI Styles" };
            PopulateRibbonNewItems(Bar1);
            PopulateMDIItems(Bar2);
            Tab.CustomRibbonBars.Add(Bar1);
            Tab.CustomRibbonBars.Add(Bar2);
        }

        /// <summary>
        /// populate ribbon items(MDI items) to the ribbon bars(Home).
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateMDIItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "MDI", Image = "MDI_blue.png", Command=MDICommand };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "TDI", Image = "Tabblue.png", Command=TDICommand };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

        /// <summary>
        /// Populate ribbon items (New items) to the ribbon bar(Home).
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        void PopulateRibbonNewItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Paste", IsLarge = true, Image = "Paste32.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Cut", Image = "Cut16.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Copy", Image = "Copy16.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "Format Painter", Image = "FormatPainter16.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
        }
        #endregion

        #region Insert tab
        /// <summary>
        /// Adding ribbon bars to the ribbon tab.
        /// </summary>
        /// <param name="Tab">Ribbon tab.</param>
        void PopulateRibbonInsertBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Table" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Illustrations" };
            CustomRibbonBar Bar3 = new CustomRibbonBar() { BarHeader = "Links" };
            PopulateRibbonTableItems(Bar1);
            PopulateRibbonIllustrationsItems(Bar2);
            PopulateRibbonLinkItems(Bar3);
            Tab.CustomRibbonBars.Add(Bar1);
            Tab.CustomRibbonBars.Add(Bar2);
            Tab.CustomRibbonBars.Add(Bar3);
        }

        /// <summary>
        /// populate ribbon items (illustration) to the insert tab.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateRibbonIllustrationsItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Picture", IsLarge = true, Image = "Picture.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Comment", IsLarge = true, Image = "0356_NewComment_32.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Shapes", IsLarge = true, IsDropDownButton=true, Image = "0202_InsertShape_32.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "Chart", IsLarge = true, IsDropDownButton=true, Image = "base_charts.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
        }

        /// <summary>
        /// Populate ribbon items (link items to the insert tab.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateRibbonLinkItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, Image = "Hyperlink32.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Replace", IsLarge = true, Image = "replace_32.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
        }

        /// <summary>
        /// Adding ribbon tables to the ribbon tab (insert).
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateRibbonTableItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, Image = "Table_32.png" };

            Bar.CustomRibbonItems.Add(Item1);
        }
        #endregion

        #endregion
    }

    /// <summary>
    /// Command method to change the child ribbon models
    /// </summary>
    public class CommandHandler : ICommand
    {
        #region ICommand
        /// <summary>
        /// Commanding methods
        /// </summary>
        private bool _canexecute;

        /// <summary>
        /// Maintains the main action.
        /// </summary>
        private Action _action;

        /// <summary>
        /// Indicates the main command action.
        /// </summary>
        /// <param name="canexecute"></param>
        /// <param name="Action"></param>
        public CommandHandler(bool canexecute, Action Action)
        {
            _canexecute = canexecute;
            _action = Action;
        }

        /// <summary>
        /// Event handler for the command.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Indicates whether the method can execute.
        /// </summary>
        /// <param name="parameter">Indicates whether the command can execute.</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canexecute;
        }

        /// <summary>
        /// Method which is used to execute the command action
        /// </summary>
        /// <param name="parameter">Implements the command.</param>
        public void Execute(object parameter)
        {
            _action();
        }
        #endregion
    }
}
