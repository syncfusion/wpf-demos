#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RibbonModelTab
{
    /// <summary>
    /// Represents a custom tab class for ribbon control.
    /// </summary>
    public class CustomRibbonTab
    {
        /// <summary>
        ///  Maintains the tab header.
        /// </summary>
        private string tabHeader;

        /// <summary>
        ///  Maintains the collection of ribbon bars.
        /// </summary>
        private ObservableCollection<CustomRibbonBar> customRibbonBars;

        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonTab" /> class.
        /// </summary>
        public CustomRibbonTab()
        {
            CustomRibbonBars = new ObservableCollection<CustomRibbonBar>();
        }

        /// <summary>
        /// Gets or sets the tab header <see cref="CustomRibbonTab"/> class.
        /// </summary>
        public string TabHeader
        {
            get
            {
                return tabHeader;
            }
            set
            {
                if(tabHeader!=value)
                tabHeader = value;             
            }
        }

        /// <summary>
        /// Gets or sets the collection of ribbon bars <see cref="CustomRibbonTab"/> class.
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
    }

    /// <summary>
    /// Represents a custom bar class for ribbon control.
    /// </summary>
    public class CustomRibbonBar
    {
        /// <summary>
        ///  Maintains the bar header.
        /// </summary>
        private string barHeader;

        /// <summary>
        ///  Maintains the collection of customRibbonItems.
        /// </summary>
        private ObservableCollection<CustomRibbonItem> customRibbonItems;

        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonBar" /> class.
        /// </summary>
        public CustomRibbonBar()
        {
            CustomRibbonItems = new ObservableCollection<CustomRibbonItem>();
        }

        /// <summary>
        /// Gets or sets the bar header <see cref="CustomRibbonBar"/> class.
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
        /// Gets or sets the collection of ribbon items <see cref="CustomRibbonBar"/> class.
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
    }

    /// <summary>
    /// Represents a class of ribbon items.
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
        ///   Indicates whether the property is large.
        /// </summary>
        private bool isLarge;

        /// <summary>
        ///   Indicates whether the control is split button.
        /// </summary>
        private bool isSplitButton;

        /// <summary>
        ///  Indicates whether the control is dropdown button.
        /// </summary>
        private bool isDropDownButton;

        /// <summary>
        ///   Indicates whether the control is check box.
        /// </summary>
        private bool isCheckBox;

        /// <summary>
        ///   Indicates whether the control is checked.
        /// </summary>
        private bool isChecked;

        /// <summary>
        ///  Maintains the command.
        /// </summary>
        private ICommand command;

        /// <summary>
        ///  Maintains the item header.
        /// </summary>
        private string itemHeader;

        /// <summary>
        ///  Indicates whether the control has table picker.
        /// </summary>
        private bool hasTablePicker;

        /// <summary>
        ///  Indicates whether the ribbon has seperator
        /// </summary>
        private bool isSeparator;

        /// <summary> 
        ///  Maintains the collection of custom ribbon items.
        /// </summary>
        private ObservableCollection<CustomDropDownItem> customDropDownItems;

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
        /// Gets or sets the item header <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the image address <see cref="CustomRibbonItem"/> class.
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
        ///  Gets or sets the value Indicating whether the property is boolean <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the property is large <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the control is split button <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the control is dropdown button <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the control is check box <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the value indicating whether the control is separator <see cref="CustomRibbonItem"/> class.
        /// </summary>
        public bool IsSeparator
        {
            get { return isSeparator; }
            set { isSeparator = value; }
        }


        /// <summary>
        /// Gets or sets the value Indicating whether the control is checked <see cref="CustomRibbonItem"/> class.
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
        /// Gets or sets the command properties <see cref="CustomRibbonItem"/> class.
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
        ///  Maintains the command.
        /// </summary>
        private ICommand command;

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

        /// <summary>
        /// Gets or sets the command properties <see cref="CustomDropDownItem"/> class.
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
}
