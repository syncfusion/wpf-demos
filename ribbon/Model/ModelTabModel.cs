#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Represents a custom tab class for ribbon control.
    /// </summary>
    public class ModelRibbonTab : NotificationObject
    {
        /// <summary>
        ///  Maintains the tab header.
        /// </summary>
        private string tabHeader;

        /// <summary>
        ///  Maintains the collection of ribbon bars.
        /// </summary>
        private ObservableCollection<ModelTabRibbonBar> customRibbonBars;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ModelRibbonTab" /> class.
        /// </summary>
        public ModelRibbonTab()
        {
            ModelTabRibbonBar = new ObservableCollection<ModelTabRibbonBar>();
        }

        /// <summary>
        /// Gets or sets the tab header <see cref="ModelRibbonTab"/> class.
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
        /// Gets or sets the collection of ribbon bars <see cref="ModelRibbonTab"/> class.
        /// </summary>
        public ObservableCollection<ModelTabRibbonBar> ModelTabRibbonBar
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
    }

    /// <summary>
    /// Represents a custom bar class for ribbon control.
    /// </summary>
    public class ModelTabRibbonBar : NotificationObject
    {
        /// <summary>
        ///  Maintains the bar header.
        /// </summary>
        private string barHeader;

        /// <summary>
        ///  Maintains the collection of customRibbonItems.
        /// </summary>
        private ObservableCollection<ModelTabRibbonItem> customRibbonItems;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ModelTabRibbonBar" /> class.
        /// </summary>
        public ModelTabRibbonBar()
        {
            ModelTabRibbonItem = new ObservableCollection<ModelTabRibbonItem>();
        }

        /// <summary>
        /// Gets or sets the bar header <see cref="ModelTabRibbonBar"/> class.
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
        /// Gets or sets the collection of ribbon items <see cref="ModelTabRibbonBar"/> class.
        /// </summary>
        public ObservableCollection<ModelTabRibbonItem> ModelTabRibbonItem
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
    }

    /// <summary>
    /// Represents a class of ribbon items.
    /// </summary>
    public class ModelTabRibbonItem : NotificationObject
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
        private ObservableCollection<ModelTabDropDownItem> customDropDownItems;

        /// <summary>
        ///  Initializes a new instance of the <see cref="ModelTabRibbonItem" /> class.
        /// </summary>
        public ModelTabRibbonItem()
        {
            IsSplitButton = false;
            IsDropDownButton = false;
            IsBoolean = true;
            ModelTabDropDownItem = new ObservableCollection<ModelTabDropDownItem>();
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
        /// Gets or sets the collection of ribbon items.
        /// </summary>
        public ObservableCollection<ModelTabDropDownItem> ModelTabDropDownItem
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
        /// Gets or sets the item header <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the image address <see cref="ModelTabRibbonItem"/> class.
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
        ///  Gets or sets the value Indicating whether the property is boolean <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the property is large <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the control is split button <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the control is dropdown button <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the value Indicating whether the control is check box <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the value indicating whether the control is separator <see cref="ModelTabRibbonItem"/> class.
        /// </summary>
        public bool IsSeparator
        {
            get
            {
                return isSeparator;
            }
            set
            {
                isSeparator = value;
                RaisePropertyChanged("IsSeparator");
            }
        }


        /// <summary>
        /// Gets or sets the value Indicating whether the control is checked <see cref="ModelTabRibbonItem"/> class.
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
        /// Gets or sets the command properties <see cref="ModelTabRibbonItem"/> class.
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
    public class ModelTabDropDownItem : NotificationObject
    {
        /// <summary>
        /// Maintains the dropdown item name.
        /// </summary>
        private string name;

        /// <summary>
        /// Maintains the dropdown item ImageTemplate.
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        ///  Maintains the command.
        /// </summary>
        private ICommand command;

        /// <summary>
        /// Gets or sets the name for dropdown item <see cref="ModelTabDropDownItem"/> class.
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
        /// Gets or sets the ImageTemplate for dropdownitem <see cref="ModelTabDropDownItem"/> class.
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

        /// <summary>
        /// Gets or sets the command properties <see cref="ModelTabDropDownItem"/> class.
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
}
