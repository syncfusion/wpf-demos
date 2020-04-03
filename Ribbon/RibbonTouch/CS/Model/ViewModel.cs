#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RibbonSample
{
    /// <summary>
    /// Represents the class of viewmodel
    /// </summary>
    public class ViewModel : NotificationObject
    {
        #region Field
        /// <summary>
        /// Maintains the collection of slide items.
        /// </summary>
        private ObservableCollection<SlideItem> slideItems;

        /// <summary>
        /// Maintains the collection of page items.
        /// </summary>
        private ObservableCollection<string> pageSetup;
        #endregion   

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>  
        public ViewModel()
        {
            InitializePageSetup();          
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the slide items.
        /// </summary>
        public ObservableCollection<SlideItem> SlideItems
        {
            get { return slideItems; }
            set
            {
                slideItems = value;
                RaisePropertyChanged("SlideItems");
            }
        }

        /// <summary>
        /// Gets or sets the values for page items.
        /// </summary>
        public ObservableCollection<string> PageSetup
        {
            get
            {
                return pageSetup;
            }
            set
            {
                pageSetup = value;
                RaisePropertyChanged("pageSetup");
            }
        }
        #endregion

        #region Helper Methods
        /// <summary>
        /// Populate page items to the page setup collection.
        /// </summary>
        private void InitializePageSetup()
        {
            PageSetup = new ObservableCollection<string>();
            PageSetup.Add("Checkable menu item");
            PageSetup.Add("Uncheckable menu item");
            PageSetup.Add("Checkable with icon");
            PageSetup.Add("Uncheckable with icon");
        }
        #endregion
    }
    /// <summary>
    /// Represents a class for slide items.
    /// </summary>
    public class SlideItem
    {
        #region Field
        /// <summary>
        /// Maintains the slide number.
        /// </summary>
        private int slideNumber;

        /// <summary>
        /// Maintains the text inside the slide item.
        /// </summary>
        private string itemText;

        /// <summary>
        /// Maintains the description of each slide item.
        /// </summary>
        private string description;

        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the value for slide number.
        /// </summary>
        public int SlideNumber
        {
            get
            {
                return slideNumber;
            }
            set
            {
                slideNumber = value;
            }
        }

        /// <summary>
        /// Gets and sets the value for item text.
        /// </summary>
        public string ItemText
        {
            get
            {
                return itemText;
            }
            set
            {
                itemText = value;
            }
        }

        /// <summary>
        /// Gets and sets the value for description.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }
        #endregion
    }

}
