#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using RibbonSample.OptionTabContent;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonSample
{
    /// <summary>
    /// Represents the viewmodel for ribbon control.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        /// Maintains the collection of option tabs.
        /// </summary>
        private ObservableCollection<OptionTab> _optionTabs;

        /// <summary>
        /// Indicates whether the quick access toolbar is below.
        /// </summary>
        private bool isQATBelow;

        #endregion

        #region constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        public ViewModel()
        {
            DisplayTabContent = new DisplayTabContent();
            GeneralTabContent = new GeneralTabContent();
            PopulateCollection();
            IsQATBelow = false;
        }
        #endregion

        #region Property
        /// <summary>
        /// Gets or sets the display tab content.
        /// </summary>     
        public DisplayTabContent DisplayTabContent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the general tab content.
        /// </summary>
        public GeneralTabContent GeneralTabContent
        {
            get;
            set;
        }

      /// <summary>
      /// Gets or sets the collection of option tab.
      /// </summary>
        public ObservableCollection<OptionTab> OptionTabsCollection
        {
            get
            {
                return _optionTabs;
            }
            set
            {
                _optionTabs = value;
                RaisePropertyCahnged("OptionTabsCollection");
            }
        }

      /// <summary>
      /// Gets and sets the value indicating whether the quick access bar is below.
      /// </summary>
        public bool IsQATBelow
        {
            get
            {
                return isQATBelow;

            }
            set
            {
                isQATBelow = value;
                RaisePropertyCahnged("IsQATBelow");
            }
        }
# endregion

        #region Helper Methods
        /// <summary>
        /// Method which is used to add tabs to the option tab.
        /// </summary>
        public void PopulateCollection()
        {
            OptionTabsCollection = new ObservableCollection<OptionTab>();
            OptionTab generalTab = new OptionTab() { Header = "General", Content = GeneralTabContent, TabPosition = TabPosition.Above };
            OptionTab displayTab = new OptionTab() { Header = "Display", Content = DisplayTabContent, TabPosition = TabPosition.Above };            
            OptionTabsCollection.Add(generalTab);
            OptionTabsCollection.Add(displayTab);
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
        void RaisePropertyCahnged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        #endregion
    }
}
