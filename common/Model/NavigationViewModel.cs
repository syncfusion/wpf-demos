#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.demoscommon.wpf
{
    public class NavigationViewModel
    {
        private string navigationItem;
        private object navigationIcon;

        /// <summary>
        /// Gets or set the NavigationItem Text
        /// </summary>
        public string NavigationItem
        {
            get { return navigationItem; }
            set { navigationItem = value; }
        }

        /// <summary>
        /// Gets or set the NavigationItem Icon
        /// </summary>
        public object NavigationIcon
        {
            get { return navigationIcon; }
            set { navigationIcon = value; }
        }

        public NavigationViewModel()
        {

        }
    }
}
