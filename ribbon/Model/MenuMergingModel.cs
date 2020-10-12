#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Represents the ribbon tab properties.
    /// </summary>
    public class MenuMergingRibbonTab : NotificationObject
    {
        /// <summary>
        ///  Maintains the tab header.
        /// </summary>
        private string tabHeader;

        /// <summary>
        ///  Maintains the merge order.
        /// </summary>
        private int mergeOrder;

        /// <summary>
        ///  Maintains the collection of ribbon bars.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonBar> customRibbonBars;

        /// <summary>
        ///  Maintains the collection of firstChildRibbon ribbon bars.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonBar> customFirstChildRibbonBars;

        /// <summary>
        ///  Maintains the collection of secondChildRibbon ribbon bars.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonBar> customSecondChildRibbonBars;

        /// <summary>
        /// Gets or sets the tab header.
        /// </summary>
        public string TabHeader
        {
            get
            {
                return tabHeader;
            }
            set
            {
                if (tabHeader != value)
                {
                    tabHeader = value;
                    RaisePropertyChanged("TabHeader");
                }
            }
        }

        /// <summary>
        /// Gets or sets the merge order.
        /// </summary>
        public int MergeOrder
        {
            get
            {
                return mergeOrder;
            }
            set
            {
                if (mergeOrder != value)
                {
                    mergeOrder = value;
                    RaisePropertyChanged("MergeOrder");
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of ribbon bars.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonBar> ModelTabRibbonBar
        {
            get
            {
                return customRibbonBars;
            }
            set
            {
                if (customRibbonBars != value)
                {
                    customRibbonBars = value;
                    RaisePropertyChanged("ModelTabRibbonBar");
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of firstChildRibbon ribbon bars.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonBar> CustomFirstChildRibbonBars
        {
            get
            {
                return customFirstChildRibbonBars;
            }
            set
            {
                if (customFirstChildRibbonBars != value)
                {
                    customFirstChildRibbonBars = value;
                    RaisePropertyChanged("CustomFirstChildRibbonBars");
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of secondChildRibbon ribbon bars.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonBar> CustomSecondChildRibbonBars
        {
            get
            {
                return customSecondChildRibbonBars;
            }
            set
            {
                if (customSecondChildRibbonBars != value)
                {
                    customSecondChildRibbonBars = value;
                    RaisePropertyChanged("CustomSecondChildRibbonBars");
                }
            }
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MenuMergingRibbonTab" /> class.
        /// </summary>
        public MenuMergingRibbonTab()
        {
            ModelTabRibbonBar = new ObservableCollection<MenuMergingRibbonBar>();
            CustomFirstChildRibbonBars = new ObservableCollection<MenuMergingRibbonBar>();
            CustomSecondChildRibbonBars = new ObservableCollection<MenuMergingRibbonBar>();
        }
    }

    /// <summary>
    /// Represents a ribbon bar properties.
    /// </summary>
    public class MenuMergingRibbonBar : NotificationObject
    {
        /// <summary>
        ///  Maintains the bar header.
        /// </summary>
        private string barHeader;

        /// <summary> 
        ///  Maintains the collection of custom ribbon items.
        /// </summary>
        private ObservableCollection<MenuMergingRibbonItem> customRibbonItems;

        /// <summary>
        /// Gets or sets the bar header.
        /// </summary>
        public string BarHeader
        {
            get
            {
                return barHeader;
            }
            set
            {
                if (barHeader != value)
                {
                    barHeader = value;
                    RaisePropertyChanged("BarHeader");
                }
            }
        }

        /// <summary>
        /// Gets or sets the collection of ribbon items.
        /// </summary>
        public ObservableCollection<MenuMergingRibbonItem> ModelTabRibbonItem
        {
            get
            {
                return customRibbonItems;
            }
            set
            {
                if (customRibbonItems != value)
                {
                    customRibbonItems = value;
                    RaisePropertyChanged("ModelTabRibbonItem");
                }
            }
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="MenuMergingRibbonBar" /> class.
        /// </summary>
        public MenuMergingRibbonBar()
        {
            ModelTabRibbonItem = new ObservableCollection<MenuMergingRibbonItem>();
        }
    }

    /// <summary>
    /// Represents  ribbon items properties.
    /// </summary>
    public class MenuMergingRibbonItem : NotificationObject
    {
        /// <summary>
        ///  Maintains the image address.
        /// </summary>
        private object image;

        /// <summary>
        /// Holds the icon template for the ribbon item.
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        /// Gets or sets the icon template for the ribbon item.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get { return imageTemplate; }
            set { imageTemplate = value; RaisePropertyChanged("ImageTemplate"); }
        }

        /// <summary>
        ///  Indicates whether the property is boolean.
        /// </summary>
        private bool isBoolean;

        /// <summary>
        ///  Indicates whether the property is large.
        /// </summary>
        private bool isLarge;

        /// <summary>
        ///  Indicates whether the control is split button.
        /// </summary>
        private bool isSplitButton;

        /// <summary>
        ///  Indicates whether the control is dropdown button.
        /// </summary>
        private bool isDropDownButton;

        /// <summary>
        ///  Indicates whether the control is checkbox.
        /// </summary>
        private bool isCheckBox;

        /// <summary>
        ///  Indicates whether the control is checked.
        /// </summary>
        private bool isChecked;

        /// <summary>
        ///  Indicates whether the control has table picker.
        /// </summary>
        private bool hasTablePicker;

        /// <summary> 
        ///  Maintains the collection of custom ribbon items.
        /// </summary>
        private ObservableCollection<MenuMergingDropDownItem> customDropDownItems;

        /// <summary>
        ///  Maintains the command.
        /// </summary>
        private ICommand command;

        /// <summary>
        ///  Maintains the item header.
        /// </summary>
        private string itemHeader;
     
        /// <summary>
        ///  Initializes a new instance of the <see cref="MenuMergingRibbonItem" /> class.
        /// </summary>
        public MenuMergingRibbonItem()
        {
            IsSplitButton = false;
            IsDropDownButton = false;
            IsBoolean = true;
            ModelTabDropDownItem = new ObservableCollection<MenuMergingDropDownItem>();
        }

        /// <summary>
        /// Gets or sets the collection of ribbon items.
        /// </summary>
        public ObservableCollection<MenuMergingDropDownItem> ModelTabDropDownItem
        {
            get
            {
                return customDropDownItems;
            }
            set
            {
                if (customDropDownItems != value)
                {
                    customDropDownItems = value;
                    RaisePropertyChanged("ModelTabDropDownItem");
                }
            }
        }

        /// <summary>
        /// Gets or sets the Item header.
        /// </summary>
        public string ItemHeader
        {
            get
            {
                return itemHeader;
            }
            set
            {
                if (itemHeader != value)
                {
                    itemHeader = value;
                    RaisePropertyChanged("ItemHeader");
                }
            }
        }

        /// <summary>
        /// Gets or sets the table picker.
        /// </summary>
        public bool HasTablePicker
        {
            get
            {
                return hasTablePicker;
            }
            set
            {
                if (hasTablePicker != value)
                {
                    hasTablePicker = value;
                    RaisePropertyChanged("HasTablePicker");
                }
            }
        }

        /// <summary>
        /// Gets or sets the image details.
        /// </summary>
        public object Image
        {
            get
            {
                return image;
            }
            set
            {
                if (image != value)
                {
                    image = value;
                    RaisePropertyChanged("Image");
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the given property is boolean.
        /// </summary>
      public bool IsBoolean
        {
            get
            {
                return isBoolean;
            }
            set
            {
                if (isBoolean != value)
                {
                    isBoolean = value;
                    RaisePropertyChanged("IsBoolean");
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the given property is large.
        /// </summary>
      public bool IsLarge
        {
            get
            {
                return isLarge;
            }
            set
            {
                if (isLarge != value)
                {
                    isLarge = value;
                    RaisePropertyChanged("IsLarge");
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the control is split button.
        /// </summary>
       public bool IsSplitButton
        {
            get
            {
                return isSplitButton;
            }
            set
            {
                if (isSplitButton != value)
                {
                    isSplitButton = value;
                    RaisePropertyChanged("IsSplitButton");
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the control is dropdown button.
        /// </summary>
        public bool IsDropDownButton
        {
            get
            {
                return isDropDownButton;
            }
            set
            {
                if (isDropDownButton != value)
                {
                    isDropDownButton = value;
                    RaisePropertyChanged("IsDropDownButton");
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the control is checkbox.
        /// </summary>
        public bool IsCheckBox
        {
            get
            {
                return isCheckBox;
            }
            set
            {
                if (isCheckBox != value)
                {
                    isCheckBox = value;
                    RaisePropertyChanged("IsCheckBox");
                }
            }
        }

        /// <summary>
        ///  Gets or sets a value indicating whether the control is checked.
        /// </summary>
        public bool Checked
        {
            get
            {
                return isChecked;
            }
            set
            {
                if (isChecked != value)
                {
                    isChecked = value;
                    RaisePropertyChanged("Checked");
                }
            }
        }

        /// <summary>
        /// Gets or sets the command properties.
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
            set
            {
                if (command != value)
                {
                    command = value;
                    RaisePropertyChanged("Command");
                }
            }
        }
    }

    /// <summary>
    /// Represents dropdown item properties.
    /// </summary>
    public class MenuMergingDropDownItem : NotificationObject
    {
        /// <summary>
        /// Maintains the dropdown item name.
        /// </summary>
        private string name;

        /// <summary>
        /// Maintains the dropdown ImageTemplate.
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        /// Gets or sets the name for dropdown item <see cref="MenuMergingDropDownItem"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the ImageTemplate for dropdownitem <see cref="MenuMergingDropDownItem"/> class.
        /// </summary>

        public DataTemplate ImageTemplate
        {
            get
            {
                return imageTemplate;
            }
            set
            {
                imageTemplate = value;
                RaisePropertyChanged("ImageTemplate");
            }
        }
    }
}
