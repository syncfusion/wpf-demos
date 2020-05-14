#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
        #region Fields
        /// <summary>
        ///  Maintains the collection of custom ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customRibbonTabs;

        /// <summary>
        ///  Maintains the collection of child1 ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customChild1RibbonTabs;

        /// <summary>
        ///  Maintains the collection of custom child2 ribbon tabs.
        /// </summary>
        private ObservableCollection<CustomRibbonTab> customChild2RibbonTabs;

        /// <summary>
        ///  Maintains the Ribbon.
        /// </summary>
        private Ribbon Ribbon;
        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel(Ribbon ribbon)
        {
            this.Ribbon = ribbon;
            CustomRibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild1RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            CustomChild2RibbonTabs = new ObservableCollection<CustomRibbonTab>();
            PopulateRibbonTabs();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the custom ribbon tabs collection .
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
        /// Gets or sets the custom child1 ribbon tabs collection .
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
        /// Gets or sets the custom child2 ribbon tabs collection .
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

        #region Event
        /// <summary>
        /// Initialize the event which notifies when the selected item changes. 
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
        #endregion

        #region Command
        /// <summary>
        /// Indicates the command for open the model.
        /// </summary>
        private ICommand modeModalCommand;

        /// <summary>
        /// Indicates the command for close model.
        /// </summary>
        private ICommand closeModalCommand;

        //Command implementation

        /// <summary>
        /// Command implementation for open model command.
        /// </summary>
        public ICommand ModalCommand
        {
            get { return modeModalCommand ?? (modeModalCommand = new CommandHandler(true, () => MyAction("Modal"))); }
        }

        /// <summary>
        /// Command implementation for close model command.
        /// </summary>
        public ICommand CloseModalCommand
        {
            get { return closeModalCommand ?? (closeModalCommand = new CommandHandler(true, () => MyAction("CloseModal"))); }
        }

        /// <summary>
        /// Method which is used to implement the model tab action.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        public void MyAction(string parameter)
        {
            if (parameter.Equals("Modal"))
            {
                CustomRibbonTabs.Clear();
                CustomRibbonTab Tab3 = new CustomRibbonTab() { TabHeader = "Print Preview" };
                PopulateRibbonPrintPreviewBars(Tab3);
                CustomRibbonTabs.Add(Tab3);
            }
            else if(parameter.Equals("CloseModal"))
            {
                CustomRibbonTabs.Clear();
                PopulateRibbonTabs();
            }
        }
        #endregion

        #region  Helper Methods
        /// <summary>
        /// Method which is used to populate items to the editing ribbon bar.
        /// </summary>
        /// <param name="Bar"></param>
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
        /// Method which is used to populate items to the paragraph ribbon bar.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
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

        /// <summary>
        /// Method which is used to populate items to mail ribbon bar.
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

        /// <summary>
        /// Method which is used to populate items to model items.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateModalItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Show ModalTab", IsLarge = true, Command=ModalCommand, Image = "modal.png" };
            Bar.CustomRibbonItems.Add(Item1);
        }

        /// <summary>
        /// Method which is used to populate ribbon bar to ribbon tab.
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

        //Home Tab
        /// <summary>
        /// Method which is used to populate child ribbon bars to Home ribbon bar.
        /// </summary>
        /// <param name="Tab">Ribbon tab.</param>
        void PopulateRibbonHomeBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Clipboard" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "MDI Styles" };
            CustomRibbonBar Bar3 = new CustomRibbonBar() { BarHeader = "Editing" };
            CustomRibbonBar Bar4 = new CustomRibbonBar() { BarHeader = "Paragraph" };
            CustomRibbonBar Bar5 = new CustomRibbonBar() { BarHeader = "Mail" };
            CustomRibbonBar Bar6 = new CustomRibbonBar() { BarHeader = "Modal" };

            PopulateRibbonNewItems(Bar1);
            PopulateEditingItems(Bar3);
            PopulateParagraphItems(Bar4);
            PopuplateRibbonMailItems(Bar5);
            PopulateModalItems(Bar6);

            Tab.CustomRibbonBars.Add(Bar1);
            Tab.CustomRibbonBars.Add(Bar3);
            Tab.CustomRibbonBars.Add(Bar4);
            Tab.CustomRibbonBars.Add(Bar5);
            Tab.CustomRibbonBars.Add(Bar6);
        }

        /// <summary>
        /// Method which is used to populate items to home bar.
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

        //Insert Tab
        /// <summary>
        /// Method which is used to populate items to insert ribbon bar.
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
        /// Method which is used to populate items to illustrations ribbon bar.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
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

        /// <summary>
        /// Method which is used to populate items to link ribbon bar.
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
        /// Method which is used to populate items to table ribbon bar.
        /// </summary>
        /// <param name="Bar">Ribbon bar.</param>
        private void PopulateRibbonTableItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Tables", IsLarge = true, IsDropDownButton = true, Image = "Table_32.png" };

            Bar.CustomRibbonItems.Add(Item1);
        }

        /// <summary>
        /// Method which is used to populate items to insert the ribbon bars.
        /// </summary>
        /// <param name="Tab"></param>
        private void PopulateRibbonPrintPreviewBars(CustomRibbonTab Tab)
        {
            CustomRibbonBar Bar1 = new CustomRibbonBar() { BarHeader = "Print" };
            CustomRibbonBar Bar2 = new CustomRibbonBar() { BarHeader = "Zoom" };
            CustomRibbonBar Bar3 = new CustomRibbonBar() { BarHeader = "Preview" };

            PopulateRibbonPrintItems(Bar1);
            PopulateRibbonZoomItems(Bar2);
            PopulateRibbonPreviewItems(Bar3);

            Tab.CustomRibbonBars.Add(Bar1);
            Tab.CustomRibbonBars.Add(Bar2);
            Tab.CustomRibbonBars.Add(Bar3);
        }

        /// <summary>
        /// Method which is used to populate items to print ribbon bar.
        /// </summary>
        /// <param name="Bar"></param>
        private void PopulateRibbonPrintItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Print", IsLarge = true, Image = "PrintAreaFlat.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Options", IsLarge = true, Image = "View Setting.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
        }

        /// <summary>
        /// Method which is used to populate items to zoom ribbon bar.
        /// </summary>
        /// <param name="Bar"></param>
        private void PopulateRibbonZoomItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Zoom", IsLarge = true, Image = "Zoom_32x32.png" };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "100%", IsLarge = true, Image = "portrait.png" };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "One Page", IsLarge = false, Image = "Team Email.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "Two Pages", IsLarge = false, Image = "Reading Pane.png" };
            CustomRibbonItem Item5 = new CustomRibbonItem() { ItemHeader = "Page Width", IsLarge = false, Image = "Reading Pane.png" };

            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
            Bar.CustomRibbonItems.Add(Item5);

        }

        /// <summary>
        /// Method which is used to populate items to preview ribbon bar.
        /// </summary>
        /// <param name="Bar"></param>
        private void PopulateRibbonPreviewItems(CustomRibbonBar Bar)
        {
            CustomRibbonItem Item1 = new CustomRibbonItem() { ItemHeader = "Show Ruler", IsLarge = false,IsCheckBox=true };
            CustomRibbonItem Item2 = new CustomRibbonItem() { ItemHeader = "Magnifier", IsLarge = false,IsCheckBox=true };
            CustomRibbonItem Item3 = new CustomRibbonItem() { ItemHeader = "Shrink on OnePage", IsLarge = false, Image = "Object16.png" };
            CustomRibbonItem Item4 = new CustomRibbonItem() { ItemHeader = "Next Page", IsLarge = false, Image = "nextpage.png" };
            CustomRibbonItem Item5 = new CustomRibbonItem() { ItemHeader = "Previous Page", IsLarge = false, Image = "previouspage.png" };
            CustomRibbonItem Item6 = new CustomRibbonItem() { IsSeparator = true };
            CustomRibbonItem Item7 = new CustomRibbonItem() { ItemHeader = "Close Print Preview", IsLarge = true,Command= CloseModalCommand, Image = "CloseTab32.png" };


            Bar.CustomRibbonItems.Add(Item1);
            Bar.CustomRibbonItems.Add(Item2);
            Bar.CustomRibbonItems.Add(Item3);
            Bar.CustomRibbonItems.Add(Item4);
            Bar.CustomRibbonItems.Add(Item5);
            Bar.CustomRibbonItems.Add(Item6);
            Bar.CustomRibbonItems.Add(Item7);

        }
        #endregion
    }

    /// <summary>
    /// Class for command.
    /// </summary>
    public class CommandHandler : ICommand
    {
        //Command methods
        /// <summary>
        /// Maintains the canexecute field.
        /// </summary>
        private bool _canexecute;

        /// <summary>
        /// Maintains the action field.
        /// </summary>
        private Action _action;
        public CommandHandler(bool canexecute, Action Action)
        {
            _canexecute = canexecute;
            _action = Action;
        }

        /// <summary>
        /// Initialize the event which executes when the selected item changes. 
        /// </summary>  
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Method which is used to check the method can execute or not.
        /// </summary>
        /// <param name="parameter">Indicates whether can execute.</param>
        /// <returns>Returns boolean.</returns>
        public bool CanExecute(object parameter)
        {
            return _canexecute;
        }

        /// <summary>
        /// Method which is used to exexute the method.
        /// </summary>
        /// <param name="parameter">Parameter which is execute the command.</param>
        public void Execute(object parameter)
        {
            _action();
        }
    }
}
