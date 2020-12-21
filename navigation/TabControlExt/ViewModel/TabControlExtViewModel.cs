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
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace syncfusion.navigationdemos.wpf
{
    public class TabControlExtViewModel : NotificationObject
    {
        private ObservableCollection<TabControlExtModel> modelItems;
        public ObservableCollection<TabControlExtModel> ModelItems
        {
            get
            {
                return modelItems;
            }

            set
            {
                modelItems = value;
            }
        }

        #region TabControlExt Properties

        private Syncfusion.Windows.Tools.Controls.CloseMode closeMode = Syncfusion.Windows.Tools.Controls.CloseMode.Hide;
        /// <summary>
        /// Gets or sets a value indicating the close mode of the TabItemExts .
        /// <c>Hide</c>
        /// <c>Delete</c>
        /// </summary>
        public Syncfusion.Windows.Tools.Controls.CloseMode CloseMode
        {
            get
            {
                return closeMode;
            }

            set
            {
                closeMode = value;
                this.RaisePropertyChanged("CloseMode");
            }
        }

        private CloseButtonType closeButtonType = CloseButtonType.Common;
        /// <summary>
        /// Gets or sets a value indicating the how and when close buttons displayed for TabItemExts.
        /// <c>Common</c> -  A single common close button for all TabItemExts. It closes the currently selected TabItemExt.
        /// <c>Individual</c> - Every TabItemExt have its own close button.
        /// <c>Both</c> - Every TabItemExt have its own close button and also the common close button available. 
        /// <c>IndividualOnMouseOver</c> - Every TabItemExt have its own close button and it is 
        /// </summary>
        public CloseButtonType CloseButtonType
        {
            get
            {
                return closeButtonType;
            }

            set
            {
                closeButtonType = value;
                this.RaisePropertyChanged("CloseButtonType");
            }
        }

        private bool allowDragDrop = true;
        /// <summary>
        /// Gets or sets a value indicating whether to allow drag and drop TabItemExt .
        /// </summary>

        public bool AllowDragDrop
        {
            get
            {
                return allowDragDrop;
            }

            set
            {
                allowDragDrop = value;
                this.RaisePropertyChanged("AllowDragDrop");
            }
        }

        private Visibility defaultContextMenuItemVisibility = Visibility.Visible;
        /// <summary>
        /// Gets or sets a value indicating the visibility of the default context menu .
        /// </summary>
        public Visibility DefaultContextMenuItemVisibility
        {
            get
            {
                return defaultContextMenuItemVisibility;
            }

            set
            {
                defaultContextMenuItemVisibility = value;
                this.RaisePropertyChanged("DefaultContextMenuItemVisibility");
            }
        }

        private Brush dragMarkerColor = Brushes.Black;
        /// <summary>
        /// Gets or sets a value indicating the color of the drag marker
        /// </summary>
        public Brush DragMarkerColor
        {
            get
            {
                return dragMarkerColor;
            }

            set
            {
                dragMarkerColor = value;
                this.RaisePropertyChanged("DragMarkerColor");
            }
        }

        private bool enableLabelEdit = true;
        /// <summary>
        /// Gets or sets a value indicating whether to allow editing the TabItemExt's header.
        /// </summary>
        public bool EnableLabelEdit
        {
            get
            {
                return enableLabelEdit;
            }

            set
            {
                enableLabelEdit = value;
                this.RaisePropertyChanged("EnableLabelEdit");
            }
        }


        private bool hideHeaderOnSingleChild;
        /// <summary>
        /// Gets or sets a value indicating whether to hide the header when the TabControlExt having the single child.
        /// </summary>
        public bool HideHeaderOnSingleChild
        {
            get
            {
                return hideHeaderOnSingleChild;
            }

            set
            {
                hideHeaderOnSingleChild = value;
                this.RaisePropertyChanged("HideHeaderOnSingleChild");
            }
        }

        private bool isDisableUnloadTabItemExtContent;
        /// <summary>
        /// Gets or sets a value indicating whether to disable the TabItemExt's content unloading on switching between the TabItemExts.
        /// </summary>
        public bool IsDisableUnloadTabItemExtContent
        {
            get
            {
                return isDisableUnloadTabItemExtContent;
            }

            set
            {
                isDisableUnloadTabItemExtContent = value;
                this.RaisePropertyChanged("IsDisableUnloadTabItemExtContent");
            }
        }

        private bool isNewButtonEnabled;
        /// <summary>
        /// Gets or sets a value indicating whether to display the NewButton.
        /// </summary>
        public bool IsNewButtonEnabled
        {
            get
            {
                return isNewButtonEnabled;
            }

            set
            {
                isNewButtonEnabled = value;
                this.RaisePropertyChanged("IsNewButtonEnabled");
            }
        }

        private bool rotateTextWhenVertical;
        /// <summary>
        /// Gets or sets a value indicating whether to rotate the TabItemExt's header when it is aligned vertically.
        /// </summary>
        public bool RotateTextWhenVertical
        {
            get
            {
                return rotateTextWhenVertical;
            }

            set
            {
                rotateTextWhenVertical = value;
                this.RaisePropertyChanged("RotateTextWhenVertical");
            }
        }


        private int scrollingTime = 100;
        /// <summary>
        /// Gets or sets a value of the time taken to scroll to view hiddent TabItemExts.
        /// </summary>
        public int ScrollingTime
        {
            get
            {
                return scrollingTime;
            }

            set
            {
                scrollingTime = value;
                this.RaisePropertyChanged("ScrollingTime");
            }
        }

        private bool selectOnCreatingNewItem = true;
        /// <summary>
        /// Gets or sets a value indicating whether to select the TabItemExt on creating .
        /// </summary>
        public bool SelectOnCreatingNewItem
        {
            get
            {
                return selectOnCreatingNewItem;
            }

            set
            {
                selectOnCreatingNewItem = value;
                this.RaisePropertyChanged("SelectOnCreatingNewItem");
            }
        }


        private bool showTabItemContextMenu = true;
        /// <summary>
        /// Gets or sets a value indicating whether to show TabItemExt's context menu         
        /// </summary>
        public bool ShowTabItemContextMenu
        {
            get
            {
                return showTabItemContextMenu;
            }

            set
            {
                showTabItemContextMenu = value;
                this.RaisePropertyChanged("ShowTabItemContextMenu");
            }
        }

        private bool showTabListContextMenu = true;
        /// <summary>
        /// Gets or sets a value indicating whether to show TabList context menu .
        /// </summary>
        public bool ShowTabListContextMenu
        {
            get
            {
                return showTabListContextMenu;
            }

            set
            {
                showTabListContextMenu = value;
                this.RaisePropertyChanged("ShowTabListContextMenu");
            }
        }

        private TabItemSizeMode tabItemSize = TabItemSizeMode.Normal;
        /// <summary>
        /// Gets or sets a value indicating TabItemSizeMode
        /// <c>Normal</c> 
        /// <c>ShrinkToFit</c> 
        /// </summary>
        public TabItemSizeMode TabItemSize
        {
            get
            {
                return tabItemSize;
            }

            set
            {
                tabItemSize = value;
                this.RaisePropertyChanged("TabItemSize");
            }
        }

        private Brush tabPanelBackground;
        /// <summary>
        /// Gets or sets a value indicating the background color of the TabPanel.
        /// </summary>
        public Brush TabPanelBackground
        {
            get
            {
                return tabPanelBackground;
            }

            set
            {
                tabPanelBackground = value;
                this.RaisePropertyChanged("TabPanelBackground");
            }
        }

        private TabScrollButtonVisibility tabScrollButtonVisibility = TabScrollButtonVisibility.Auto;
        /// <summary>
        /// Gets or sets a value indicating the TabScrollButtonVisibility.
        /// <c>Auto</c> -  TabScrollButtons become visible only when the not enough size to display all TabItemExt items.
        /// <c>Hidden</c> - TabScrollButtons always hided.
        /// <c>Visible</c> - TabScrollButtons always visible.
        /// </summary>
        public TabScrollButtonVisibility TabScrollButtonVisibility
        {
            get
            {
                return tabScrollButtonVisibility;
            }

            set
            {
                tabScrollButtonVisibility = value;
                this.RaisePropertyChanged("TabScrollButtonVisibility");
            }
        }

        private TabScrollStyle tabScrollStyle = TabScrollStyle.Normal;
        /// <summary>
        /// Gets or sets a value indicating the TabScrollStyle.
        /// <value>
        /// <c>Normal</c> - This displays Next/Previous buttons only.
        /// <c>Extended</c> - This displays First,Last,Next and Previous buttons.
        /// </value>
        /// </summary>
        public TabScrollStyle TabScrollStyle
        {
            get
            {
                return tabScrollStyle;
            }

            set
            {
                tabScrollStyle = value;
                this.RaisePropertyChanged("TabScrollStyle");
            }
        }

        private Dock tabStripPlacement = Dock.Top;
        /// <summary>
        /// Gets or sets a value indicating TabStrip's Placement.
        /// <c>Top</c> - TabItems header displayed in the top of the TabPanel.
        /// <c>Bottom</c> - TabItems header displayed in the bottom of the TabPanel.
        /// <c>Right</c> - TabItems header displayed in the right of the TabPanel.
        /// <c>Left</c> - TabItems header displayed in the left of the TabPanel.
        /// </summary>
        public Dock TabStripPlacement
        {
            get
            {
                return tabStripPlacement;
            }

            set
            {
                tabStripPlacement = value;
                this.RaisePropertyChanged("TabStripPlacement");
            }
        }

        private TabItemLayoutType tabItemLayout = TabItemLayoutType.SingleLine;
        /// <summary>
        /// Gets or sets a value indicating TabItemLayout type.
        /// <c>SingleLine</c> - TabItems header displayed in a single line and TabScrollButtons used to view the hidden TabItems.
        /// <c>MultiLine</c> - TabItems header displayed in the multiline.
        /// <c>MultiLineWithFullWidth</c> - TabItems header displayed in the multiline and the header part takes full width to display its content.        
        /// </summary>
        public TabItemLayoutType TabItemLayout
        {
            get
            {
                return tabItemLayout;
            }

            set
            {
                tabItemLayout = value;
                this.RaisePropertyChanged("TabItemLayout");
            }
        }

        #endregion        

        #region Implementation

        public TabControlExtViewModel()
        {
            modelItems = new ObservableCollection<TabControlExtModel>();
            PopulateCollection();
        }



        private void PopulateCollection()
        {
            TabControlExtModel model1 = new TabControlExtModel()
            {
                Header = "New York",
                Country = "United States",
                Climate = Climate.Cloudy,
                FeelsLike = "-2",
                Degree = "4",
                SunRise = "7.11",
                SunSet = "5.45",
                Latitude = "45.21",
                Longitude = "21.12",
                Humidity = "50"
            };

            TabControlExtModel model2 = new TabControlExtModel()
            {
                Header = "London",
                Country = "England",
                Climate = Climate.Rainy,
                FeelsLike = "3",
                Degree = "7",
                SunRise = "6.11",
                SunSet = "6.45",
                Latitude = "49.21",
                Longitude = "41.12",
                Humidity = "10"
            };

            TabControlExtModel model3 = new TabControlExtModel()
            {
                Header = "Beijing",
                Country = "China",
                Climate = Climate.Cloudy,
                FeelsLike = "1",
                Degree = "6",
                SunRise = "5.11",
                SunSet = "7.45",
                Latitude = "25.21",
                Longitude = "11.12",
                Humidity = "10"
            };

            TabControlExtModel model4 = new TabControlExtModel()
            {
                Header = "Brussels",
                Country = "Belgium",
                Climate = Climate.Cloudy,
                FeelsLike = "5",
                Degree = "8",
                SunRise = "6.05",
                SunSet = "6.45",
                Latitude = "15.21",
                Longitude = "51.12",
                Humidity = "78"
            };

            TabControlExtModel model5 = new TabControlExtModel()
            {
                Header = "Nairobi",
                Country = "Kenya",
                Climate = Climate.Sunny,
                FeelsLike = "34",
                Degree = "40",
                SunRise = "5.16",
                SunSet = "6.45",
                Latitude = "62.21",
                Longitude = "18.12",
                Humidity = "2"
            };

            TabControlExtModel model6 = new TabControlExtModel()
            {
                Header = "Madagascar",
                Country = "Antananarivo",
                Climate = Climate.Sunny,
                FeelsLike = "30",
                Degree = "32",
                SunRise = "7.00",
                SunSet = "6.45",
                Latitude = "15.21",
                Longitude = "71.12",
                Humidity = "10"
            };

            TabControlExtModel model7 = new TabControlExtModel()
            {
                Header = "New Delhi",
                Country = "India",
                Climate = Climate.Sunny,
                FeelsLike = "36",
                Degree = "38",
                SunRise = "6.00",
                SunSet = "6.45",
                Latitude = "85.21",
                Longitude = "31.12",
                Humidity = "7"
            };

            ModelItems.Add(model3);
            ModelItems.Add(model6);
            ModelItems.Add(model1);
            ModelItems.Add(model2);
            ModelItems.Add(model4);
            ModelItems.Add(model5);
            ModelItems.Add(model7);
        }

        #endregion
    }
}
