#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace RibbonMenuMerging
{
    /// <summary>
    /// Represents the ribbon tab properties.
    /// </summary>
    public class CustomRibbonTab
    {
        #region Fields
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
        ///  Maintains the collection of child1 ribbon bars.
        /// </summary>
        private ObservableCollection<CustomRibbonBar> customChild1RibbonBars;

        /// <summary>
        ///  Maintains the collection of child2 ribbon bars.
        /// </summary>
        private ObservableCollection<CustomRibbonBar> customChild2RibbonBars;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the tab header.
        /// </summary>
        [Category("Summary")]
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
        [Category("Summary")]
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
        [Category("Summary")]
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
        /// Gets or sets the collection of child1 ribbon bars.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<CustomRibbonBar> CustomChild1RibbonBars
        {
            get
            {
                return customChild1RibbonBars;
            }
            set
            {
                if (customChild1RibbonBars != value)
                    customChild1RibbonBars = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of child2 ribbon bars.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<CustomRibbonBar> CustomChild2RibbonBars
        {
            get
            {
                return customChild2RibbonBars;
            }
            set
            {
                if (customChild2RibbonBars != value)
                    customChild2RibbonBars = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonTab" /> class.
        /// </summary>
        public CustomRibbonTab()
        {
            CustomRibbonBars = new ObservableCollection<CustomRibbonBar>();
            CustomChild1RibbonBars = new ObservableCollection<CustomRibbonBar>();
            CustomChild2RibbonBars = new ObservableCollection<CustomRibbonBar>();
        }
        #endregion
    }

    /// <summary>
    /// Represents a ribbon bar properties.
    /// </summary>
    public class CustomRibbonBar
    {
        #region Field
        /// <summary>
        ///  Maintains the bar header.
        /// </summary>
        private string barheader;

        /// <summary> 
        ///  Maintains the collection of custom ribbon items.
        /// </summary>
        private ObservableCollection<CustomRibbonItem> customRibbonItems;
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the bar header.
        /// </summary>
        [Category("Summary")]
        public string BarHeader
        {
            get
            {
                return barheader;
            }
            set
            {
                if (barheader != value)
                    barheader = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of ribbon items.
        /// </summary>
        [Category("Summary")]
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

        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonBar" /> class.
        /// </summary>
        public CustomRibbonBar()
        {
            CustomRibbonItems = new ObservableCollection<CustomRibbonItem>();
        }
        #endregion
    }

    /// <summary>
    /// Represents custom ribbon items.
    /// </summary>
    public class CustomRibbonItem
    {
        #region Fields
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
        private bool checkedd;

        /// <summary>
        ///  Maintains the command.
        /// </summary>
        private ICommand command;

        /// <summary>
        ///  Maintains the item header.
        /// </summary>
        private string itemHeader;
        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="CustomRibbonItem" /> class.
        /// </summary>
        public CustomRibbonItem()
        {
            IsSplitButton = false;
            IsDropDownButton = false;
            IsBoolean = true;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the Item header.
        /// </summary>
        [Category("Summary")]
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
        /// Gets or sets the image details.
        /// </summary>
        [Category("Summary")]
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
        [Category("Data")]
        [Description("Indicates whether the property is set to be boolean type")]
        [DefaultValue(false)]
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
        [Category("Control")]
        [Description("Indicates whether the property is set to be large ")]
        [DefaultValue(false)]
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
        [Category("Control")]
        [Description("Indicates whether the button is set to be split button")]
        [DefaultValue(false)]
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
        [Category("Control")]
        [Description("Indicates whether the control is set to be dropdown button.")]
        [DefaultValue(false)]
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
        [Category("Control")]
        [Description("Indicates whether the control is set to be checkbox.")]
        [DefaultValue(false)]
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
        [Category("Control")]
        [Description("Indicates whether to the control to be checked")]
        [DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return checkedd;
            }
            set
            {
                if (checkedd != value)
                    checkedd = value;
            }
        }

        /// <summary>
        /// Gets or sets the command properties.
        /// </summary>
        [Category("Summary")]
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
        #endregion
    }
}
