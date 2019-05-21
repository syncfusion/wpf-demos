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
    /// 
    /// </summary>
    public class ViewModel : NotificationObject
    {
        private ObservableCollection<SlideItem> slideItems;
        /// <summary>
        /// 
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

    }
    /// <summary>
    /// 
    /// </summary>
    public class SlideItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int SNo
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ItemText
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            get;
            set;
        }
    }
}
