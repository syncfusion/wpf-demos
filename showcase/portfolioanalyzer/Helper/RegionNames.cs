#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Represents the region names in the application.
    /// </summary>
    public sealed class RegionNames : RegionNamesMain
    {
        public const string DetailsRegion = "DetailsRegion";
        public const string TabRegion = "TabRegion";
        public const string SelectionRegion = "SelectionRegion";

        private RegionNames()
        {
        }
    }

    public class RegionNamesMain
    {

        /// <summary>
        /// Docking Region that contains dock window views.
        /// </summary>
        public const string DockingRegion = "DockingRegion";

        /// <summary>
        /// Ribbon Region that contains RibbonTab views.
        /// </summary>
        public const string RibbonRegion = "RibbonRegion";

        /// <summary>
        /// Application Menu Region that contains AppMenu items view.
        /// </summary>
        public const string AppMenuRegion = "AppMenuRegion";
    }
}
