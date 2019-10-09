#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
    public class ViewModel :INotifyPropertyChanged
    {
        public ObservableCollection<CustomRibbonTab> CustomRibbonTabs { get; set; }
        public ObservableCollection<CustomRibbonTab> CustomChild1RibbonTabs { get; set; }
        public ObservableCollection<CustomRibbonTab> CustomChild2RibbonTabs { get; set; }
        public ViewModel()
        {
            CustomRibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild1RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild2RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            PopulateRibbonTabs();
            PopulateChild1RibbonTabs();
            PopulateChild2RibbonTabs();
        }
        #region Command

        private DocumentContainerMode mode;

        public DocumentContainerMode DocMode
        {
            get { return mode; }
            set
            {
                mode = value;
                OnPropertyChanged("DocMode");
            }
        }

        private ICommand modeCommand;

        public ICommand MDICommand
        {
            get { return modeCommand ?? (modeCommand = new CommandHandler(true, () => MyAction("MDI"))); }
        }

        private ICommand modeTDICommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand TDICommand
        {
            get { return modeTDICommand ?? (modeTDICommand = new CommandHandler(true, () => MyAction("TDI"))); }
        }

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
        private void PopulateChild1RibbonTabs()
        {
            CustomRibbonTab Tab1 = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab Tab2 = new CustomRibbonTab() { TabHeader = "Design" };
            PopulateChildHomeBar(Tab1);
            PopulateDesignBar(Tab2);
            CustomChild1RibbonTabs.Add(Tab1);
            CustomChild1RibbonTabs.Add(Tab2);
        }

        private void PopulateDesignBar(CustomRibbonTab tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Table Style Options" };
            PopulateDesignItems(Bar1);
            tab.CustomChild1RibbonBars.Add(Bar1);
        }

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

        private void PopulateChildHomeBar(CustomRibbonTab tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Editing" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Paragraph" };
            PopulateEditingItems(Bar1);
            PopulateParagraphItems(Bar2);
            tab.CustomChild1RibbonBars.Add(Bar1);
            tab.CustomChild1RibbonBars.Add(Bar2);
        }

        private void PopulateEditingItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Find", Image = "Search.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Replace", Image = "replace_32.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Select", Image = "start2.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
        }
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
        private void PopulateChild2RibbonTabs()
        {
            CustomRibbonTab Tab1 = new CustomRibbonTab() { TabHeader = "Mailings" , MergeOrder= 1 };
            CustomRibbonTab Tab2 = new CustomRibbonTab() { TabHeader = "Print" };
            PopulateMailingsBars(Tab1);
            PopulatePrintBars(Tab2);
            CustomChild2RibbonTabs.Add(Tab1);
            CustomChild2RibbonTabs.Add(Tab2);
        }

        private void PopulatePrintBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Print" };
            PopulatePrintItems(Bar1);
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Zoom" };
            PopuplateZoomItems(Bar2);
            Tab.CustomChild2RibbonBars.Add(Bar1);
            Tab.CustomChild2RibbonBars.Add(Bar2);
        }

        private void PopulatePrintItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Print", IsLarge = true, Image = "PrintAreaflat.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Options", IsLarge = true, Image = "View Setting.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

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

        private void PopulateMailingsBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Create" };
            PopulateCreateItems(Bar1);
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Mail" };
            PopuplateRibbonMailItems(Bar2);
            Tab.CustomChild2RibbonBars.Add(Bar1);
            Tab.CustomChild2RibbonBars.Add(Bar2);
        }

        private void PopulateCreateItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Envelopes", IsLarge = true, Image = "Read unread.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Labels", IsLarge = true, Image = "Send and recive all folder.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

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
        void PopulateRibbonTabs()
        {
            CustomRibbonTab Tab1 = new CustomRibbonTab() { TabHeader = "Home" };
            CustomRibbonTab Tab2 = new CustomRibbonTab() { TabHeader = "Insert" };
            PopulateRibbonHomeBars(Tab1);
            PopulateRibbonInsertBars(Tab2);
            CustomRibbonTabs.Add(Tab1);
            CustomRibbonTabs.Add(Tab2);
        }

 

        //Home Tab
        void PopulateRibbonHomeBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Clipboard" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "MDI Styles" };
            PopulateRibbonNewItems(Bar1);
            PopulateMDIItems(Bar2);
            Tab.CustomRibbonBars.Add(Bar1);
            Tab.CustomRibbonBars.Add(Bar2);
        }

        private void PopulateMDIItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "MDI", Image = "MDI_blue.png", Command=MDICommand };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "TDI", Image = "Tabblue.png", Command=TDICommand };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

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

        //Insert Tab
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

        private void PopulateRibbonLinkItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Hyperlink", IsLarge = true, Image = "Hyperlink32.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Replace", IsLarge = true, Image = "replace_32.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
        }
        private void PopulateRibbonTableItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, Image = "Table_32.png" };

            Bar.CustomRibbonItems.Add(Item1);
        }
        #endregion
    }

    public class CommandHandler : ICommand
    {
        private bool _canexecute;
        private Action _action;
        public CommandHandler(bool canexecute, Action Action)
        {
            _canexecute = canexecute;
            _action = Action;
        }


        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            return _canexecute;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
