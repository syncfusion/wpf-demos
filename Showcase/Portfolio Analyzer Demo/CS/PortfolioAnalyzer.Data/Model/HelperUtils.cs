#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Shapes;
using System.IO;
using System.ComponentModel;
using PortfolioAnalyzer.Model;

namespace PortfolioAnalyzer.Model
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
            // Check both in parent folder and Parent\Data folders.
            string dataFileName = string.Format(@"PortfolioAnalyzer.Data\Model\{0}", fileName);
            for (int n = 0; n < 12; n++)
            {
                if (System.IO.File.Exists(dataFileName))
                {
                    return new FileInfo(dataFileName).FullName;
                }
                
                dataFileName = @"..\" + dataFileName;
            }

            return dataFileName;
        }
    }
}
