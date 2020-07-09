#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RibbonMenuMerging
{
    /// <summary>
    /// Represents the ribbon tab properties.
    /// </summary>
    public class CustomRibbonTab
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
        private ObservableCollection<CustomRibbonBar> customRibbonBars;

        /// <summary>
        ///  Maintains the collection of firstChildRibbon ribbon bars.
        /// </summary>
        private ObservableCollection<CustomRibbonBar> customFirstChildRibbonBars;

        /// <summary>
        ///  Maintains the collection of secondChildRibbon ribbon bars.
        /// </summary>
        private ObservableCollection<CustomRibbonBar> customSecondChildRibbonBars;

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
                    tabHeader = value;
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
                    mergeOrder = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ribbon bars.
        /// </summary>
        public ObservableCollection<CustomRibbonBar> CustomRibbonBars
        {
            get
            {
                return customRibbonBars;
            }
            set
            {
                if (customRibbonBars != value)
                    customRibbonBars = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of firstChildRibbon ribbon bars.
        /// </summary>
        public ObservableCollection<CustomRibbonBar> CustomFirstChildRibbonBars
        {
            get
            {
                return customFirstChildRibbonBars;
            }
            set
            {
                if (customFirstChildRibbonBars != value)
                    customFirstChildRibbonBars = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of secondChildRibbon ribbon bars.
        /// </summary>
        public ObservableCollection<CustomRibbonBar> CustomSecondChildRibbonBars
        {
            get
            {
                return customSecondChildRibbonBars;
            }
            set
            {
                if (customSecondChildRibbonBars != value)
                    customSecondChildRibbonBars = value;
            }
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonTab" /> class.
        /// </summary>
        public CustomRibbonTab()
        {
            CustomRibbonBars = new ObservableCollection<CustomRibbonBar>();
            CustomFirstChildRibbonBars = new ObservableCollection<CustomRibbonBar>();
            CustomSecondChildRibbonBars = new ObservableCollection<CustomRibbonBar>();
        }
    }

    /// <summary>
    /// Represents a ribbon bar properties.
    /// </summary>
    public class CustomRibbonBar
    {
        /// <summary>
        ///  Maintains the bar header.
        /// </summary>
        private string barHeader;

        /// <summary> 
        ///  Maintains the collection of custom ribbon items.
        /// </summary>
        private ObservableCollection<CustomRibbonItem> customRibbonItems;

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
                    barHeader = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ribbon items.
        /// </summary>
        public ObservableCollection<CustomRibbonItem> CustomRibbonItems
        {
            get
            {
                return customRibbonItems;
            }
            set
            {
                if (customRibbonItems != value)
                    customRibbonItems = value;
            }
        }

        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonBar" /> class.
        /// </summary>
        public CustomRibbonBar()
        {
            CustomRibbonItems = new ObservableCollection<CustomRibbonItem>();
        }
    }

    /// <summary>
    /// Represents  ribbon items properties.
    /// </summary>
    public class CustomRibbonItem
    {
        /// <summary>
        ///  Maintains the image address.
        /// </summary>
        private string image;

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
        private ObservableCollection<CustomDropDownItem> customDropDownItems;

        /// <summary>
        ///  Maintains the command.
        /// </summary>
        private ICommand command;

        /// <summary>
        ///  Maintains the item header.
        /// </summary>
        private string itemHeader;
     
        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonItem" /> class.
        /// </summary>
        public CustomRibbonItem()
        {
            IsSplitButton = false;
            IsDropDownButton = false;
            IsBoolean = true;
            CustomDropDownItems = new ObservableCollection<CustomDropDownItem>();
        }

        /// <summary>
        /// Gets or sets the collection of ribbon items.
        /// </summary>
        public ObservableCollection<CustomDropDownItem> CustomDropDownItems
        {
            get
            {
                return customDropDownItems;
            }
            set
            {
                if (customDropDownItems != value)
                    customDropDownItems = value;
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
                    itemHeader = value;
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
                    hasTablePicker = value;
            }
        }

        /// <summary>
        /// Gets or sets the image details.
        /// </summary>
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                if (image != value)
                    image = value;
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
                    isBoolean = value;
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
                    isLarge = value;
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
                    isSplitButton = value;
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
                    isDropDownButton = value;
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
                    isCheckBox = value;
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
                    isChecked = value;
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
                    command = value;
            }
        }
    }

    /// <summary>
    /// Represents dropdown item properties.
    /// </summary>
    public class CustomDropDownItem
    {
        /// <summary>
        /// Maintains the dropdown item name.
        /// </summary>
        private string name;

        /// <summary>
        /// Maintains the dropdown item image.
        /// </summary>
        private string image;

        /// <summary>
        /// Gets or sets the name for dropdown item <see cref="CustomDropDownItem"/> class.
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
            }
        }

        /// <summary>
        /// Gets or sets the name for dropdown image <see cref="CustomDropDownItem"/> class.
        /// </summary>
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }
    }
}
