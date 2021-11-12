#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Provides access to the database.
    /// </summary>
    public static class DataUtils
    {
        public readonly static string connString = "Data Source=" + DataUtils.FindFile("PortfolioManagerDB.sdf");

        /// <summary>
        /// Finds the database file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string FindFile(string fileName)
        {
            return @"Assets\portfolioanalyzer\" + fileName;
        }
    }
}
