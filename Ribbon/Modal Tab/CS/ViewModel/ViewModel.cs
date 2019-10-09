#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RibbonModelTab
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<CustomRibbonTab> CustomRibbonTabs { get; set; }
        public ObservableCollection<CustomRibbonTab> CustomChild1RibbonTabs { get; set; }
        public ObservableCollection<CustomRibbonTab> CustomChild2RibbonTabs { get; set; }
        

        private Ribbon Ribbon;
        public ViewModel(Ribbon ribbon)
        {
            this.Ribbon = ribbon;
            CustomRibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild1RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild2RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            PopulateRibbonTabs();
           
        }
        #region Command


        private ICommand modeModalCommand;
        private ICommand closeModalCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand ModalCommand
        {
            get { return modeModalCommand ?? (modeModalCommand = new CommandHandler(true, () => MyAction("Modal"))); }
        }

        public ICommand CloseModalCommand
        {
            get { return closeModalCommand ?? (closeModalCommand = new CommandHandler(true, () => MyAction("CloseModal"))); }
        }

        public void MyAction(string parameter)
        {
            if (parameter.Equals("Modal"))
            {
                Ribbon.ShowModalTab("printpreview");
            }
            else if(parameter.Equals("CloseModal"))
            {
                Ribbon.CloseModalTabs();
            }
        }
        #endregion
        #region Main Ribbon


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

        private void PopuplateRibbonMailItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Attach File", IsLarge = true, Image = "base_paperclip_32.png", IsSplitButton = true };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Business card", IsLarge = true, Image = "base_business_contacts.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Audio", IsLarge = true, Image = "base_speaker_32.png" };
            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
        }

        private void PopulateModalItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Show ModalTab", IsLarge = true, Command=ModalCommand, Image = "modal.png" };
            Bar.CustomRibbonItems.Add(Item1);
        }


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
            CustomRibbonBar Bar3 = new CustomRibbonBar() { BarHeader = "Editing" };
            CustomRibbonBar Bar4 = new CustomRibbonBar() { BarHeader = "Paragraph" };
            PopulateEditingItems(Bar3);
            PopulateParagraphItems(Bar4);
            CustomRibbonBar Bar5 = new CustomRibbonBar() { BarHeader = "Mail" };
            PopuplateRibbonMailItems(Bar5);
            CustomRibbonBar Bar6 = new CustomRibbonBar() { BarHeader = "Modal" };
            PopulateModalItems(Bar6);
            Tab.CustomRibbonBars.Add(Bar1);
            Tab.CustomRibbonBars.Add(Bar3);
            Tab.CustomRibbonBars.Add(Bar4);
            Tab.CustomRibbonBars.Add(Bar5);
            Tab.CustomRibbonBars.Add(Bar6);
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
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Shapes", IsLarge = true, IsDropDownButton = true, Image = "0202_InsertShape_32.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "Chart", IsLarge = true, IsDropDownButton = true, Image = "base_charts.png" };

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
