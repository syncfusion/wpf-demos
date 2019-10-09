#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RibbonMenuMerging
{
    public class CustomRibbonTab
    {
        public string TabHeader { get; set; }
        public int MergeOrder { get; set; }
        public ObservableCollection<CustomRibbonBar> CustomRibbonBars { get; set; }
        public ObservableCollection<CustomRibbonBar> CustomChild1RibbonBars { get; set; }
        public ObservableCollection<CustomRibbonBar> CustomChild2RibbonBars { get; set; }
        public CustomRibbonTab()
        {
            CustomRibbonBars = new ObservableCollection<CustomRibbonBar>();
            CustomChild1RibbonBars = new ObservableCollection<CustomRibbonBar>();
            CustomChild2RibbonBars = new ObservableCollection<CustomRibbonBar>();
        }
    }
    public class CustomRibbonBar
    {
        public string BarHeader { get; set; }
        public ObservableCollection<CustomRibbonItem> CustomRibbonItems { get; set; }
        public CustomRibbonBar()
        {
            CustomRibbonItems = new ObservableCollection<CustomRibbonItem>();
        }
    }
    public class CustomRibbonItem
    {
        public CustomRibbonItem()
        {
            IsSplitButton = false;
            IsDropDownButton = false;
            IsBoolean = true;
        }
        public string ItemHeader
        {
            get;
            set;
        }
        public string Image { get; set; }
        public bool IsBoolean { get; set; }
        public bool IsLarge { get; set; }
        public bool IsSplitButton { get; set; }
        public bool IsDropDownButton { get; set; }
        public bool IsCheckBox { get; set; }
        public bool Checked { get; set; }
        public ICommand Command { get; set; }

    }
}
